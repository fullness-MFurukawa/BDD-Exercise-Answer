namespace Exercise.Demo.Demos;

/// <summary>
/// 計算機能を提供するクラス
/// </summary>
public class Calculator
{
    /// <summary>
    /// 割り算メソッド
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="ArithmeticException"></exception>
    public int Div(int x , int y)
    {
        if (y == 0)
        {
            throw new ArithmeticException("0除算はできません。");
        }
        return x / y;
    }
}
