using ObserverLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект фондовой биржи  
            Stock stock = new Stock(200, "DDF");
            //Создаем объекты наблюдателей 
            Investor investor1 = new Investor("Иван");
            Investor investor2 = new Investor("Вика");
            //Добавляем к объекту двух наблюдателей
            stock.AddObserver(investor1);
            stock.AddObserver(investor2);

            stock.UpdatePrice(1032.0);
            stock.UpdatePrice(232);
            stock.UpdatePrice(9323);

            Console.ReadLine();

        }
    }
}
