using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_14.Models
{
    /// <summary>
    /// Депозитный счёт
    /// </summary>
    public class Deposit : Account, IAccount<Account>
    {
        #region Конструкторы
        public Deposit(object number, object balance) : base(number, balance)
        {
        }
        #endregion

        #region Методы
        public override void ReplenishBalance(decimal sum)
        {
            // За пополнение, бонус 3% для привлечения клиентов
            sum += sum / 100 * 3;
            this.Balance = (decimal)this.Balance + sum;
        }

        #endregion
    }
}
