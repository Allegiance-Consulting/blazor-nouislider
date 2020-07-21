using System;
using System.Collections.Generic;
using System.Text;

namespace Allegiance.Blazor.NoUiSlider.Components.SingleNoUiSlider
{
    public partial class SingleSlider
    {
        private static double myValue = 30;
        private static double myValue2 = 50;

        public Models.NoUiSliderConfiguration<double> Config = new Models.NoUiSliderConfiguration<double>
        {
            Start = 10,
            Range = new Models.Range<double>
            {
                Min = 0,
                Max = 100
            },
        };
        public Models.NoUiSliderConfiguration<double> Config2 = new Models.NoUiSliderConfiguration<double>
        {
            Start = 30,
            Range = new Models.Range<double>
            {
                Min = 0,
                Max = 100
            },
        };
        public void Change()
        {
            // Change slider with Config.Start
            Config.Start = 50;
            // Change slider with bound value
            myValue2 = 100;
            Config.Range.Max = 300;
            Config2.Range.Max = 300;
        }
    }
}
