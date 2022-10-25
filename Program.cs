using System.Collections;

namespace _25_10_Prog_Grund
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FirstAssignment();
            //SecondAssignment();
            ThirdAssignment();

        }

        private static void ThirdAssignment()
        {
            PhotoBook book1 = new PhotoBook();
            Console.WriteLine("Book 1: "+ book1.GetNumberOfPages());
            PhotoBook book2 = new PhotoBook(24);
            Console.WriteLine("Book 2 " + book2.GetNumberOfPages());
            BigPhotoBook bigBook = new BigPhotoBook();
            Console.WriteLine("Big Photo Book " + bigBook.GetNumberOfPages());
        }

        public class PhotoBook
        {
            protected int _numPages;

            public PhotoBook()
            {
                _numPages = 16;
            }

            public PhotoBook(int numPages)
            {
                _numPages = numPages;
            }

            public int GetNumberOfPages() => _numPages;
        }

        public class BigPhotoBook : PhotoBook
        {
            public BigPhotoBook()
            {
                _numPages = 64;
            }
        }

        private static void SecondAssignment()
        {
            ArrayList peopleArrayList = new ArrayList();

            //Input
            for (int index = 0; index < 3; index++)
            {
                Console.Write("Enter a Name: ");
                string name = Console.ReadLine() ?? "";
                Console.Write("Enter an Age: ");
                int age = int.Parse(Console.ReadLine() ?? "10");
                peopleArrayList.Add(new Person(name, age));
            }

            PrintList();

            void PrintList()
            {
                foreach (object o in peopleArrayList)
                {
                    //Method 1, override ToString
                    Console.WriteLine(o.ToString());

                    //Method 2, unboxing
                    if(o is Person person)
                        Console.WriteLine("Unbox Version: " + person.ToReadable());

                    //Method 3, old unboxing
                    if (o.GetType() == typeof(Person))
                    {
                        Person unbox = (Person)o;
                        Console.WriteLine("Old Unbox Version: " + unbox.ToReadable());
                    }

                }
            }

        }

        //I forgot about this but we can actually do private classes as long as they are nested inside another class
        private class Person
        {
            private string _name;
            private int _age;

            public Person(string name, int age)
            {
                _name = name;
                _age = age;
            }

            public override string ToString()
            {
                return $"{_name}, {_age}";
            }

            public string ToReadable()
            {
                return $"{_name}, {_age}";
            }
        }


        public static void FirstAssignment()
        {
            List<bok> books = new List<bok>();
            //6 books because why not
            for (int index = 0; index < 6; index++)
            {
                Console.Write("Title: ");
                string title = Console.ReadLine() ?? "";
                Console.Write("Publication Year: ");
                int pubYear = int.Parse(Console.ReadLine() ?? "1980");
                Console.Write("Page Count: ");
                int pageCount = int.Parse(Console.ReadLine() ?? "10");
                books.Add(new bok(title, pageCount, pubYear));


                //Sorting by linq cause it's a lot easier to read than the .Sort method imo
                books = books.OrderByDescending(n => n.PublicationYear).ToList();
                PrintList();
            }


            Console.WriteLine("Final Print");
            PrintList();

            void PrintList()
            {
                //Sorting via Linq cause it's a ton clearer than the Sort Method
                foreach (bok book in books)
                {
                    Console.WriteLine($"{book.Title}, {book.PublicationYear}, {book.NumberOfPages}");
                }
            }
        }

        public class bok
        {
            private string _title;
            private int _numberOfPages;
            private int _publicationYear;

            public bok(string title, int numberOfPages, int publicationYear)
            {
                _title = title;
                _numberOfPages = numberOfPages;
                _publicationYear = publicationYear;
            }

            public string Title => _title;
            public int NumberOfPages => _numberOfPages;
            public int PublicationYear => _publicationYear;

        }
    }

    
}