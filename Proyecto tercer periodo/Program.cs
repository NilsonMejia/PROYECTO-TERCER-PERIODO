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
 