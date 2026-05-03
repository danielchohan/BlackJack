namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game();
                game.Start();
            }
            catch(Exception Invalid)
        }
    }
}
