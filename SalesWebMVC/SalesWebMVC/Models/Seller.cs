using System;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMVC.Models
{
    public class Seller
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime birthDate { get; set; }
        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; } //garante que quando preencher o formulario
                                              // preenchar o departamento, devido não aceita objetos nulos.

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            this.birthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;

        }


        public void Addsales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

       
    }
}
