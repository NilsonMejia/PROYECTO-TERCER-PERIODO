class Estacionamineto
{
    public static void Main(string[] args)
    {
        int salida, vehiculo, pago, zona, lugar, parqueo1 = 6, parqueo2 = 5, parqueo3 = 9;
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
                Console.WriteLine(" ");
                Console.WriteLine("Por favor selecciones lugar de estacionamiento");
                Console.WriteLine(" 1. ZONA NORTE      2. ZONA SUR ");
                zona = int.Parse(Console.ReadLine());
                Console.Clear();
                int fil = 1;
                int column = 70;
                switch (zona)
                {
                    case 1:

                        Console.WriteLine("");
                        Console.WriteLine("Parqueos disponibles de la zona");
                        Console.WriteLine("   1      2      3      4      5      6      7     8       9");

                        int filaColoreada = 5;
                        int columnaColoreadaInicio = 42;
                        int columnaColoreadaFin = 70;
                        // Posición de la fila y columna para colorear

                        for (int i = 2; i < filas; i++)
                        {
                            for (int j = 7; j < columnas; j++)
                            {
                                // Si está en el borde o en la fila/columna coloreada, imprime un asterisco
                                if (j == 0 || j == column - 1 || i == 18 || i == fil + 0 || j % 7 == 0 || (j >= columnaColoreadaInicio && j <= columnaColoreadaFin && i == filaColoreada))
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
                        Console.WriteLine("Por favor ingrese un luga disponible de la zona");
                        lugar = int.Parse(Console.ReadLine());
                        while (parqueo1 <= lugar)
                        {
                            Console.WriteLine("Por favor ingrese un parqueo disponible");
                            lugar = int.Parse(Console.ReadLine());
                        }
                        break;
                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Parqueos disponibles de la zona");
                        int filaColoread = 15;
                        int columnaColoreadaInici = 2;
                        int columnaColoreadaFi = 42;
                        // Posición de la fila y columna para colorear

                        for (int i = 2; i < filas; i++)
                        {
                            for (int j = 7; j < columnas; j++)
                            {
                                // Si está en el borde o en la fila/columna coloreada, imprime un asterisco
                                if (j == 1 || j == column - 1 || i == 2 || i == fil - 0 || j % 7 == 0 || (j >= columnaColoreadaInici && j <= columnaColoreadaFi && i == filaColoread))
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
                        Console.WriteLine("   1      2      3      4      5      6      7     8       9");
                        Console.WriteLine("");
                        Console.WriteLine("Por favor ingrese un luga disponible de la zona");
                        lugar = int.Parse(Console.ReadLine());
                        while (parqueo2 >= lugar)
                        {
                            Console.WriteLine("Por favor ingrese un parqueo disponible");
                            lugar = int.Parse(Console.ReadLine());
                        }
                        break;
                }
                break;
            case 2:
                int fi = 19;
                int colu = 69;
                Console.WriteLine("                           ZONA NORTE");
                for (int i = 2; i < fi; i++)
                {
                    for (int j = 7; j < colu; j++)
                    {
                        if (j == 0 || j == colu - 1 || i == 0 || i == fi - 9 || j % 4 == 0)
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
                Console.WriteLine("Por favor selecciones lugar de estacionamiento");
                Console.WriteLine(" 1. ZONA NORTE      2. ZONA SUR ");
                zona = int.Parse(Console.ReadLine());
                Console.Clear();
                int fila = 1;
                int columna = 69;
                switch (zona)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine("Parqueos disponibles de la zona");
                        Console.WriteLine("   1   2   3   4   5   6   7   8   9   10  11  12  13  14  15");
                        int filaColoreadaa = 6;
                        int columnaColoreadaInicioo = 2;
                        int columnaColoreadaFinn = 44;
                        for (int i = 2; i < filas; i++)
                        {
                            for (int j = 7; j < columnas; j++)
                            {
                                if (j == 0 || j == columna - 1 || i == 18 || i == fila + 0 || j % 4 == 0 || (j >= columnaColoreadaInicioo && j <= columnaColoreadaFinn && i == filaColoreadaa))
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
                        Console.WriteLine("Por favor ingrese un luga disponible de la zona");
                        lugar = int.Parse(Console.ReadLine());
                        while (parqueo3 >= lugar)
                        {
                            Console.WriteLine("Por favor ingrese un parqueo disponible");
                            lugar = int.Parse(Console.ReadLine());
                        }
                        break;
                    case 2:

                   break;
                }
           break;
        }
    }
}