using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuffleMnist : MonoBehaviour
{
    public int n = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DrawMNIST();
            n++;
        }
    }

    public byte[] DataImport()
    {
        // データインポート
        TextAsset text_asset = (TextAsset)Resources.Load("t10k-images-idx3-ubyte");
        byte[] file_data = text_asset.bytes;
        return file_data;
    }

    public void DrawMNIST()
    {
        // data import
        byte[] file_data = DataImport();

        Texture2D mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
        Color[] pixels = mainTexture.GetPixels();

        Color[] change_pixels = new Color[pixels.Length];

        // 28×28の座標

        //int n = 10; // ０なら１枚目、１なら２枚目、２なら３枚目......


        for (int i = 16 + (28 * 28) * n; i < 16 + (28 * 28) * (n + 1); i++)
        {
            int j = i - 15;
            j -= 28 * 28 * n;

            // 座標＝＞インデックス　(28* y1 + 1) + (x)

            // j:1 ~ 1+(28*28)
            // j:1+(28*28) ~ 1+(28*28*2)
            // j:1+(28*28*2) ~ 1+(28*28*3)

            int y1 = (j - 1) / 28;
            int x1 = j - (28 * y1 + 1);

            // 18倍した座標
            y1 *= 18;
            x1 *= 18;

            //Debug.Log("x1,y1,f:" + x1 + "," + y1 + "," + file_data[i]);

            for (int y = y1; y < y1 + 18; y++)
            {
                for (int x = x1; x < x1 + 18; x++)
                {
                    //Debug.Log("(x,y):" + x + "," + y);

                    // 512×512の座標=>インデックス
                    int index = (512 * y) + x;
                    float c = file_data[i] / 255.0f;
                    Color change_pixel = new Color(c, c, c, 1.0f);
                    //Color change_pixel = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    change_pixels.SetValue(change_pixel, index);
                }

            }
        }
        // 書き換え用テクスチャの生成
        Texture2D change_texture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        change_texture.filterMode = FilterMode.Point;
        change_texture.SetPixels(change_pixels);
        change_texture.Apply();
        // テクスチャを貼り替える
        GetComponent<Renderer>().material.mainTexture = change_texture;

        //// 子供のGameObjectを取得
        //for (int ch = 0; )
        //{
        //    // テクスチャを貼り替える
        //    GameObject c;

        //    c.GetComponent<Renderer>().material.mainTexture = change_texture;


        //}
    }

    
}

    