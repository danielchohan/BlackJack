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
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Invalid)
        }
    }
}
