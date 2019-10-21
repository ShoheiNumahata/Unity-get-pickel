using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentTest : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;

    // Update is called once per frame
    void Update()
    {
        // 子オブジェクトを全て取得する
        foreach (Transform childTransform in parentObject.transform)
        {
            Debug.Log(childTransform.gameObject.name);
        }

        //// 子オブジェクトの名前を一つだけ取得
        //Transform childObject = transform.GetChild(2);
        //Debug.Log(childObject.name);
        //// transformを取得

        for (int n = 0; n < 9; n++)
        {
            // 座標を取得
            Vector3 pos = transform.GetChild(n).position;
            pos.x += 0.01f;    // x座標へ0.01加算
            pos.y += 0.01f;    // y座標へ0.01加算
            pos.z += 0.01f;    // z座標へ0.01加算

            transform.GetChild(n).position = pos;  // 座標を設定
        }
    }
}

