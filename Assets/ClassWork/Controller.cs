using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public MeshRenderer[] figure;
    public Material materialRed;
    public Material materialwhite;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            figure[0].material.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            figure[1].material.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            figure[2].material.color = Color.red;
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            figure[0].material.color = Color.white;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            figure[1].material.color = Color.white;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            figure[2].material.color = Color.white;
        }
    }
}
