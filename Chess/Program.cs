namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Chess chess = new Chess();
            for (var pos = 0; pos < chess.Tabuleiro.Length; pos++)
            {
                Console.Write(chess.Tabuleiro[pos]);
                if ((pos + 1) % 8 == 0)
                {
                    if (pos != 0)
                    {
                        Console.Write("\n");
                    }
                }
            }
        }
    }

    public class Chess
    {
        public string[] Tabuleiro = new string[64];
        public bool player { get; set; }
        public Chess()
        {
            for (var pos = 0; pos < 64; pos++)
            {
                if (pos == 0 || pos == 7)
                {
                    Tabuleiro[pos] = "TW" + "\t";
                }else if (pos == 1 || pos == 6)
                {
                    Tabuleiro[pos] = "CW" + "\t";
                }else if (pos == 2 || pos == 5)
                {
                    Tabuleiro[pos] = "BW" + "\t";
                }else if (pos == 3)
                {
                    Tabuleiro[pos] = "KW" + "\t";
                }else if (pos == 4)
                {
                    Tabuleiro[pos] = "QW" + "\t";
                }else if (pos > 6 && pos <= 15)
                {
                    Tabuleiro[pos] = "PW" + "\t";
                }else if (pos > 15 && pos < 48)
                {
                    Tabuleiro[pos] = "XX" + "\t";
                }else if (pos >= 48 && pos <= 55)
                {
                    Tabuleiro[pos] = "PB" + "\t";;
                }else if (pos == 56 || pos == 63)
                {
                    Tabuleiro[pos] = "TB" + "\t";;
                }else if (pos == 57 || pos == 62)
                {
                    Tabuleiro[pos] = "CB" + "\t";;
                }else if (pos == 58 || pos == 61)
                {
                    Tabuleiro[pos] = "BB" + "\t";;
                }else if (pos == 59)
                {
                    Tabuleiro[pos] = "KB" + "\t";;
                }else if (pos == 60)
                {
                    Tabuleiro[pos] = "QB" + "\t";;
                }
            }
        }
    }
}