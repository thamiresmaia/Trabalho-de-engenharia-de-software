﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rodar : MonoBehaviour
{

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
}
