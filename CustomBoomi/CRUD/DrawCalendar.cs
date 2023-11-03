using CustomBoomi.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CustomBoomi.CRUD
{
    public static class DrawCalendar
    {
        public static DrawCalendarResponse List()
        {
            // Generate random number between [1-9]
            var rnd = new Random();
            var count = rnd.Next(1, 10);

            var draws = new DrawCalendarResponse { 
                Draws = new List<Draw>()
            };

            for (var i = 1; i <= count; i++) {

                var draw = new Draw {
                    Numbers = new List<int>(),
                    Date = DateTime.Now.AddDays(rnd.Next(1, 50) * -1),
                    DrawNumber = i
                };

                // Generate 5 random numbers between [1-99]
                for (var j = 0; j < 5; j++) {
                    draw.Numbers.Add(rnd.Next(1, 100));
                }

                draws.Draws.Add(draw);
            }

            return draws;
        }
    }
}
