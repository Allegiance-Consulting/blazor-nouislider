﻿using Allegiance.Blazor.NoUiSlider.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace Allegiance.Blazor.NoUiSlider.Components.SingleNoUiSlider
{
    public partial class SingleSlider
    {
        private static double myValue = 20;
        private static double myValue2 = 50;

        public NoUiSliderConfiguration<double> Config = new NoUiSliderConfiguration<double>
        {
            //Start = 10,
            Range = new Range<double>
            {
                Min = 0,
                Max = 100
            },
            //To have the step linked to a percentage of max value
            PercentageStep = 20,
            //TooltipsFormat = new Models.TooltipsFormat
            //{
            //    Prefix = "",
            //    Suffix = "%",
            //    Decimals = 0
            //}
        };

        public NoUiSliderConfiguration<double> Config2 = new NoUiSliderConfiguration<double>
        {
            //Start = 30,
            Range = new Range<double>
            {
                Min = 0,
                Max = 100
            },
            PercentageStep = 0,
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
