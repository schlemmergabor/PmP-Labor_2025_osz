using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_OOPtulajdonság
{
    internal class Mole
    {
        // vakond pozija
        int pos;

       

        // paraméter nélküli ctor
        public Mole()
        {
            this.pos = 0;
        }

        // paraméteres ctor
        // Metódus overloading -> túlterhelés
        // több változat esetén a meghívott paraméternek megfelelő
        // fog lefutni
        public Mole(int pos)
        {
            this.pos = pos;
        }

        // property
        public int Pos { get => pos;  }

        // feljön és megmutatja magát
        public void TurnUp()
        {
            Console.SetCursorPosition(this.pos, 0);
            Console.WriteLine("M");
        }

        // elbújik és a, b közötti helyen feltűnik
        public void Hide(int a, int b)
        {
            Console.SetCursorPosition(this.pos, 0);
            Console.WriteLine(" ");
            Random rnd = new Random();
            this.pos = rnd.Next(a, b);
        }
    }
}
