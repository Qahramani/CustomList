using System.Collections;

namespace CustomList;

public class CustomList<T> : IEnumerable<T>
{
    public int Count { get => Items.Length; }
    private T[] Items;
    public CustomList()
    {
        Items = new T[0];
    }

    public T this[int index]
    {
        get => Items[index];
        set => Items[index] = value;
    }
    public void Add(T item)
    {
        Array.Resize(ref Items, Items.Length + 1);
        Items[^1] = item;
    }
    public bool Remove(T item)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].Equals(item))
            {
                for (int j = i; j < Items.Length - 1; j++)
                {
                    Items[j] = Items[j + 1];
                }
                Array.Resize(ref Items, Items.Length - 1);
                return true;
            }
        }
        return false;
    }
    public T Find(Predicate<T> predicate)
    {
        foreach (var i in Items)
        {
            if (predicate(i))
            {
                return i;
            }
        }
        return default(T);
    }
    public CustomList<T> FindAll(Predicate<T> predicate)
    {
        CustomList<T> filteredList = new CustomList<T>();
        foreach (var i in Items)
        {
            if (predicate(i))
            {
                filteredList.Add(i);
            }
        }
        return filteredList;
    }
    public int RemoveAll(Predicate<T> predicate)
    {
        int count = 0;
        for (int i = 0; i < Items.Length; i++)
        {
            if (predicate(Items[i]))
            {
                for (int j = i; j < Items.Length - 1; j++)
                {
                    Items[j] = Items[j + 1];
                }
                Array.Resize(ref Items, Items.Length - 1);
                count++;
                i--;
            }
        }
        return count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var i in Items)
        {
            yield return i;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
    public void Clear()
    {
        Array.Resize(ref Items, 0);
    }
    public bool Contains(T item)
    {
        foreach (var i in Items)
        {
            if (i.Equals(item))
                return true;
        }
        return false;
    }
    public int IndexOf(T item)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].Equals(item))
                return i;
        }
        return -1;
    }

    public void ForEach(Action<T> action)
    {
        foreach (var i in Items)
        {
            action(i);
        }
    }
    public void Reverse()
    {
        for (int i = 0; i < Items.Length / 2; i++)
        {
            T item = Items[i];
            Items[i] = Items[Items.Length - i - 1];
            Items[Items.Length - i - 1] = item;
        }
    }

}
