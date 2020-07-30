using System;
using System.Collections.Generic;
using System.Text;

namespace Allegiance.Blazor.NoUiSlider.Models
{
    public class RangeSliderConfiguration<T>
    {
        public T[] Start { get; set; }
        public bool Connect { get; set; } = true;
        public Ranges<T> Range { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Tooltips { get; set; } = true;
        public TooltipsFormat TooltipsFormat { get; set; } = new TooltipsFormat();
        public T Step { get; set; }
        public int? PercentageStep { get; set; }
        public Pips Pips { get; set; } = new Pips();
        public bool SetSlider { get; set; } = false;
        public string Behaviour { get; set; } = "snap";
        public string Event { get; set; } = "end";
        public bool Growth { get; set; } = false;
    }
    public class Ranges<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
    }
}
