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

    public partial class Form1 : Form
    {

        public static string sciezka;
        public int LiczbaFaktur = 0;
        public double WartoscFaktur = 0;
        List<Naglowek> naglowek;
        List<Podmiot1> podmiot;
        List<Faktura_typu_G> faktura;
        List<Faktura_wiersz> faktura_wiersz;
        SqlConnection connection = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
            this.naglowek = new List<Naglowek>();
            this.podmiot = new List<Podmiot1>();
            this.faktura = new List<Faktura_typu_G>();
            data_wytworzenia_JPK.Text = DateTime.Now.ToString();

        }

        //GENEROWNIE KODU NAGŁÓWKA I PODNIOTY W PLIKU TEKSTOWYM
        private void zapisz_przycisk_Click(object sender, EventArgs e)
        {

            Naglowek nag = new Naglowek();
            nag.KodFormularza = kod_formularza.Text;
            nag.WariantFormularza = wariant_formularza.Text;
            nag.CelZlozenia = cel_zlozenia.Text;
            nag.DataWytwozreniaJPK = data_wytworzenia_JPK.Text;
            nag.DataOd = data_od.Text;
            nag.DataDo = data_do.Text;
            nag.DomyslnyKodWaluty = domyslny_kod_waluty.Text;
            nag.KodUrzedu = kod_urzedu.Text;


            Podmiot1 pod = new Podmiot1();
            pod.KodKraju = kod_kraju.Text;
            pod.Wojewodztwo = wojewodztwo.Text;
            pod.Powiat = powiat.Text;
            pod.Gmina = gmina.Text;
            pod.Ulica = ulica.Text;
            pod.NrDomu = nr_domu.Text;
            pod.NrLokalu = nr_lokalu.Text;
            pod.Miejscowosc = miejscowosc.Text;
            pod.KodPocztowy = kod_pocztowy.Text;
            pod.Poczta = poczta.Text;
            pod.NIP = nip.Text;
            pod.PelnaNazwa = pelna_nazwa.Text;
            pod.REGON = regon.Text;

            if (nag.KodFormularza == "" || nag.WariantFormularza == "" || nag.CelZlozenia == "" || nag.DataWytwozreniaJPK == "" || nag.DataOd == "" || nag.DataDo == "" || nag.DomyslnyKodWaluty == "" || nag.KodUrzedu == "" ||
                pod.KodKraju == "" || pod.Wojewodztwo == "" || pod.Powiat == "" || pod.Gmina == "" || pod.Ulica == "" || pod.NrDomu == "" || pod.NrLokalu == "" || pod.Miejscowosc == "" || pod.KodPocztowy == "" || pod.Poczta == "" || pod.NIP == "" || pod.PelnaNazwa == "" || pod.REGON == "")
            {
                MessageBox.Show("Puste pole!");
            }
            else
            {
                zapisz_przycisk.Enabled = false;
                naglowek.Add(nag);
                podmiot.Add(pod);
            }
            sciezka = sciezka_tb.Text.ToString();
            JPK faktura = new JPK();
            faktura.generuj_naglowek(sciezka, naglowek);
            this.naglowek.Clear();
            faktura.generuj_podmiot(sciezka, podmiot);
            this.podmiot.Clear();

        }


        private void odswierz_Click_1(object sender, EventArgs e)
        {
           
            //ODŚWIERZANIE
            connection.ConnectionString = "data source = DOM\\SQLEXPRESS; database = faktura; integrated security = SSPI";
            SqlCommand cmd = new SqlCommand("select data , numer, nazwa, adres from Table_2", connection);
            connection.Open();
            cmd.Connection = connection;
            SqlDataReader DR = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = DR;
            dataGridView1.DataSource = source;
            connection.Close();

        }

        private void usun_Click(object sender, EventArgs e)
        {
            //USUWANIE Z WYSKAKUJĄCYM OKIENKIEM POTWIERDZENIA
            DialogResult dialogResult = MessageBox.Show("                Jesteś pewien aby usunąć", "Usuń", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int x = dataGridView1.CurrentCell.RowIndex;
                int y = dataGridView1.CurrentCell.ColumnIndex;
                connection.ConnectionString = "data source = DOM\\SQLEXPRESS; database = faktura; integrated security = SSPI";
                SqlCommand cmd = new SqlCommand("DELETE FROM Table_2 WHERE data = '" + dataGridView1.Rows[x].Cells[y].Value.ToString() + "' and numer = '" + dataGridView1.Rows[x].Cells[y + 1].Value.ToString() + "' and nazwa = '" + dataGridView1.Rows[x].Cells[y + 2].Value.ToString() + "' and adres = '" + dataGridView1.Rows[x].Cells[y + 3].Value.ToString() + "';", connection);
                connection.Open();
                cmd.Connection = connection;
                SqlDataReader DR = cmd.ExecuteReader();
                connection.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }
        

        private void edytuj_Click(object sender, EventArgs e)
        {
            //EDYTOWANIE W DATAGRIDVIEW
            int x = dataGridView1.CurrentCell.RowIndex;
            int y = dataGridView1.CurrentCell.ColumnIndex;
            //string text = "' WHERE  numer = '" + dataGridView1.Rows[x].Cells[y + 1].Value + "'and  nazwa = '" + dataGridView1.Rows[x].Cells[y + 2].Value + "' and adres = '" + dataGridView1.Rows[x].Cells[y + 3].Value + "' ;";
            string text = "";
            connection.ConnectionString = "data source = DOM\\SQLEXPRESS; database = faktura; integrated security = SSPI";
            
            if (dataGridView1.Columns[y].HeaderText.ToString() == "data") { text = "' WHERE  numer = '" + dataGridView1.Rows[x].Cells[y + 1].Value + "'and  nazwa = '" + dataGridView1.Rows[x].Cells[y + 2].Value + "' and adres = '" + dataGridView1.Rows[x].Cells[y + 3].Value + "' ;"; }
            else if (dataGridView1.Columns[y].HeaderText.ToString() == "numer") { text = "' WHERE  data = '" + dataGridView1.Rows[x].Cells[y - 1].Value + "'and  nazwa = '" + dataGridView1.Rows[x].Cells[y + 1].Value + "' and adres = '" + dataGridView1.Rows[x].Cells[y + 2].Value + "' ;"; }
            else if (dataGridView1.Columns[y].HeaderText.ToString() == "nazwa") { text = "' WHERE  data = '" + dataGridView1.Rows[x].Cells[y - 2].Value + "'and  numer = '" + dataGridView1.Rows[x].Cells[y - 1].Value + "' and adres = '" + dataGridView1.Rows[x].Cells[y + 1].Value + "' ;"; }
            else if (dataGridView1.Columns[y].HeaderText.ToString() == "adres") { text = "' WHERE  data = '" + dataGridView1.Rows[x].Cells[y - 3].Value + "'and  numer = '" + dataGridView1.Rows[x].Cells[y - 2].Value + "' and nazwa = '" + dataGridView1.Rows[x].Cells[y - 1].Value + "' ;"; }

            SqlCommand cmd = new SqlCommand("UPDATE Table_2 SET " + dataGridView1.Columns[y].HeaderText + " = '" + edytuj_tb.Text.ToString() + text , connection);
            connection.Open();
            cmd.Connection = connection;
            SqlDataReader DR = cmd.ExecuteReader();
            connection.Close();
            edytuj_tb.Text = "";

        }
        // OTWIERANIE DRUGIEJ FORMY
        private void dodaj_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.blok();

        }
        //MADYFIKOWANIE DANYCH Z BAZY DANYCH W DRUGIEJ FORMIE
        private void modyfikuj_Click(object sender, EventArgs e)
        {
            int x = dataGridView1.CurrentCell.RowIndex;
            int y = dataGridView1.CurrentCell.ColumnIndex;
            Form2 form2 = new Form2();
            form2.Show() ;

            connection.ConnectionString = "data source = DOM\\SQLEXPRESS; database = faktura; integrated security = SSPI";
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Table_2 WHERE data = '" + dataGridView1.Rows[x].Cells[y].Value.ToString() + "' and numer = '" + dataGridView1.Rows[x].Cells[y + 1].Value.ToString() + "' and nazwa = '" + dataGridView1.Rows[x].Cells[y + 2].Value.ToString() + "' and adres = '" + dataGridView1.Rows[x].Cells[y + 3].Value.ToString() + "';";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                form2.mod(reader.GetString(0).ToString(), reader.GetString(1).ToString(), reader.GetString(2).ToString(), reader.GetString(3).ToString(), reader.GetString(4).ToString(), reader.GetString(5).ToString(), reader.GetString(6).ToString(), reader.GetString(7).ToString(), reader.GetString(8).ToString(), reader.GetString(9).ToString(), reader.GetString(10).ToString(), reader.GetString(11).ToString(), reader.GetString(12).ToString(), reader.GetString(13).ToString(), reader.GetString(14).ToString(), reader.GetString(15).ToString(), reader.GetString(16).ToString(), reader.GetString(17).ToString(), reader.GetString(18).ToString(), reader.GetString(19).ToString(), reader.GetString(20).ToString(), reader.GetString(21).ToString(), reader.GetString(22).ToString(), reader.GetString(23).ToString(), reader.GetString(24), reader.GetString(25).ToString(), reader.GetString(26).ToString(), reader.GetString(27).ToString(), reader.GetString(28).ToString(), reader.GetString(29).ToString(), reader.GetString(30).ToString(), reader.GetString(31).ToString(), reader.GetString(32).ToString(), reader.GetString(33).ToString(), reader.GetString(34).ToString(), reader.GetString(35).ToString(), reader.GetString(36).ToString(), reader.GetString(37).ToString(), reader.GetString(38).ToString(), reader.GetString(39).ToString(), reader.GetString(40).ToString(), reader.GetString(41).ToString(), reader.GetString(42).ToString(), reader.GetString(43).ToString(), reader.GetString(44).ToString(), reader.GetString(45).ToString(), reader.GetString(46).ToString(), reader.GetString(47).ToString(), reader.GetString(48).ToString());
            }
            //USUWANIE WIERSZA 
            reader.Close();
            connection.Close();
            connection.ConnectionString = "data source = DOM\\SQLEXPRESS; database = faktura; integrated security = SSPI";
            SqlCommand cmd1 = new SqlCommand("DELETE FROM Table_2 WHERE data = '" + dataGridView1.Rows[x].Cells[y].Value.ToString() + "' and numer = '" + dataGridView1.Rows[x].Cells[y + 1].Value.ToString() + "' and nazwa = '" + dataGridView1.Rows[x].Cells[y + 2].Value.ToString() + "' and adres = '" + dataGridView1.Rows[x].Cells[y + 3].Value.ToString() + "';", connection);
            connection.Open();
            cmd1.Connection = connection;
            SqlDataReader DR = cmd1.ExecuteReader();
            connection.Close();

        }
        // GENEROWANIE FAKTUR W PLIKU TEKSTOWYM
        private void generuj_plik_Click(object sender, EventArgs e)
        {
            int x = dataGridView1.CurrentCell.RowIndex;
            int y = dataGridView1.CurrentCell.ColumnIndex;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                connection.ConnectionString = "data source = DOM\\SQLEXPRESS; database = faktura; integrated security = SSPI";
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Table_2 WHERE data = '" + dataGridView1.Rows[x].Cells[y].Value.ToString() + "' and numer = '" + dataGridView1.Rows[x].Cells[y + 1].Value.ToString() + "' and nazwa = '" + dataGridView1.Rows[x].Cells[y + 2].Value.ToString() + "' and adres = '" + dataGridView1.Rows[x].Cells[y + 3].Value.ToString() + "';";
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // WPISANIE DO LISTY 
                    LiczbaFaktur = LiczbaFaktur + 1;
                    WartoscFaktur = WartoscFaktur + double.Parse(reader.GetValue(23).ToString());
                    Faktura_typu_G fak = new Faktura_typu_G();
                    fak.P_1 = reader.GetValue(0).ToString().Trim();
                    fak.P_2A = reader.GetValue(1).ToString().Trim();
                    fak.P_3A = reader.GetValue(2).ToString().Trim();
                    fak.P_3B = reader.GetValue(3).ToString().Trim();
                    fak.P_3C = reader.GetValue(4).ToString().Trim();
                    fak.P_3D = reader.GetValue(5).ToString().Trim();
                    fak.P_4A = reader.GetValue(6).ToString().Trim();
                    fak.P_4B = reader.GetValue(7).ToString().Trim();
                    fak.P_5A = reader.GetValue(8).ToString().Trim();
                    fak.P_5B = reader.GetValue(9).ToString().Trim();
                    fak.P_6 = reader.GetValue(10).ToString().Trim();
                    fak.P_13_1 = reader.GetValue(11).ToString().Trim();
                    fak.P_14_1 = reader.GetValue(12).ToString().Trim();
                    fak.P_13_2 = reader.GetValue(13).ToString().Trim();
                    fak.P_14_2 = reader.GetValue(14).ToString().Trim();
                    fak.P_13_3 = reader.GetValue(15).ToString().Trim();
                    fak.P_14_3 = reader.GetValue(16).ToString().Trim();
                    fak.P_13_4 = reader.GetValue(17).ToString().Trim();
                    fak.P_14_4 = reader.GetValue(18).ToString().Trim();
                    fak.P_13_5 = reader.GetValue(19).ToString().Trim();
                    fak.P_14_5 = reader.GetValue(20).ToString().Trim();
                    fak.P_13_6 = reader.GetValue(21).ToString().Trim();
                    fak.P_13_7 = reader.GetValue(22).ToString().Trim();
                    fak.P_15 = reader.GetValue(23).ToString().Trim();
                    fak.P_16 = reader.GetValue(24).ToString().Trim();
                    fak.P_17 = reader.GetValue(25).ToString().Trim();
                    fak.P_18 = reader.GetValue(26).ToString().Trim();
                    fak.P_19 = reader.GetValue(27).ToString().Trim();
                    fak.P_19A = reader.GetValue(28).ToString().Trim();
                    fak.P_19B = reader.GetValue(29).ToString().Trim();
                    fak.P_19C = reader.GetValue(30).ToString().Trim();
                    fak.P_20 = reader.GetValue(31).ToString().Trim();
                    fak.P_20A = reader.GetValue(32).ToString().Trim();
                    fak.P_20B = reader.GetValue(33).ToString().Trim();
                    fak.P_21 = reader.GetValue(34).ToString().Trim();
                    fak.P_21A = reader.GetValue(35).ToString().Trim();
                    fak.P_21B = reader.GetValue(36).ToString().Trim();
                    fak.P_21C = reader.GetValue(37).ToString().Trim();
                    fak.P_22A = reader.GetValue(38).ToString().Trim();
                    fak.P_22B = reader.GetValue(39).ToString().Trim();
                    fak.P_22C = reader.GetValue(40).ToString().Trim();
                    fak.P_23 = reader.GetValue(41).ToString().Trim();
                    fak.P_106E_2 = reader.GetValue(42).ToString().Trim();
                    fak.P_106E_3 = reader.GetValue(43).ToString().Trim();
                    fak.P_106E_3A = reader.GetValue(44).ToString().Trim();
                    fak.rodzaj_faktury = reader.GetValue(45).ToString().Trim();
                    fak.przyczyna_korekty = reader.GetValue(46).ToString().Trim();
                    fak.nr_fa_korygowanej = reader.GetValue(47).ToString().Trim();
                    fak.okres_fa_korygowanej = reader.GetValue(48).ToString().Trim();
                    faktura.Add(fak);

                }
                x = x + 1;
                reader.Close();
                connection.Close();
            }
            //WYSŁANIE DO PLIKU
            sciezka = sciezka_tb.Text.ToString();
            JPK plik = new JPK();
            plik.generuj_fakture(sciezka, faktura);
            this.faktura.Clear();
            plik.generuj_fakture_ctrl(sciezka, LiczbaFaktur, WartoscFaktur);
            plik.stawki_podatku(sciezka);
            LiczbaFaktur = 0;
            WartoscFaktur = 0;
        }
    }
}
