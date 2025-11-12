namespace L08_OOPfeladatmegoldás
{
    internal class Program
    {
        // Random játékosok generálása

        // static jelölő a metódusnál azt jelenti, hogy az osztályhoz kapcsolódik
        // így nem kell példányosítani, nem kell belőle objektumot csinálni, hogy
        // használni (meghívni) lehessen
        // 
        // azaz ezt a metódust így hívjuk meg: Program.RandomPlayers(10);
        // nem pedig úgy, hogy:
        // Program p = new Program(); // példányosítás, objektumkészítés
        // p.RandomPlayers(10); // metódushívás objektumon keresztül static nélkül
        static Player[] RandomPlayers(int a)
        {
            // tömb méretének lefoglalása, ennyi játékos generálunk
            Player[] players = new Player[a];

            Random rnd = new Random();

            // tömb feltöltése, véletlenszerű jétkosokkal
            for (int i = 0; i < players.Length; i++)
            {
                // véletlenszerű játékosnév - 3 betűs
                string nev = "P-" + (char)rnd.Next((int)'A', (int)'Z' + 1) + (char)rnd.Next((int)'A', (int)'Z' + 1); ;

                // Pozi enum-ba, véletlenszerűen
                Position pos = (Position)rnd.Next(0, 4);

                // tömb elemre létrehozás -> itt hívjuk meg a ctor-t, a tömb indexére
                players[i] = new Player(nev, pos);
            }

            // elkészült tömb visszaadása
            return players;
        }

        // Játékosok kiválasztása és csapatba rendelése
        static void ElsoFeladat()
        {
            // kezdő csapat létrehozása (0 elem van benne)
            Team csapat = new Team();

            // választható, véletlen játékosok egy tömbbe
            // itt hívjuk meg a static metódust
            // a Main is static, static-ból csak static-ot tudunk meghívni
            // és nem kell kiírni az osztály nevét (tehát a Program. -ot)
            Player[] valaszthatok = RandomPlayers(15);

            // amíg nincs tele a csapat
            while (!csapat.IsFull)
            {
                Console.WriteLine("Választható játékosok:\n");
                for (int i = 0; i < valaszthatok.Length; i++)
                {
                    Console.WriteLine($"{i} -> {valaszthatok[i]}");
                }
                Console.Write("\nMelyiket adjuk a csapathoz?");
                int index = int.Parse(Console.ReadLine());

                // hozzáadás
                csapat.Include(valaszthatok[index]);
            }
        }
        static void MasodikFeladat()
        {
            // bölényes feladat
            // játéktér méretének bekérése
            Console.Write("N=? ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("M=? ");
            int M = int.Parse(Console.ReadLine());
            
            // játék létrehozása és elindítása
            Game g = new Game(M, N);
            g.Run();

        }
        static void Main(string[] args)
        {
            // teszteléshez használt kód

            // létrehoztunk két játékost
            Player p1 = new Player("Kiraly Gabor", Position.Goalkeeper);
            Player p2 = new Player("Szoboszlai Dominik", Position.Forward);

            Team ftc = new Team();

            bool a = ftc.IsIncluded(p1);
            ftc.Include(p1);
            bool b = ftc.IsIncluded(p1);
            ; // break point ot tettünk ide
            ftc.Include(p2);
            ; // és ide

            // Első Feladat (futsal csapatos)
            ElsoFeladat();

            // Második Feladat (bölényes)
            MasodikFeladat();
        }
    }
}
