using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ReisApplicatie
{
    public partial class Form1 : Form
    {
        List<String> landenLijst;


        public Form1()
        {
            InitializeComponent();
            landenLijst = new List<string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("DataSource=D:\\Databases\\SQLite\\Reisbureau.db");
            try
            {
                con.Open();
            }
            catch
            {
                Console.WriteLine("DB con open error");
            }

            SQLiteDataReader sQLiteDataReader;
            SQLiteCommand sQLiteCommand = con.CreateCommand();
            sQLiteCommand.CommandText = "SELECT name FROM Land";

            sQLiteDataReader = sQLiteCommand.ExecuteReader();
            if (sQLiteDataReader.HasRows)
            {
                while (sQLiteDataReader.Read())
                {
                    // Access data from the reader here
                    string landNaam = sQLiteDataReader["name"].ToString();
                    landenLijst.Add(landNaam);
                }
            }

            // Close the connection when done
            con.Close();

            listBoxLand.DataSource = landenLijst;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Hotel> hotelLijst = new List<Hotel>();
            SQLiteConnection con = new SQLiteConnection("DataSource=D:\\Databases\\SQLite\\Reisbureau.db");
            try
            {
                con.Open();
            }
            catch
            {
                Console.WriteLine("DB con open error");
            }

            SQLiteDataReader sQLiteDataReader;
            SQLiteCommand sQLiteCommand = con.CreateCommand();
            int landId = listBoxLand.SelectedIndex;
            sQLiteCommand.CommandText = $"SELECT name, prijspernacht FROM Hotel where landId = {landId + 1}";

            sQLiteDataReader = sQLiteCommand.ExecuteReader();
            if (sQLiteDataReader.HasRows)
            {
                while (sQLiteDataReader.Read())
                {
                    // Access data from the reader here
                    string hotelNaam = sQLiteDataReader["name"].ToString();
                    double prijs = double.Parse(sQLiteDataReader["prijspernacht"].ToString());
                    Hotel hotelObj = new Hotel(hotelNaam, prijs);
                    hotelLijst.Add(hotelObj);
                }
            }
            else
            {
                //listBox3.Text = "NOthing found";
            }
            sQLiteDataReader.Close();

            listBoxHotel.DataSource = hotelLijst;

            List<Vlucht> vluchtLijst = new List<Vlucht>();
            sQLiteCommand.CommandText = $"SELECT vm.name, vl.prijspervlucht FROM Vlucht as vl JOIN VliegMaatschappij as vm ON vl.vliegmaatschappijId = vm.vliegmaatschappijId WHERE landId = {landId + 1}";

            sQLiteDataReader = sQLiteCommand.ExecuteReader();
            if (sQLiteDataReader.HasRows)
            {
                while (sQLiteDataReader.Read())
                {
                    // Access data from the reader here
                    string vliegMaatschappijNaam = sQLiteDataReader["name"].ToString();
                    double prijsPerVlucht = double.Parse(sQLiteDataReader["prijspervlucht"].ToString());
                    Vlucht vluchtObj = new Vlucht(vliegMaatschappijNaam, prijsPerVlucht);
                    vluchtLijst.Add(vluchtObj);
                }
            }
            else
            {
                //label1.Text = "NOthing found";
            }

            listBoxVlucht.DataSource = vluchtLijst;


            // Close the connection when done
            con.Close();
        }

        private void buttonBereken_Click(object sender, EventArgs e)
        {
            if (textBoxNacht.Text != null)
            {
                Hotel hotelObj = (Hotel)listBoxHotel.SelectedValue;
                Vlucht vluchtObj = (Vlucht)listBoxVlucht.SelectedValue;
                double nachten = double.Parse(textBoxNacht.Text);

                double totalePrijs = (nachten * hotelObj.price) + vluchtObj.price;
                labelTotaal.Text = $"{totalePrijs: € #,##0.00}";
            }
        }
    }
}