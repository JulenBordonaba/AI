using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class PathfindingManager : MonoBehaviour
{
    public SortingAlgorithm<int> sortingAlgorithm;
    public BinaryPile<int> binaryPile;

    public string aux = "";

    private void Start()
    {
        sortingAlgorithm = new SortingAlgorithm<int>();
        binaryPile = new BinaryPile<int>();

        sortingAlgorithm.sortingOrder = SortingOrder.ascendant;


        for (int i = 0; i < 20; i++)
        {
            binaryPile.Add(Random.Range(0, 100));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            aux += "0";
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            aux += "1";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            aux += "2";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            aux += "3";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            aux += "4";
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            aux += "5";
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            aux += "6";
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            aux += "7";
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            aux += "8";
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            aux += "9";
        }
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            aux.Remove(aux.Length - 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //sortingAlgorithm.Insert(int.Parse(aux));
            binaryPile.Add(int.Parse(aux));

            

            aux = "";
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int lowestValue = binaryPile.TakeFirst();
            print(lowestValue);
        }
    }
}
