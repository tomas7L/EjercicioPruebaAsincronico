using ClasesEjercicioPrueba.Models;
using ClasesEjercicioPrueba.Repository;
/*
Console.WriteLine("Ingrese el modelo del vehiculo");
string modelo = Console.ReadLine();
Console.WriteLine("Ingrese la marca del vehiculo");
string marca = Console.ReadLine();
Console.WriteLine("Ingrese la patente del vehiculo");
string patente = Console.ReadLine();
Console.WriteLine("Ingrese la cantidad de puertas del vehiculo");
int cantidadPuertas = int.Parse(Console.ReadLine());
Console.WriteLine("Ingrese el motor del vehiculo");
string motor = Console.ReadLine();

Vehiculo vehiculo = new Vehiculo()
{
    modelo = modelo,
    marca = marca,
    patente = patente,
    cantidadPuertas = cantidadPuertas,
    motor = motor
};

VehiculoRepository.GuardarVehiculo(vehiculo);
Console.WriteLine("Vehiculo guardado con exito");


List<Vehiculo> vehiculos = VehiculoRepository.ObtenerVehiculos();

foreach(var v in vehiculos)
{
    Console.WriteLine($"Id: {v.id} - Modelo: {v.modelo} - Marca: {v.marca} - Patente: {v.patente} - Cantidad de puertas: {v.cantidadPuertas} - Motor: {v.motor}");
}
*/
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
    