using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoubleList5;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;
    private int _count;

    public DoublyLinkedList()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public int Count => _count;

    // Adicionar en orden ascendente
    public void AddInOrder(T data)
    {
        var newNode = new DoubleNode<T>(data);

        if (_head == null) // Lista vacía
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            var current = _head;
            DoubleNode<T>? previous = null;

            // Buscar la posición correcta para mantener el orden
            while (current != null && current.Data.CompareTo(data) <= 0)
            {
                previous = current;
                current = current.Next;
            }

            if (previous == null) // Insertar al inicio
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }
            else if (current == null) // Insertar al final
            {
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
            else // Insertar en medio
            {
                previous.Next = newNode;
                newNode.Prev = previous;
                newNode.Next = current;
                current.Prev = newNode;
            }
        }
        _count++;
    }

    // Mostrar hacia adelante
    public string GetForward()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Next;
        }
        return output.Length > 0 ? output.Substring(0, output.Length - 5) : "Lista vacía";
    }

    // Mostrar hacia atrás
    public string GetBackward()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        return output.Length > 0 ? output.Substring(0, output.Length - 5) : "Lista vacía";
    }

    // Ordenar descendentemente (invierte la lista)
    public void SortDescending()
    {
        if (_head == null || _head.Next == null)
            return;

        var current = _head;
        DoubleNode<T>? temp = null;

        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }

        temp = _head;
        _head = _tail;
        _tail = temp;
    }

    // Encontrar la(s) moda(s)
    public List<T> GetModes()
    {
        Dictionary<T, int> frequencies = new Dictionary<T, int>();
        var current = _head;

        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data))
                frequencies[current.Data]++;
            else
                frequencies[current.Data] = 1;

            current = current.Next;
        }

        if (frequencies.Count == 0)
            return new List<T>();

        int maxFrequency = frequencies.Values.Max();
        return frequencies.Where(kv => kv.Value == maxFrequency).Select(kv => kv.Key).ToList();
    }

    // Mostrar gráfico de frecuencias
    public void ShowFrequencyChart()
    {
        Dictionary<T, int> frequencies = new Dictionary<T, int>();
        var current = _head;

        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data))
                frequencies[current.Data]++;
            else
                frequencies[current.Data] = 1;

            current = current.Next;
        }

        foreach (var item in frequencies.OrderBy(kv => kv.Key))
        {
            Console.Write($"{item.Key} ");
            Console.WriteLine(new string('*', item.Value));
        }
    }

    // Verificar si existe un elemento
    public bool Exists(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0)
                return true;
            current = current.Next;
        }
        return false;
    }

    // Eliminar la primera ocurrencia
    public bool RemoveFirstOccurrence(T data)
    {
        var current = _head;

        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0)
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev;

                _count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    // Eliminar todas las ocurrencias
    public int RemoveAllOccurrences(T data)
    {
        int removed = 0;
        var current = _head;

        while (current != null)
        {
            var next = current.Next;

            if (current.Data.CompareTo(data) == 0)
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev;

                removed++;
                _count--;
            }
            current = next;
        }
        return removed;
    }
}

