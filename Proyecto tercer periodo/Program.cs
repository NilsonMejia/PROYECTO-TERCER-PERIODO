using System.Diagnostics;

class Estacionamineto
{
    public static void Main(string[] args)
    {
        int salida, vehiculo, pago, zona, lugar, tarjeta, parqueo;
        double cambio;
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

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        switch (vehiculo)
        {
            case 1:
                int filas = 4; // cantidad de cuadros en fila
                int columnas = 16; // cantidad de cuadros en columno
                int tamañoCuadro = 10; // tamaño de cada cuadro

                int nuevolugar = 1;
                do
                {
                    DibujarCuadroGrande(filas, columnas, tamañoCuadro);

                    static void DibujarCuadroGrande(int filas, int columnas, int tamañoCuadro) // el static void es un tipo de valor devuelto de un metodo que queda estatico
                    {
                        int alturaTotal = filas * tamañoCuadro;
                        int anchuraTotal = columnas * tamañoCuadro;

                        for (int i = 0; i < alturaTotal; i++)
                        {
                            for (int j = 0; j < anchuraTotal; j++)
                            {
                                if (EsBordeCuadro(i, j, tamañoCuadro))
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
                        Console.WriteLine(new string('*', anchuraTotal));
                    }

                    static bool EsBordeCuadro(int i, int j, int tamañoCuadro)
                    {
                        return (i % tamañoCuadro == 0 || j % tamañoCuadro == 0 || i % tamañoCuadro == tamañoCuadro - 3 || j % tamañoCuadro == tamañoCuadro - 1);
                    }
                    /////////////////////////////////////////////////////////////EMPIEZA EL OTRO GRAFICADOR /////////////////////////////////////////////////////////////////
                    int filaSeleccionada = ObtenerEntradaUsuario("Seleccione el número de fila del cuadro (1 a " + filas + "): ", 1, filas) - 1;
                    int columnaSeleccionada = ObtenerEntradaUsuario("Seleccione el número de columna del cuadro (1 a " + columnas + "): ", 1, columnas) - 1;

                    DibujarCuadroGrandee(filas, columnas, tamañoCuadro, filaSeleccionada, columnaSeleccionada);

                    static int ObtenerEntradaUsuario(string mensaje, int minimo, int maximo)
                    {
                        int valor;
                        while (true)
                        {
                            Console.WriteLine(mensaje);
                            if (int.TryParse(Console.ReadLine(), out valor) && valor >= minimo && valor <= maximo)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Error: Por favor, introduzca un número entre {minimo} y {maximo}.");
                            }
                        }
                        return valor;
                    }

                    static void DibujarCuadroGrandee(int filas, int columnas, int tamañoCuadro, int filaSeleccionada, int columnaSeleccionada)
                    {
                        int alturaTotal = filas * tamañoCuadro;
                        int anchuraTotal = columnas * tamañoCuadro;

                        for (int i = 0; i < alturaTotal; i++)
                        {
                            for (int j = 0; j < anchuraTotal; j++)
                            {
                                // Determina la pocision en la que se encuentra
                                int filaActual = i / tamañoCuadro;
                                int columnaActual = j / tamañoCuadro;

                                if (filaActual == filaSeleccionada && columnaActual == columnaSeleccionada)
                                {
                                    // Colorear el cuadro seleccionado en rojo
                                    if (EselBordeCuadro(i, j, tamañoCuadro))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("*");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(" ");
                                    }
                                }
                                else
                                {
                                    // Colorear los cuadros que no estan seleccionados en verde
                                    if (EselBordeCuadro(i, j, tamañoCuadro))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("*");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write(" ");
                                    }
                                }
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("");
                        Console.ResetColor();
                    }
                    //aqui va pegar el siguiente
                    // ajuste para la cantidad de espacios en el parqueo
                    static bool EselBordeCuadro(int i, int j, int tamañoCuadro)
                    {
                        return (i % tamañoCuadro == 0 || j % tamañoCuadro == 0 || i % tamañoCuadro == tamañoCuadro - 3 || j % tamañoCuadro == tamañoCuadro - 1);
                    }
                    Console.WriteLine("¿desea cambiar su parqueo?");
                    Console.WriteLine("1. SI     2. NO");
                    parqueo = int.Parse(Console.ReadLine());
                    Console.Clear();
                }
                while (parqueo == nuevolugar);

                Console.WriteLine("");
                Console.WriteLine("presione ENTER para obtener su codigo");
                Console.ReadKey();
                Console.Clear();
                break;
            //Empieza el case de motos
                Console.WriteLine("¿desea cambiar su parqueo?");
                    Console.WriteLine("1. SI     2. NO");
                    parqueo = int.Parse(Console.ReadLine());
                    Console.Clear();
        }
                while (parqueo == nuevolugar);
                break;
            case 2:
               
            break;
        }
        Console.Clear();
        Random rnd = new Random();
        int numeroAleatorio = rnd.Next(100, 999);

        Console.WriteLine("");
        Console.WriteLine("************************************************");
        Console.WriteLine("************************************************");
        Console.WriteLine("************************************************");
        Console.WriteLine("************************************************");
        Console.WriteLine("***************Su código es: " + numeroAleatorio + "****************");
        Console.WriteLine("************************************************");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("************************************************");
        Console.WriteLine("************************************************");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("************************************************");
        Console.WriteLine("************************************************");
        Console.WriteLine("************************************************");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Disfrute de su estancia");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Registro de pago ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("Por favor ingrese el código");
        salida = int.Parse(Console.ReadLine());

        while (numeroAleatorio != salida)
        {
            Console.WriteLine("¡¡¡¡CÓDIGO INCORRECTO!!!!");
            Console.WriteLine("Por favor ingrese el código que se le brindó en la entrada:");
            salida = int.Parse(Console.ReadLine());
        }

        stopwatch.Stop();
        TimeSpan tiempoTranscurrido = stopwatch.Elapsed;

        Console.WriteLine($"Tiempo transcurrido: {tiempoTranscurrido.Hours:00}:{tiempoTranscurrido.Minutes:00}:{tiempoTranscurrido.Seconds:00}");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine("Ingrese el metodo de pago");
        Console.WriteLine("1. Pago en efectivo      2. Tarteja de credito/debito");
        pago = int.Parse(Console.ReadLine());
        Console.Clear();
        double cobro, pago2;
        cobro = tiempoTranscurrido.TotalMinutes;
        DateTime fechaActual = DateTime.Now;

        switch (pago)
        {
            case 1:
                Console.WriteLine("Monto a cobrar:" + cobro.ToString("F2"));
                Console.WriteLine("");
                Console.WriteLine("ingrese el pago");
                pago2 = double.Parse(Console.ReadLine());
                while (pago2 < 0.09)
                {
                    Console.WriteLine("por favor ingrese un billete o moneda oficial");
                    pago2 = double.Parse(Console.ReadLine());
                }
                if (pago2 >= 0.10)
                {
                    Console.WriteLine(" ");
                    cambio = pago2 - cobro;
                    if (pago2 > cobro)
                    {
                        Console.WriteLine("SU PAGO SE REALIZO CON EXITO");
                    }
                    while (pago2 <= cobro)
                    {
                        Console.WriteLine("¡¡ERROR!! Por favor ingrese un billete o moneda de mayor valor");
                        pago2 = double.Parse(Console.ReadLine());
                    }
                    cambio = pago2 - cobro;
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("*");
                    Console.WriteLine("*");
                    Console.WriteLine("**********************  FACTURA  ************************");
                    Console.WriteLine("*");
                    Console.WriteLine("******* tiempo ------------------------- " + tiempoTranscurrido.TotalMinutes.ToString("F2") + " ***********");
                    Console.WriteLine("******* monto total -------------------- " + cobro.ToString("F2") + " ***********");
                    Console.WriteLine("******* pago --------------------------- " + pago2.ToString("F2") + " ***********");
                    Console.WriteLine("******* cambio ------------------------- " + cambio.ToString("F2") + " ***********");
                    Console.WriteLine("*");
                    Console.WriteLine("******* fecha ----------------- " + fechaActual + " *******");
                    Console.WriteLine("******* codigo ---------------- " + numeroAleatorio + " *********************");
                    Console.WriteLine("*");
                    Console.WriteLine("*");
                    Console.WriteLine("*");
                    Console.WriteLine("*");
                }
                break;
            case 2:
                Console.WriteLine("Monto a cobrar:" + cobro.ToString("F2"));
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Ingrese su PIN de 4 dígitos");
                tarjeta = int.Parse(Console.ReadLine());

                while (tarjeta < 1000 || tarjeta > 9999)
                {
                    Console.WriteLine("Por favor, ingrese un PIN de 4 dígitos");
                    tarjeta = int.Parse(Console.ReadLine());
                }
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("SU COBRO SE REALIZO CON EXITO");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("*");
                Console.WriteLine("*");
                Console.WriteLine("**********************  FACTURA  ************************");
                Console.WriteLine("*");
                Console.WriteLine("******* tiempo ------------------------- " + tiempoTranscurrido.TotalMinutes.ToString("F2") + " ***********");
                Console.WriteLine("******* monto total -------------------- " + cobro.ToString("F2") + " ***********");
                Console.WriteLine("******* pago ------------------- " + "con tarjeta " + " ***********");
                Console.WriteLine("*");
                Console.WriteLine("******* fecha ----------------- " + fechaActual + " *******");
                Console.WriteLine("******* codigo ---------------- " + numeroAleatorio + " *********************");
                Console.WriteLine("*");
                Console.WriteLine("*");
                Console.WriteLine("*");
                Console.WriteLine("*");
                break;
        }
        Console.WriteLine("");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Registro de salida ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Por favor ingrese el código de factura");
        salida = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        while (numeroAleatorio != salida)
        {
            Console.WriteLine("¡¡¡¡CÓDIGO INCORRECTO!!!!");
            Console.WriteLine("Por favor ingrese el código establecido en la factura:");
            salida = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Gracias por visitarnos. Que tenga buen viaje.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}