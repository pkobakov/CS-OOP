namespace Demo
{
	using System;
	public class Program
	{
		public static void Main(string[] args)
		{
			try
			{
			    var student1 = new Student("Gosho", 43);
			    var student2 = new Student("Ivan", 17);
			    var course = new Course("OOP with C#");
				course.AddStudent(student1);
                Console.WriteLine(student1);
				Console.WriteLine(course);
                course.AddStudent(student2);
                Console.WriteLine(student2);
                Console.WriteLine(course);
                Console.WriteLine($"Total students count {course.Students.Count}");

            }
			catch (Exception e)
			{

                Console.WriteLine(e.Message);
            }

			

		}
	}
}
