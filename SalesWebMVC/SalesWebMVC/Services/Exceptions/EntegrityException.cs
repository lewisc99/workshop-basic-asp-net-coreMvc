using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services.Exceptions
{
    public class EntegrityException :ApplicationException 
    {
        public EntegrityException(string message):base(message)
        {
            //aqui cria uma excessão personalizada, que enviada la para o seller service
            //metodo remove.
        }
    }
}
