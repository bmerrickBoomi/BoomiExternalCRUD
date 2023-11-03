using System;
using System.Collections.Generic;

namespace CustomBoomi.Models
{
    public class DrawCalendarResponse
    {
        public List<Draw> Draws { get; set; }
    }

    public class Draw
    {
        public List<int> Numbers { get; set; }

        public DateTime Date { get; set; }
    }
}
