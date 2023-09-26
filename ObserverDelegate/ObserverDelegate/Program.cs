using System;
using ObserverLib;


namespace ObserverDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        
       {
            //Метод который выводит информацию о том что цена акций изменилась
            void OnPriceChanged(double price , string symbol)
            {
                Console.WriteLine($"Цена акций биржи {symbol} изменена: {price}");
            }

            //Объект stock со значениями акций и начальной ценой 100
            var stock = new Stock("AABL", 100.0);

            //Обработчик событий OnPriceChanged подписывается на событие PriceChanged объекта stock.
            stock.PriceChanged += new Action<double,string>(OnPriceChanged);

            stock.Price = 107.0;
            
            Console.ReadLine();
        }
    }
}
