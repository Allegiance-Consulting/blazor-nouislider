using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Allegiance.Blazor.NoUiSlider.Models
{
    public class NoUiSliderConfiguration<T>
    {
        public T Start { get; set; }
        public string Connect { get; set; } = "lower";
        public Range<T> Range { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Tooltips { get; set; } = true;
        public bool Disabled { get; set; } = false;
        public TooltipsFormat TooltipsFormat { get; set; } = new TooltipsFormat();
        public bool SetSlider { get; set; } = false;
        public bool ManualSliderSet { get; set; } = false;
        public T Step { get; set; } = (T)Convert.ChangeType(0, typeof(T));
        //If percentage step is sent in, the slider step jumps with a percentage of max value
        public double PercentageStep { get; set; } = 0;
        //Allows slider handle to jump to mouse position on click
        public string Behaviour { get; set; } = "snap";
        public string Event { get; set; } = "end";
        public string SlideEvent { get; set; } = "slide";
        public bool Growth { get; set; } = false;
        public string InputFormat { get; set; }
        public bool Animate { get; set; } = false;
        //Enables a default step value
        public bool EnableStep { get; set; } = false;
        public bool ExactInput { get; set; } = false;
        //Changes the color of the slider tooltip and handle
        //when sliderstart < ChangeColorOnLessValue
        public bool ChangeColor { get; set; } = false;
        public string Color { get; set; }
        public double ChangeColorOnLessValue { get; set; }
        //Adds a limit of your choice to the range
        public double RangeLimit { get; set; } = 0;
        public double IncreaseRange { get; set; } = 0;
        public double ReturnStep { get; set; } = 0;
    }

    public class Range<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
    }    
    
    public class TooltipsFormat
    {
        public string Prefix { get; set; } = "";
        public string Suffix { get; set; } = "";
        public string Thousand { get; set; } = " ";
        public int Decimals { get; set; } = 0;
    }
}
