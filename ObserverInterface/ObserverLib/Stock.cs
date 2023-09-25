using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLib
{
   
        //класс для фондовой биржи, который  реализовывает интерфейс IObservable


        //В этом классе мы храним список наблюдателей и информацию о текущей цене.
        //Методы AddObserver, RemoveObserver и NotifyObservers соответствуют методам, определенным в интерфейсе IObservable.
        //Метод UpdatePrice используется для обновления информации о цене и вызывает метод NotifyObservers для оповещения наблюдателей.
        public class Stock : IObservable
        {
            private List<IObserver> observers = new List<IObserver>();
            private double price;
            public string burse { get; private set; }

            public Stock(double price, string burse)
            {
                this.price = price;
                this.burse = burse;
            }

            public void AddObserver(IObserver observer)
            {
                observers.Add(observer);
            }
            public void RemoveObserver(IObserver observer)
            {
                observers.Remove(observer);
            }
            public void NotifyObservers()
            {
                foreach (IObserver observer in observers)
                {
                    observer.Update(price, burse);
                }
            }

            public void UpdatePrice(double newPrice)
            {
                price = newPrice;
                NotifyObservers();
            }


        }
    

}
