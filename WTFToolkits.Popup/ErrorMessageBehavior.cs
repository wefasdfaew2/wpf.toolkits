using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace WTFToolkits.Popup
{
    public class ErrorMessageBehavior : Behavior<TextBlock>
    {
        /// <summary>
        /// this is behavior property
        /// </summary>


        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(ErrorMessageBehavior), new PropertyMetadata(null, OnErrorMessageChanged));



        private static void OnErrorMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = ((ErrorMessageBehavior)d);
            behavior.AssociatedObject.Text = e.NewValue.ToString();
            //behavior.AssociatedObject.Visibility = Visibility.Visible;
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            /*
             * you can add everything in here
             * example click event
             */
            AssociatedObject.PreviewMouseLeftButtonDown += delegate
            {
                // AssociatedObject.Visibility = Visibility.Collapsed;
                AssociatedObject.Text = string.Empty;
            };
        }
    }
}
