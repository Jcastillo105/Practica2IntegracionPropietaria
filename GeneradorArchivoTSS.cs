using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class GeneradorArchivoTSS
{
    public void GenerarArchivo(List<Empleado> empleados)
    {
        // Obtener la ruta de la carpeta dentro del proyecto
        string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArchivosGenerados");

        // Verificar si la carpeta existe, si no, crearla
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Definir el nombre del archivo
        string filePath = Path.Combine(folderPath, "archivo_tss.txt");

        // Crear el contenido del archivo
        StringBuilder sb = new StringBuilder();
        foreach (var empleado in empleados)
        {
            sb.AppendLine($"{empleado.Cedula};{empleado.Nombre};{empleado.Salario};{empleado.Deducciones}");
        }

        // Escribir el contenido en el archivo
        File.WriteAllText(filePath, sb.ToString());

        Console.WriteLine($"Archivo generado en: {filePath}");
    }
}
