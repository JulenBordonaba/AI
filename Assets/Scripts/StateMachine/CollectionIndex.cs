using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionIndex<T>
{
    protected List<T> list;
    protected int index = 0;

    public CollectionIndex()
    {
        list = new List<T>();
    }

    public CollectionIndex(List<T> _list)
    {
        list = _list;
    }

    public CollectionIndex(List<T> _list, int _index)
    {
        list = _list;
        index = _index;
    }

    public int Index
    {
        get
        {
            if (list == null) Debug.LogError("List not assigned");

            while (index < 0)
            {
                index += list.Count;
            }

            while (index >= list.Count)
            {
                index -= list.Count;
            }

            return index;
        }

        set
        {
            index = value;

            if (list == null) return;

            while (index < 0)
            {
                index += list.Count;
            }

            while (index >= list.Count)
            {
                index -= list.Count;
            }
        }
    }

    public static implicit operator int(CollectionIndex<T> d) => d.Index;
    //public static explicit operator CollectionIndex<T>(byte b) => new CollectionIndex<T>(b);

    public static CollectionIndex<T> operator +(CollectionIndex<T> a, int b)
    {
        a.Index += b;
        return a;
    }

    public static CollectionIndex<T> operator -(CollectionIndex<T> a, int b)
    {
        a.Index -= b;
        return a;
    }

    public static bool operator <=(CollectionIndex<T> a, int b)
    {
        return a.Index <= b;
    }

    public static bool operator >=(CollectionIndex<T> a, int b)
    {
        return a.Index >= b;
    }

}
