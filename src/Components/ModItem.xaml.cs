using System;
using System.Collections.Generic;
using System.Linq;
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
using DtDMMAdonis.src.Objects;
using DtDMMAdonis.src.Pages;

namespace DtDMMAdonis.src.Components {
    /// <summary>
    /// Interaction logic for ModItem.xaml
    /// </summary>
    public partial class ModItem : UserControl {
        public ModItem(Mod _mod, ref Frame _details) {
            details = _details;
            mod = _mod;
            modName = mod.modName;
            InitializeComponent();
        }

        public ModItem(Mod _mod) {
            details = null;
            mod = _mod;
            modName = mod.modName;
            InitializeComponent();
            viewButton.Visibility = Visibility.Hidden;
        }

        public static readonly DependencyProperty ModNameProperty = DependencyProperty.Register(
            "modName",
            typeof(string),
            typeof(ModItem));

        private string modName { get => (string)GetValue(ModNameProperty); set => SetValue(ModNameProperty, value); }
        public Mod mod { get; set; }
        private Frame details;

        private void viewButton_Click(object sender, RoutedEventArgs e) {
            details.NavigationService.RemoveBackEntry();
            var page = new ModDetails(mod);
            details.Content = page;
        }
    }
}
