using System;
using System.IO;
using System.Collections.Generic;

public class LectorArchivoTSS
{
    public List<Empleado> LeerArchivo()
    {
        // Definir la ruta del archivo
        string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArchivosGenerados");
        string filePath = Path.Combine(folderPath, "archivo_tss.txt");

        // Verificar si el archivo existe
        if (!File.Exists(filePath))
        {
            Console.WriteLine("El archivo no existe.");
            return null;
        }

        List<Empleado> empleados = new List<Empleado>();

        // Leer todas las líneas del archivo
        string[] lineas = File.ReadAllLines(filePath);

        // Procesar cada línea
        foreach (var linea in lineas)
        {
            // Separar los campos de la línea por el separador ';'
            var datos = linea.Split(';');

            // Crear un objeto Empleado con los datos leídos
            Empleado empleado = new Empleado
            {
                Cedula = datos[0],
                Nombre = datos[1],
                Salario = decimal.Parse(datos[2]),
                Deducciones = decimal.Parse(datos[3])
            };

            // Agregar el empleado a la lista
            empleados.Add(empleado);
        }

        return empleados;
    }
}
