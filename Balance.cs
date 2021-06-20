using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBank
{
    class Balance
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;
        public int Sum { get;  set; }

        public void Put(int sum)
        {
            Sum += sum;
            Notify.Invoke($"На счет поступило: {sum} | Текущий баланс : {Sum}");   
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета снято: {sum} | Текущий баланс : {Sum}");  
            }
            else
            {
                Notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}"); ;
            }
        }

    }
}
