//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class GetPixel : MonoBehaviour
//{

//    void Start()
//    {


//        // 元絵のPixel情報取得
//        // Texture2D で新規のテキスチャを作成。中身はマテリアルのテキスチャ情報
//        Texture2D mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
//        // GetPixels()  Color[]テクスチャのミップマップレベルのすべてのピクセル配列
//        Color[] pixels = mainTexture.GetPixels();


//		// 書き換え用テクスチャ用配列の新規作成
//		Color[] change_pixels = new Color[pixels.Length];
//		for (int i = 0; i < pixels.Length; i++)
//		{


//			Color pixel = pixels[i];

//			// 書き換え用テクスチャのピクセル色を指定
//			Color change_pixel = new Color(1f, pixel.g, pixel.b, pixel.a);
//			change_pixels.SetValue(change_pixel, i);
//		}


//			//// 書き換え用テクスチャの生成
//			//Texture2D change_texture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
//			//change_texture.filterMode = FilterMode.Point;

//	change_texture.SetPixels(change_pixels);
//        change_texture.Apply();
//        // テクスチャを貼り替える
//        GetComponent<Renderer>().material.mainTexture = change_texture;
//    }
//}
