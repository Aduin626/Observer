using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLib
{

    // Класс Stock наследует класс Observable (не виден в предоставленном коде),
    // который  предоставляет методы для добавления, удаления и оповещения наблюдателей.
    public class Stock : Observable
    {
        private double _price;        // Поле для хранения цены акции.

        // Свойство Symbol только для чтения. Внешние пользователи этого класса не могут изменить символ акции после его создания;
        // символ акции можно установить только при инициализации экземпляра класса.
        public string _symbol { get; private set; }


        // Свойство Price содержит методы get и set для чтения и изменения цены акции соответственно.
        public double Price
        {
            get { return _price; }
            set
            {
                // При изменении значения цены акции вызывается метод Notify(),
                // который оповещает всех наблюдателей об изменении цены.
                _price = value;
                Notify();
            }
        }



        // Конструктор класса Stock, принимающий символ и начальную цену акции.
        public Stock(string symbol, double price)
        {
            _symbol = symbol;
            _price = price;
        }
    }

}
