using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[SerializeField]
public class SortingAlgorithm<T> where T : IConvertible
{
    [SerializeField]
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

    public SortingAlgorithm()
    {
        list = new List<T>();
    }

    public void Insert(T newElement)
    {
        if (list == null) throw new NullReferenceException();
        if (list.Count <= 0) list.Add(newElement);

        int pos = GetPosition(list, newElement, Convert.ToSingle(newElement));
        
    }

    //switch (sortingOrder)
    //{
    //    case SortingOrder.ascendant:
    //        break;
    //    case SortingOrder.descendent:
    //        break;
    //    default: break;
    //}

    private int GetPosition(List<T> currentList, T newElement, float newElementValue)
    {
        //exit Condition
        if (currentList.Count == 1)
        {
            switch(sortingOrder)
            {
                case SortingOrder.ascendant:
                    return newElementValue >= Convert.ToSingle(currentList[0]) ? 1 : 0;
                case SortingOrder.descendent:
                    return newElementValue <= Convert.ToSingle(currentList[0]) ? 1 : 0;
                default:
                    break;
            }
        }

        bool pair = currentList.Count % 2 == 0;

        int halfIndex = Mathf.CeilToInt(currentList.Count / 2f);
        

        switch (sortingOrder)
        {
            case SortingOrder.ascendant:
                List<T> aux = currentList;
                if (Convert.ToSingle(list[halfIndex]) > newElementValue)
                {
                    
                    if(pair)
                    {
                        aux.RemoveRange(halfIndex, halfIndex);
                    }
                    else
                    {
                        aux.RemoveRange(halfIndex, halfIndex+1);
                    }

                    return 0 + GetPosition(aux, newElement, newElementValue);
                }
                else
                {
                    aux.RemoveRange(0, halfIndex);

                    return 0 + GetPosition(aux, newElement, newElementValue);
                }

            case SortingOrder.descendent:
                break;
            default: break;
        }

        throw new Exception();
    }

    public T TakeFirst()
    {
        T returnValue = FirstElement;

        list.RemoveAt(0);

        return returnValue;
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
