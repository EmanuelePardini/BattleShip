using System;

namespace BattagliaNavale
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Char match = 'y';
                while (true)
                {
                    
                    if (match == 'y')
                    {
                        Partita();
                    }
                    else
                    {
                        continue;
                    }

                    Console.WriteLine("Digita y per rigiocare o un altro pulsante per uscire");
                    match = Convert.ToChar(Console.ReadLine());
                }
            }
             catch (Exception ex)
            {
                Console.WriteLine("Errore generico" + ex);
            }
            finally
            {
                Console.WriteLine("Sto rilasciando eventuali risorse...");
            }

        }
        static void Riempiarray(string[,] player)
        {
            int pos1x, pos1y, pos2x, pos2y;
            pos1x = Convert.ToInt32(Console.ReadLine());
            pos1y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nave posizionata");
            pos2x = Convert.ToInt32(Console.ReadLine());
            pos2y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Posizionamento completato");
                while(pos1x == pos2x && pos1y == pos2y)
                {
                    Console.WriteLine("Posizione occupata, riprovare: ");
                    pos2x = Convert.ToInt32(Console.ReadLine());
                    pos2y = Convert.ToInt32(Console.ReadLine());
                }
            for (int i=0; i<7;i++)
            {
                for (int j = 0; j < 7; j++)
                {

                        player[i, j] = "Acqua";
                }
            }

            player[pos1x, pos1y] = "Colpito";
            player[pos2x, pos2y] = "Colpito";

            Console.Clear();
        }
        static int Attacco(string[,] enemy, int punteggio)
        {
           int  posx = Convert.ToInt32(Console.ReadLine());
           int posy = Convert.ToInt32(Console.ReadLine());
            if (enemy[posx, posy] == "Colpito")
            {
                punteggio++;
                Console.WriteLine(enemy[posx, posy]);
                enemy[posx, posy] = "Acqua";
            }
            else
            {
                Console.WriteLine("Acqua");
            }
            return punteggio;
        }

        static void Partita()
        {
            string[,] p1 = new string[7, 7];
            string[,] p2 = new string[7, 7];
            int punteggiop1 = 0, punteggiop2 = 0;
            Console.WriteLine("Giocatore 1: Definire coordinate x e y delle 2 navi");
            Riempiarray(p1);
            Console.WriteLine("Giocatore 2: Definire coordinate x e y delle 2 navi");
            Riempiarray(p2);
            while (true)
            {
                Console.WriteLine("Giocatore 1: Definire coordinate di attacco");
               punteggiop1= Attacco(p2, punteggiop1);
                Console.WriteLine("Punteggio: "+punteggiop1);
                if (punteggiop1 == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Giocatore 1: Vittoria");
                    Console.WriteLine("Giocatore 2: Sconfitta");
                    break;
                }
                Console.WriteLine("Giocatore 2: Definire coordinate di attacco");
               punteggiop2= Attacco(p1, punteggiop2);
                Console.WriteLine("Punteggio: " + punteggiop2);

                if (punteggiop2 == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Giocatore 2: Vittoria");
                    Console.WriteLine("Giocatore 1: Sconfitta");
                    break;
                }
            }
           

        }
    }
}
