using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;

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

            if (behavior.AssociatedObject == null) return;

            behavior.AssociatedObject.LayoutTransform = new ScaleTransform();
            var ani = new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(250)));

            // if (DesignerProperties.GetIsInDesignMode(behavior)) return;
            if (e.NewValue != null)
            {
                ani.From = 0;
                ani.To = 1;
                behavior.AssociatedObject.Text = e.NewValue.ToString();
                // behavior.AssociatedObject.BeginStoryboard(GetStoryboard());
                // behavior.AssociatedObject.BeginAnimation(ScaleTransform.ScaleYProperty, ani);
            }
            else
            {
                ani.From = 1;
                ani.To = 0;
                behavior.AssociatedObject.Text = string.Empty;
                // behavior.AssociatedObject.BeginStoryboard(GetStoryboard(false));
            }

            behavior.AssociatedObject.BeginAnimation(ScaleTransform.ScaleYProperty, ani);
            //behavior.AssociatedObject.Visibility = Visibility.Visible;
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.LayoutTransform = new ScaleTransform();
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

        private static Storyboard GetStoryboard(bool hasText =true)
        {
            var storyboard = new Storyboard();

            var ani = new DoubleAnimation(hasText ? 1 : 0, new Duration(TimeSpan.FromMilliseconds(250)));

            Storyboard.SetTargetProperty(ani, new PropertyPath("(LayoutTransform).(ScaleTransform.ScaleY)"));

            storyboard.Children.Add(ani);

            return storyboard;
        }
    }

    public class ErrorMessageContentBehavior : Behavior<ContentControl>
    {
        /// <summary>
        /// this is behavior property
        /// </summary>


        public object ErrorMessage
        {
            get { return (object)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(ErrorMessageContentBehavior), new PropertyMetadata(null, OnErrorMessageChanged));



        //public object ErrorMessageContent
        //{
        //    get { return (object)GetValue(ErrorMessageContentProperty); }
        //    set { SetValue(ErrorMessageContentProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ErrorMessageContent.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ErrorMessageContentProperty =
        //    DependencyProperty.Register("ErrorMessageContent", typeof(object), typeof(Error), new PropertyMetadata(0));

        


        private static void OnErrorMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = ((ErrorMessageContentBehavior)d);

            if (behavior.AssociatedObject == null) return;

            // if (DesignerProperties.GetIsInDesignMode(behavior)) return;
            if (e.NewValue != null)
            {
                behavior.AssociatedObject.Content = e.NewValue.ToString();
            }
            else
            {
                behavior.AssociatedObject.Content = string.Empty;
            }

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
                AssociatedObject.Content = string.Empty;
            };
        }
    }
}
