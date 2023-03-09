
namespace Shapes
{
	using System;
    using System.Xml;

    public class StartUp
	{
		public static void Main(string[] args)
		{
			Shape rect = new Rectangle(3, 5);
			Shape circle = new Circle(3);

            Console.WriteLine(rect.Draw());
            Console.WriteLine(circle.Draw());
		}
	}
}
