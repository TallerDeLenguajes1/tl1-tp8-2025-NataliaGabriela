using EspacioCalculadora;

class Program
{
    static void Main()
    {
        Calculadora Calc = new Calculadora();
        bool salir = false;

        do
        {
            Console.WriteLine("\nIngrese la operación que desea realizar");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Limpiar");
            Console.WriteLine("6. Mostrar historial");
            Console.WriteLine("0. Salir");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                double numero;
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese número a sumar: ");
                        if (double.TryParse(Console.ReadLine(), out numero))
                            Calc.Sumar(numero);
                        else
                            Console.WriteLine("Número inválido.");
                        break;
                    case 2:
                        Console.Write("Ingrese número a restar: ");
                        if (double.TryParse(Console.ReadLine(), out numero))
                            Calc.Restar(numero);
                        else
                            Console.WriteLine("Número inválido.");
                        break;
                    case 3:
                        Console.Write("Ingrese número a multiplicar: ");
                        if (double.TryParse(Console.ReadLine(), out numero))
                            Calc.Multiplicar(numero);
                        else
                            Console.WriteLine("Número inválido.");
                        break;
                    case 4:
                        Console.Write("Ingrese número a dividir: ");
                        if (double.TryParse(Console.ReadLine(), out numero))
                            Calc.Dividir(numero);
                        else
                            Console.WriteLine("Número inválido.");
                        break;
                    case 5:
                        Calc.Limpiar();
                        Console.WriteLine("Resultado limpiado.");
                        break;
                    case 6:
                        Calc.MostrarHistorial();
                        break;
                    case 0:
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine($"Resultado actual: {Calc.Resultado}");
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
            }
        } while (!salir);
    }
}