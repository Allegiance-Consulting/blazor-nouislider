using System;
using System.Collections.Generic;
using System.Text;

namespace Allegiance.Blazor.NoUiSlider.Models
{
    public class NoUiSliderConfiguration<T>
    {
        public T Start { get; set; }
        public bool Connect { get; set; } = true;
        public Range<T> Range { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
    }

    public class Range<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
    }
}
