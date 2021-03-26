using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeConverterChecker<TFrom, TTo>
{
    public bool CanConvert { get; private set; }

    public TypeConverterChecker(TFrom from)
    {
        try
        {
            TTo to = (TTo)(dynamic)from;
            CanConvert = true;
        }
        catch
        {
            CanConvert = false;
        }
    }
}
