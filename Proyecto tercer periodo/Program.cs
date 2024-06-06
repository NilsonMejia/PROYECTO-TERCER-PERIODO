using System.Diagnostics;

class Program
{
    static bool[,] lugaresOcupados;
    static void Main(string[] args)
    {
        int salida, vehiculo, pago, tarjeta, parqueo;
        double cambio;

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Registro de entrada");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("");

        Console.WriteLine("Por favor ingrese su vehiculo");
        Console.WriteLine("1. Carro sedan o camioneta    2. Motocicleta o bicicleta    3. Parqueo para el personal    4. Camion de carga");
        vehiculo = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start(); //Inicia a contar el tiempo
        switch (vehiculo)
        {
            case 1:

                int nuevolugar = 1;
                do
                {
                    Console.Clear();
                    int filas = 4; // cantidad de cuadros en fila
                    int columnas = 16; // cantidad de cuadros en columna
                    int tamañoCuadro = 10; // tamaño de cada cuadro

                    lugaresOcupados = new bool[filas, columnas]; // IMPORTANTE, aqui se inicializa la matriz de lugares ocupados

                    // colocamos algunos lugares ocupados 
                    lugaresOcupados[3, 3] = true;
                    lugaresOcupados[3, 11] = true;
                    lugaresOcupados[0, 7] = true;
                    lugaresOcupados[2, 7] = true;
                    lugaresOcupados[1, 5] = true;
                    lugaresOcupados[1, 2] = true;
                    lugaresOcupados[2, 14] = true;
                    lugaresOcupados[0, 15] = true;

                    DibujarCuadroGrande(filas, columnas, tamañoCuadro); //empieza la graficadora segun el tamaño seleccionado 

                    static void DibujarCuadroGrande(int filas, int columnas, int tamañoCuadro)
                    {
                        int alturaTotal = filas * tamañoCuadro;
                        int anchuraTotal = columnas * tamañoCuadro;

                        for (int i = 0; i < alturaTotal; i++)
                        {
                            for (int j = 0; j < anchuraTotal; j++)
                            {
                                // Determina la posición en la que se encuentra
                                int filaActual = i / tamañoCuadro;
                                int columnaActual = j / tamañoCuadro;

                                if (lugaresOcupados[filaActual, columnaActual])
                                {
                                    // Colorea los cuadros ocupados en azul
                                    if (EsBordeCuadro(i, j, tamañoCuadro))
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
                                    // Colorea los cuadros que no están ocupados por ahora de verde
                                    if (EsBordeCuadro(i, j, tamañoCuadro))
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

                    static bool EsBordeCuadro(int i, int j, int tamañoCuadro) // Función para verificar si es un borde del cuadro
                    {
                        return (i % tamañoCuadro == 0 || j % tamañoCuadro == 0 || i % tamañoCuadro == tamañoCuadro - 3 || j % tamañoCuadro == tamañoCuadro - 1);
                    }
                    /////////////////////////////////////////////////////////////EMPIEZA EL OTRO GRAFICADOR /////////////////////////////////////////////////////////////////
                    Console.WriteLine(" ");
                    lugaresOcupados = new bool[filas, columnas]; //se vuelve a inicializar la matriz de lugares ocupados pero del segundo parqueo

                    // Simula nuevamente algunos lugares ocupados
                    lugaresOcupados[3, 3] = true;
                    lugaresOcupados[3, 11] = true;
                    lugaresOcupados[0, 7] = true;
                    lugaresOcupados[2, 7] = true;
                    lugaresOcupados[1, 5] = true;
                    lugaresOcupados[1, 2] = true;
                    lugaresOcupados[2, 14] = true;
                    lugaresOcupados[0, 15] = true; //si deseas agregar mas lugares ocupados deberas agregarlos tambien al graficador de arriba

                    int filaSeleccionada, columnaSeleccionada;

                    while (true)
                    {
                        filaSeleccionada = ObtenerEntradaUsuario($"Seleccione el número de fila del parqueo (1 a {filas}): ", 1, filas) - 1; //se le pide al usuario colocar el lugar que desea ocupar
                        columnaSeleccionada = ObtenerEntradaUsuario($"Seleccione el número de columna del parqueo (1 a {columnas}): ", 1, columnas) - 1;

                        if (lugaresOcupados[filaSeleccionada, columnaSeleccionada])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("¡Lugar ocupado! Seleccione otro lugar.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            DibujarCuadroGrandee(filas, columnas, tamañoCuadro, filaSeleccionada, columnaSeleccionada);
                            break; // se sale del bucle si el lugar está libre
                        }
                    }

                    static int ObtenerEntradaUsuario(string mensaje, int minimo, int maximo) // si el usuario coloca un numero mayor o menor al que esta puesto sale el aviso
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
                                // Determina la posición en la que se encuentra
                                int filaActual = i / tamañoCuadro;
                                int columnaActual = j / tamañoCuadro;

                                if (filaActual == filaSeleccionada && columnaActual == columnaSeleccionada)
                                {
                                    // Colorea el cuadro seleccionado de azul
                                    if (EselBordeCuadro(i, j, tamañoCuadro))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write("*");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write(" ");
                                    }
                                }
                                else if (lugaresOcupados[filaActual, columnaActual])
                                {
                                    // Colorea los cuadros ocupados de rojo
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
                                    // Colorear los cuadros que no están seleccionados ni ocupados de verde
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

                    static bool EselBordeCuadro(int i, int j, int tamañoCuadro) // Función para verificar si es un borde del cuadro
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
            case 2:        //EMPIEZA EL CASE DE MOTOS 

                int nuevolugar2 = 1;
                do
                {
                    Console.Clear();
                    int filaa = 4; // cantidad de cuadros en fila
                    int columnaa = 16; // cantidad de cuadros en columno
                    int tamañoCuadroo = 8; // tamaño de cada cuadro

                    lugaresOcupados = new bool[filaa, columnaa];

                    // Simular algunos lugares ocupados (ejemplo)
                    lugaresOcupados[3, 3] = true;
                    lugaresOcupados[3, 11] = true;
                    lugaresOcupados[0, 7] = true;
                    lugaresOcupados[2, 7] = true;
                    lugaresOcupados[1, 5] = true;
                    lugaresOcupados[1, 2] = true;
                    lugaresOcupados[2, 14] = true;
                    lugaresOcupados[0, 15] = true;

                    DibujarCuadroGrandeee(filaa, columnaa, tamañoCuadroo);


                    static void DibujarCuadroGrandeee(int filaa, int columnaa, int tamañoCuadroo)
                    {
                        int alturaTotal = filaa * tamañoCuadroo;
                        int anchuraTotal = columnaa * tamañoCuadroo;

                        for (int i = 0; i < alturaTotal; i++)
                        {
                            for (int j = 0; j < anchuraTotal; j++)
                            {
                                int filaActual = i / tamañoCuadroo;
                                int columnaActual = j / tamañoCuadroo;

                                if (lugaresOcupados[filaActual, columnaActual])
                                {
                                    if (EsBordeCuadroo(i, j, tamañoCuadroo))
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
                                    if (EsBordeCuadroo(i, j, tamañoCuadroo))
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

                    static bool EsBordeCuadroo(int i, int j, int tamañoCuadroo)
                    {
                        return (i % tamañoCuadroo == 0 || j % tamañoCuadroo == 0 || i % tamañoCuadroo == tamañoCuadroo - 3 || j % tamañoCuadroo == tamañoCuadroo - 1);
                    }
                    ///////////////////////////////////////////////////////////EMPIEZA EL OTRO GRAFICADOR /////////////////////////////////////////////////////////////////
                    Console.WriteLine(" ");
