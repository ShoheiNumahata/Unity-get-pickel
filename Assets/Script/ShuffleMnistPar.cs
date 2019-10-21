using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleMnistPar : MonoBehaviour
{
    public int n = 0;
    [SerializeField] private GameObject parentObject;

    public float span = 0.5f;
    private float currentTime = 0f;


    private void Start()
    {
        //createFloor();
        DrawMNIST();
        n++;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            currentTime = 0f;
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


    void MakePicture(Color[] change_pixels)
    {
        byte[] file_data = DataImport();

        for (int i = 16 + (28 * 28) * n; i < 16 + (28 * 28) * (n + 1); i++)
        {
            int j = i - 15;
            j -= 28 * 28 * n;
            int y1 = (j - 1) / 28;
            int x1 = j - (28 * y1 + 1);
            y1 *= 18;
            x1 *= 18;
            for (int y = y1; y < y1 + 18; y++)
            {
                for (int x = x1; x < x1 + 18; x++)
                {
                    int index = (512 * y) + x;
                    float c = file_data[i] / 255.0f;
                    Color change_pixel = new Color(c, c, c, 1.0f);
                    //Color change_pixel = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    change_pixels.SetValue(change_pixel, index);
                }

            }
        }
    }

    //int side2;
    int side = generate.GetSideCount();
    //int side1 = GetJson.side_original();

    void DrawMNIST()
    {
        Transform childObjectIdeal = transform.GetChild(0);
        Texture2D mainTextureIdeal = (Texture2D)childObjectIdeal.GetComponent<Renderer>().material.mainTexture;
        Color[] pixels = mainTextureIdeal.GetPixels();
        Color[] change_pixels = new Color[pixels.Length];
        MakePicture(change_pixels);

        for (int ch = 0; ch < side * side; ch++)
        {
            // 子オブジェ取得
            Transform childObjectReal = transform.GetChild(ch);
            Texture2D mainTextureReal = (Texture2D)childObjectReal.GetComponent<Renderer>().material.mainTexture;

            // mnistデータ貼り付け
            Texture2D change_texture = new Texture2D(mainTextureReal.width, mainTextureReal.height, TextureFormat.RGBA32, false);
            change_texture.filterMode = FilterMode.Point;
            change_texture.SetPixels(change_pixels);
            change_texture.Apply();
            // テクスチャを貼り替える
            childObjectReal.GetComponent<Renderer>().material.mainTexture = change_texture;
        }
    }
}
