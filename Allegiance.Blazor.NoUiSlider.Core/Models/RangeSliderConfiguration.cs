using System;
using System.Collections.Generic;
using System.Text;

namespace Allegiance.Blazor.NoUiSlider.Core.Models
{
    public class RangeSliderConfiguration<T>
    {
        public T[] Start { get; set; }
        public bool[] Connect { get; set; } = { false, true, false };
        public Ranges<T> Range { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Tooltips { get; set; } = true;
        public TooltipsFormat TooltipsFormat { get; set; } = new TooltipsFormat();
        public T Step { get; set; }
        public int? PercentageStep { get; set; }
        public bool SetSlider { get; set; } = false;
        public string Behaviour { get; set; } = "snap";
        public string Event { get; set; } = "end";
        public bool Growth { get; set; } = false;
        public T Margin { get; set; }
        public bool GenerateConnectClasses { get; set; } = false;
        //Changes the color of the slider tooltip and handle
        //when sliderstart < ChangeColorOnLessValue
        public double ChangeColorFirstHandleLessThen { get; set; } = 0;
        public double ChangeColorFirstHandleBiggerThen { get; set; } = 0;
        public double ChangeColorSecHandleLessThen { get; set; } = 0;
        public double ChangeColorSecHandleBiggerThen { get; set; } = 0;
        public string Color { get; set; }
    }
    public class Ranges<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
    }
}
