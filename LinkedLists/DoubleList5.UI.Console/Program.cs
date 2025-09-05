
using DoubleList5;
//prueba2
DoublyLinkedList<string> list = new DoublyLinkedList<string>();
bool exit = false;

while (!exit)
{
    Console.WriteLine("\nMenú:");
    Console.WriteLine("1. Adicionar elemento");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar la(s) moda(s)");
    Console.WriteLine("6. Mostrar gráfico de frecuencias");
    Console.WriteLine("7. Verificar si existe");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");

    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Ingrese el valor a adicionar: ");
            string value = Console.ReadLine();
            list.AddInOrder(value);
            Console.WriteLine("Elemento añadido en orden.");
            break;
        case "2":
            Console.WriteLine("Lista hacia adelante:");
            Console.WriteLine(list.GetForward());
            break;
        case "3":
            Console.WriteLine("Lista hacia atrás:");
            Console.WriteLine(list.GetBackward());
            break;
        case "4":
            list.SortDescending();
            Console.WriteLine("Lista ordenada descendentemente.");
            break;
        case "5":
            var modes = list.GetModes();
            if (modes.Count == 0)
                Console.WriteLine("La lista está vacía.");
            else if (modes.Count == 1)
                Console.WriteLine($"La moda es: {modes[0]}");
            else
                Console.WriteLine($"Las modas son: {string.Join(", ", modes)}");
            break;
        case "6":
            Console.WriteLine("Gráfico de frecuencias:");
            list.ShowFrequencyChart();
            break;
        case "7":
            Console.Write("Ingrese el valor a buscar: ");
            string searchValue = Console.ReadLine();
            Console.WriteLine(list.Exists(searchValue) ? "Existe" : "No existe");
            break;
        case "8":
            Console.Write("Ingrese el valor a eliminar (primera ocurrencia): ");
            string removeValue = Console.ReadLine();
            bool removed = list.RemoveFirstOccurrence(removeValue);
            Console.WriteLine(removed ? "Elemento eliminado." : "Elemento no encontrado.");
            break;
        case "9":
            Console.Write("Ingrese el valor a eliminar (todas las ocurrencias): ");
            string removeAllValue = Console.ReadLine();
            int count = list.RemoveAllOccurrences(removeAllValue);
            Console.WriteLine($"Se eliminaron {count} ocurrencias.");
            break;
        case "0":
            exit = true;
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}