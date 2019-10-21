using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate : MonoBehaviour
{

    public GameObject[] FloorPrefabs;
    public GameObject FloorHolder;

    public static int side  =30;

    void Start()
    {
        createFloor();
    }

    public static int GetSideCount()
    {
        return side;
    }

    GameObject SampleFloor()
    {
        GameObject prefab = null;

        prefab = FloorPrefabs[0];

        return prefab;
    }

    public void createFloor()
    {
        GameObject floor;
        Vector3 placePosition = new Vector3(0, 0, 0);
        Quaternion q = new Quaternion();
        q = Quaternion.identity;
        for (int a = 0; a < side; a++)
        {
            for (int b = 0; b < side; b++)
            {
                placePosition += new Vector3(30, 0, 0);
                floor = (GameObject)Instantiate(SampleFloor(), placePosition, q);
                floor.transform.parent = FloorHolder.transform;
            }
            placePosition -= new Vector3(30 * side, 0, 0);
            placePosition += new Vector3(0, 0, 30);
        }
    }
}
