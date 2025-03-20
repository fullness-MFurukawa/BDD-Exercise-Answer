Feature: Calculator

#
# 計算機能クラスのテストシナリオ
#

Scenario: 割り算ができる
	Given 割られる値 100 と、割る値 20 用意する
	When 割り算する
	Then 答え 5 が返されるはず

Scenario: ゼロで割ると例外がスローされる
	Given 割られる値 100 と、割る値 0 用意する
	When 割り算する
	Then ArithmeticExceptionがスローされる "0除算はできません。"



