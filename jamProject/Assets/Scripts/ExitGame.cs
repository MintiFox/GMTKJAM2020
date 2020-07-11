using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{



    public void Exit()
    {
        if (Application.isEditor)
        {
            print("Can't quit in editor!");

        }
        else 
        {
            Application.Quit();
        }
    }
}
