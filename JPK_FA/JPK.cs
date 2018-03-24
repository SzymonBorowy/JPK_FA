using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPK_FA
{
    
    public class JPK
    {
        
        public JPK()
        {
            
        }
        //WYPISYWANIE NAGŁÓWKA
        public void generuj_naglowek(string sciezka, List<Naglowek> naglowek)
        {
            foreach (var pom in naglowek)
            {

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(sciezka, true))
                {
                    file.WriteLine("<?xml version=\"1.0\" encoding=\"UTF - 8\"?>" + Environment.NewLine +
                                  "<JPK xmlns=\"http://jpk.mf.gov.pl/wzor/2016/03/09/03095/ \" xmlns:etd=\"http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2016/01/25/eD/DefinicjeTypy/ \" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance \" xsi:schemaLocation=\"http://jpk.mf.gov.pl/wzor/2016/03/09/03095/ Schemat_JPK_FA(1)_v1-0.xsd\">" + Environment.NewLine +
                                  "        <Naglowek>" + Environment.NewLine +
                                  "                <KodFormularza kodSystemowy = \"JPK_FA (1)\" wersjaSchemy = \"1-0\">" + pom.KodFormularza + "</KodFormularza>" + Environment.NewLine +
                                  "                <WariantFormularza>" + pom.WariantFormularza + "</WariantFormularza>" + Environment.NewLine +
                                  "                <CelZlozenia>" + pom.CelZlozenia + "</CelZlozenia>" + Environment.NewLine +
                                  "                <!--1 lub 2, gdy poprawka -->" + Environment.NewLine +
                                  "                <DataWytworzeniaJPK>" + pom.DataWytwozreniaJPK + "</DataWytworzeniaJPK>" + Environment.NewLine +
                                  "                <DataOd>" + pom.DataOd + "</DataOd>" + Environment.NewLine +
                                  "                <DataDo>" + pom.DataDo + "</DataDo>" + Environment.NewLine +
                                  "                <DomyslnyKodWaluty>" + pom.DomyslnyKodWaluty + "</DomyslnyKodWaluty>" + Environment.NewLine +
                                  "                <KodUrzedu>" + pom.KodUrzedu + "</KodUrzedu>" + Environment.NewLine +
                                  "        </Naglowek>");
                }
            }
        }
        //WYPISYWANIE PODMIOTU
        public void generuj_podmiot(string sciezka, List<Podmiot1> podmiot)
        {

            foreach (var pom in podmiot)
            {
                
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(sciezka, true))
                {
                    file.WriteLine("        <Podmiot1>" + Environment.NewLine +
                                   "                <IdentyfikatorPodmiotu>" + Environment.NewLine +
                                   "                              <etd:NIP>" + pom.NIP + "</etd:NIP>" + Environment.NewLine +
                                   "                              <etd:PelnaP_>" + pom.PelnaNazwa + "</etd:PelnaP_>" + Environment.NewLine +
                                   "                              <etd:REGON>" + pom.REGON + "</etd:REGON>" + Environment.NewLine +
                                   "                </IdentyfikatorPodmiotu>" + Environment.NewLine +
                                   "                <AdresPodmiotu>" + Environment.NewLine +
                                   "                              <etd:KodKraju>" + pom.KodKraju + "</etd:KodKraju>" + Environment.NewLine +
                                   "                              <etd:Wojewodztwo>" + pom.Wojewodztwo + "</etd:Wojewodztwo>" + Environment.NewLine +
                                   "                              <etd:Powiat>" + pom.Powiat + "</etd:Powiat>" + Environment.NewLine +
                                   "                              <etd:Gmina > " + pom.Gmina + " </ etd:Gmina > " + Environment.NewLine +
                                   "                              <etd:Ulica>" + pom.Ulica + "</etd:Ulica>" + Environment.NewLine +
                                   "                              <etd:NrDomu>" + pom.NrDomu + "</etd:NrDomu>" + Environment.NewLine +
                                   "                              <etd:NrLokalu>" + pom.NrLokalu + "</etd:NrLokalu>" + Environment.NewLine +
                                   "                              <etd:Miejscowosc>" + pom.Miejscowosc + "</etd:Miejscowosc>" + Environment.NewLine +
                                   "                              <etd:KodPocztowy>" + pom.KodPocztowy + "</etd:KodPocztowy>" + Environment.NewLine +
                                   "                              <etd:Poczta>" + pom.Poczta + "</etd:Poczta>" + Environment.NewLine +
                                   "                </AdresPodmiotu>" + Environment.NewLine +
                                   "        </Podmiot1>");
                }
            }
        }
        //WYPISYWANIE FAKTUR
        public void generuj_fakture(string sciezka, List<Faktura_typu_G> faktura)
        {
            foreach (var pom in faktura)
            {  
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(sciezka, true))
                {
                    file.WriteLine("        <Faktura typ=\"G\">" + Environment.NewLine +
                                   "                <P_1>" + pom.P_1 + "</P_1>" + Environment.NewLine +
                                   "                <P_2A>" + pom.P_2A + "</P_2A>" + Environment.NewLine +
                                   "                <P_3A>" + pom.P_3A + "</P_3A>" + Environment.NewLine +
                                   "                <P_3B>" + pom.P_3B + "</P_3B>" + Environment.NewLine +
                                   "                <P_3C>" + pom.P_3C + "</P_3C>" + Environment.NewLine +
                                   "                <P_3D>" + pom.P_3D + "</P_3D>");

                    if (pom.P_4A != "") { file.WriteLine("                <P_4A>" + pom.P_4A + "</P_4A>"); }
                    if (pom.P_4B != "") { file.WriteLine("                <P_4B>" + pom.P_4B + "</P_4B>"); }
                    if (pom.P_5A != "") { file.WriteLine("                <P_5A>" + pom.P_5A + "</P_5A>"); }
                    if (pom.P_5B != "") { file.WriteLine("                <P_5B>" + pom.P_5B + "</P_5B>"); }

                    file.WriteLine("                <P_6>" + pom.P_6 + "</P_6>");

                    if (pom.P_13_1 != "") { file.WriteLine("                <P_13_1>" + pom.P_13_1 + "</P_13_1>" + Environment.NewLine +
                                                              "                <P_14_1>" + pom.P_14_1 + "</P_14_1>"); }
                    if (pom.P_13_2 != "") { file.WriteLine("                <P_13_2> " + pom.P_13_2 + " </P_13_2> " + Environment.NewLine +
                                                              "                <P_14_2>" + pom.P_14_2 + "</P_14_2>"); }
                    if (pom.P_13_3 != "") { file.WriteLine("                <P_13_3>" + pom.P_13_3 + "</P_13_3>" + Environment.NewLine +
                                                              "                <P_14_3>" + pom.P_14_3 + "</P_14_3>"); }
                    if (pom.P_13_4 != "") { file.WriteLine("                <P_13_4>" + pom.P_13_4 + "</P_13_4>" + Environment.NewLine +
                                                              "                <P_14_4>" + pom.P_14_4 + "</P_14_4>"); }
                    if (pom.P_13_5 != "") { file.WriteLine("                <P_13_5>" + pom.P_13_5 + "</P_13_5>" + Environment.NewLine +
                                                              "                <P_14_5>" + pom.P_14_5 + "</P_14_5>"); }

                    file.WriteLine("                <P_15>" + pom.P_15 + "</P_15>" + Environment.NewLine +
                                   "                <P_16>" + pom.P_16 + "</P_16>" + Environment.NewLine +
                                   "                <P_17>" + pom.P_17 + "</P_17>" + Environment.NewLine +
                                   "                <P_18>" + pom.P_18 + "</P_18>" + Environment.NewLine +
                                   "                <P_19>" + pom.P_19 + "</P_19>");

                    if (pom.P_19 == "true") { file.WriteLine("                <P_19A>" + pom.P_19A + "</P_19A>" + Environment.NewLine +
                                                                "                <P_19B>" + pom.P_19B + "</P_19B>" + Environment.NewLine +
                                                                "                <P_19C>" + pom.P_19C + "</P_19C>"); }

                    file.WriteLine("                <P_20>" + pom.P_20 + "</P_20>");

                    if (pom.P_20 == "true") { file.WriteLine("                <P_20A>" + pom.P_20A + "</P_20A>" + Environment.NewLine +
                                                                "                <P_20B>" + pom.P_20B + "</P_20B>"); }

                    file.WriteLine("                <P_21>" + pom.P_21 + "</P_21>");

                    if (pom.P_21 == "true") { file.WriteLine("                <P_21A>" + pom.P_21A + "</P_21A>" + Environment.NewLine +
                                                                "                <P_21B>" + pom.P_21B + "</P_21B>" + Environment.NewLine +
                                                                "                <P_21C>" + pom.P_21C + "</P_21C>"); }
                    if (pom.P_22A != "") { file.WriteLine("                <P_22A>" + pom.P_22A + "</P_22A>"); }
                    if (pom.P_22B != "") { file.WriteLine("                <P_22B>" + pom.P_22B + "</P_22B>"); }
                    if (pom.P_22C != "") { file.WriteLine("                <P_22C>" + pom.P_22C + "</P_22C>"); }
                    file.WriteLine("                <P_23>" + pom.P_23 + "</P_23>" + Environment.NewLine +
                                   "                <P_106E_2>" + pom.P_106E_2 + "</P_106E_2>" + Environment.NewLine +
                                   "                <P_106E_3>" + pom.P_106E_3 + "</P_106E_3>");

                    if (pom.P_106E_3 == "true") { file.WriteLine("                <P_106E_3A>" + pom.P_106E_3A + "</P_106E_3A>"); }

                    file.WriteLine("                <RodzajFaktury>" + pom.rodzaj_faktury + "</RodzajFaktury>");
                    if (pom.rodzaj_faktury == "KOREKTA") { file.WriteLine("                <PrzyczynaKorekty>" + pom.przyczyna_korekty + "</PrzyczynaKorekty>" + Environment.NewLine +
                                                                          "                <NrFaKorygowanej>" + pom.nr_fa_korygowanej + "</NrFaKorygowanej>" + Environment.NewLine +
                                                                          "                <OkresFaKorygowanej>" + pom.okres_fa_korygowanej + "</OkresFaKorygowanej>"); }
                    file.WriteLine("        </Faktura typ=\"G\">");

                }
            }
        }
        //WYPISYWANIE FAKTURY CTRL
        public void generuj_fakture_ctrl(string sciezka,int dlugosc,double wartosc)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(sciezka, true))
            {
                file.WriteLine("        <FakturaCtrl>");
                file.WriteLine("                <LiczbaFaktur>"+dlugosc+ "</LiczbaFaktur>");
                file.WriteLine("                <WartoscFaktur>" +wartosc + "</WartoscFaktur>");
                file.WriteLine("        </FakturaCtrl>");
            }
        }
        //WYPISYWANIE STAWKI POKATKOWEJ
        public void stawki_podatku(string sciezka)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(sciezka, true))
            {
                file.WriteLine("        <StawkiPodatku>");
                file.WriteLine("                <Stawka1> 0.23 </Stawka1>" + Environment.NewLine +
                               "                <Stawka2> 0.08 </Stawka2 >" + Environment.NewLine +
                               "                <Stawka3> 0.05 </Stawka3 >" + Environment.NewLine +
                               "                <Stawka4> 0.00 </Stawka4 >" + Environment.NewLine +
                               "                <Stawka5> 0.00 </Stawka5 >");
                file.WriteLine("        </StawkiPodatku>");
            }
        }
        //WYPISYWANIE FAKTUR WIERSZ
        public void generuj_faktura_wiersz(string sciezka, List<Faktura_wiersz>faktura_wiersz)
        {
            foreach (var pom in faktura_wiersz)
            {

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(sciezka, true))
                {
                    file.WriteLine("        <FakturaWiersz typ=\"G\">");
                    file.WriteLine("                <P_2B>"+ pom.P_2B+"</P_2B>");
                    if (pom.P_7 != "") { file.WriteLine("                <P_7>" + pom.P_7 + "</P_7>"); }
                    if (pom.P_8A != "") { file.WriteLine("                <P_8A >" +pom.P_8A +"</ P_8A >"); }
                    if (pom.P_8B != "") { file.WriteLine("                <P_8B>"+pom.P_8B+"</P_8B>"); }
                    if (pom.P_9A != "") { file.WriteLine("                <P_9A>" + pom.P_9A + "</P_9A>"); }
                    file.WriteLine("                <P_9B>" + pom.P_9B + "</P_9B>");
                    if (pom.P_10 != "") { file.WriteLine("                <P_10>" + pom.P_10 + "</P_10>"); }
                    if (pom.P_11 != "") { file.WriteLine("                <P_11>" + pom.P_11 + "</P_11>"); }
                    if (pom.P_11A != "") { file.WriteLine("                <P_11A>" + pom.P_11A + "</P_11A>"); }
                    if (pom.P_12 != "") { file.WriteLine("                <P_12>" + pom.P_12 + "</P_12>"); }
                    file.WriteLine("        </FakturaWiersz>"); 
               }
            }
        }
        //WYPISYWANIE FAKTURA WIERSZ CTRL
        public void generuj_fakture_wiersz_ctrl(string sciezka, int dlugosc, double wartosc)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(sciezka, true))
            {
                file.WriteLine("        <FakturaWierszCtrl>");
                file.WriteLine("                <LiczbaFakturWiersz>" + dlugosc + "</LiczbaFaktur>");
                file.WriteLine("                <WartoscFakturWiersz>" + wartosc + "</WartoscFaktur>");
                file.WriteLine("        </FakturaWierszCtrl>");
                file.WriteLine("</JPK>" + Environment.NewLine);
            }
        }

    }
}
