using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MnistTrainImage : MonoBehaviour
{
    void Start()
    {
        // resourcesフォルダの中にあるファイルを取得
        TextAsset text_asset = (TextAsset)Resources.Load("t10k-images-idx3-ubyte");
        // 取得したファイルを元に配列を作成
        byte[] file_data = text_asset.bytes;

        //Debug.Log("file_size_of_images : " + file_data.Length);

        //Debug.Log("IsLittleEndian_of_labels : " + BitConverter.IsLittleEndian);

        // new はインスタンス作成
        byte[] magic_num_byte_array = new byte[4];
        // 新規インスタンスに元となるデータを４つ格納
        Array.Copy(file_data, magic_num_byte_array, 4);

        //Debug.Log("magic_Num_with_bytes" + magic_num_byte_array);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(magic_num_byte_array);


        // 4バイトから変換された３２ビット符号なし整数を返す
        uint magic_num = BitConverter.ToUInt32(magic_num_byte_array, 0);
        //Debug.Log("magic_number_of_images : " + magic_num);

        byte[] num_of_items_byte_array = new byte[4];
        Array.Copy(file_data, 4, num_of_items_byte_array, 0, 4);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(num_of_items_byte_array);

        uint num_of_images = BitConverter.ToUInt32(num_of_items_byte_array, 0);
        //Debug.Log("num_of_images : " + num_of_images);

        //
        //  28×28のとこ
        //
        byte[] num_of_rows_byte_array = new byte[4];
        Array.Copy(file_data, 8, num_of_rows_byte_array, 0, 4);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(num_of_rows_byte_array);

        uint num_of_rows = BitConverter.ToUInt32(num_of_rows_byte_array, 0);
        //Debug.Log("num_of_rows : " + num_of_rows);

        byte[] num_of_columns_byte_array = new byte[4];
        Array.Copy(file_data, 12, num_of_columns_byte_array, 0, 4);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(num_of_columns_byte_array);

        uint num_of_columns = BitConverter.ToUInt32(num_of_columns_byte_array, 0);
        //Debug.Log("num_of_columns : " + num_of_columns);

        //
        //　画像データ（欲しいやつ）
        //
        string image_str = "";
        for (int i = 16; i < 16 + 28 * 28; ++i)
        {
            image_str += file_data[i].ToString() + ",";
        }

        //Debug.Log("image_str: " + image_str);

        Texture2D mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
        Color[] pixels = mainTexture.GetPixels();



        //やりたいこと
        Color[] change_pixels = new Color[pixels.Length];

        // 28×28の座標

        int n = 10; // ０なら１枚目、１なら２枚目、２なら３枚目......
        

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
                    Color change_pixel = new Color(c, c, c,1.0f);
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
    }
}
