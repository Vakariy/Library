using System;
using System.Collections.Generic;
using System.Text;

namespace Library.V2
{
    class Program
    {
        //глобальная база хранения в программе
         
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            List<Book> db_library = new List<Book>();
            Menu menu = new Menu(db_library);
            menu.Start();
            //Мотор программы
            while (true)
            {
                menu.PanelManager();
            }



            

        }
    }
}
