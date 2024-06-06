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

                    lugaresOcupados = new bool[filaa, columnaa]; // Inicializar matriz de lugares ocupados

                    lugaresOcupados[3, 3] = true;
                    lugaresOcupados[3, 11] = true;
                    lugaresOcupados[0, 7] = true;
                    lugaresOcupados[2, 7] = true;
                    lugaresOcupados[1, 5] = true;
                    lugaresOcupados[1, 2] = true;
                    lugaresOcupados[2, 14] = true;
                    lugaresOcupados[0, 15] = true;

                    int filaSeleccionada, columnaSeleccionada;

                    while (true)
                    {
                        filaSeleccionada = ObtenerEntradaUsuario($"Seleccione el número de fila del parqueo (1 a {filaa}): ", 1, filaa) - 1;
                        columnaSeleccionada = ObtenerEntradaUsuario($"Seleccione el número de columna del parqueo (1 a {columnaa}): ", 1, columnaa) - 1;

                        if (lugaresOcupados[filaSeleccionada, columnaSeleccionada])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("¡Lugar ocupado! Seleccione otro lugar.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            DibujarCuadroGrandeeee(filaa, columnaa, tamañoCuadroo, filaSeleccionada, columnaSeleccionada);
                            break;
                        }
                    }

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

                    static void DibujarCuadroGrandeeee(int filaa, int columnaa, int tamañoCuadroo, int filaSeleccionada, int columnaSeleccionada)
                    {
                        int alturaTotal = filaa * tamañoCuadroo;
                        int anchuraTotal = columnaa * tamañoCuadroo;

                        for (int i = 0; i < alturaTotal; i++)
                        {
                            for (int j = 0; j < anchuraTotal; j++)
                            {
                                int filaActual = i / tamañoCuadroo;
                                int columnaActual = j / tamañoCuadroo;

                                if (filaActual == filaSeleccionada && columnaActual == columnaSeleccionada)
                                {
                                    if (EsunBordeCuadro(i, j, tamañoCuadroo))
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
                                    if (EsunBordeCuadro(i, j, tamañoCuadroo))
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
                                    if (EsunBordeCuadro(i, j, tamañoCuadroo))
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
                        Console.WriteLine("********************************************************************************************************************************");
                        Console.ResetColor();
                    }

                    static bool EsunBordeCuadro(int i, int j, int tamañoCuadroo)
                    {
                        return (i % tamañoCuadroo == 0 || j % tamañoCuadroo == 0 || i % tamañoCuadroo == tamañoCuadroo - 3 || j % tamañoCuadroo == tamañoCuadroo - 1);
                    }
                    Console.WriteLine("¿desea cambiar su parqueo?");
                    Console.WriteLine("1. SI     2. NO");
                    parqueo = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.Clear();
                }
                while (parqueo == nuevolugar2);

                Console.WriteLine("");
                Console.WriteLine("presione ENTER para obtener su codigo");
                Console.ReadKey();
                Console.Clear();
                break;
            case 3: //    EMPIEZA EL CASE DE PERSONAL
                string nombre, apellido;
                int codigosecreto = 5544; // se declara una variable con el codigo de trabajo        CODIGO 5544
                int codigo;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("verificacion de personal");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Por favor ingrese su nombre"); //se le piden datos para verificar su identificacion 
                nombre = Console.ReadLine();
                Console.WriteLine("Por favor ingrese su apellido");
                apellido = Console.ReadLine();
                Console.WriteLine("Por favor ingrese su codigo de acceso");
                codigo = int.Parse(Console.ReadLine());
                while (codigosecreto != codigo) //si el codigo no es el que se coloco arriba no va poder seguir el usuario al estacionamiento de personal
                {
                    Console.WriteLine("¡¡¡Su código no coincide con su información personal!!!");
                    Console.WriteLine("Por favor ingrese el código que se le brindó en su trabajo");
                    codigo = int.Parse(Console.ReadLine());
                }
                Console.Clear();
                Console.WriteLine("Bienvenido " + nombre + " " + apellido);
                Console.WriteLine(" ");
                Console.WriteLine("Por favor escoja un parqueo de su agrado!!");
                int filaaa = 5;
                int columnaaa = 16;
                int tamañoCuadrooo = 9;

                int nuevolugar3 = 1;
                do
                {
                    lugaresOcupados = new bool[filaaa, columnaaa];

                    lugaresOcupados[3, 3] = true;
                    lugaresOcupados[3, 11] = true;
                    lugaresOcupados[0, 7] = true;
                    lugaresOcupados[2, 7] = true;
                    lugaresOcupados[1, 5] = true;
                    lugaresOcupados[1, 2] = true;
                    lugaresOcupados[2, 14] = true;
                    lugaresOcupados[4, 15] = true;
                    lugaresOcupados[4, 2] = true;
                    lugaresOcupados[4, 9] = true;
                    lugaresOcupados[4, 5] = true;
                    lugaresOcupados[0, 13] = true;

                    DibujarCuadroGrandeeee(filaaa, columnaaa, tamañoCuadrooo);


                    static void DibujarCuadroGrandeeee(int filaaa, int columnaaa, int tamañoCuadrooo)
                    {
                        int alturaTotal = filaaa * tamañoCuadrooo;
                        int anchuraTotal = columnaaa * tamañoCuadrooo;

                        for (int i = 0; i < alturaTotal; i++)
                        {
                            for (int j = 0; j < anchuraTotal; j++)
                            {
                                int filaActual = i / tamañoCuadrooo;
                                int columnaActual = j / tamañoCuadrooo;

                                if (lugaresOcupados[filaActual, columnaActual])
                                {
                                    if (EsunBordeCuadroo(i, j, tamañoCuadrooo))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("/");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(" ");
                                    }
                                }
                                else
                                {
                                    if (EsunBordeCuadroo(i, j, tamañoCuadrooo))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("/");
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
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    static bool EsunBordeCuadroo(int i, int j, int tamañoCuadrooo)
                    {
                        return (i % tamañoCuadrooo == 0 || j % tamañoCuadrooo == 0 || i % tamañoCuadrooo == tamañoCuadrooo - 3 || j % tamañoCuadrooo == tamañoCuadrooo - 1);
                    }
                    ///////////////////////////////////////////////////////////EMPIEZA EL OTRO GRAFICADOR /////////////////////////////////////////////////////////////////
                    lugaresOcupados = new bool[filaaa, columnaaa];

                    lugaresOcupados[3, 3] = true;
                    lugaresOcupados[3, 11] = true;
                    lugaresOcupados[0, 7] = true;
                    lugaresOcupados[2, 7] = true;
                    lugaresOcupados[1, 5] = true;
                    lugaresOcupados[1, 2] = true;
                    lugaresOcupados[2, 14] = true;
                    lugaresOcupados[0, 15] = true;

                    int filaSeleccionada, columnaSeleccionada;

                    while (true)
                    {
                        filaSeleccionada = ObtenerEntradaUsuario($"Seleccione el número de fila del parqueo (1 a {filaaa}): ", 1, filaaa) - 1;
                        columnaSeleccionada = ObtenerEntradaUsuario($"Seleccione el número de columna del parqueo (1 a {columnaaa}): ", 1, columnaaa) - 1;

                        if (lugaresOcupados[filaSeleccionada, columnaSeleccionada])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("¡Lugar ocupado! Seleccione otro lugar.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            DibujarCuadroGrandeeea(filaaa, columnaaa, tamañoCuadrooo, filaSeleccionada, columnaSeleccionada);
                            break;
                        }
                    }

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

                    static void DibujarCuadroGrandeeea(int filaaa, int columnaaa, int tamañoCuadrooo, int filaSeleccionada, int columnaSeleccionada)
                    {
                        int alturaTotal = filaaa * tamañoCuadrooo;
                        int anchuraTotal = columnaaa * tamañoCuadrooo;

                        for (int i = 0; i < alturaTotal; i++)
                        {
                            for (int j = 0; j < anchuraTotal; j++)
                            {
                                int filaActual = i / tamañoCuadrooo;
                                int columnaActual = j / tamañoCuadrooo;

                                if (filaActual == filaSeleccionada && columnaActual == columnaSeleccionada)
                                {
                                    if (EsunBordeCuadrooo(i, j, tamañoCuadrooo))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write("/");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write(" ");
                                    }
                                }
                                else if (lugaresOcupados[filaActual, columnaActual])
                                {
                                    if (EsunBordeCuadrooo(i, j, tamañoCuadrooo))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("/");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(" ");
                                    }
                                }
                                else
                                {
                                    if (EsunBordeCuadrooo(i, j, tamañoCuadrooo))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("/");
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
                        Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                        Console.ResetColor();
                    }

                    static bool EsunBordeCuadrooo(int i, int j, int tamañoCuadrooo)
                    {
                        return (i % tamañoCuadrooo == 0 || j % tamañoCuadrooo == 0 || i % tamañoCuadrooo == tamañoCuadrooo - 3 || j % tamañoCuadrooo == tamañoCuadrooo - 1);
                    }

                    Console.WriteLine("¿desea cambiar su parqueo?");
                    Console.WriteLine("1. SI     2. NO");
                    parqueo = int.Parse(Console.ReadLine());
                    Console.Clear();
                }
                while (parqueo == nuevolugar3);
                break;

            case 4:    //    EMPIEZA EL CASE DE PERSONAL
                int codigosecreto2 = 4455; // se declara una variable con el codigo de trabajo        CODIGO 4455
                Console.WriteLine("Por favor ingrese su codigo de acceso");
                codigo = int.Parse(Console.ReadLine());
                while (codigosecreto2 != codigo)
                {
                    Console.WriteLine("¡¡¡Su código no coincide con su información personal!!!");
                    Console.WriteLine("Por favor ingrese el código que se le brindó en su trabajo");
                    codigo = int.Parse(Console.ReadLine());
                }
                Console.Clear();
                Console.WriteLine("Por favor escoja un lugar de carga");
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                int filao = 1;
                int columnao = 16;
                int tamañoCuadroa = 10;

                int nuevolugar4 = 1;
                do
                {
                    Console.WriteLine("││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││");
                    Console.WriteLine("││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││");
                    Console.WriteLine("│││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││  ZONA DE CARGAMENTO  │││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││");
                    Console.WriteLine("││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││");
                    Console.WriteLine("││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││");
                    Console.WriteLine("││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││");
                    Console.WriteLine("││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││");
                    Console.WriteLine("││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││");
                    Console.WriteLine("││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││");
                    lugaresOcupados = new bool[filao, columnao];

                    lugaresOcupados[0, 1] = true;
                    lugaresOcupados[0, 6] = true;
                    lugaresOcupados[0, 10] = true;
                    lugaresOcupados[0, 15] = true;

                    DibujarCuadroGrandea(filao, columnao, tamañoCuadroa);

                    static void DibujarCuadroGrandea(int filao, int columnao, int tamañoCuadroa)
                    {
                        int alturaTotal = filao * tamañoCuadroa;
                        int anchuraTotal = columnao * tamañoCuadroa;

                        for (int i = 0; i < alturaTotal; i++)
                        {
                            for (int j = 0; j < anchuraTotal; j++)
                            {
                                int filaActual = i / tamañoCuadroa;
                                int columnaActual = j / tamañoCuadroa;

                                if (lugaresOcupados[filaActual, columnaActual])
                                {
                                    if (EsunBordeCuadroe(i, j, tamañoCuadroa))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("/");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(" ");
                                    }
                                }
                                else
                                {
                                    if (EsunBordeCuadroe(i, j, tamañoCuadroa))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("/");
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
                        Console.ResetColor();
                    }

                    static bool EsunBordeCuadroe(int i, int j, int tamañoCuadroa)
                    {
                        return (i % tamañoCuadroa == 0 || j % tamañoCuadroa == 0 || i % tamañoCuadroa == tamañoCuadroa - 3 || j % tamañoCuadroa == tamañoCuadroa - 1);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    ///////////////////////////////////////////////////////////EMPIEZA EL OTRO GRAFICADOR /////////////////////////////////////////////////////////////////

                    lugaresOcupados = new bool[filao, columnao];

                    lugaresOcupados[0, 3] = true;
                    lugaresOcupados[0, 11] = true;
                    lugaresOcupados[0, 7] = true;
                    lugaresOcupados[0, 15] = true;

                    int filaSeleccionada, columnaSeleccionada;

                    while (true)
                    {
                        filaSeleccionada = ObtenerEntradaUsuario($"Seleccione el número de fila del parqueo (1 a {filao}): ", 1, filao) - 1;
                        columnaSeleccionada = ObtenerEntradaUsuario($"Seleccione el número de columna del parqueo (1 a {columnao}): ", 1, columnao) - 1;

                        if (lugaresOcupados[filaSeleccionada, columnaSeleccionada])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("¡Lugar ocupado! Seleccione otro lugar.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.WriteLine("││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││");
                            Console.WriteLine("││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││");
                            Console.WriteLine("│││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││  ZONA DE CARGAMENTO  │││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││");
                            Console.WriteLine("││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││││");
                            Console.WriteLine("││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││");
                            Console.WriteLine("││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││");
                            Console.WriteLine("││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││");
                            Console.WriteLine("││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││");
                            Console.WriteLine("││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││││      ││");
                            DibujarCuadroGrandeao(filao, columnao, tamañoCuadroa, filaSeleccionada, columnaSeleccionada);
                            break;
                        }
                    }

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

                    static void DibujarCuadroGrandeao(int filao, int columnao, int tamañoCuadroa, int filaSeleccionada, int columnaSeleccionada)
                    {
                        int alturaTotal = filao * tamañoCuadroa;
                        int anchuraTotal = columnao * tamañoCuadroa;

                        for (int i = 0; i < alturaTotal; i++)
                        {
                            for (int j = 0; j < anchuraTotal; j++)
                            {
                                int filaActual = i / tamañoCuadroa;
                                int columnaActual = j / tamañoCuadroa;

                                if (filaActual == filaSeleccionada && columnaActual == columnaSeleccionada)
                                {
                                    if (EsunBordeCuadroa(i, j, tamañoCuadroa))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write("/");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write(" ");
                                    }
                                }
                                else if (lugaresOcupados[filaActual, columnaActual])
                                {
                                    if (EsunBordeCuadroa(i, j, tamañoCuadroa))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("/");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(" ");
                                    }
                                }
                                else
                                {
                                    if (EsunBordeCuadroa(i, j, tamañoCuadroa))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("/");
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
                        Console.ResetColor();
                    }

                    static bool EsunBordeCuadroa(int i, int j, int tamañoCuadroa)
                    {
                        return (i % tamañoCuadroa == 0 || j % tamañoCuadroa == 0 || i % tamañoCuadroa == tamañoCuadroa - 3 || j % tamañoCuadroa == tamañoCuadroa - 1);
                    }

                    Console.WriteLine("¿desea cambiar su parqueo?");
                    Console.WriteLine("1. SI     2. NO");
                    parqueo = int.Parse(Console.ReadLine());
                    Console.Clear();
                }
                while (parqueo == nuevolugar4);
                break;
        }
        Random rnd = new Random();    //Llama un numero aleatorio de 3 digitos 
        int numeroAleatorio = rnd.Next(100, 999);

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Su código es: " + numeroAleatorio + "*");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
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
        Console.WriteLine("Registro de pago ");   //INICIA REGISTRO DE PAGO
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

        stopwatch.Stop(); //Termina el tiempo 
        TimeSpan tiempoTranscurrido = stopwatch.Elapsed;

        Console.WriteLine($"Tiempo transcurrido: {tiempoTranscurrido.Hours:00}:{tiempoTranscurrido.Minutes:00}:{tiempoTranscurrido.Seconds:00}"); //Muestra el tiempo transcurrido 
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine("Ingrese el metodo de pago");
        Console.WriteLine("1. Pago en efectivo      2. Tarteja de credito/debito      3.codigo de peronsal autorizado");
        pago = int.Parse(Console.ReadLine());
        Console.Clear();
        double cobro, pago2;
        cobro = tiempoTranscurrido.TotalMinutes;
        DateTime fechaActual = DateTime.Now;
        switch (pago)
        {