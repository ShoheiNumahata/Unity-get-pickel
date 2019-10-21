using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MnistLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {

        TextAsset text_asset = (TextAsset)Resources.Load("t10k-labels-idx1-ubyte");
        //TextAsset text_asset;
        //text_asset = Resources.Load("t10k-labels-idx1-ubyte") as TextAsset;
        byte[] row_data = text_asset.bytes;

		Debug.Log( "file_size_of_labels : " + row_data.Length );

		Debug.Log ("IsLittleEndian_of_labels : " + BitConverter.IsLittleEndian);

		// magic number 4 byte
        // new はインスタンス作成
		byte[] magic_num_byte_array = new byte[4];
		Array.Copy (row_data, magic_num_byte_array, 4);

		// If the system architecture is little-endian (that is, little end first),
		// reverse the byte array.
		if (BitConverter.IsLittleEndian)
			Array.Reverse(magic_num_byte_array);

        // 4バイトから変換された３２ビット符号なし整数を返す
		uint magic_num = BitConverter.ToUInt32 (magic_num_byte_array, 0);
		Debug.Log ("magic_number_of_labels : " + magic_num);

		// number of items  4byte
		byte[] num_of_items_byte_array = new byte[4];
		Array.Copy (row_data, 4, num_of_items_byte_array, 0, 4);

		if (BitConverter.IsLittleEndian)
			Array.Reverse (num_of_items_byte_array);

		uint num_of_items = BitConverter.ToUInt32 (num_of_items_byte_array, 0);
		Debug.Log ("num_of_items_of_labels : " + num_of_items);

		// read label
		string label_str = "";
		for(int i = 8; i < row_data.Length; ++i){
			label_str += row_data[i].ToString() + ",";
		}
		Debug.Log("label_str_of_labels: " + label_str);

	}
}
