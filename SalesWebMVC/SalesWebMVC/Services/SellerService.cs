using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }


        //asyncrona
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
           await _context.SaveChangesAsync(); //nela que acessa o banco de dados
        }

        //sincrona vai rodar o banco de dados e aplicação
        // vai ficar esperando terminar.

        /* public void Insert(Seller obj)
         {

             _context.Add(obj);
             _context.SaveChanges();
         } */
        public async Task<Seller> FindByIdAsync(int id)
        {                                                              //operação que acessa o banco de dados.
            return  await _context.Seller.Include(obj =>obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);

            //method includ it's like join in database, add a foreign key to the table.


        }


        public async Task RemoveAsync(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        /*
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        } */



        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny =  await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotfoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
              await  _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        /*
        public void  Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotfoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
           catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        } */

    }
}
