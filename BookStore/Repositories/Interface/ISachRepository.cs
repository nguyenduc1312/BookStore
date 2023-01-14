using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.Interface
{
    interface ISachRepository
    {
        Task<DataSet> GetAllHomePage();
    }
}
