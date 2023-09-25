using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLib
{
    // класс для инвесторов, который  реализовывает интерфейс IObserver:
    public class Investor : IObserver
    {
        //В этом классе мы храним имя инвестора и реализуем метод Update для обновления информации о цене.
        private string name;

        public Investor(string name)
        {
            this.name = name;
        }


        public void Update(double price, string burse)
        {
            Console.WriteLine($"Цена акций биржи {burse} была изменена на {price} для {name}");

        }
    }
}