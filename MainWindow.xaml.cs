using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DtDMMAdonis.src.Objects;
using DtDMMAdonis.src.Components;
using Newtonsoft.Json;

namespace DtDMMAdonis {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisUI.Controls.AdonisWindow {
        public MainWindow() {
            InitializeComponent();

        }

        private async Task<ModData[]> FetchData() {
            ModData[] data = null;
            var client = new HttpClient();
            var result = await client.GetAsync("https://sevendtdmm.netlify.app/modData.json");

            if (result.IsSuccessStatusCode) {
                var a = await result.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<ModData[]>(a);
            }

            return data;
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e) {
            var v = await FetchData();
            var client = new HttpClient();
            List<Mod> mods = new List<Mod>();
            foreach (var mod in v) {
                var result = await client.GetAsync($"https://sevendtdmm.netlify.app/{mod.modName}.json");
                if (result.IsSuccessStatusCode) {
                    sp.Children.Add(new ModItem(
                        JsonConvert.DeserializeObject<Mod>(result.Content.ReadAsStringAsync().Result), ref details));
                }
            }
        }
    }
}
