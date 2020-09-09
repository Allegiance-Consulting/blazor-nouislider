using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Allegiance.Blazor.NoUiSlider.Components.RangeNoUiSlider
{
    public partial class RangeSlider
    {
        public double[] rangeValue = new double[] { 10, 50 };
        private double valBetween;
        private double minFirst;
        public string red = "red";

        [Parameter]
        public EventCallback<double> ValBetweenChanged { get; set; }

        public Models.RangeSliderConfiguration<double> Configs = new Models.RangeSliderConfiguration<double>
        {
            Start = new double[] { 10, 50 },
            Range = new Models.Ranges<double>
            {
                Min = 0,
                Max = 100
            },
            GenerateConnectClasses = true,
            Connect = new bool[] {true, true, true},
            Growth = true,
        };

        public double ValBetween
        {
            get 
            {
                return valBetween;
            }
            set 
            {
                ValBetweenChanged.InvokeAsync(value);
            }
        }
        public double MinFirst
        {
            get => minFirst;
            set => minFirst = value;
        }
        public void Change()
        {
            Configs.Start = new double[] { 30, 150 };
            rangeValue = Configs.Start;
            Configs.Range.Max = 300;
        }
    }
}
