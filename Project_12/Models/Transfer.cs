﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_12.Models
{
    /// <summary>
    /// Класс для перевода средств
    /// </summary>
    public class Transfer : ITransfer<Account, Account>
    {
        /// <summary>
        /// Перевод средств
        /// </summary>
        /// <param name="acc_out">Счёт вывода средств</param>
        /// <param name="acc_in">Счёт пополнения</param>
        /// <param name="sum">Сумма перевода</param>
        public void Post(Account acc_out, Account acc_in, decimal sum)
        {
            if ((decimal)acc_out.Balance >= sum)
            {
                acc_out.Balance = (decimal)acc_out.Balance - sum;
                acc_in.Balance = (decimal)acc_in.Balance + sum;
            }
            else
            {
                MessageBox.Show("Недостаточно средств для перевода!");
            }
        }
    }
}
