using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesEjercicioPrueba.Repository
{
    public static class DepartamentoRepository
    {
        public static bool GuardarDepartamento(Departamento departamento)
        {
            using var context = new ApplicationDbContext();


            bool existe = context.Departamentos.Any(e => e.Nombre == departamento.Nombre);

            if (existe)
            {
                return false;
            }

            context.Departamentos.Add(departamento);
            context.SaveChanges();
            return true;
        }


    }
}
