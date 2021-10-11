using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

using System.Collections.Generic;
using System.Linq;


namespace SalesWebMVC.Services
{
    public class SellerService
    {
        //readonly para previnir que a propriedade não seja alterada.
        private readonly SalesWebMVCContext _context;


        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        //sincrona vai rodar o banco de dados e aplicação
        // vai ficar esperando terminar.

        public void Insert(Seller obj)
        {
           
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj =>obj.Department).FirstOrDefault(obj => obj.Id == id);

            //method includ it's like join in database, add a foreign key to the table.


        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        
    }
}
