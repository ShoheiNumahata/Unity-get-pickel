using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCube : MonoBehaviour
{
    public GameObject[] cubePrefabs;
    public GameObject cubeHolder;
    const int count = 2;
    int sampleCubeCount;

    GameObject SampleCube()
    {
        GameObject prefab = null;

        int index = Random.Range(0, cubePrefabs.Length);
        prefab = cubePrefabs[index];


        sampleCubeCount++;

        return prefab;
    }



    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Drop();
    }

    Vector3 GetInstantiatePosition()
    {
        if (sampleCubeCount % count == 0)
        {
            return transform.position + new Vector3(0, 4, -3);
        }
        else
        {
            return transform.position + new Vector3(0, 4, 3);
        }
    }

    public void Drop()
    {
        // プレファブからCubeオブジェクト作成
        GameObject cube = (GameObject)Instantiate(
            SampleCube(),
            // cubePrefab,
            GetInstantiatePosition(),
            Quaternion.identity
            );

        cube.transform.parent = cubeHolder.transform;
    }
}
