using System;

using GameOn.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GameOn.Views
{
    public sealed partial class CalendarDetailControl : UserControl
    {
        public SampleOrder ListMenuItem
        {
            get { return GetValue(ListMenuItemProperty) as SampleOrder; }
            set { SetValue(ListMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListMenuItemProperty = DependencyProperty.Register("ListMenuItem", typeof(SampleOrder), typeof(CalendarDetailControl), new PropertyMetadata(null, OnListMenuItemPropertyChanged));

        public CalendarDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CalendarDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
