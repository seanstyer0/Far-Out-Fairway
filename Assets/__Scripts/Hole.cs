using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    static public bool goalMet = false;
    void OnTriggerEnter()
    {
        RunGame.S.levelComplete = true;
        print("hole completed in " + RunGame.S.shotCount + " shots!");
    }
}
