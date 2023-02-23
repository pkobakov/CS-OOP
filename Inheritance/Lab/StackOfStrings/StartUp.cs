namespace CustomStack
{
    public class StartUp
    {
        public static void Main (string[] args)
        {

            StackOfStrings stack = new StackOfStrings ();

            Console.WriteLine(stack.IsEmpty());

            var list = new List<string>() {"C#", "Love", "I"};

            stack.AddRange (list);

            Console.WriteLine(stack.IsEmpty());

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}