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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WTFToolkits.Popup
{
    /// <summary>
    /// Interaction logic for WTFPopup.xaml
    /// </summary>
    public partial class WTFPopup
    {
        private WTFPopup(UIElement element, string title)
        {
            InitializeComponent();

            base.PopupContent = element;
            this.Title = title;
            this.CancelButton.Click += delegate
            {
                var sb = TryFindResource("ClosePopupStoryboard") as Storyboard;
                if (sb == null)
                {
                    this.Close();
                    return;
                }

                sb.Completed += delegate
                {
                    this.Close();
                };
                this.BeginStoryboard(sb);
            };
            this.CustomButton.Click += delegate
            {
                this.ErrorMessage = DateTime.Now.ToShortDateString();
                //this.HasError = !this.HasError;
            };
            this.TitleText.PreviewMouseLeftButtonDown += (sender, e) =>
            {
                if (e.ClickCount > 1)
                {
                    this.WindowState = WindowState == System.Windows.WindowState.Maximized ? WindowState.Normal : System.Windows.WindowState.Maximized;
                }
            };
            this.PreviewMouseDown += (sender, e) =>
            {
                if (e.Source is Button) return;
                if (e.Source is TextBlock) this.ErrorMessage = string.Empty;
                this.Cursor = Cursors.SizeAll;
            };
            this.PreviewMouseUp += delegate
            {
                this.Cursor = null;
            };
            this.OkButton.Click += delegate
            {
                this.HasError = true;
            };
            this.DataContext = this;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.MainWindow.Opacity = 1;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        public static void Popup(UIElement element, string title)
        {
            var wtf = new WTFPopup(element, title);
            Application.Current.MainWindow.Opacity = 0.5;
            wtf.ShowDialog();
        }
    }
}
