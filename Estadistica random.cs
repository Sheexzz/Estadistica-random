using System;

public class HelloWorld
{
    public static short[] LlenarRandom(int tam)
    {
        short[] aux = new short[tam];
        Random misemilla = new Random();
        for (int i = 0; i < aux.Length; i++)
            aux[i] = (short)misemilla.Next(600, 1201);
        return aux;
    }

    public static float CalcularProm(short[] aux)
    {
        float prom = 0;
        for (int i = 0; i < aux.Length; i++)
            prom += aux[i];
        prom /= aux.Length;
        return prom;
    }

    static void ShellSort(short[] aux)
    {
        int n = aux.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                short temp = aux[i];
                int j;
                for (j = i; j >= gap && aux[j - gap] > temp; j -= gap)
                {
                    aux[j] = aux[j - gap];
                }
                aux[j] = temp;
            }
        }
    }

    static double Mediana(short[] aux)
    {
        int n = aux.Length;
        ShellSort(aux); 
        if (n % 2 == 0)
            return (aux[n / 2 - 1] + aux[n / 2]) / 2.0;
        else
            return aux[n / 2];
    }

    static double DesviacionEstandar(short[] aux)
    {
        float prom = CalcularProm(aux);
        double sum = 0;
        for (int i = 0; i < aux.Length; i++)
        {
            sum += Math.Pow(aux[i] - prom, 2);
        }
        return Math.Truncate((Math.Sqrt(sum / aux.Length)));
    }

   
    public static void EncontrarFrecuencia(short[] aux, short[] valoresUnicos, int[] frecuencias, out int elementosUsados)
    {
        bool[] contados = new bool[aux.Length]; 
        int index = 0;

        for (int i = 0; i < aux.Length; i++){
            if (!contados[i])
            {
                int frecuencia = 0;
                for (int j = 0; j < aux.Length; j++)
                {
                    if (aux[i] == aux[j])
                    {
                        frecuencia++;
                        contados[j] = true; 
                    }
                }
                frecuencias[index] = frecuencia;
                valoresUnicos[index] = aux[i];
                index++;
            }
        }
        elementosUsados = index;
    }

    public static void Imprimir(short[] aux, int op, float prom = 0, double mediana = 0, double desviacion = 0, short[] valoresUnicos = null, int[] frecuencias = null, int elementosUsados = 0)
    {
        if (op == 1)
        {
            Console.WriteLine("\t\t\t\tIMPRESIÓN DE VECTOR");
            for (int i = 0; i < aux.Length; i++)
                Console.Write(aux[i] + "\t");
            Console.WriteLine();
        }
        else if (op == 2)
        {
            Console.WriteLine("\t\t\t\tIMPRESIÓN DEL PROMEDIO");
            Console.WriteLine($"\tEL PROMEDIO DE PRODUCCIÓN ES: "+prom);
        }
          if (op == 3)
        {
            Console.WriteLine("\t\t\t\tIMPRESIÓN DE VECTOR ORGANIZADO");
            for (int i = 0; i < aux.Length; i++)
                Console.Write(aux[i] + "\t");
            Console.WriteLine();
        }
        else if (op == 4) 
        {
            Console.WriteLine("\t\t\t\tFRECUENCIA DE LOS DATOS");
            for (int i = 0; i < elementosUsados; i++)
            {
                Console.WriteLine("El valor "+ valoresUnicos[i]+ " aparece "+ frecuencias[i]+ " veces.");
            }
        }
        else if (op == 5)
        {
            Console.WriteLine("\t\t\t\tMEDIANA Y DESVIACIÓN ESTÁNDAR");
            Console.WriteLine("\tMediana: "+mediana);
            Console.WriteLine("\tDesviación estándar: "+desviacion);
        }
    }

    public static void Main(string[] args)
    {
        int op = 0;
        short[] produccionMensual = new short[20];
        float promedio = 0;
        double median = 0, desviacion = 0;
        short[] valoresUnicos = new short[produccionMensual.Length];
        int[] frecuencias = new int[produccionMensual.Length];
        int elementosUsados = 0;
        
        do
        {
            Console.Clear();
            Console.WriteLine("Menú de Opciones");
            Console.WriteLine("1) Inicializar vector con números random");
            Console.WriteLine("2) Obtener promedio de producción mensual");
            Console.WriteLine("3) Ordenar vector (ShellSort)");
            Console.WriteLine("4) Encontrar frecuencia de los datos");
            Console.WriteLine("5) Hallar mediana y desviación estándar");
            Console.WriteLine("6) Salir");
            Console.Write("Seleccione una opción: ");
            op = int.Parse(Console.ReadLine());

            switch (op)
            {
            case 1:
            produccionMensual = LlenarRandom(produccionMensual.Length);
            Imprimir(produccionMensual, op);
            break;

            case 2:
            promedio = CalcularProm(produccionMensual);
            Imprimir(null, op, promedio);
            break;

            case 3:
            ShellSort(produccionMensual);
            Imprimir(produccionMensual, op);
            break;

            case 4:
            EncontrarFrecuencia(produccionMensual, valoresUnicos, frecuencias, out elementosUsados);
            Imprimir(produccionMensual, op, 0, 0, 0, valoresUnicos, frecuencias, elementosUsados);
            break;

            case 5:
            median = Mediana(produccionMensual);
            desviacion = DesviacionEstandar(produccionMensual);
            Imprimir(null, op, 0, median, desviacion);
            break;

            case 6:
            Console.WriteLine("Gracias por usar el programa");
            break;

            default:
            Console.WriteLine("OPCIÓN INVÁLIDA.");
            break;
            }
            if (op != 6)
            {
                Console.WriteLine("\nPresione Cualquier tecla para continuar");
                Console.ReadLine();
            }
        } while (op != 6);
    }
}
