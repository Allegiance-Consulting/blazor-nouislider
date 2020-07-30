using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
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
        public TooltipsFormat TooltipsFormat { get; set; } = new TooltipsFormat();
        public bool SetSlider { get; set; } = false;
        public T Step { get; set; }
        //If percentage step is sent in, the slider step jumps with a percentage of max value
        public int? PercentageStep { get; set; }
        public string Behaviour { get; set; } = "snap";
        public string Event { get; set; } = "end";
        public bool Growth { get; set; } = false;
    }
    public class Range<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
    }    
    
    public class TooltipsFormat
    {
        public string Prefix { get; set; } = "R ";
        public string Suffix { get; set; } = "";
        public string Thousand { get; set; } = " ";
        public int Decimals { get; set; } = 2;
    }
}
