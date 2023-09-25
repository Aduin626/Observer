using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLib
{
    // Определение класса Observer, который служит для отслеживания изменений в объектах типа Stock
    public class Observer
    {

        // Метод OnPriceChanged вызывается при изменении цены акции
        // sender: объект, вызывающий событие (в данном случае объект типа Stock)
        // args: аргументы события
        public void OnPriceChanged(object sender, EventArgs args)
        {
            // Проверяем, является ли отправитель события объектом класса Stock
            if (sender is Stock stock)
            {
                // Выводим информацию об изменении цены акции на экран
                Console.WriteLine($"Предприятие {stock._symbol} цена акций изменена на {stock.Price}");
            }
        }

    }
}
