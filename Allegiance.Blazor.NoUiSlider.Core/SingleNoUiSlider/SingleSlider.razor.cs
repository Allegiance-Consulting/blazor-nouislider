using Allegiance.Blazor.NoUiSlider.Core.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Dynamic;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Allegiance.Blazor.NoUiSlider.Core.SingleNoUiSlider
{
    public partial class SingleSlider : ComponentBase
    {
        [Inject] IJSRuntime JSRuntime { get; set; }

        private double myValue;
        private double myValue2;
        private static Guid singleSliderId = Guid.NewGuid();
        private bool disabled = false;
        private bool setSlidetAfterSlide;
        //private EventCallback<bool> setSlidetAfterSlideChanged { get; set; }

        public double MyValue2
        {
            get => myValue2;
            set
            {
                if (value != myValue2)
                {
                    myValue2 = value;
                }
            }
        }

        public NoUiSliderConfiguration<double> Config = new NoUiSliderConfiguration<double>
        {
            Start = 50,
            Range = new Models.Range<double>
            {
                Min = 0,
                Max = 10000000
            },
            //To have the step linked to a percentage of max value
            //PercentageStep = 10,
            InputFormat = "currency",
            Animate = true,
            IncreaseRange = 500,
            Growth = true,
            //Id = singleSliderId,
            EnableStep = true,
            //ExactInput = true,
            Step = 1,
            //ReturnStep = 100,
            ChangeColorBiggerThen = 5000000,
            SingleSliderConnectClass = "single-slider-color",
        };

        public NoUiSliderConfiguration<double> Config2 = new NoUiSliderConfiguration<double>
        {
            Range = new Models.Range<double>
            {
                Min = 0,
                Max = 100
            },
            InputFormat = "percentage",
            ReturnStep = 5,
            ChangeColorBiggerThen = 50
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

        public void ChangeStep(double value)
        {
            Config.Step = value;
        }
    }
}
