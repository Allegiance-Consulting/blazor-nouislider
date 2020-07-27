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
        public Pips Pips { get; set; } = new Pips();
        public bool SetSlider { get; set; } = false;
        public T Step { get; set; }
        //If percentage step is sent in, the slider step jumps with a percentage of max value
        public int? PercentageStep { get; set; }
        public string Behaviour { get; set; } = "snap";
        public string Event { get; set; } = "end";
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

    public class Pips
    {
        public string Mode { get; set; } = "positions";
        public int Density { get; set; } = 100;
        public int[] Values { get; set; } = { 0, 100 };
    }
}
