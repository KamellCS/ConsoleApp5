using System;

namespace ConsoleApp5
{
    internal class Program
    {
        static bool ValidarDatos(double precio, int cantidad)
        {
            if (precio <= 0 || cantidad <= 0)
            {
                Console.WriteLine("Precio o cantidad incorrectos.");
                return false;
            }

            return true;
        }

        static void ImprimirMatrizDatos(double[,] datos, string[] codigos)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(codigos[i] + "  Precio: $" + datos[i, 0] +"  Cantidad: " + datos[i, 1]);
            }
        }

        static void Ordenar(
            double[,] datos, string[] codigos, string[] modelos, double[] montos)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5 - i; j++)
                {
                    if (montos[j] < montos[j + 1])
                    {
                        double temporalMonto = montos[j];
                        montos[j] = montos[j + 1];
                        montos[j + 1] = temporalMonto;

                        double temporal = datos[j, 0];
                        datos[j, 0] = datos[j + 1, 0];
                        datos[j + 1, 0] = temporal;

                        temporal = datos[j, 1];
                        datos[j, 1] = datos[j + 1, 1];
                        datos[j + 1, 1] = temporal;

                        string temporalTexto = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = temporalTexto;

                        temporalTexto = modelos[j];
                        modelos[j] = modelos[j + 1];
                        modelos[j + 1] = temporalTexto;
                    }
                }
            }
        }

        static void BuscarCodigo(
            string[] codigos, string[] modelos, double[] montos, string buscado)
        {
            for (int i = 0; i < 6; i++)
            {
                if (codigos[i] == buscado)
                {
                    Console.WriteLine("Modelo: " + modelos[i]);
                    Console.WriteLine("Monto neto: $" + montos[i]);
                    return;
                }
            }

            Console.WriteLine("Código vacío o no encontrado.");
        }

        static void Main(string[] args)
        {
            string[] codigos =
            {
                "AUTO-201", "AUTO-202", "AUTO-203",
                "AUTO-204", "AUTO-205", "AUTO-206"
            };

            string[] modelos =
            {
                "SUV Interceptor", "Sedan Executive", "PickUp Titan",
                "City Hatchback", "Electric EV", "Van Carga"
            };

            double[,] datos =
            {
                { 28000, 2 }, { 18500, 4 }, { 35000, 1 },
                { 14000, 5 }, { 42000, 1 }, { 22500, 3 }
            };

            double[] montos = new double[6];
            double total = 0;
            int premium = 0;

            for (int i = 0; i < 6; i++)
            {
                if (!ValidarDatos(datos[i, 0], (int)datos[i, 1]))
                {
                    return;
                }

                montos[i] = datos[i, 0] * datos[i, 1];
                total = total + montos[i];

                if (montos[i] > 50000)
                {
                    premium++;
                }
            }

            Console.WriteLine("Ventas:");
            ImprimirMatrizDatos(datos, codigos);

            Console.WriteLine("\nTotal: $" + total);
            Console.WriteLine("Ventas premium: " + premium);

            Ordenar(datos, codigos, modelos, montos);

            Console.WriteLine("\nVentas ordenadas:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(codigos[i] + " - " + modelos[i] + " - $" + montos[i]);
            }

            Console.Write("\nEscriba un código para buscar: ");
            string buscado = Console.ReadLine();

            BuscarCodigo(codigos, modelos, montos, buscado);
        }
    }
}