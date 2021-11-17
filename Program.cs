using System;

namespace Examen5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Colonización a Marte - Envío de material a las planicies");
            Console.WriteLine("Se realizarán 15 lanzamientos de materiales necesarios para la colonización,");
            Console.WriteLine("que estarán ubicados en las planicies(A)cidalia, (E)lysium y (U)topia.");
            Console.WriteLine("Cada lanzamiento tiene un cargamento de hasta 10.000 kg.\n");

            Aterrizaje[] ArregloAterrizajes = new Aterrizaje[15];
            int i = 0;

            while (i < ArregloAterrizajes.Length)
            {
                ArregloAterrizajes[i] = new Aterrizaje();
                Console.WriteLine($"Ingrese un destino para el lanzamiento {i + 1}: ");
                ArregloAterrizajes[i].destino = Console.ReadLine().ToUpper();
                if (ArregloAterrizajes[i].destino == "A" || ArregloAterrizajes[i].destino == "E" || ArregloAterrizajes[i].destino == "U")
                {
                    bool valido = false;
                    while (valido == false)
                    {

                        try
                        {
                            Console.WriteLine($"Ingrese la carga con la que llegó el lanzamiento {i + 1}: ");
                            ArregloAterrizajes[i].carga = float.Parse(Console.ReadLine());

                            if (ArregloAterrizajes[i].carga <= 0 || ArregloAterrizajes[i].carga >= 10000)
                                Console.WriteLine("La carga del lanzamiento es un número no válido, intente nuevamente\n");
                            else
                            {
                                valido = true;
                                i++;
                            }

                        }
                        catch (FormatException error)
                        {
                            Console.WriteLine("Ingresaste un dato no numérico. Intenta nuevamente!");
                            Console.WriteLine("Error: {0} \n", error.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ingresaste un destino inválido. Intenta nuevamente! \n");
                }
            }

            float promedios = CalculaPromedioEfectividad(ArregloAterrizajes);

            Console.WriteLine("\n\nResultados obtenidos de los lanzamientos:\n");
            Console.WriteLine("Las planicies son A(cidalia), E(lysium) y U(topia)\n");

            for (i = 0; i < ArregloAterrizajes.Length; i++)
            {
                Console.WriteLine($"Lanzamiento N°{i + 1}: ");
                Console.WriteLine($"Carga: {ArregloAterrizajes[i].carga} kg");
                Console.WriteLine($"Destino: {ArregloAterrizajes[i].destino}");
                Console.WriteLine();
            }

            Console.WriteLine($"\nPromedio: {promedios}");

        }

        
        static float CalculaPromedioEfectividad(Aterrizaje[] aterrizajes)
        {

            float promedios = 0;
            int i;

            for (i = 0; i < aterrizajes.Length; i++)
            {
                promedios += aterrizajes[i].carga;

            }
            promedios /= aterrizajes.Length;

            return promedios;
        }
    }
}
