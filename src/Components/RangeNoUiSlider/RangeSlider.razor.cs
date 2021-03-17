using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Allegiance.Blazor.NoUiSlider.Components.RangeNoUiSlider
{
    public partial class RangeSlider
    {
        //private double valBetween;
        //private double minFirst;
        private bool disabled = false;

        public double[] rangeValue = new double[] { 10, 50 };
        public double MinFirst;
        public double ValBetween;

        [Parameter]
        public EventCallback<double> ValBetweenChanged { get; set; }
        public EventCallback<double> MinFirstChanged { get; set; }

        public Models.RangeSliderConfiguration<double> Configs = new Models.RangeSliderConfiguration<double>
        {
            Start = new double[] { 10, 50 },
            Range = new Models.Ranges<double>
            {
                Min = 0,
                Max = 100
            },
            GenerateConnectClasses = true,
            Connect = new bool[] { true, true, true },
            Growth = true,
            ChangeColorBiggerThen = true,
            Color = "#EA6868",
            ChangeColorOnValue = 60
        };

        private void SetMinFirst(double value)
        {
            MinFirst = value;
        }

        public void Change()
        {
            Configs.Start = new double[] { 30, 150 };
            rangeValue = Configs.Start;
            Configs.Range.Max = 300;
        }

        public void Disable()
        {
            disabled = true;
        }
    }
}
