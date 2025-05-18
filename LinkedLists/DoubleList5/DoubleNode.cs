namespace DoubleList5;

public class DoubleNode<T> where T : IComparable<T>
{
    public DoubleNode(T data)
    {
        Data = data;
        Prev = null;
        Next = null;
    }

    public DoubleNode<T>? Prev { get; set; }
    public T Data { get; set; }
    public DoubleNode<T>? Next { get; set; }
}
