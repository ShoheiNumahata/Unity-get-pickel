using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetChildren : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;

    // Use this for initialization
    private void Start()
    {
        GameObject ChildObject;

        // 子オブジェクトを全て取得する
        foreach (Transform childTransform in parentObject.transform)
        {
            //Debug.Log(childTransform.gameObject.name);
            Debug.Log(childTransform.name);

            //// 全ての子オブジェクトの座標を(0,0,0)にする
            //childTransform.position = new Vector3(0, 0, 0);

        }
        ChildObject = transform.GetChild(1).gameObject;
        // Cube(1)だけ操作
        Debug.Log(ChildObject.name);


    }

    //private void Update()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        transform.childTransform.Translate(0.0f, 1.0f, 0.0f);
    //    }
    //}
}
