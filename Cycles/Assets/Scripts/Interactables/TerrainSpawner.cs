using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : PickUpSpawner
{

    // Start is called before the first frame update
    protected override void Start()
    {
        SetValues();
        SpawnLevel(40, 60, xoffset, zoffset, ypos);
       // SpawnLevel(float _xdistance, float _zdistance, float _xoffset, float zoffset, float ypos)
    }

    protected override void SetValues()
    {
        xoffset = -20f;
        zoffset = -200f;
        ypos = 90f;
    }

}
