using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MovieApp.Controls
{
    public partial class GenreTile : Frame
    {
        public GenreTile()
        {
            InitializeComponent();
        }


        public static readonly BindableProperty GenreTileTextProperty = BindableProperty.Create(
                                                  nameof(GenreTileText),
                                                  typeof(string),
                                                  typeof(GenreTile),
                                                  "",
                                                  BindingMode.TwoWay,
                                                  propertyChanged: TitleTextPropertyChanged);
        public string GenreTileText { get; set; }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (GenreTile)bindable;
            control.label.Text = newValue.ToString();
        }
    }
}
