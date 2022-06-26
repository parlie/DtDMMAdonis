using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DtDMMAdonis.src.Components {
    /// <summary>
    /// Interaction logic for Carousel.xaml
    /// </summary>
    public partial class Carousel : UserControl {
        public Carousel() {
            InitializeComponent();
            image.Source = null;
        }

        #region Properties

        public static readonly DependencyProperty ImagesProperty = DependencyProperty.Register(
            "Images",
            typeof(string[]),
            typeof(Carousel));

        public string[] images {
            get => (string[])GetValue(ImagesProperty);
            set {
                SetValue(ImagesProperty, value);
                NextImage(0);
            }
        }

        private int imageIndex = 0;

        #endregion

        private void NextImage(int position) {
            if (images.Length == 0) {
                this.Visibility = Visibility.Hidden;
                return;
            }

            if (images.Length == 1 && image.Source != null) {
                return;
            } else if (images.Length == 1) {
                image.Source = new BitmapImage(new Uri(images[imageIndex], UriKind.Absolute));
                return;
            }

            imageIndex += position;
            if (imageIndex < 0) {
                imageIndex = images.Length - 1;
            } else if (imageIndex >= images.Length) {
                imageIndex = 0;
            }

            var newImage = new BitmapImage();
            newImage.BeginInit();
            newImage.UriSource = new Uri(images[imageIndex], UriKind.Absolute);
            newImage.DecodePixelHeight = (int)image.ActualHeight;
            newImage.DecodePixelWidth = (int)image.ActualWidth;
            newImage.EndInit();
            image.Source = newImage;
        }

        private void rightButton_Click(object sender, RoutedEventArgs e) {
            NextImage(1);
        }

        private void leftButton_Click(object sender, RoutedEventArgs e) {
            NextImage(-1);
        }

        private void Button_OnMouseEnter(object sender, MouseEventArgs e) {
            var button = (Button)sender;
            button.Height += 5;
            button.Width += 5;
        }

        private void Button_OnMouseLeave(object sender, MouseEventArgs e) {
            ((Button)sender).Height -= 5;
            ((Button)sender).Width -= 5;
        }
    }
}
