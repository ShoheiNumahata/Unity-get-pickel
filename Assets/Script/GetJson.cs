
using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;
using System.Text;
using System;

public class GetJson : MonoBehaviour
{
    private string url = "http://localhost:3000?index=5";
    public UserData userData;

    string[] arr;

    public int n = 0;

    IEnumerator Start()
    {
        var www = new WWW(url);
        yield return www;

        userData = JsonUtility.FromJson<UserData>(www.text);

        GetMaterialPixel();
    }

    void GetMaterialPixel()
    {
        Texture2D mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
        Color[] pixels = mainTexture.GetPixels(); //配列
        Color[] change_pixels = new Color[pixels.Length]; //書き換え用

        for (int i = 1 + (28 * 28) * n; i < 1 + (28 * 28) * (n + 1); i++)
        {
            i -= 28 * 28 * n;

            int y1 = (i - 1) / 28;
            int x1 = i - (28 * y1 + 1);

            // 18倍した座標
            y1 *= 18;
            x1 *= 18;

            arr = userData.text.Split(',');
            //Debug.Log(i);
            //Debug.Log(float.Parse(arr[t]));   // Debug.Log(arr)とすると、arrのデータ型を教えてくれるだけ(string)
            float c = float.Parse(arr[i-1]) / 255.0f;
            //Debug.Log(c);

            for (int y = y1; y < y1 + 18; y++)
            {
                for (int x = x1; x < x1 + 18; x++)
                {
                    //512×512の座標 => インデックス
                    int index = (512 * y) + x;
                    Color change_pixel = new Color(c, c, c, 1.0f);
                    //Color change_pixel = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    change_pixels.SetValue(change_pixel, index);
                    //Debug.Log(c);
                }
            }
        }
        // 書き換え用テクスチャの生成3
        Texture2D change_texture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        change_texture.filterMode = FilterMode.Point;
        change_texture.SetPixels(change_pixels);
        change_texture.Apply();
        // テクスチャを貼り替える
        GetComponent<Renderer>().material.mainTexture = change_texture;
    }
}