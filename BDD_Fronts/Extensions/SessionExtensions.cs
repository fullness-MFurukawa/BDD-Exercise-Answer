using System.Text.Json;

namespace BDD_Fronts.Extensions;
/// <summary>
/// セッションにオブジェクトを保存および取得するための拡張メソッドクラス
/// 提供
/// </summary>
public static class SessionExtensions
{
    /// <summary>
    /// オブジェクトをシリアル化してセッションに保存する
    /// </summary>
    /// <typeparam name="T">保存するオブジェクトの型</typeparam>
    /// <param name="session">オブジェクトを保存するセッション</param>
    /// <param name="key">オブジェクトを保存するためのキー</param>
    /// <param name="value">保存するオブジェクト</param>
    public static void SetObject<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    /// <summary>
    /// セッションからオブジェクトを取得してデシリアル化する
    /// </summary>
    /// <typeparam name="T">取得するオブジェクトの型</typeparam>
    /// <param name="session">オブジェクトを取得するセッション</param>
    /// <param name="key">オブジェクトを取得するためのキー</param>
    /// <returns>デシリアル化されたオブジェクト。キーが存在しない場合は型 T の既定値を返す</returns>
    public static T? GetObject<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }
}
