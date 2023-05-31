using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace komputer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Stacja> stacje;

        public MainWindow()
        {
            InitializeComponent();
            wezdane();
        }

        private async void wezdane()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:8080/data");

                string jsontekst = await response.Content.ReadAsStringAsync();

                stacje = JsonConvert.DeserializeObject<List<Stacja>>(jsontekst);
            }

            stacja.Items.Clear();

            for (int i = 0; i < stacje.Count(); i++)
            {
                stacja.Items.Add(stacje[i].Nazwa);
            }
        }

        private void stacja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Stacja s = stacje[stacja.SelectedIndex];

            nazwaLbl.Content = $"Nazwa: {s.Nazwa}";
            tempLbl.Content = $"Temperatura: {s.Temperatura} *C";
            opisLbl.Content = $"Opis: {s.Opis}";
            cisnLbl.Content = $"Ciśnienie: {s.Cisnienie} hPa";
            wiatrLbl.Content = $"Wiatr: {s.Wiatr} m/s";
        }
    }
}
