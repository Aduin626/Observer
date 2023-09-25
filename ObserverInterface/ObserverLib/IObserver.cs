using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLib
{

    //Интерфейс IObserver, который будет использоваться наблюдателями(инвесторами). Он  содержит метод для обновления информации о изменении цены:
    public interface IObserver
    {
        void Update(double price, string burse);
    }
}

