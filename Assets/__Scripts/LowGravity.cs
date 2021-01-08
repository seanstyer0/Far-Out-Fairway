using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGravity : MonoBehaviour
{  
    void Update()
    {
        Physics.gravity = new Vector3(0, -4, 0);
    }
}
