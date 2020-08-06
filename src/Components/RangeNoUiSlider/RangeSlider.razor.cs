using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Allegiance.Blazor.NoUiSlider.Components.RangeNoUiSlider
{
    public partial class RangeSlider
    {
        private static double[] rangeValue = new double[] { 10, 50 };
        private static double valBetween { get; set; }
        private static double startfirst { get; set; }

        public Models.RangeSliderConfiguration<double> Configs = new Models.RangeSliderConfiguration<double>
        {
            Start = new double[] { 10, 50 },
            Range = new Models.Ranges<double>
            {
                Min = 0,
                Max = 100
            },
            Growth = true
        };

        public void Change()
        {
            Configs.Start = new double[] { 30, 150 };
            rangeValue = Configs.Start;
            Configs.Range.Max = 300;
        }
    }
}
