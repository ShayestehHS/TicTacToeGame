using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTocToeGame
{
    public class TextsInButtons
    {
        public ModelOfButtons Free = new ModelOfButtons()
        {
            text = " ",
            backColor = Color.White,
            foreColor = Color.Black
        };

        public ModelOfButtons Nought = new ModelOfButtons()
        {
            text = "O",
            backColor = Color.Red,
            foreColor = Color.White
        };

        public ModelOfButtons Cross = new ModelOfButtons()
        {
            text = "X",
            backColor = Color.White,
            foreColor = Color.Red
        };
    }
}
