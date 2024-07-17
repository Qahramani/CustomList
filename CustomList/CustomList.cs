using System.Collections;

namespace CustomList;

public class CustomList<T> : IEnumerable<T>
{
    public int Count { get; private set; }
    public int Capacity { get => Items.Length; private set { } } // ?
    private T[] Items;
    public CustomList()
    {
        Items = new T[0];
    }
    public CustomList(int count)
    {
        Items = new T[count];
        Capacity = count;
    }

    public T this[int index]
    {
        get => Items[index];
        set => Items[index] = value;
    }
    public void Add(T item)
    {
        if(Items.Length == 0)
        {
            Array.Resize(ref Items, 4);
            Items[0] = item;
        }
        else if(Count < Capacity)
        {
            Items[Count] = item;
        }
        else
        {
            Array.Resize(ref Items, Capacity * 2);
            Items[Count] = item;
        }
        Count++;
    }
    public bool Remove(T item)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].Equals(item))
            {
                for (int j = i; j < Count; j++)
                {
                    Items[j] = Items[j + 1];
                }
                Items[Count] = default(T);
                Count--;
                return true;
            }
        }
        return false;
    }
    public int RemoveAll(Predicate<T> predicate)
    {
        int count = 0;
        for (int i = 0; i < Count; i++)
        {
            if (predicate(Items[i]))
            {
                Remove(Items[i]);
                count++;
                i--;
            }
        }
        return count;
    }
    public T? Find(Predicate<T> predicate)
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
 

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return Items[i];
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
        for (int i = 0; i < Count; i++)
        {
            action(Items[i]);
        }
    }
    public void Reverse()
    {
        for (int i = 0; i < Count / 2; i++)
        {
            T item = Items[i];
            Items[i] = Items[Count - i - 1];
            Items[Count - i - 1] = item;
        }
    }

}
