using System;
using Exercise.Demo.Demos;
using Reqnroll;

namespace Exercise.DemoTests;

[Binding]
public class CalculatorStepDefinitions
{
    private Calculator calculator;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public CalculatorStepDefinitions()
    {
        // テストターゲットを生成
        this.calculator = new Calculator();
    }

    private int value1, value2;
    private int result;
    private Exception? _exception;
    [Given("割られる値 {int} と、割る値 {int} 用意する")]
    public void Given割られる値と割る値用意する(int value1, int value2)
    {
        this.value1 = value1;
        this.value2 = value2;
    }

    [When("割り算する")]
    public void When割り算する()
    {
        try
        {
            result = calculator.Div(this.value1, this.value2);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [Then("答え {int} が返されるはず")]
    public void Then答えが返されるはず(int expected)
    {
        Assert.AreEqual(expected, result);
    }

    [Then("ArithmeticExceptionがスローされる {string}")]
    public void ThenArithmeticExceptionがスローされる(string mesage)
    {
        Assert.IsNotNull(_exception);
        Assert.IsInstanceOfType(_exception, typeof(ArithmeticException));
        Assert.AreEqual(_exception.Message, mesage);
    }

}
