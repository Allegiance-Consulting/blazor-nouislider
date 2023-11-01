using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Allegiance.Blazor.NoUiSlider.Core.RangeNoUiSlider
{
    public partial class RangeSlider
    {
        private bool disabled = false;
        private double[] rangeValue = new double[] { 10, 50 };
        private double minFirst;
        private double valBetween;

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
            ChangeColorFirstHandleBiggerThen = 60,
            ChangeColorSecHandleLessThen = 80,
            Color = "#EA6868",
        };

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                SetHandleDifferences();
                base.OnAfterRender(firstRender);
            }
        }

        private void ChangeSliderValue(int handle, double value)
        {
            rangeValue[handle] = value;
            SetHandleDifferences();
        }

        private void SetHandleDifferences()
        {
            minFirst = rangeValue[0];
            valBetween = rangeValue[1] - rangeValue[0];
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
