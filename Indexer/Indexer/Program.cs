using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    interface IContainer
    {
        string this[int i] { get; set; }
        int this[string name] { get; }
    }

    class Bookshelf : IContainer
    {
        private string[] books = new string[10];//my bookshelf can only hold 10 books

        public string this[int i]//put or get my book from a specified lattice
        {
            get
            {
                if (i >= 0 && i <= 9)
                {
                    return books[i] == null ? "--empty--" : books[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i <= 9)
                {
                    books[i] = value;//book will be replaced
                }
            }
        }

        public int this[string name]//get where my book stored
        {
            get
            {
                for (int i = 0; i < 10; i++)
                {
                    if (books[i] == name)
                    {
                        return i;
                    }
                }
                return -1;//book not found
            }
        }

        public string Overview()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                stringBuilder.Append("lattice " + i.ToString() + " : " + ((books[i] == null) ? "--empty--" : books[i]) + "\n");
            }
            return stringBuilder.ToString();
        }
    }

    class SwitchConsole
    {
        private bool A1, A2, A3;
        private bool B1, B2, B3;
        private bool C1, C2, C3;

        public bool this[string index]
        {
            get
            {
                bool result = false;
                switch (index)
                {
                    case "A1":
                        result = A1;
                        break;
                    case "A2":
                        result = A2;
                        break;
                    case "A3":
                        result = A3;
                        break;
                    case "B1":
                        result = B1;
                        break;
                    case "B2":
                        result = B2;
                        break;
                    case "B3":
                        result = B3;
                        break;
                    case "C1":
                        result = C1;
                        break;
                    case "C2":
                        result = C2;
                        break;
                    case "C3":
                        result = C3;
                        break;
                    default:
                        break;
                }
                return result;
            }
            set
            {
                switch (index)
                {
                    case "A1":
                        A1 = value;
                        break;
                    case "A2":
                        A2 = value;
                        break;
                    case "A3":
                        A3 = value;
                        break;
                    case "B1":
                        B1 = value;
                        break;
                    case "B2":
                        B2 = value;
                        break;
                    case "B3":
                        B3 = value;
                        break;
                    case "C1":
                        C1 = value;
                        break;
                    case "C2":
                        C2 = value;
                        break;
                    case "C3":
                        C3 = value;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //empty bookshelf
            Bookshelf bookshelf = new Bookshelf();
            Console.WriteLine(bookshelf.Overview());

            //put some books
            bookshelf[2] = "CLR via C#";
            bookshelf[3] = "C# in depth";
            bookshelf[5] = "Introduction to Algorithms";
            Console.WriteLine(bookshelf.Overview());

            //get book
            Console.WriteLine("lattice 3 : " + bookshelf[3]);
            Console.WriteLine("lattice 7 : " + bookshelf[7]);
            Console.WriteLine("lattice 10 : " + bookshelf[10]);
            Console.WriteLine();

            //replace book
            bookshelf[5] = "Professional C#";
            Console.WriteLine(bookshelf.Overview());

            //find books
            Console.WriteLine("book CLR via C# in lattice " + bookshelf["CLR via C#"]);
            Console.WriteLine("book Introduction to Algorithms in lattice " + bookshelf["Introduction to Algorithms"]);

            //change switch status
            SwitchConsole switchConsole = new SwitchConsole();
            string[] switches = { "A1", "B2", "C3" };
            foreach (var item in switches)
            {
                switchConsole[item] = !switchConsole[item];
            }
        }
    }
}