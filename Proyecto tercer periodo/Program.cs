class Estacionamineto
{
    public static void Main(string[] args)
    {
        int salida, vehiculo, pago;
        Console.WriteLine("  //////////////////////////////     Estacionamiento     ////////////////////////// ");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Registro de entrada");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Por favor ingrese su vehiculo");
        Console.WriteLine("1. Carro sedan o camioneta    2. Motocicleta o bicicleta");
        vehiculo = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        int filas = 19;
        int columnas = 70;
        switch (vehiculo)
        {
            case 1:
                Console.WriteLine("                           ZONA NORTE");
                for (int i = 2; i < filas; i++)
                {
                    for (int j = 7; j < columnas; j++)
                    {
                        if (j == 0 || j == columnas - 1 || i == 0 || i == filas - 9 || j % 7 == 0)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("                              ZONA SUR");
                Console.WriteLine(" ");
            break;

        }
    }
}

