using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEngine;

public class Planes : MonoBehaviour
{
    [SerializeField] private ColorPlane colorPlane;
    [SerializeField] private SaveColor saveColor;
    [SerializeField] private Mesh[] meshPlanes;
    [SerializeField] private MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    public int numberPlace = 0;//номерной знак коробля


    public void NextPlane()
    {
        numberPlace++;
        if (numberPlace >= 4)
        {
            numberPlace = 0;
        }
        ActivePlanes();
    }
    public void BacktPlane()
    {
        numberPlace--;
        if (numberPlace <= -1)
        {
            numberPlace = 3;
        }
        ActivePlanes();
    }
    private void ActivePlanes()
    {
        for (int i = 0; i < meshPlanes.Length; i++)
        {
            if (numberPlace == i)
            {
                meshFilter.mesh = meshPlanes[i];
                saveColor.GetColor(i);
            }
        }
    }
}
