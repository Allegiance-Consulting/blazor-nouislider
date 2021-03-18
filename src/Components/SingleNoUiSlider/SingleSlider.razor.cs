using Allegiance.Blazor.NoUiSlider.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Dynamic;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Allegiance.Blazor.NoUiSlider.Components.SingleNoUiSlider
{
    public partial class SingleSlider : ComponentBase
    {
        private double myValue = 50;
        private double myValue2 = 50;
        private static Guid singleSliderId = Guid.NewGuid();
        private bool disabled = false;
        private bool setSlidetAfterSlide;
        //private EventCallback<bool> setSlidetAfterSlideChanged { get; set; }
        [Inject] IJSRuntime JSRuntime{get; set;}

        public NoUiSliderConfiguration<double> Config = new NoUiSliderConfiguration<double>
        {
            Start = 50,
            Range = new Range<double>
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
            //Step = 50,
            //ReturnStep = 100,
            ChangeColorBiggerThen = 5000000,
            Color = "#EA6868",
        };

        public NoUiSliderConfiguration<double> Config2 = new NoUiSliderConfiguration<double>
        {
            Range = new Range<double>
            {
                Min = 0,
                Max = 100
            },
            InputFormat = "percentage",
            ReturnStep = 5,
            ChangeColorBiggerThen = 50,
            Color = "red",
        };

        public double MyValue
        {
            get => myValue;
            set 
            { 
                myValue = value;
                //Task.Delay(2000, Console.WriteLine("Delay")).Wait();
                //Console.WriteLine("Delay hit");
            }
        } 
        public double MyValueInput
        {
            get => myValue;
            set => myValue = value;
        }

        public void Change()
        {
            // Change slider with Config.Start
            myValue = Config.Start = 50;
            // Change slider with bound value
            myValue2 = 100;
            Config.Range.Max = 300;
            Config2.Range.Max = 300;
        }

        public async Task setSlidetAfterSlideChanged() 
        {
            await Task.Delay(500);
            Console.WriteLine("I have done it SUCCESSFULLY");
        }

        public void ChangeConfig()
        {
            //double TempStep = Config.PercentageStep;
            //Config.Range.Max = myValue * 10;
            ////Config.Step = 0;
            //if (TempStep > 0)
            //{
            //    Config.PercentageStep = 0;
            //    Thread.Sleep(100);
            //    Config.PercentageStep = TempStep;
            //    //int seconds = 100;
            //    //var timer = new Timer(RenewSteps, null, 0, seconds);
            //    //void RenewSteps()
            //    //{
            //    //    Config.PercentageStep = TempStep;
            //    //}
            //}
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
