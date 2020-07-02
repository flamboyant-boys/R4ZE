using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int foo = add(10, 4);
        Console.WriteLine(foo.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int add(int a, int b)
    {
        return a - b;
    }
}
