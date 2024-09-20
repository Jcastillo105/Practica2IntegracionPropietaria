using System;
using System.Collections.Generic;

public partial class Program
{
    static void Main(string[] args)
    {
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

        Console.WriteLine("Proceso terminado.");
    }
}
