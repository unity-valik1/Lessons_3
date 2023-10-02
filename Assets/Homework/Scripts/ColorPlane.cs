using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlane : MonoBehaviour
{
    [SerializeField] private Planes planes;

    [SerializeField] private Material[] materials;
    public void AirplaneColor(int index)
    {
        for (int i = 0; i < materials.Length; i++)
        {
            if (i == index)
            {
                planes.meshRenderer.material = materials[index];
                return;
            }
        }
    }
}
