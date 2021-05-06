using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
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
            if (list.Count <= 0)
            {
                list.Add(newElement);
                return;
            }

            List<T> aux = new List<T>(list.ToArray());

            int index = GetIndex(aux, newElement, Convert.ToSingle(newElement));

            Debug.Log(index);

            if (index >= aux.Count)
            {
                Debug.Log("Out of range");

                foreach (T a in list)
                {
                    Debug.Log("antes del add: " + a);
                }

                list.Add(newElement);

                foreach (T a in list)
                {
                    Debug.Log("después del add: " + a);
                }


                Debug.Log("element added");
                return;
            }

            Debug.Log("In range");
            list.Insert(index, newElement);




        }

        //switch (sortingOrder)
        //{
        //    case SortingOrder.ascendant:
        //        break;
        //    case SortingOrder.descendent:
        //        break;
        //    default: break;
        //}

        private int GetIndex(List<T> currentList, T newElement, float newElementValue)
        {
            //exit Condition
            if (currentList.Count == 1)
            {
                switch (sortingOrder)
                {
                    case SortingOrder.ascendant:
                        return newElementValue >= Convert.ToSingle(currentList[0]) ? 1 : 0;
                    case SortingOrder.descendent:
                        return newElementValue <= Convert.ToSingle(currentList[0]) ? 1 : 0;
                    default:
                        throw new Exception("Sorting order not detected");
                }
            }

            bool pair = currentList.Count % 2 == 0;

            Debug.Log("pair count: " + pair);

            int halfIndex = Mathf.CeilToInt(currentList.Count / 2f);
            if (!pair)
            {
                halfIndex -= 1;
            }

            Debug.Log("halfIndex: " + halfIndex);

            switch (sortingOrder)
            {
                case SortingOrder.ascendant:
                    List<T> aux = currentList;
                    if (Convert.ToSingle(list[halfIndex]) > newElementValue)
                    {

                        Debug.Log("lower");

                        if (pair)
                        {
                            aux.RemoveRange(halfIndex, halfIndex);
                        }
                        else
                        {
                            aux.RemoveRange(halfIndex, halfIndex + 1);
                        }

                        return 0 + GetIndex(aux, newElement, newElementValue);
                    }
                    else
                    {

                        Debug.Log("higher");

                        aux.RemoveRange(0, halfIndex);

                        return halfIndex + GetIndex(aux, newElement, newElementValue); //funciona si es pair (falta comprobar si con inpair también
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
}