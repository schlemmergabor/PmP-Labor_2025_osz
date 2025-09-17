namespace L01_utasitasok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat

            // kiírás
            Console.WriteLine("Hello World!");

            // beolvasás
            Console.ReadLine();

            // Console.WriteLine(); <- kiírás után új sor
            // Console.Write(); <- kiírás után nincs új sor

            ////////////////////////////////////////////////

            // 2. feladat

            // letörli a Console-t
            Console.Clear();

            // beállítja a Console magasságát
            Console.WindowHeight = 5;

            // beállítja a Console szélességét
            Console.WindowWidth = 30;

            // beállítja a Console háttérszínét - fehérre
            // enum-ok közül tudunk választani (felsorolás típus)
            Console.BackgroundColor = ConsoleColor.White;

            // beállítja a Console írószínét - feketére
            Console.ForegroundColor = ConsoleColor.Black;

            // A kurzort a 2, 3 poz-ba állítja (left, top)
            Console.SetCursorPosition(2, 3);

            // A kurzor láthatóságát állítja
            // default: true (látható) | false (nem látható)
            Console.CursorVisible = false;

            // visszaállítjuk a Console színeit, előző beállításait
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = true;
            Console.SetWindowSize(80, 25);

            // utasítások, parancsok mögött () jel van
            // ezzel történik az utasítás meghívása, futtatása
            // tulajdonságok, propertyk mögött nincs () jel
            // mintha változó lenne, = jellel értéket adunk neki

            // 3. feladat

            // kiírjuk a "tájékoztató" üzenetet
            Console.Write("Kérem a neved: ");

            // string (szöveg) típusú változót csinálunk 
            // a változó neve inputName lesz
            // és beolvassuk amit beír a felhasználó beírt
            string inputName = Console.ReadLine();

            // kiírjuk a szöveget, figyelj a $ -re !!!
            Console.WriteLine($"Szia kedves {inputName}!");

            // 4. feladat

            Console.Write("Születési éved: ");
            
            // egész számként olvassuk be
            // int.Parse()-al átalakítjuk
            // Convert.ToInt64 -et is használhatsz
            int inputYear = int.Parse(Console.ReadLine());

            int year = 2025 - inputYear;
            // int year = DateTime.Now.Year - inputYear;
            // ez a fenti kód minden évben jól fog működni, mert
            // DateTime.Now.Year   -> ez a mostani évet jelenti

            Console.WriteLine("Korod: {0}", year);
            Console.WriteLine($"Jövőre {year + 1} éves leszel.");

            // 5. feladat

            // ennél a feladatnál emlékezz arra, hogy mi történt
            // ha rosszul írta be a felhasználó a tizedespontot
            Console.Write("Testmagasság [m]: ");

            // lebegőpontos (tört) számot olvasunk be
            // ezért kell a double.Parse()
            double h = double.Parse(Console.ReadLine());

            Console.Write("Testtömeg [kg]: ");
            double m = double.Parse(Console.ReadLine());

            // Math.Pow -> Power -> hatványozás
            double bmi = m / Math.Pow(h,2);

            Console.WriteLine($"A BMI értéke: {bmi}");

            // 6. feladat
            Console.Write("Az időtartam másodpercben: ");
            
            int sec = int.Parse(Console.ReadLine());
            
            // egész osztás int/int
            // levágja a tizedesjegyeket
            int outMin = sec / 60;
            
            // maradékos osztás
            // elosztja és megmondja mennyi maradt
            int outSec = sec % 60; 
            
            // változó utáni :00, két helyiértéket használjon
            Console.WriteLine($"Az időtartam formázva: {outMin}:{outSec:00}");

            // 7. feladat
            Console.Write("Jelszó1: ");
            string pwA = Console.ReadLine();
            Console.Write("Jelszó2: ");
            string pwB = Console.ReadLine();

            if (pwA == pwB) // jelszoA == jelszoB
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("Beléphet.");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Belépés M E G T A G A D V A ! ! !");
            }

            // visszaállítom a Console beállításait
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();

            // 9. feladat
            Console.Write("Add meg az első számot: ");
            int numberA = int.Parse(Console.ReadLine());
            Console.Write("Add meg a második számot: ");
            int numberB = int.Parse(Console.ReadLine());
            Console.Write("Add meg a műveletet: ");
            string op = Console.ReadLine();

            int result = 0;

            // itt switch -et használtam, nézd át azt is!
            if (op == "+") result = numberA + numberB;
            if (op == "-") result = numberA - numberB;
            if (op == "/") result = numberA / numberB;
            if (op == "*") result = numberA * numberB;

            Console.WriteLine($"{numberA} {op} {numberB} = {result}");

            // szürkével jelzett feladatok -> önálló gyakorlásra
            // sárgával jelzett feladatok -> advanced feladatok :)
        }
    }
}
