


namespace scufiBirds.Models
{
    public class Class1
    {
        private int birdPlaceFromLeft;

        private int[] map;

        private int birdPosition;

        private bool isAlive;

        private bool jump;

        private int tick;

        public Class1(int start)
        {
            birdPosition = start;
            birdPlaceFromLeft = 5;
            map = new int[17];
            isAlive = true;
            jump = true;
            tick = 0;
        }


        private void spawnPipe()
        {
            if (tick % 5 == 0)
            {
                Random rnd = new Random();
                map[map.Length - 1] = rnd.Next(7);
            }

        }

        private void movePipes()
        {
            for (int i = 1; i < map.Length; i++)
            {
                map[i - 1] = map[i];
            }
            map[map.Length - 1] = -1;
        }

        public void startGame()
        {
            for (int i = 0; i < map.Length; i++)
            {
                map[i] = -1;
            }

            // Lag en knapp som setter jump til true



            //

            nextTick();
        }

        private void checkIfBirdIsAlive()
        {
            if (birdPosition == -1) { isAlive = false; };

            if (map[birdPlaceFromLeft] != -1)
            {
                switch (map[birdPlaceFromLeft] - birdPosition)
                {
                    case 0:
                        break;
                    case -1:
                        break;
                    case -2:
                        break;
                    default:
                        isAlive = false;
                        break;
                }
            }
        }

        public string renderPipe(int tallEn, int tallTo)
        {
            if (tallEn == tallTo) return " ";
            if (tallEn == tallTo - 1) return " ";
            if (tallEn == tallTo - 2) return " ";
            return "H";
        }

        private void printGame()
        {
            //Stopp tilbake NÅ

            string[] brettOppNed = new string[10];

            Console.Clear();
            Console.WriteLine(tick);
            string line = "";
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < map.Length; i++)
                {
                    if (i == birdPlaceFromLeft && birdPosition == j) line += "0";
                    else if (map[i] == -1) line += " ";
                    else
                    {
                        line += renderPipe(map[i], j);
                    }
                }
                brettOppNed[j] = line;
                line = "";
            }

            for (int i = brettOppNed.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(brettOppNed[i]);
            }
            Console.WriteLine("PPPPPPPPPPPPPPPPP");
        }

        private void birdJumpQuestionMarke()
        {
            if (jump) birdPosition += 2;

            birdPosition--;
        }

        private void nextTick()
        {
            jump = false;


            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {

                    jump = true;
                }
                else
                {
                    jump = false;
                }
            };

            birdJumpQuestionMarke();

            checkIfBirdIsAlive();

            movePipes();

            spawnPipe();

            printGame();

            tick++;

            if (isAlive)
            {
                Thread.Sleep(500);
                nextTick();
            }
            else Console.WriteLine("Du døde XD");

        }

        public void GetUserInput()
        {
            string kake = Console.ReadLine();
            if (kake == "Ok")
            {
                //Gjør ting
            }
            else
            {
                GetUserInput();
            }
        }

    }
}
