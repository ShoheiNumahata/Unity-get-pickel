using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MnistImage: MonoBehaviour
{
	Texture2D drawTexture;
	Color[] buffer;

	// Use this for initialization
	void Start()
	{
        
		TextAsset text_asset = Resources.Load("t10k-images-idx3-ubyte") as TextAsset;
		byte[] row_data = text_asset.bytes;

        Debug.Log("file_size_of_images : " + row_data.Length);

        Debug.Log("IsLittleEndian_of_images : " + BitConverter.IsLittleEndian);



        // magic number 4 byte
        byte[] magic_num_byte_array = new byte[4];
		Array.Copy(row_data, magic_num_byte_array, 4);

		// If the system architecture is little-endian (that is, little end first),
		// reverse the byte array.
		if (BitConverter.IsLittleEndian)
			Array.Reverse(magic_num_byte_array);

		uint magic_num = BitConverter.ToUInt32(magic_num_byte_array, 0);
        Debug.Log("magic_number_of_images : " + magic_num);



        // number of images  4byte
        byte[] num_of_images_byte_array = new byte[4];
		Array.Copy(row_data, 4, num_of_images_byte_array, 0, 4);

		if (BitConverter.IsLittleEndian)
			Array.Reverse(num_of_images_byte_array);

		uint num_of_images = BitConverter.ToUInt32(num_of_images_byte_array, 0);
        Debug.Log("num_of_images : " + num_of_images);






        // number of rows  4byte
        byte[] num_of_rows_byte_array = new byte[4];
		Array.Copy(row_data, 8, num_of_rows_byte_array, 0, 4);

		if (BitConverter.IsLittleEndian)
			Array.Reverse(num_of_rows_byte_array);

		uint num_of_rows = BitConverter.ToUInt32(num_of_rows_byte_array, 0);
        Debug.Log("num_of_rows : " + num_of_rows);


        // number of rows  4byte
        byte[] num_of_columns_byte_array = new byte[4];
		Array.Copy(row_data, 12, num_of_columns_byte_array, 0, 4);

		if (BitConverter.IsLittleEndian)
			Array.Reverse(num_of_columns_byte_array);

		uint num_of_columns = BitConverter.ToUInt32(num_of_columns_byte_array, 0);
		Debug.Log("num_of_columns : " + num_of_columns);


		// read label
		//string label_str = "";

  //      GameObject cube = GameObject.Find("Cube");
		//Debug.Log(cube.name);
		//Texture tex = cube.GetComponent<Renderer>().material.mainTexture;

		// Texture情報取得
		//GameObject mainTexture = 
		//Debug.Log(tex.name);
		// 黒く塗る
		//tex
		//Texture2D mainTexture = (Texture2D)cube.GetComponent<Renderer>().material.mainTexture;
		//Debug.Log(mainTexture.name);
		//Color[] pixels = mainTexture.GetPixels();
		//Debug.Log(pixels);
		//buffer = new Color[pixels.Length];
		//pixels.CopyTo(buffer, 0);

		//// 画面上半分を塗りつぶす
		//for (int x = 0; x < mainTexture.width; x++)
		//{
		//	for (int y = 0; y < mainTexture.height; y++)
		//	{
		//		if (y < mainTexture.height / 2)
		//		{
		//			buffer.SetValue(Color.black, x + mainTexture.width * y);
		//		}
		//	}
		//}

		//drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
		//drawTexture.filterMode = FilterMode.Point;

		////GetComponent<Renderer>().material.mainTexture;
		////for (int i = 16; i < row_data.Length; ++i)
		//for (int i = 16; i < 28*28+16; ++i)
		//{
		//	label_str += row_data[i].ToString() + ",";
  //          //textureに書き込み
  //          // 28x28の一つを塗る
  //          //tex.
		//}
		//Debug.Log("label_str: " + label_str);

	}

	// Update is called once per frame
	//void Update()
	//{
	//	GameObject cube = GameObject.Find("Cube");
	//	drawTexture.SetPixels(buffer);
	//	drawTexture.Apply();
	//	cube.GetComponent<Renderer>().material.mainTexture = drawTexture;
	//}
}
