using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conversation
{
    class Line
    {
        public string Text { get; set; }
        public Stat LineEffect { get; set; } 

        public Line()
        {
            Text = "...";
            LineEffect = Stat.sad;
        }
    }
}
