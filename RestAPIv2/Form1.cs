namespace RestAPIv2
{
    // this is a .Net app as opposed to .Netframework so can use system.text.json
    using System.Text.Json;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.openweathermap.org/data/2.5/weather?q=Southampton,uk&appid=8316724b67d895ab2649049167efaf76");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string jsonText = await response.Content.ReadAsStringAsync();
            //dynamic? weather = JsonSerializer.Deserialize<dynamic>(jsonText);
            Rootobject weather = JsonSerializer.Deserialize<Rootobject>(jsonText);
            if (weather != null)
            {
                lblTemp.Text = (weather.main.temp - 273.0).ToString();
            }
        }
    }
    // this is created by getting the json text and copying it in debug
    // then paste special in the menu to create the classes.
    public class Rootobject
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public string _base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

}