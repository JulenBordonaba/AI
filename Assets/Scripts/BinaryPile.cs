using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BinaryPile<T> where T : IConvertible
{
    private List<T> list;

    private SortingOrder _sortingOrder = SortingOrder.ascendant;

    public SortingOrder sortingOrder
    {
        get
        {
            return _sortingOrder;
        }
        set
        {
            _sortingOrder = value;

            if (list == null) return;
            if (list.Count <= 1) return;

            switch (_sortingOrder)
            {
                case SortingOrder.ascendant:

                    if (Convert.ToSingle(list[0]) > Convert.ToSingle(list[list.Count - 1]))
                    {
                        list.Reverse();
                    }

                    break;
                case SortingOrder.descendent:

                    if (Convert.ToSingle(list[0]) < Convert.ToSingle(list[list.Count - 1]))
                    {
                        list.Reverse();
                    }

                    break;
                default:
                    break;
            }
        }
    }

    public BinaryPile()
    {
        list = new List<T>();
    }

    public void Insert(T newElement)
    {
        if (list == null) Debug.LogError("Object not initialized");

        list.Add(newElement);

        int currentIndex = list.Count - 1;
        int parentIndex = Mathf.FloorToInt(currentIndex + 1 / 2f) - 1;

        CheckParent(currentIndex, parentIndex);


    }

    public void CheckParent(int currentIndex, int parentIndex)
    {

        if (currentIndex <= 0) return;
        if (Convert.ToSingle(list[parentIndex]) <= Convert.ToSingle(list[currentIndex])) return;

        T aux = list[currentIndex];
        list[currentIndex] = list[parentIndex];
        list[parentIndex] = aux;

        CheckParent(parentIndex, Mathf.FloorToInt(parentIndex + 1 / 2f) - 1);
    }

    public T TakeFirst()
    {
        T returnValue = FirstElement;

        list[0] = list[list.Count - 1];

        list.RemoveAt(list.Count - 1);

        CheckChild(1);



        return returnValue;
    }

    public void CheckChild(int currentIndex)
    {
        int[] childs = new int[2];
        childs[0] = (currentIndex * 2) - 1;
        childs[1] = currentIndex * 2;

        if (childs[0] >= list.Count) return;


        int minIndex = -1;

        if (childs[1] >= list.Count)
        {
            minIndex = childs[0];
        }
        else
        {
            if (Convert.ToSingle(list[childs[0]]) < Convert.ToSingle(list[childs[1]]))
            {
                minIndex = 0;
            }
            else
            {
                minIndex = 1;
            }
        }

        if (!(Convert.ToSingle(list[currentIndex]) < Convert.ToSingle(list[minIndex])))
        {
            T aux = list[minIndex];
            list[minIndex] = list[currentIndex];
            list[currentIndex] = aux;

            CheckChild(minIndex + 1);
        }
        

    }

    public T FirstElement
    {
        get
        {
            if (list == null) return default(T);
            if (list.Count <= 0) return default(T);
            return list[0];
        }
    }

    public T this[int key]
    {
        get => list[key];
        set => list[key] = value;
    }

}
