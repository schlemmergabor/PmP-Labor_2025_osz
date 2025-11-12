using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_OOPfeladatmegoldás
{
    internal class Game
    {
        // mezők
        // játéktér, Field
        Field f;

        // bölényeket tároló tömb
        Buffalo[] bfs;

        // ctor
        public Game(int jatekterMerete, int bolenyekSzama)
        {
            // Field létrehozása -> játéktér
            this.f = new Field(jatekterMerete);

            // bölények tömbjének létrehozása
            this.bfs = new Buffalo[bolenyekSzama];

            // egyes bölények létrehozása a tömbbe
            // itt hívjuk meg a Buffalo ctorját az egyes indexekre
            for (int i = 0; i < bfs.Length; i++)
            {
                this.bfs[i] = new Buffalo();
            }
        }

        // Property - véget ért-e már a játék?
        public bool IsOver
        {
            get
            {
                // ha egy bölény célbe ért, azaz végignézzük az összeset
                foreach (Buffalo item in bfs)
                {
                    // ha megtaláltuk az első célba ért bölényt
                    // akkor máris return true -> nem kell a többit végig nézni
                    // ekkor a foreach ciklusból azonnal "visszalép"
                    if (item.X == this.f.TargetX && item.Y == this.f.TargetY) return true;
                }

                // vége a játéknak a másik esetben is, azaz,
                // ha a bölények mind meghaltak

                // kezdetben azt mondjuk nincs élő bölény
                bool vanElo = false;

                // végig nézzük az összes bölényt
                foreach (Buffalo item in bfs)
                {
                    // ha találtunk élőt -> akkor van legalább egy élő
                    if (item.Aktiv) vanElo = true;
                }

                // vanélő negálása, megfordítása
                // ha volt élő, akkor vanElo = true, tehát false-t ad vissza
                // ha nem volt élő, akkor vanElo = false, tehát true-t ad vissza
                return !vanElo;
            }
        }

        // játék megjelenítése
        public void VisualizeElements()
        {
            // képernyő törlése
            Console.Clear();

            // játéktér megjelenítése
            this.f.Show();

            // bölények tömbjének bejárása
            foreach (Buffalo item in bfs)
            {
                // megjelenítés
                item.Show();

                // mozgatás
                item.Move(f);
            }
        }

        // lövés
        private void Shoot()
        {
            // alul jelenjen meg a lövés "panel"
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("---------------------------");
            Console.Write("X=? ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Y=? ");
            int y = int.Parse(Console.ReadLine());


            // lövés...
            foreach (Buffalo item in bfs)
            {
                // ha az X,Y-on van az item (bölény)
                if (item.X == x && item.Y == y)
                {
                    // deaktiválás -> eltaláltam
                    item.Deactivate();
                }
            }

        }
        public void Run()
        {
            // amíg nincs vége a játéknak
            while (!this.IsOver)
            {
                // kirajzol
                VisualizeElements();

                // lövés
                Shoot();
            }

            // eldöntjük, hogy ki nyert

            // van-e élő bölény még?
            bool vanElo = false;
            foreach (Buffalo item in bfs)
            {
                // ha találtunk élőt -> akkor van élő
                if (item.Aktiv) vanElo = true;
            }

            // ha van még élő -> akkor az célba ért
            if (vanElo) Console.WriteLine("A bölények nyertek!");
            else Console.WriteLine("A játékos nyert!");


        }
    }
}
