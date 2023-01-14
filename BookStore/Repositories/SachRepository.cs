using BookStore.Models;
using BookStore.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookStore.Repositories
{
    public class SachRepository : ISachRepository
    {
        private readonly BookStoreDBContext _context;

        public SachRepository()
        {
            _context = new BookStoreDBContext();
        }
        public async Task<DataSet> GetAllHomePage()
        {
            DataSet returnData = await _context.ExecuteQuery("EXEC QRY_GetAllHomePage");
            return returnData;
        }
    }
}