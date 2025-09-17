using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;

namespace ClasesEjercicioPrueba.Repository
{
    public static class EmpleadoRepository
    {
        public static bool GuardarEmpleado(Empleado empleado)
        {
            using var context = new ApplicationDbContext();

            
            bool existe = context.Empleados.Any(e => e.Email == empleado.Email);

            if (existe)
            {
                return false; 
            }

            context.Empleados.Add(empleado);
            context.SaveChanges();
            return true; 
        }

        public static List<Empleado> ObtenerEmpleados()
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.ToList();
        }
        public static Empleado BuscarPorEmail(string email)
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.FirstOrDefault(e => e.Email == email);
        }
        public static bool ActualizarSalario(string email, decimal nuevoSalario)
        {
            using var context = new ApplicationDbContext();
            var empleado = context.Empleados.FirstOrDefault(e => e.Email == email);

            if (empleado == null)
                return false;

            empleado.Salario = nuevoSalario;
            context.Empleados.Update(empleado);
            context.SaveChanges();
            return true;
        }
        public static bool EliminarEmpleado(string email)
        {
            using var context = new ApplicationDbContext();
            var empleado = context.Empleados.FirstOrDefault(e => e.Email == email);

            if (empleado == null)
                return false; 

            context.Empleados.Remove(empleado);
            context.SaveChanges();
            return true; 
        }
    }

}
