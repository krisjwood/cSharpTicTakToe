namespace HelloWorld;

class Program
{
    static char[] spaces = new char[] {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
    static int player = 1;
    static int choice;
    static int flag = 0;

    static void DrawTable() {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", spaces[0], spaces[1], spaces[2]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", spaces[3], spaces[4], spaces[5]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", spaces[6], spaces[7], spaces[8]);
        Console.WriteLine("     |     |      ");
    }

    static int CheckWin() {
        if (spaces[0] == spaces[1] && spaces[1] == spaces[2] || spaces[3] == spaces[4] && spaces[4] == spaces[5] || spaces[6] == spaces[7] && spaces[7] == spaces[8] || spaces[0] == spaces[3] && spaces[3] == spaces[6] || spaces[1] == spaces[4] && spaces[4] == spaces[7] || spaces[2] == spaces[5] && spaces[5] == spaces[8] || spaces[0] == spaces[4] && spaces[4] == spaces[8] || spaces[2] == spaces[4] && spaces[4] == spaces[6]) {
            return 1;
        } else if (spaces[0] != '1' && spaces[1] != '2' && spaces[2] != '3' && spaces[3] != '4' && spaces[4] != '5' && spaces[5] != '6' && spaces[6] != '7' && spaces[7] != '8' && spaces[8] != '9') {
            return -1;
        } else {
            return 0;
        }
    }

    public enum IPlayer { X = 'X', O = 'O' };

    static void Draw(int pos, IPlayer player) {
        spaces[pos] = (char)player;
    }

    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Player1: X and Player2: O");
            if(player % 2 == 0)
            {
                Console.WriteLine("Turn Player 2");
            }
            else
            {
                Console.WriteLine("Turn Player 1");
            }
            Console.WriteLine("\n");
            DrawTable();
            choice = int.Parse(Console.ReadLine()) - 1;

            if(spaces[choice] != 'X' && spaces[choice] != 'O')
            {
                if(player % 2 == 0)
                {
                    Draw(choice, IPlayer.O);
                }
                else
                {
                    Draw(choice, IPlayer.X);
                }
                player++;
            }
            else
            {
                Console.WriteLine("Sorry the row {0} is already marked with an {1}", choice + 1, spaces[choice]);
                Console.WriteLine("\n");
                Console.WriteLine("Please wait 2 second board is loading again...");
                Thread.Sleep(2000);
            }
            flag = CheckWin();
        } while (flag != 1 && flag != -1);

        Console.Clear();
        DrawTable();

        if(flag == 1)
        {
            Console.WriteLine("Player {0} has won", (player % 2) + 1);
        }
        else
        {
            Console.WriteLine("Draw");
        }
    }
}