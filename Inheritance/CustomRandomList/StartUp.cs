namespace CustomRandomList
{

    public class StartUp
    {
        public static void Main(string[] args)
        {

            RandomList list= new RandomList();
            list.Add("Dimitrichko");
            list.Add("Pesho");
            list.Add("Gosho");


            Console.WriteLine(list.RandomString()); 
        }
    }
}
