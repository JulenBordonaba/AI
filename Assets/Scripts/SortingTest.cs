using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingTest : MonoBehaviour
{
    public SortingAlgorithm<int> sortingAlgorithm;

    public string aux = "";

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
            sortingAlgorithm.Insert(int.Parse(aux));
            aux = "";
        }
    }
}
