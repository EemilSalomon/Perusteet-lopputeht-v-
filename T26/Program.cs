using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T25
{
    class Program
    {
        private static bool VarmennaKortti ()
        {
            bool cardverified = true;

            Console.WriteLine("Syötä kortti");
            Console.ReadKey();
            return cardverified;
        }

        private static void KorttiaEiVarmennettu (bool cardverified)
        {
            if (cardverified == false)
            {
                Console.WriteLine("Korttia ei pystytty varmentamaan");
                PoistaKortti();
            }
        }

        private static void PoistaKortti ()
        {
            Console.WriteLine("\nPoista kortti");
        }

        private static string SyötäPIN()
        {
            string koodi;

            Console.WriteLine("Syötä PIN");
            koodi = Console.ReadLine();

            return koodi;
        }

        private static void PINOnVäärä (string PIN)
        {
            if (PIN != "1234")
            {
                Console.WriteLine("PIN on väärä");
                PoistaKortti();
            }
        }

        private static void TarkistaSaldo()
        {
            string syöte;
            double summa, tilinsaldo;
            tilinsaldo = 443.68;

            Console.WriteLine("Syötä summa, jonka haluat nostaa");
            syöte = Console.ReadLine();
            double.TryParse(syöte, out summa);

            if (summa < tilinsaldo)
            {
                tilinsaldo = tilinsaldo - summa;
                Console.WriteLine("Rahansiirto onnistui");
                Console.WriteLine("\nPoista kortti");

            }

            else
            {
                Console.WriteLine("Rahansiirto ylittäisi tilin saldon");
                PoistaKortti();
            }
        }

        private static void SaldoYlitetty (double summa, double tilinsaldo)
        {
            if (summa > tilinsaldo)
            {
                Console.WriteLine("Rahansiirto ylittäisi tilin saldon");
                PoistaKortti();
            }
        }
        static void Main(string[] args)
        {
            string PIN;
            bool cardverified;

            cardverified = VarmennaKortti();

            if (cardverified == true)
            {
                PIN = SyötäPIN();

                if (PIN == "1234")
                {
                    TarkistaSaldo();
                }

                PINOnVäärä(PIN);
            }

            KorttiaEiVarmennettu(cardverified);

            Console.ReadKey();
        }
    }
}
