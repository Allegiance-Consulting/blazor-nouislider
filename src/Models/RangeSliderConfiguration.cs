using System;
using System.Collections.Generic;
using System.Text;

namespace Allegiance.Blazor.NoUiSlider.Models
{
    public class RangeSliderConfiguration<T>
    {
        public T[] Start { get; set; }
        public object Connect { get; set; }
        public Ranges<T> Range { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Tooltips { get; set; } = true;
        public bool SetSlider { get; set; } = false;
    }
    public class Ranges<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
    }
}
