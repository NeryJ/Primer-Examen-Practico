using System;

class Program
{
    struct Libro
    {
        public string Codigo;
        public string Titulo;
        public string ISBN;
        public string Edicion;
        public string Autor;
    }

    static Libro[] biblioteca = new Libro[100]; // Puedes ajustar el tamaño del arreglo según tus necesidades
    static int totalLibros = 0;

    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Calcular costo de llamada internacional");
            Console.WriteLine("2. Gestión de Biblioteca");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CalcularCostoLlamada();
                    break;
                case "2":
                    GestionBiblioteca();
                    break;
                case "3":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            if (continuar)
            {
                Console.Write("Presione cualquier tecla para volver al menú principal...");
                Console.ReadKey();
            }
        }
    }

    static void CalcularCostoLlamada()
    {
        Console.Clear();
        Console.WriteLine("Cálculo de Costo de Llamada Internacional");
        Console.WriteLine("");
        Console.WriteLine("Clave | Zona              | Precio");
        Console.WriteLine("______|___________________|_______");
        Console.WriteLine("12    | América del norte | $2");
        Console.WriteLine("15    | América central   | $2.20");
        Console.WriteLine("18    | América del sur   | $4.50");
        Console.WriteLine("19    | Europa            | $3.50");
        Console.WriteLine("23    | Asia              | $6");
        Console.WriteLine();

        Console.WriteLine("Ingrese la clave de la zona:");
        int claveZona = int.Parse(Console.ReadLine());

        string zona = "";

        double costoPorMinuto = 0;

        // Asociar la clave de zona con el costo por minuto y obtener la zona correspondiente
        switch (claveZona)
        {
            case 12:
                zona = "América del norte";
                costoPorMinuto = 2;
                break;
            case 15:
                zona = "América central";
                costoPorMinuto = 2.2;
                break;
            case 18:
                zona = "América del sur";
                costoPorMinuto = 4.5;
                break;
            case 19:
                zona = "Europa";
                costoPorMinuto = 3.5;
                break;
            case 23:
                zona = "Asia";
                costoPorMinuto = 6;
                break;
            default:
                Console.WriteLine("Clave de zona no válida.");
                return;
        }

        Console.WriteLine($"Ha seleccionado la zona: {zona}");

        Console.WriteLine("Ingrese la cantidad de minutos utilizados:");
        double minutosUtilizados = double.Parse(Console.ReadLine());

        double costoTotal = minutosUtilizados * costoPorMinuto;
        Console.WriteLine($"El costo total de la llamada es: {costoTotal:C}");
    }

    static void GestionBiblioteca()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Gestión de Biblioteca");
            Console.WriteLine("1. Agregar un libro");
            Console.WriteLine("2. Mostrar listado de libros");
            Console.WriteLine("3. Buscar libro por código");
            Console.WriteLine("4. Editar información de un libro");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarLibro();
                    break;
                case "2":
                    MostrarListadoLibros();
                    break;
                case "3":
                    BuscarLibroPorCodigo();
                    break;
                case "4":
                    EditarInformacionLibro();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            if (continuar)
            {
                Console.Write("Presione cualquier tecla para volver al menú de gestión de biblioteca...");
                Console.ReadKey();
            }
        }
    }

    static void AgregarLibro()
    {
        Console.Clear();
        if (totalLibros < biblioteca.Length)
        {
            Console.WriteLine("Ingrese los datos del libro:");
            Libro nuevoLibro;
            Console.Write("Código del libro: ");
            nuevoLibro.Codigo = Console.ReadLine();
            Console.Write("Título: ");
            nuevoLibro.Titulo = Console.ReadLine();
            Console.Write("ISBN: ");
            nuevoLibro.ISBN = Console.ReadLine();
            Console.Write("Edición: ");
            nuevoLibro.Edicion = Console.ReadLine();
            Console.Write("Autor: ");
            nuevoLibro.Autor = Console.ReadLine();

            biblioteca[totalLibros] = nuevoLibro;
            totalLibros++;

            Console.WriteLine("Libro agregado con éxito.");
        }
        else
        {
            Console.WriteLine("La biblioteca está llena, no se pueden agregar más libros.");
        }
    }

    static void MostrarListadoLibros()
    {
        Console.Clear();
        if (totalLibros > 0)
        {
            Console.WriteLine("Listado de Libros:");
            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15} {4,-20}", "Código", "Título", "ISBN", "Edición", "Autor");
            for (int i = 0; i < totalLibros; i++)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-15} {4,-20}", biblioteca[i].Codigo, biblioteca[i].Titulo, biblioteca[i].ISBN, biblioteca[i].Edicion, biblioteca[i].Autor);
            }
        }
        else
        {
            Console.WriteLine("No hay libros en la biblioteca.");
        }
    }

    static void BuscarLibroPorCodigo()
    {
        Console.Clear();
        Console.WriteLine("Buscar libro por código:");
        Console.Write("Ingrese el código del libro a buscar: ");
        string codigoBuscado = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < totalLibros; i++)
        {
            if (biblioteca[i].Codigo == codigoBuscado)
            {
                Console.WriteLine("Libro encontrado:");
                Console.WriteLine("Código: " + biblioteca[i].Codigo);
                Console.WriteLine("Título: " + biblioteca[i].Titulo);
                Console.WriteLine("ISBN: " + biblioteca[i].ISBN);
                Console.WriteLine("Edición: " + biblioteca[i].Edicion);
                Console.WriteLine("Autor: " + biblioteca[i].Autor);
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }

    static void EditarInformacionLibro()
    {
        Console.Clear();
        Console.WriteLine("Editar información de un libro:");
        Console.Write("Ingrese el código del libro a editar: ");
        string codigoEditar = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < totalLibros; i++)
        {
            if (biblioteca[i].Codigo == codigoEditar)
            {
                Console.WriteLine("Libro encontrado. Ingrese los nuevos datos:");
                Console.Write("Título: ");
                biblioteca[i].Titulo = Console.ReadLine();
                Console.Write("ISBN: ");
                biblioteca[i].ISBN = Console.ReadLine();
                Console.Write("Edición: ");
                biblioteca[i].Edicion = Console.ReadLine();
                Console.Write("Autor: ");
                biblioteca[i].Autor = Console.ReadLine();
                Console.WriteLine("Información del libro actualizada.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }
}