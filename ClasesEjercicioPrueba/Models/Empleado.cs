using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesEjercicioPrueba.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public List<Departamento> Departamentos { get; set; }
        public decimal Salario { get; set; }

        public Empleado(int id, string nombre, string Email, decimal salario)
        {
            Id = id;
            Nombre = nombre;
            this.Email = Email;
            
            Salario = salario;
        }
    }
}
