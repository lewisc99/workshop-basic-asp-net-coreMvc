using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace SalesWebMVC.Models
{
    public class Seller
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60,MinimumLength = 3,ErrorMessage ="{0} size should be between 3 and 60.")]
        public string Name { get; set; }



        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.EmailAddress)] //muda o formato do email
        public string Email { get; set; }



        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //muda o formato da data para brasileiro.
        [Display(Name = "Birth Date ")] //vai alterar la na view a forma que aparece.
        [DataType(DataType.Date)] //aqui altera o data para que aparece de forma que não precisa de preencher as horas.
        public DateTime birthDate { get; set; }



        [Range(100.0, 50000.0,ErrorMessage ="{0} must be from {1} to {2}")]
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Base Salary")] //altera la na view aparecendo Base salary com espaço
        [DisplayFormat(DataFormatString = "{0:F2}")] //para que aparece com 2 casas decimais
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
