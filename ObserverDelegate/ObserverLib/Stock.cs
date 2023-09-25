using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLib
{
    //Класс Stock предстваляет акции на фондовой бирже
    public class Stock
    {

        private readonly string _symbol; //символ акции на бирже(частный, только для чтения);
        private double _price; //текущая цена акции (частная переменная).

        public Stock(string symbol, double price)
        {

            _symbol = symbol;
            _price = price;
        }

        //Свойство Price предоставляет доступ к переменной _price.
        //Когда значение _price изменяется, вызывается метод Notify().
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }

        //Событие PriceChanged создается c использованием делегата Action<double, string>, 
        //который принимает два параметра: новую цену(double) и символ акции(string).
        public event Action<double, string> PriceChanged;


        //Метод Notify() вызывает событие PriceChanged, 
        //которое проксирует параметры _price и _symbol к подписанным методам-обработчикам.
        private void Notify()
        {
            PriceChanged?.Invoke(_price, _symbol);
        }

    }
}
