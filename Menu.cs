using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.V2
{

    class Menu
    {
        //объявление базы для хранения
        public List<Book> db_library;
       
        public Menu(List<Book> db_library)
        {
            this.db_library = db_library;
        }


        public void Start()
        {
            db_library.Add(new Book("Harry Potter and the prisoner of Azkaban", "Joanne Rowling"));
            db_library.Add(new Book("Programming", "Tkachenko O.M."));
            db_library.Add(new Book("Harry Potter and the secret room", "Joanne Rowling"));
            db_library.Add(new Book("Witcher", "Andrzej Sapkowski"));
            db_library.Add(new Book("Sergey Yesenin. Collected works in one book", "Sergey Yesenin"));
        }
        //метод для вывода книг
        public void ShowCatalogOfLibrary(List<Book> db_library)
        {
            foreach (Book book in db_library)
            {
                Console.WriteLine("Summary: " + book.Summary + " | author: " + book.Author);
            }
            Console.WriteLine();
            Console.WriteLine("System: Click Enter for continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //метод добавления книги
        public void AddBookInDateBase()
        {
            Console.WriteLine("Adding a book");
            Console.Write("Input title of book: ");
            string summary = Console.ReadLine();
            Console.Write("Input author of book: ");
            string author = Console.ReadLine();
            db_library.Add(new Book(summary, author));
            Console.WriteLine("The book has been added");
            Console.WriteLine("System: Click Enter for continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Метод удаления книги
        public void DeleteOfBookFromDB(string summary, List<Book> db_library)
        {
            foreach (Book book in db_library.Where(b => b.Summary == summary))
            {
                Console.WriteLine(book.Summary + " " + book.Author);
                bool flag = db_library.Remove(book);
                if (flag)
                {
                    Console.WriteLine("System: The book has been deleted");
                    Console.WriteLine("System: Click Enter for continue...");
                    Console.ReadKey();
                }
                else Console.WriteLine("System: not found...");
                Console.WriteLine("System: Click Enter for continue...");
                Console.ReadKey();
                Console.Clear();
                break;
            }
        }

        //Сортировка каталога книг по названию
        public void SortNameCatalog()
        {
            var sortedUsers = from tmp in db_library
                              orderby tmp.Summary
                              select tmp;

            foreach (Book u in sortedUsers)
                Console.WriteLine(u.Summary + " " + u.Author);

            Console.WriteLine("System: Click Enter for continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Сортировка каталога книг по автору
        public void SortForAuthor()
        {
            var sortedUsers = from tmp in db_library
                              orderby tmp.Author
                              select tmp;

            foreach (Book u in sortedUsers)
                Console.WriteLine(u.Summary + " " + u.Author);

            Console.WriteLine("System: Click Enter for continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Поиск книги по автору
        public void SearchForAuthor()
        {
            Console.Write("Input author for finding: ");
            string choiceAuthor = Console.ReadLine();
            var sortedUsers = from tmp in db_library
                              orderby tmp.Author
                              select tmp;

            foreach (Book u in sortedUsers)
            {
                if (u.Author == choiceAuthor)
                {
                    Console.WriteLine(u.Summary + " " + u.Author);
                }
            }

            Console.WriteLine("System: Click Enter for continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Поиск книги по названию или автору
        public static void SearchOfBook(List<Book> db_library)
        {

            Console.Write("Input title or author for finding: ");
            string inputRequest = Console.ReadLine();



            foreach (Book book in db_library)
            {
                if (book.Summary.Contains(inputRequest) || book.Author.Contains(inputRequest))
                {
                    Console.WriteLine(book.Summary, book.Author);
                }
            }

            Console.WriteLine("System: Click Enter for continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Ввод ФИО человека который берет книгу на прокат и количество дней
        public static void SetBookRental(List<Book> db_library)
        {
            int id = 0;
            int inputLog = 0;
            int amountDays = 0;
            foreach (Book book in db_library)
            {
                Console.Write(id + " ");
                Console.WriteLine(book.Summary, book.Author);
                id++;
            }
            Console.WriteLine();
            for (; ; )
            {
                do
                {
                    Console.Write("Input index of book for give away it for person: ");
                } while (!int.TryParse(Console.ReadLine(), out inputLog));

                if (inputLog >= 0 && inputLog < id)
                {
                    break;
                }
            }

            for (; ; )
            {
                do
                {
                    Console.WriteLine("Max time for rent is 100 days: ");
                    Console.Write("Write amount days for rent of book: ");


                } while (!int.TryParse(Console.ReadLine(), out amountDays));

                if (amountDays > 0 && amountDays <= 100)
                {
                    break;
                }
            }
            
            
            db_library[inputLog].LogOfTime += amountDays;

            Console.WriteLine("Input name of person for rent");
            string person = Console.ReadLine();
            db_library[inputLog].LastPerson = person;
            Console.WriteLine("System: Click Enter for continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Получение информации книги о последней человеке взявшего ее в прокат и суммарное количество дней кнги в прокате
        public static void GetBookRental(List<Book> db_library)
        {
            int id = 0;
            int inputLog = 0;
            foreach (Book book in db_library)
            {
                Console.Write(id + " ");
                Console.WriteLine(book.Summary, book.Author);
                id++;
            }
            Console.WriteLine();
            do
            {
                Console.Write("Input index of book for show rent history: ");
            } while (!int.TryParse(Console.ReadLine(), out inputLog) && (inputLog < -1 || inputLog > id));
            Console.WriteLine("Summary of book: " + db_library[inputLog].Summary + "was rent - " + db_library[inputLog].LogOfTime + " days.");
            Console.WriteLine("Last person whick took rented a book - " + db_library[inputLog].LastPerson);
            Console.WriteLine("System: Click Enter for continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //Выход из программы
        public void ExitFromProgram()
        {
            Environment.Exit(0); 
        }


        //Панель администратора
        public void PanelManager()
        {
            int input;
            do
            {
                Console.WriteLine(@"System: ");
                Console.WriteLine(@"1 - Add a new book in library");
                Console.WriteLine(@"2 - Delete a book from library");
                Console.WriteLine(@"3 - Show a catalog of book");
                Console.WriteLine(@"4 - Sort catalog by title");
                Console.WriteLine(@"5 - Sort catalog by author");
                Console.WriteLine(@"6 - Find a book by title or author");
                Console.WriteLine(@"7 - Rent a book");
                Console.WriteLine(@"8 - Rent history of a book");
                Console.WriteLine(@"9 - Exit");
                Console.Write("Admin: ");
            } while (!int.TryParse(Console.ReadLine(), out input)); //добавить валидный ввод

            switch (input)
            {
                case 1:
                    AddBookInDateBase();
                    break;

                case 2:
                    Console.WriteLine("Delete of book");
                    Console.Write("Summary of book: ");
                    string summary = Console.ReadLine();
                    DeleteOfBookFromDB(summary, db_library);
                    break;
                case 3:
                    Console.WriteLine("Catalog of books: ");
                    ShowCatalogOfLibrary(db_library);
                    break;
                case 4:
                    SortNameCatalog();
                    break;
                case 5:
                    SearchForAuthor();
                    break;
                case 6:
                    SearchOfBook(db_library);
                    break;
                case 7:
                    SetBookRental(db_library);
                    break;
                case 8:
                    GetBookRental(db_library);
                    break;
                case 9:
                    ExitFromProgram();
                    break;
            }
        }
    }
}
