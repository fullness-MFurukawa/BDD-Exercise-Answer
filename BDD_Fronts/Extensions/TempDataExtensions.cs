using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace BDD_Fronts.Extensions;
/// <summary>
/// TempDataにオブジェクトを保存および取得するための拡張メソッドクラス
/// 提供
/// </summary>
public static class TempDataExtensions
{
    /// <summary>
    /// オブジェクトをシリアル化してTempDataに保存する
    /// </summary>
    /// <typeparam name="T">保存するオブジェクトの型</typeparam>
    /// <param name="tempData">オブジェクトを保存するTempData</param>
    /// <param name="key">オブジェクトを保存するためのキー</param>
    /// <param name="value">保存するオブジェクト</param>
    public static void SetObject<T>(this ITempDataDictionary tempData, string key, T value)
    {
        // オブジェクトをJSON文字列にシリアル化し、指定されたキーを使用してTempDataに保存
        tempData[key] = JsonSerializer.Serialize(value);
    }
    /// <summary>
    /// TempDataからオブジェクトを取得してデシリアルする
    /// </summary>
    /// <typeparam name="T">取得するオブジェクトの型</typeparam>
    /// <param name="tempData">オブジェクトを取得するTempData</param>
    /// <param name="key">オブジェクトを取得するためのキー</param>
    /// <returns>デシリアル化されたオブジェクト、キーが存在しない場合は型 T の既定値を返す</returns>
    public static T? GetObject<T>(this ITempDataDictionary tempData, string key)
    {
        // 指定されたキーを使用してTempDataからJSON文字列を取得する
        tempData.TryGetValue(key, out var o);
        // JSON文字列を型 T のオブジェクトにデシリアル化して返す
        // JSON文字列が null の場合は型 T の既定値を返す
        return o == null ? default : JsonSerializer.Deserialize<T>((string)o);
    }
}
