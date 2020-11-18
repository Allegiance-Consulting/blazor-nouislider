using Allegiance.Blazor.NoUiSlider.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Dynamic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Allegiance.Blazor.NoUiSlider.Components.SingleNoUiSlider
{
    public partial class SingleSlider : ComponentBase
    {
        private static double myValue = 20;
        private static double myValue2 = 50;
        private static Guid singleSliderId = Guid.NewGuid();
        private bool disabled = false;
        [Inject] IJSRuntime JSRuntime{get; set;}

        public NoUiSliderConfiguration<double> Config = new NoUiSliderConfiguration<double>
        {
            Start = 20,
            Range = new Range<double>
            {
                Min = 0,
                Max = 100
            },
            //To have the step linked to a percentage of max value
            //PercentageStep = 10,
            InputFormat = "currency",
            Animate = true,
            IncreaseRange = 50,
            Id = singleSliderId,
            //EnableStep = true,
            Step = 50
        };

        public NoUiSliderConfiguration<double> Config2 = new NoUiSliderConfiguration<double>
        {
            Range = new Range<double>
            {
                Min = 0,
                Max = 100
            },
            InputFormat = "percentage",
        };

        public void Change()
        {
            // Change slider with Config.Start
            myValue = Config.Start = 50;
            // Change slider with bound value
            myValue2 = 100;
            Config.Range.Max = 300;
            Config2.Range.Max = 300;
        }

        public void ChangeConfig()
        {
            double TempStep = Config.PercentageStep;
            Config.Range.Max = myValue * 10;
            //Config.Step = 0;
            if (TempStep > 0)
            {
                Config.PercentageStep = 0;
                Thread.Sleep(100);
                Config.PercentageStep = TempStep;
                //int seconds = 100;
                //var timer = new Timer(RenewSteps, null, 0, seconds);
                //void RenewSteps()
                //{
                //    Config.PercentageStep = TempStep;
                //}
            }
        }

        public void Disable()
        {
            disabled = true;
        }  

        public void Enable()
        {
            disabled = false;
        }
    }
}
