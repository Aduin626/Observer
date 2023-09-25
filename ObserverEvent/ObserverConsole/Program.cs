using System;
using ObserverLib;
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

            //Создание двух объектов класса 'Stock' с разными исходными значениями стоимости акций
            Stock logi = new Stock("LOGI", 102);
            Stock fohj = new Stock("FOHJ", 120);
            //Создание объекта-наблюдателя
            Observer observer = new Observer();
            //Регистрация наблюдателя для события 'PriceChanged' каждого объекта 'Stock'
            logi.PriceChanged += observer.OnPriceChanged;
            fohj.PriceChanged += observer.OnPriceChanged;

            logi.Price = 2324;
            fohj.Price = 501;

            Console.ReadLine();
        }
    }
}
