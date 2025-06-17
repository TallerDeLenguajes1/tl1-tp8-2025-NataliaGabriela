using EspacioTarea;
int cantidad;
string opcion;
bool salir = false;

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

Console.Write("Ingrese cuántas tareas desea generar aleatoriamente: ");
while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
{
    Console.WriteLine("Número inválido. Intente de nuevo:");
}

// Generación aleatoria de tareas
GenerarTareasAleatorias(tareasPendientes, cantidad);

while (!salir)
{
    Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
    Console.WriteLine("1. Mover tarea a realizadas");
    Console.WriteLine("2. Buscar tarea pendiente por descripción");
    Console.WriteLine("3. Ver tareas pendientes");
    Console.WriteLine("4. Ver tareas realizadas");
    Console.WriteLine("5. Ver todas las tareas");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            MoverTarea(tareasPendientes, tareasRealizadas);
            break;
        case "2":
            BuscarTarea(tareasPendientes);
            break;
        case "3":
            MostrarTareas(tareasPendientes, "Tareas Pendientes");
            break;
        case "4":
            MostrarTareas(tareasRealizadas, "Tareas Realizadas");
            break;
        case "5":
            MostrarTodas(tareasPendientes, tareasRealizadas);
            break;
        case "6":
            salir = true;
            break;
        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

// ----------- FUNCIONES AUXILIARES -----------

static void GenerarTareasAleatorias(List<Tarea> lista, int cantidad)
{
    Random rand = new Random();
    string[] ejemplos = { "Revisar stock", "Enviar correos", "Empaquetar pedidos", "Atención al cliente", "Control de calidad", "Cargar datos", "Actualizar sistema" };

    for (int i = 0; i < cantidad; i++)
    {
        int id = i + 1;
        string descripcion = ejemplos[rand.Next(ejemplos.Length)] + $" #{id}";
        int duracion = rand.Next(10, 101);
        lista.Add(new Tarea(id, descripcion, duracion));
    }

    Console.WriteLine($"\n{cantidad} tareas generadas correctamente.");
}

static void MoverTarea(List<Tarea> pendientes, List<Tarea> realizadas)
{
    Console.Write("\nIngrese el ID de la tarea a mover: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Tarea tarea = pendientes.Find(t => t.TareaID == id);
        if (tarea != null)
        {
            pendientes.Remove(tarea);
            realizadas.Add(tarea);
            Console.WriteLine("Tarea movida con éxito.");
        }
        else
        {
            Console.WriteLine("Tarea no encontrada en pendientes.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
}

static void BuscarTarea(List<Tarea> pendientes)
{
    Console.Write("\nIngrese una palabra clave para buscar en la descripción: ");
    string palabra = Console.ReadLine();
    var resultados = pendientes.FindAll(t => t.Descripcion.Contains(palabra, StringComparison.OrdinalIgnoreCase));

    if (resultados.Count == 0)
    {
        Console.WriteLine("No se encontraron tareas.");
    }
    else
    {
        Console.WriteLine("Tareas encontradas:");
        foreach (var t in resultados)
            t.Mostrar();
    }
}

static void MostrarTareas(List<Tarea> lista, string titulo)
{
    Console.WriteLine($"\n--- {titulo} ---");
    if (lista.Count == 0)
    {
        Console.WriteLine("No hay tareas.");
    }
    else
    {
        foreach (var t in lista)
        {
            t.Mostrar();
        }
    }
}

static void MostrarTodas(List<Tarea> pendientes, List<Tarea> realizadas)
{
    MostrarTareas(pendientes, "Tareas Pendientes");
    MostrarTareas(realizadas, "Tareas Realizadas");
}