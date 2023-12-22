using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerticalGradientChanger : MonoBehaviour
{
    public TMP_Text mainTimeText; // 通常の秒数用テキスト
    public TMP_Text fractionTimeText; // 小数点以下の秒数用テキスト

    // Start is called before the first frame update
    void Start()
    {
        // グラデーションのカラーコードを指定
        Color topColor = HexToColor("#FF5733");
        Color bottomColor = HexToColor("#3357FF");

        // VertexGradientオブジェクトを作成
        VertexGradient gradient = new VertexGradient(topColor, topColor, bottomColor, bottomColor);

        // mainTimeTextのテキストにグラデーションを適用
        mainTimeText.enableVertexGradient = true;
        mainTimeText.colorGradient = gradient;

        // fractionTimeTextのテキストにグラデーションを適用
        fractionTimeText.enableVertexGradient = true;
        fractionTimeText.colorGradient = gradient;
    }

    public void DefaltColor()
    {
        // デフォルトの色（白）を設定
        Color topColor = HexToColor("#FFFFFF");
        Color bottomColor = HexToColor("#FFFFFF");

        // VertexGradientオブジェクトを作成
        VertexGradient gradient = new VertexGradient(topColor, topColor, bottomColor, bottomColor);

        // テキストにデフォルトのグラデーションを適用
        mainTimeText.enableVertexGradient = true;
        mainTimeText.colorGradient = gradient;
        fractionTimeText.enableVertexGradient = true;
        fractionTimeText.colorGradient = gradient;
    }

    public void DangerColor()
    {
        // 危険を示す色を設定
        Color topColor = HexToColor("#FD48F1");
        Color bottomColor = HexToColor("#EC203C");

        // VertexGradientオブジェクトを作成
        VertexGradient gradient = new VertexGradient(topColor, topColor, bottomColor, bottomColor);

        // テキストに危険色のグラデーションを適用
        mainTimeText.enableVertexGradient = true;
        mainTimeText.colorGradient = gradient;
        fractionTimeText.enableVertexGradient = true;
        fractionTimeText.colorGradient = gradient;
    }

    public void BonusColor()
    {
        // ボーナスを示す色を設定
        Color topColor = HexToColor("#00FFC6");
        Color bottomColor = HexToColor("#00ABFF");

        // VertexGradientオブジェクトを作成
        VertexGradient gradient = new VertexGradient(topColor, topColor, bottomColor, bottomColor);

        // テキストにボーナス色のグラデーションを適用
        mainTimeText.enableVertexGradient = true;
        mainTimeText.colorGradient = gradient;
        fractionTimeText.enableVertexGradient = true;
        fractionTimeText.colorGradient = gradient;
    }

    // HEX形式のカラーコードをColorに変換する関数
    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
