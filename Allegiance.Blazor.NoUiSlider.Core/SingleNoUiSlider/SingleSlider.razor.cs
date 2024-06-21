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

        public double MyValue
        {
            get => myValue;
            set
            {
                if (value != myValue)
                {
                    myValue = value;
                    Config.TooltipsFormat.Suffix = " / " + (myValue + 10).ToString();
                }
            }
        }

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
            Start = 0,
            Range = new Models.Range<double>
            {
                Min = 0,
                Max = 100000
            },
            //To have the step linked to a percentage of max value
            //PercentageStep = 10,
            Animate = true,
            IncreaseRange = 500,
            Growth = true,
            //Id = singleSliderId,
            //ExactInput = true,
            Step = 1,
            //ReturnStep = 100,
            ChangeColorBiggerThen = 50000,
            SingleSliderConnectClass = "single-slider-color",
            TooltipsFormat = new TooltipsFormat()
            {
                Prefix = "R ",
                Thousand = " ",
                Suffix = " / 30"
            },
            CustomColor = "red",
        };

        public NoUiSliderConfiguration<double> Config2 = new NoUiSliderConfiguration<double>
        { 
            Range = new Models.Range<double>
            {
                Min = 0,
                Max = 100
            },
            InputFormat = "percentage",
            ReturnStep = 5
        };

        public void Change()
        {
            // Change slider with Config.Start
            myValue = Config.Start = 50;
            Config.TooltipsFormat.Suffix = " / 50";
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
