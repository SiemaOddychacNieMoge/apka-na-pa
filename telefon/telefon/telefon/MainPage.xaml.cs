using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace telefon
{
    public partial class MainPage : ContentPage
    {
        private List<Stacja> stacjaList;

        public MainPage()
        {
            InitializeComponent();
            wezdane();
        }

        private async void wezdane()
        {
            using (var client = new HttpClient())
            {
                var res = await client.GetAsync("http://10.0.2.2:8080/data");

                string content = await res.Content.ReadAsStringAsync();

                stacjaList = JsonConvert.DeserializeObject<List<Stacja>>(content);
            }

            if (stacjaList.Count == 0 || stacjaList == null) return;

            stacja.Items.Clear();

            for (int i = 0; i < stacjaList.Count; i++)
            {
                stacja.Items.Add(stacjaList[i].Nazwa);
            }
        }

        private void stacja_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stacja s = stacjaList[stacja.SelectedIndex];

            nazwaLbl.Text = s.Nazwa;
            tempLbl.Text = $"Temperatura: {s.Temperatura} *C";
            opisLbl.Text = $"Opis: {s.Opis}";
            cisnLbl.Text = $"Ciśnienie: {s.Cisnienie} hPa";
            wiatrLbl.Text = $"Wiatr: {s.Wiatr} m/s";
        }
    }
}
