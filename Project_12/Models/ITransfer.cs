﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_12.Models;

namespace Project_12.Models
{
    /// <summary>
    /// Контравариантный интерфейс
    /// </summary>
    /// <typeparam name="T1">Тип счёта</typeparam>
    /// <typeparam name="T2">Тип счёта</typeparam>
    public interface ITransfer<in T1, in T2> where T1 : Account where T2 : Account
    {
        public void Post(Account acc_out, Account acc_in, decimal sum);
    }
}
