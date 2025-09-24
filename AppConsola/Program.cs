using ClasesEjercicioPrueba.Models;
using ClasesEjercicioPrueba.Repository;

static void Main(string[] args)
{

    
    while (true)
    {
        Console.Clear();
        Console.WriteLine("--- MENÚ PRINCIPAL ---");
        Console.WriteLine("1 - Registrar nuevo Empleado");
        Console.WriteLine("2 - Actualiza salario de empleado");
        Console.WriteLine("3 - Eliminar empleado");
        Console.WriteLine("4 - Registrar Departamento");
        Console.WriteLine("5 - Mostrar estadisticas");
        Console.WriteLine("6 - Salir");
        Console.WriteLine("Seleccione una opción: ");
        string opcion = Console.ReadLine();
        switch (opcion.Trim())
        {
            case "1":
                Console.Clear();
                Console.WriteLine("Ingrese su nombre");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese su email");
                
                string email = Console.ReadLine();
                Console.WriteLine("Ingrese su salario");
                decimal salario = decimal.Parse(Console.ReadLine());
                if (EmpleadoRepository.GuardarEmpleado(new Empleado(0, nombre, email, salario)))
                {
                    Console.WriteLine("Empleado guardado con exito");
                }
                else
                {
                    Console.WriteLine("El email ya existe en la base de datos");
                }
                Console.WriteLine("Para volver al menu principal presione una tecla");
                Console.ReadKey();
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("Ingrese el email del empleado al que desea actualizar el salario");
                string emailActualizar = Console.ReadLine();
                while (true)
                {
                    var empleado = EmpleadoRepository.BuscarPorEmail(emailActualizar);

                    if (empleado != null)
                    {
                        Console.WriteLine("Ingrese el nuevo salario:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nuevoSalario))
                        {
                            if (EmpleadoRepository.ActualizarSalario(emailActualizar, nuevoSalario))
                            {
                                
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("El valor ingresado no es válido, intente nuevamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El email no existe en la base de datos, ingrese un email válido:");
                        emailActualizar = Console.ReadLine();
                    }
                    Console.WriteLine("Para volver al menu principal presione una tecla");
                    Console.ReadKey();
                }
                break;



            case "3":
                Console.Clear();
                Console.WriteLine("Ingrese el email del empleado al que desea eliminar");
                string emailEliminar = Console.ReadLine();
                while (true)
                {
                    var empleado = EmpleadoRepository.BuscarPorEmail(emailEliminar);

                    if (empleado != null)
                    {
                        EmpleadoRepository.EliminarEmpleado(emailEliminar);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("El email no existe en la base de datos, ingrese un email válido:");
                    }
                }

                        Console.WriteLine("Para volver al menu principal presione una tecla");
                Console.ReadKey();
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("Ingrese el nombre del departamento");
                while (true)
                {
                    string nombreDepartamento = Console.ReadLine();
                    Console.WriteLine("Ingrese la descripcion del departamento");
                    string descripcionDepartamento = Console.ReadLine();
                    if (DepartamentoRepository.GuardarDepartamento(new Departamento() { Nombre = nombreDepartamento, Descripcion = descripcionDepartamento }))
                    {
                        Console.WriteLine("Departamento guardado con exito");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("El departamento ya existe en la base de datos, ingrese un nombre válido:");
                    }
                }
                Console.WriteLine("Para volver al menu principal presione una tecla");
                Console.ReadKey();
                break;

            case "5":
                Console.Clear();
                int TotalEmpleados = departamento.Empleados.Count;
                Console.WriteLine($"Total de empleados: {TotalEmpleados}");
                decimal SalarioPromedio = departamento.Empleados.Average(e => e.Salario);
                Console.WriteLine($"Salario promedio: {SalarioPromedio}");
                decimal SalarioMaximo = departamento.Empleados.Max(e => e.Salario);
                Console.WriteLine($"Salario máximo: {SalarioMaximo}");
                decimal SalarioMinimo = departamento.Empleados.Min(e => e.Salario);
                Console.WriteLine($"Salario mínimo: {SalarioMinimo}");
                var porDepartamento = departamento.Empleados
                    .GroupBy(e => e.Equals(departamento.Id))
                    .Select(g => new { DepartamentoId = g.Key, Cantidad = g.Count() })
                    .ToList();
                foreach (var grupo in porDepartamento)
                {
                    Console.WriteLine($"Departamento ID: {grupo.DepartamentoId}, Cantidad de empleados: {grupo.Cantidad}");
                }
                Console.WriteLine("Para volver al menu principal presione una tecla");
                Console.ReadKey();
                break;
 
            case "6":
                Console.Clear();
                Console.WriteLine("Volviendo al menu principal ");
                break;

            default:
                Console.WriteLine("Opción inválida. Ingrese un valor entre 1 y 6.");
                Console.ReadKey();
                break;
        }
    }
}
    
