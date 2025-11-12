using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_OOPfeladatmegoldás
{
    internal class Team
    {
        // adattagok, mezők

        // játékosokat tömbben tároljuk el (ahogy a feladat kérte)
        Player[] players;

        // Property - lehetett volna mező is
        // játékosok aktuális száma
        // tömb indexelésre fogjuk használni
        public int NumberOfPlayers { get; set; }


        // ha játékosok száma == 5 -> true, másik esetben false
        // emlékezz, hogy lehet get; set; része a propertynek
        public bool IsFull { get => this.NumberOfPlayers == 5; }

        // ctor
        public Team()
        {
            // itt hozzuk létre a tömböt !!! FONTOS !!!
            // ha ez kimarad, akkor futtáskor hibát kapsz
            this.players = new Player[5];

            // kezdetben 0 játékosunk van
            this.NumberOfPlayers = 0;
        }

        // Metódusok
        // eldönti, hogy a parameter szerepel-e már a csapatban
        // lásd Eldöntés programozási tétel
        // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf
        // 25. oldal

        public bool IsIncluded(Player pl)
        {
            // tömb indexelés 0-tól indul, jegyzetben 1-től
            // ezért le kell egyet vonni belőle!
            int i = 1 - 1; // 0

            // tömb mérete -> szintén indexelés miatt - 1 !!!
            int n = this.players.Length - 1;

            // ciklus amíg ...
            // ha egy utasítás van a ciklusmagban, akkor elhagyható a { }
            while ( (i <= n) && !(this.players[i] == pl))
                i++;

            bool van = i <= n;

            // vissza van változó értéke
            return van;
        }

        // eldönti, hogy a parameter pozíciója szabad-e
        public bool IsAvailable(Player pl)
        {
            // csapatban a szabad poziciók kezdőszáma
            // 1 kapus, 1 csatár, 2 szélső, 1 védő
            // Enumban is ilyen sorrendben vannak
            // enum -> ból int-et tudunk készíteni (lásd jegyzet!)
            // Goalkeeper, Forward, Winger, Defender
            //      0         1       2        3
            int[] nums = new int[] { 1, 1, 2, 1 };

            // végig nézzük az összes játékost
            // a tömböt csak a játékosok számáig kell nézni, mert
            // lehet, hogy pl. csak 1 játékos van benne
            for (int i = 0; i < this.NumberOfPlayers; i++)
            {
                // az adott játékos posztját számmá alakítjuk
                // a poszt ugye enum, így enum -> int
                // kapus=0, csatár=1, szélső=2, védő=3 lesz
                int pos = (int)this.players[i].Pos;

                // ezzek indexeljük a tömböt
                // maradék szabad helyekből 1-t levonunk
                nums[pos]--;
            }

            // itt a nums tömbben az van benne, hogy menni
            // szabad hely van az egyes pozikon

            // ha a player paraméter Pos -nak megfelelő indexen van még hely...
            if (nums[(int)pl.Pos] > 0) return true;
            else return false;
        }

        //  játékos hozzáadása a csapathoz
        public void Include(Player pl)
        {
            // ha nincs tele a csapat
            // ha nincs még benne
            // ha szabad a posztja
            if (!this.IsFull && !IsIncluded(pl) && IsAvailable(pl))

                // hozzáadjuk a tömbhöz
                // megnöveljük a játékosok számát!
                // emlékezz a post és pre operátor szerepére!
                this.players[this.NumberOfPlayers++] = pl;
        }
    }
}
