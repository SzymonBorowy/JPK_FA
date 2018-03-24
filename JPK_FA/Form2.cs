using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace JPK_FA
{
    public partial class Form2 : Form
    {
        //public string sciezka = @"C:\Users\Borowy\Desktop\faktura1.xml";
        //public  int LiczbaFaktur = 0;
        //public double WartoscFaktur = 0;
        public int LiczbaFakturWiersz = 0;
        public double WartoscFakturWiersz = 0;
        public string data;
        List<Faktura_typu_G> faktura;
        List<Faktura_wiersz> faktura_wiersz;
        public Form2()
        {
            InitializeComponent();
            this.faktura = new List<Faktura_typu_G>();
            this.faktura_wiersz = new List<Faktura_wiersz>();
            data = p_2a.Text.ToString();
        }
        public void blok()
        { 
            p_13_6.Enabled = false;                                     //BLOKOWANIE PRZYCISKÓW
            p_13_7.Enabled = false;
            p_19a.Enabled = false;
            p_19b.Enabled = false;
            p_19c.Enabled = false;
            p_20a.Enabled = false;
            p_20b.Enabled = false;
            p_21a.Enabled = false;
            p_21b.Enabled = false;
            p_21c.Enabled = false;
            p_106e_3a.Enabled = false;
            przyczyna_korekty.Enabled = false;
            nrfakorygowanej.Enabled = false;
            okresfakorygowanej.Enabled = false;

            p_13_6.BackColor = Color.Silver;                                     //USTAWIANIE KOLORU PRZYCISKÓW
            p_13_7.BackColor = Color.Silver;
            p_19a.BackColor = Color.Silver;
            p_19b.BackColor = Color.Silver;
            p_19c.BackColor = Color.Silver;
            p_20a.BackColor = Color.Silver;
            p_20b.BackColor = Color.Silver;
            p_21a.BackColor = Color.Silver;
            p_21b.BackColor = Color.Silver;
            p_21c.BackColor = Color.Silver;
            p_106e_3a.BackColor = Color.Silver;
            przyczyna_korekty.BackColor = Color.Silver; ;
            nrfakorygowanej.BackColor = Color.Silver;
            okresfakorygowanej.BackColor = Color.Silver;

            p_16.SelectedIndex = 0;                                     //USTAWIANIE PIERWSZEJ MOŻLIWOŚCI NA "FALSE"
            p_17.SelectedIndex = 0;
            p_18.SelectedIndex = 0;
            p_19.SelectedIndex = 0;
            p_20.SelectedIndex = 0;
            p_21.SelectedIndex = 0;
            p_23.SelectedIndex = 0;
            p_106e_2.SelectedIndex = 0;
            p_106e_3.SelectedIndex = 0;
        }

        //DODAWNIE 1 FAKTURY WIERSZ
        private void dodaj_fakture_wiersz_Click_1(object sender, EventArgs e)
        {

            Faktura_wiersz fak_wiersz = new Faktura_wiersz();
            fak_wiersz.P_2B = p_2b.Text;
            fak_wiersz.P_7 = p_7.Text;
            fak_wiersz.P_8A = p_8a.Text;
            fak_wiersz.P_8B = p_8b.Text;
            fak_wiersz.P_9A = p_9a.Text;
            fak_wiersz.P_9B = p_9b.Text;
            fak_wiersz.P_10 = p_10.Text;
            fak_wiersz.P_11 = p_11.Text;
            fak_wiersz.P_11A = p_11a.Text;
            fak_wiersz.P_12 = p_12.Text;
            if (fak_wiersz.P_2B == "" || fak_wiersz.P_9B == "" || fak_wiersz.P_11 == "")
            {
                MessageBox.Show("Puste pole!");
                if(fak_wiersz.P_2B == "") { p_2b.BackColor = Color.Red; }
                if (fak_wiersz.P_9B == "") { p_9b.BackColor = Color.Red; }
                if (fak_wiersz.P_11 == "") { p_11.BackColor = Color.Red; }
            }
            else
            {
                p_2b.BackColor = Color.White;
                p_9b.BackColor = Color.White;
                p_11.BackColor = Color.White;
                faktura_wiersz.Add(fak_wiersz);
                LiczbaFakturWiersz = LiczbaFakturWiersz + 1;
                WartoscFakturWiersz = WartoscFakturWiersz + double.Parse(p_11.Text);
            }
            
        }

        //DODAWANIE 1 FAKTURY
        private void dodaj_fakture_Click_1(object sender, EventArgs e)
        {
           
            //DODAWANIE DO BAZY DANYCH SQL
            SqlConnection connection = new SqlConnection();
            //ustanowienie połączenia z baząstring 
            string ConnectionString = "data source = DOM\\SQLEXPRESS; database = faktura; integrated security = SSPI";
            //utworzenie obiektu 
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            try
            {
                //zapytanie do bazy         
                string commandString = "INSERT INTO Table_2 (data, numer ,nazwa ,adres ,P_3C ,P_3D ,P_4A ,P_4B ,P_5A ,P_5B ,P_6 ,P_13_1 ,P_14_1 ,P_13_2 ,P_14_2 ,P_13_3 ,P_14_3 ,P_13_4 ,P_14_4 ,P_13_5 ,P_14_5 ,P_13_6 ,P_13_7 ,P_15 ,P_16 ,P_17 ,P_18 ,P_19 ,P_19A ,P_19B ,P_19C ,P_20 ,P_20A ,P_20B ,P_21 ,P_21A ,P_21B ,P_21C ,P_22A ,P_22B ,P_22C ,P_23 ,P_106E_2 ,P_106E_3 ,P_106E_3A ,rodzaj ,przyczyna ,nr ,okres) VALUES (@data, @numer ,@nazwa ,@adres ,@P_3C ,@P_3D ,@P_4A ,@P_4B ,@P_5A ,@P_5B ,@P_6 ,@P_13_1 ,@P_14_1 ,@P_13_2 ,@P_14_2 ,@P_13_3 ,@P_14_3 ,@P_13_4 ,@P_14_4 ,@P_13_5 ,@P_14_5 ,@P_13_6 ,@P_13_7 ,@P_15 ,@P_16 ,@P_17 ,@P_18 ,@P_19 ,@P_19A ,@P_19B ,@P_19C ,@P_20 ,@P_20A ,@P_20B ,@P_21 ,@P_21A ,@P_21B ,@P_21C ,@P_22A ,@P_22B ,@P_22C ,@P_23 ,@P_106E_2 ,@P_106E_3 ,@P_106E_3A ,@rodzaj ,@przyczyna ,@nr ,@okres)";
                //
                // dodanie parametrow do commandString i wykonanie zapytania
                SqlCommand dodaj = new SqlCommand(commandString, conn);
                dodaj.Parameters.AddWithValue("@data", p_1.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@numer", p_2a.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@nazwa", p_3a.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@adres", p_3b.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_3C", p_3c.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_3D", p_3d.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_4A", p_4a.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_4B", p_4b.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_5A", p_5a.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_5B", p_5b.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_6", p_6.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_13_1", p_13_1.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_13_2", p_13_2.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_13_3", p_13_3.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_13_4", p_13_4.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_13_5", p_13_5.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_13_6", p_13_6.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_13_7", p_13_7.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_14_1", p_14_1.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_14_2", p_14_2.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_14_3", p_14_3.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_14_4", p_14_4.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_14_5", p_14_5.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_15", p_15.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_16", p_16.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_17", p_17.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_18", p_18.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_19", p_19.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_19A", p_19a.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_19B", p_19b.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_19C", p_19c.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_20", p_20.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_20A", p_20a.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_20B", p_20b.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_21", p_21.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_21A", p_21a.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_21B", p_21b.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_21C", p_21c.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_22A", p_22a.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_22B", p_22b.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_22C", p_22c.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_23", p_23.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_106E_2", p_106e_2.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_106E_3", p_106e_3.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@P_106E_3A", p_106e_3a.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@rodzaj", rodzaj_faktury.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@przyczyna", przyczyna_korekty.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@nr", nrfakorygowanej.Text.ToString().Trim());
                dodaj.Parameters.AddWithValue("@okres", okresfakorygowanej.Text.ToString().Trim());
                dodaj.ExecuteNonQuery();
            }
            finally
            {
                //zamknięcie połączenia 
                conn.Close();
            }
            

        }

        //GENEROWNIE PLKIU TEKSTOWEGO
        private void generuj_przycisk_Click(object sender, EventArgs e)
        {
            JPK plik = new JPK();
            //plik.generuj_fakture(Form1.sciezka, faktura);
            //this.faktura.Clear();
            //plik.generuj_fakture_ctrl(Form1.sciezka, LiczbaFaktur, WartoscFaktur);
            //plik.stawki_podatku(Form1.sciezka);
            plik.generuj_faktura_wiersz(Form1.sciezka, faktura_wiersz);
            this.faktura_wiersz.Clear();
            plik.generuj_fakture_wiersz_ctrl(Form1.sciezka, LiczbaFakturWiersz, WartoscFakturWiersz);
            //LiczbaFaktur = 0;
            LiczbaFakturWiersz = 0;
            //WartoscFaktur = 0;
            WartoscFakturWiersz = 0;
            this.Close();
        }


        //ODBLOKOWANIE ZABLOKOWANYCH PRZYCISKÓW
        private void p_19_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (p_19.SelectedIndex == 1)
            {
                p_19a.Enabled = true;
                p_19b.Enabled = true;
                p_19c.Enabled = true;

                p_19a.BackColor = Color.White;
                p_19b.BackColor = Color.White;
                p_19c.BackColor = Color.White;
            }
            else
            {
                p_19a.Enabled = false;
                p_19b.Enabled = false;
                p_19c.Enabled = false;

                p_19a.Text = "";
                p_19b.Text = "";
                p_19c.Text = "";

                p_19a.BackColor = Color.Silver;
                p_19b.BackColor = Color.Silver;
                p_19c.BackColor = Color.Silver;
            }
        }

        private void p_20_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (p_20.SelectedIndex == 1)
            {
                p_20a.Enabled = true;
                p_20b.Enabled = true;

                p_20a.BackColor = Color.White;
                p_20b.BackColor = Color.White;
            }
            else
            {
                p_20a.Enabled = false;
                p_20b.Enabled = false;

                p_20a.Text = "";
                p_20b.Text = "";

                p_20a.BackColor = Color.Silver;
                p_20b.BackColor = Color.Silver;
            }
        }

        private void p_21_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (p_21.SelectedIndex == 1)
            {
                p_21a.Enabled = true;
                p_21b.Enabled = true;
                p_21c.Enabled = true;

                p_21a.BackColor = Color.White;
                p_21b.BackColor = Color.White;
                p_21c.BackColor = Color.White;
            }
            else
            {
                p_21a.Enabled = false;
                p_21b.Enabled = false;
                p_21c.Enabled = false;

                p_21a.Text = "";
                p_21b.Text = "";
                p_21c.Text = "";

                p_21a.BackColor = Color.Silver;
                p_21b.BackColor = Color.Silver;
                p_21c.BackColor = Color.Silver;
            }
        }

       

        private void p_106e_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (p_106e_2.SelectedIndex == 1)
            {
                p_13_6.Enabled = true;
                p_13_7.Enabled = true;

                p_13_6.BackColor = Color.White;
                p_13_7.BackColor = Color.White;
            }
            else
            {
                p_13_6.Enabled = false;
                p_13_7.Enabled = false;

                p_13_6.Text = "";
                p_13_7.Text = "";

                p_13_6.BackColor = Color.Silver;
                p_13_7.BackColor = Color.Silver;
            }
        }

        private void p_106e_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (p_106e_3.SelectedIndex == 1)
            {
                p_106e_3a.Enabled = true;
                p_13_6.Enabled = true;
                p_13_7.Enabled = true;

                p_106e_3a.BackColor = Color.White;
                p_13_6.BackColor = Color.White;
                p_13_7.BackColor = Color.White;
            }
            else
            {
                p_106e_3a.Enabled = false;
                p_13_6.Enabled = false;
                p_13_7.Enabled = false;

                p_106e_3a.Text = "";
                p_13_6.Text = "";
                p_13_7.Text = "";

                p_106e_3a.BackColor = Color.Silver;
                p_13_6.BackColor = Color.Silver;
                p_13_7.BackColor = Color.Silver;
            }
    }

        private void rodzaj_faktury_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rodzaj_faktury.SelectedIndex == 1)
            {
                przyczyna_korekty.Enabled = true;
                nrfakorygowanej.Enabled = true;
                okresfakorygowanej.Enabled = true;

                przyczyna_korekty.BackColor = Color.White;
                nrfakorygowanej.BackColor = Color.White;
                okresfakorygowanej.BackColor = Color.White;

            }
            else
            {
                przyczyna_korekty.Enabled = false;
                nrfakorygowanej.Enabled = false;
                okresfakorygowanej.Enabled = false;

                przyczyna_korekty.Text = "";
                nrfakorygowanej.Text = "";
                okresfakorygowanej.Text = "";

                przyczyna_korekty.BackColor = Color.Silver;
                przyczyna_korekty.BackColor = Color.Silver;
                nrfakorygowanej.BackColor = Color.Silver;
                okresfakorygowanej.BackColor = Color.Silver;
            }
        }
        //FUNKCJA WYSYŁAJĄCA DANE Z BAZY DANYCH DO FORMY2 W CELU MODYFIKACJI
        public void mod (string P_1, string P_2A, string P_3A, string P_3B, string P_3C, string P_3D, string P_4A, string P_4B, string P_5A, string P_5B, string P_6, string P_13_1, string P_14_1, string P_13_2, string P_14_2, string P_13_3, string P_14_3, string P_13_4, string P_13_5, string P_14_4, string P_13_6, string P_13_7, string P_14_5, string P_15, string P_16, string P_17, string P_18, string P_19, string P_19A, string P_19B, string P_19C, string P_20, string P_20A, string P_20B, string P_21, string P_21A, string P_21B, string P_21C, string P_22A, string P_22B, string P_22C, string P_23, string P_106E_2, string P_106E_3, string P_106E_3A, string rodzaj, string przyczyna, string nr, string okres)
        {
            p_1.Text = P_1;
            p_2a.Text = P_2A;
            p_3a.Text = P_3A;
            p_3b.Text = P_3B;
            p_3c.Text = P_3C;
            p_3d.Text = P_3D;
            p_4a.Text = P_4A;
            p_4b.Text = P_4B;
            p_5a.Text = P_5A;
            p_5b.Text = P_5B;
            p_6.Text = P_6;
            p_13_1.Text = P_13_1;               
            p_13_2.Text = P_13_2;
            p_13_3.Text = P_13_3;
            p_13_4.Text = P_13_4;
            p_13_5.Text = P_13_5;
            p_13_6.Text = P_13_6;
            p_13_7.Text = P_13_7;
            p_14_1.Text = P_14_1;
            p_14_2.Text = P_14_2;
            p_14_3.Text = P_14_3;
            p_14_4.Text = P_14_4;
            p_14_5.Text = P_14_5;
            p_15.Text = P_15;
            p_16.Text = P_16;
            if(P_16=="true      ") { p_16.SelectedIndex = 1; }
            else { p_16.SelectedIndex = 0; }
            //MessageBox.Show("|"+P_16+"|");
            p_17.Text = P_17;
            if (P_17 == "true      ") { p_17.SelectedIndex = 1; }
            else { p_17.SelectedIndex = 0; }
            p_18.Text = P_18;
            if (P_18 == "true      ") { p_18.SelectedIndex = 1; }
            else { p_18.SelectedIndex = 0; }
            p_19.Text = P_19;
            p_19a.Text = P_19A;
            p_19b.Text = P_19B;
            p_19c.Text = P_19C;
            if (P_19 == "true      ") { p_19.SelectedIndex = 1; }
            else { p_19.SelectedIndex = 0; }
            p_20.Text = P_20;
            p_20a.Text = P_20A;
            p_20b.Text = P_20B;
            if (P_20 == "true      ") { p_20.SelectedIndex = 1; }
            else { p_20.SelectedIndex = 0; }
            p_21.Text = P_21;
            p_21a.Text = P_21A;
            p_21b.Text = P_21B;
            p_21c.Text = P_21C;
            if (P_21 == "true      ") { p_21.SelectedIndex = 1; }
            else { p_21.SelectedIndex = 0; }
            p_22a.Text = P_22A;
            p_22b.Text = P_22B;
            p_22c.Text = P_22C;
            p_23.Text = P_23;
            if (P_23 == "true      ") { p_23.SelectedIndex = 1; }
            else { p_23.SelectedIndex = 0; }
            p_106e_2.Text = P_106E_2;
            if (P_106E_2 == "true      ") { p_106e_2.SelectedIndex = 1; }
            else { p_106e_2.SelectedIndex = 0; }
            p_106e_3.Text = P_106E_3;
            if (P_106E_3 == "true      ") { p_106e_3.SelectedIndex = 1; }
            else { p_106e_3.SelectedIndex = 0; }
            p_106e_3a.Text = P_106E_3A;
            rodzaj_faktury.Text = rodzaj;
            if (P_106E_2 == "KOREKTA   ") { p_106e_2.SelectedIndex = 1; }
            przyczyna_korekty.Text = przyczyna;
            nrfakorygowanej.Text = nr;
            okres = okresfakorygowanej.Text = okres;
        }
    }
}

    

