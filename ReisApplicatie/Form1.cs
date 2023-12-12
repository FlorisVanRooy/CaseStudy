using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ReisApplicatie
{
    public partial class Form1 : Form
    {
        // lijst van landen declareren (String type omdat er verder niets met
        // de landen erin moet gebeuren, hier is dus geen object nodig)
        List<String> landenLijst;


        public Form1()
        {
            // formulier initialiseren
            InitializeComponent();
            // landenlijst initialiseren
            landenLijst = new List<string>();
        }

        // als het formulier geladen wordt
        private void Form1_Load(object sender, EventArgs e)
        {
            // maak een SQLite connectie met de SQLite database
            SQLiteConnection con = new SQLiteConnection("DataSource=D:\\Databases\\SQLite\\Reisbureau.db");
            // probeer een connectie te maken
            try
            {
                con.Open();
            }
            // als het niet lukt, geef een error message
            catch
            {
                Console.WriteLine("DB con open error");
            }

            // declareer een SQLite data reader
            SQLiteDataReader sQLiteDataReader;
            // maak een leeg commando aan
            SQLiteCommand sQLiteCommand = con.CreateCommand();
            // geef het commando (hier namen van landen selecteren)
            sQLiteCommand.CommandText = "SELECT name FROM Land";

            // de data uit de databank ophalen
            sQLiteDataReader = sQLiteCommand.ExecuteReader();
            // als er data is opgehaald
            if (sQLiteDataReader.HasRows)
            {
                // overloop de data rij per rij
                while (sQLiteDataReader.Read())
                {
                    // Selecteer de naam, zet die om naar type string
                    // en voeg die toe aan de landenlijst
                    string landNaam = sQLiteDataReader["name"].ToString();
                    landenLijst.Add(landNaam);
                }
            }

            // Sluit de connectie
            con.Close();

            // zorg dat de landen te zien zijn in de listbox
            listBoxLand.DataSource = landenLijst;
        }

        // als er een ander land wordt geselecteerd
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // declareer de hotellijst van type Hotel
            // (hier is een eigen klasse voor nodig omdat we verder willen
            // rekenen met de objecten van de lijst en dus kunnen we deze
            // niet als string declareren)
            List<Hotel> hotelLijst = new List<Hotel>();
            // maak weer een connectie met de datatbase
            SQLiteConnection con = new SQLiteConnection("DataSource=D:\\Databases\\SQLite\\Reisbureau.db");
            try
            {
                con.Open();
            }
            // en geef een error als de connectie niet lukt
            catch
            {
                Console.WriteLine("DB con open error");
            }

            // maak een nieuwe reader aan
            SQLiteDataReader sQLiteDataReader;
            // en geef het commando mee dat uitgevoerd moet worden
            SQLiteCommand sQLiteCommand = con.CreateCommand();
            int landId = listBoxLand.SelectedIndex;
            // hier wordt de naam en prijs van het hotel opgevraagd
            sQLiteCommand.CommandText = $"SELECT name, prijspernacht FROM Hotel where landId = {landId + 1}";

            // haal data op
            sQLiteDataReader = sQLiteCommand.ExecuteReader();
            // als data is opgehaald
            if (sQLiteDataReader.HasRows)
            {
                // overloop de data
                while (sQLiteDataReader.Read())
                {
                    // en maak een object aan van type Hotel met de naam en de prijs van het hotel
                    string hotelNaam = sQLiteDataReader["name"].ToString();
                    double prijs = double.Parse(sQLiteDataReader["prijspernacht"].ToString());
                    Hotel hotelObj = new Hotel(hotelNaam, prijs);
                    hotelLijst.Add(hotelObj);
                }
            }
            // sluit de connectie
            sQLiteDataReader.Close();

            // laat de hotels zien in de lijst
            listBoxHotel.DataSource = hotelLijst;

            // maak een lijst van Vluchten aan
            List<Vlucht> vluchtLijst = new List<Vlucht>();
            // selecteer de naam van de vliegmaatschappij en de prijs van de vlucht naar een land
            // van de tabellen vliegmaatschappij en vlucht van de database
            sQLiteCommand.CommandText = $"SELECT vm.name, vl.prijspervlucht FROM Vlucht as vl JOIN VliegMaatschappij as vm ON vl.vliegmaatschappijId = vm.vliegmaatschappijId WHERE landId = {landId + 1}";

            // haal de data op
            sQLiteDataReader = sQLiteCommand.ExecuteReader();
            if (sQLiteDataReader.HasRows)
            {
                // overloop de data
                while (sQLiteDataReader.Read())
                {
                    // maak een object van type Vlucht met de naam en prijs en zet deze bij in de lijst
                    string vliegMaatschappijNaam = sQLiteDataReader["name"].ToString();
                    double prijsPerVlucht = double.Parse(sQLiteDataReader["prijspervlucht"].ToString());
                    Vlucht vluchtObj = new Vlucht(vliegMaatschappijNaam, prijsPerVlucht);
                    vluchtLijst.Add(vluchtObj);
                }
            }

            // laat de vluchten zien in de listbox
            listBoxVlucht.DataSource = vluchtLijst;


            // sluit de connectie
            con.Close();
        }

        // als er op de knop bereken wordt gedrukt
        private void buttonBereken_Click(object sender, EventArgs e)
        {
            // alleen als het aantal nachten is ingevuld
            if (textBoxNacht.Text != null)
            {
                // haal het geselecteerde hotel en de geselecteerde vlucht op
                // en het aantal nachten dat de gebruiker wil overnachten
                Hotel hotelObj = (Hotel)listBoxHotel.SelectedValue;
                Vlucht vluchtObj = (Vlucht)listBoxVlucht.SelectedValue;
                double nachten = double.Parse(textBoxNacht.Text);

                // bereken de totale prijs
                double totalePrijs = (nachten * hotelObj.price) + vluchtObj.price;
                // geef het totaal weer in de label
                labelTotaal.Text = $"{totalePrijs: € #,##0.00}";
            }
        }
    }
}