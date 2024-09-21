using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear un menú para seleccionar qué acción realizar
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Generar archivo de empleados");
            Console.WriteLine("2. Leer archivo de empleados");
            Console.WriteLine("3. Salir");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    GenerarArchivo();
                    break;

                case "2":
                    LeerArchivo();
                    break;

                case "3":
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }
    }

    static void GenerarArchivo()
    {
        // Crear lista de empleados
        List<Empleado> empleados = new List<Empleado>();
        bool continuar = true;

        while (continuar)
        {
            // Crear un nuevo empleado
            Empleado empleado = new Empleado();

            // Solicitar cédula
            Console.WriteLine("Ingrese la cédula del empleado:");
            empleado.Cedula = Console.ReadLine();

            // Solicitar nombre
            Console.WriteLine("Ingrese el nombre del empleado:");
            empleado.Nombre = Console.ReadLine();

            // Solicitar salario
            Console.WriteLine("Ingrese el salario del empleado:");
            empleado.Salario = Convert.ToDecimal(Console.ReadLine());

            // Solicitar deducciones
            Console.WriteLine("Ingrese las deducciones del empleado:");
            empleado.Deducciones = Convert.ToDecimal(Console.ReadLine());

            // Agregar empleado a la lista
            empleados.Add(empleado);

            // Preguntar si se desea agregar otro empleado
            Console.WriteLine("¿Desea agregar otro empleado? (s/n):");
            string respuesta = Console.ReadLine().ToLower();

            if (respuesta != "s")
            {
                continuar = false;
            }
        }

        // Instanciar el generador de archivos y generar el archivo
        GeneradorArchivoTSS generador = new GeneradorArchivoTSS();
        generador.GenerarArchivo(empleados);
    }

    static void LeerArchivo()
    {
        // Instanciar el lector de archivos
        LectorArchivoTSS lector = new LectorArchivoTSS();

        // Leer el archivo y obtener la lista de empleados
        List<Empleado> empleados = lector.LeerArchivo();

        // Verificar si se leyeron empleados
        if (empleados != null && empleados.Count > 0)
        {
            // Mostrar los empleados en la consola
            foreach (var empleado in empleados)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}, Salario: {empleado.Salario}, Deducciones: {empleado.Deducciones}");
            }
        }
        else
        {
            Console.WriteLine("No se encontraron empleados o el archivo está vacío.");
        }
    }
}
