using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLib
{
    //Интерфейс IObservable, который  используется объектом(фондовой биржей). Он  содержит методы для добавления и удаления наблюдателей
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
}
