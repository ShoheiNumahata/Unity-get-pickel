using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MnistTrainLabel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // resourcesフォルダの中にあるファイルを取得
        TextAsset text_asset = (TextAsset)Resources.Load("train-labels-idx1-ubyte");
        // 取得したファイルを元に配列を作成
        byte[] file_data = text_asset.bytes;

        Debug.Log("file_size_of_labels : " + file_data.Length);

        Debug.Log("IsLittleEndian_of_labels : " + BitConverter.IsLittleEndian);

        // new はインスタンス作成
        byte[] magic_num_byte_array = new byte[4];
        // 新規インスタンスに元となるデータを４つ格納
        Array.Copy(file_data, magic_num_byte_array, 4);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(magic_num_byte_array);

        // 4バイトから変換された３２ビット符号なし整数を返す
        uint magic_num = BitConverter.ToUInt32(magic_num_byte_array, 0);
        Debug.Log("magic_number_of_labels : " + magic_num);

        byte[] num_of_items_byte_array = new byte[4];
        Array.Copy(file_data, 4, num_of_items_byte_array, 0, 4);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(num_of_items_byte_array);

        uint num_of_items = BitConverter.ToUInt32(num_of_items_byte_array, 0);
        Debug.Log("num_of_items_of_labels : " + num_of_items);

        // 空の配列作成
        string label_str = "";
        for (int i = 8; i < file_data.Length; ++i)
        {
            label_str += file_data[i].ToString() + ",";
        }
        Debug.Log("label_str_of_labels: " + label_str);

        // 
    }
}
