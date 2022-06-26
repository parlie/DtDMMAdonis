using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using DtDMMAdonis.src.ExtensionMethods;
using DtDMMAdonis.src.Objects;
using MdXaml;

namespace DtDMMAdonis.src.Pages {
    /// <summary>
    /// Interaction logic for ModDetails.xaml
    /// </summary>
    public partial class ModDetails : Page {
        public ModDetails(Mod _mod) {
            mod = _mod;
            InitializeComponent();
            LoadContent();
        }

        #region Properties

        public static readonly DependencyProperty ModProperty = DependencyProperty.Register(
            "mod",
            typeof(Mod),
            typeof(ModDetails));

        private Mod mod {
            get => (Mod)GetValue(ModProperty);
            set => SetValue(ModProperty, value);
        }

        #endregion

        private void LoadContent() {
            modAuthors.Content = $"By: {mod.modAuthors.ListItems()}";
            modCreatedTime.Content = $"Created: {mod.modCreatedTime}";
            modUpdatedTime.Content = $"Last update: {mod.modLastUpdatedTime}";
            modDescription.MarkdownStyle = MarkdownStyle.Standard;
            modDescription.ClickAction = ClickAction.OpenBrowser;
            modDescription.Markdown = mod.modDescription;
            modTags.Content = $"Tags: {mod.modTags.ListItems()}";
            imageCarousel.images = mod.modImages;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/56270446/disable-scrolling-in-scrollviewer-child-of-a-frame-which-has-a-scrollviewer-as-p
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BubblePreviewMouseWheel(object sender, MouseWheelEventArgs e) {
            e.Handled = true;
            var e2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            e2.RoutedEvent = UIElement.MouseWheelEvent;
            ((UIElement)sender).RaiseEvent(e2);
        }
    }
}
