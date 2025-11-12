using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_OOPfeladatmegoldás
{
    // itt hoztuk létre a saját felsorolás típust
    // itt a namespace és az első class között látszódni fog az egész projektedben

    // Position lesz az enum neve (vagy típusa)
    enum Position
    {
        // ezek az enum egyes értékei, ezek közül lehet választani
        Goalkeeper, Forward, Winger, Defender
    }
    internal class Player
    {
        // adattagok, mezők, belső változók
        string name;
        Position pos;

        // ctor
        public Player(string name, Position pos)
        {
            this.name = name;
            this.pos = pos;
        }

        // Proprety
        // feladat nem írta elő, de kelleni fog
        // lekérdezni, hogy a játékos milyen poszton játszik
        public Position Pos { get => pos; }

        // ToString() felüldefiniálása
        // ha az elkészült objektumot berakod egy Console.WriteLine()-ba akkor
        // ez fog meghívódni és kiírja a játékos nevét és posztját
        public override string? ToString()
        {
            return $"{this.name} - {this.pos}";
        }

    }
}
