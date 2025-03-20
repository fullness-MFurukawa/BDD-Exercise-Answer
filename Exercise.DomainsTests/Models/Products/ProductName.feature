Feature: ProductName
#
# このFeatureは、商品名を表す値オブジェクトの単体テストを目的とする
#

#
# インスタンス生成(コンストラクタ)のテストシナリオ
#
Scenario: 30文字以内の商品名を保持したインスタンスが生成される
	Given 商品名を用意する '水性ボールペン 青'
	When ProductNameを生成する
	Then ProductNameの値は '水性ボールペン 青' である
Scenario: 空文字を用いてインスタンス生成するとValidateException例外をスローする
	Given 商品名を用意する '' 
	When ProductNameを生成する
	Then ValidateExceptionがスローされる 'ProductNameは必須です。'
Scenario: nullを用いてインスタンス生成するとValidateException例外をスローする
	Given 商品名を用意する 'null' 
	When ProductNameを生成する
	Then ValidateExceptionがスローされる 'ProductNameは必須です。'
Scenario: 30文字より大きい文字列でインスタンス生成するとValidateException例外をスローする
	Given 商品名を用意する '40cffd3bf63645c69a875c87ecb6f0000' 
	When ProductNameを生成する
	Then ValidateExceptionがスローされる 'ProductNameは30文字以内である必要があります。'
#
#	Equals()メソッド共通ステップのシナリオ
#
Scenario Outline: ProductNameのEquals()メソッドを検証する
	Given 商品名を比較する値を用意する
	| value1	| value2	|
	| <value1>  | <value2>  |
	When Equalsメソッドを実行する
	And object型でEqualsメソッドを実行する
	Then Equalsメソッド実行結果を評価する
	| result   |
	| <result> |
	Examples:
		| value1			| value2			| result |
		| 水性ボールペン 青	| 水性ボールペン 青	| true   |
		| 水性ボールペン 青	| 油性ボールペン 赤	| false  |
#
#	GetHashCode()メソッド共通ステップのシナリオ
#
Scenario Outline: ProductNameのGetHashCodeメソッドを検証する
    Given 商品名のハッシュ値を生成する値を用意する
    | value1	| value2	|
    | <value1>	| <value2>	|
    When GetHashCodeメソッドを実行する
    Then GetHashCodeメソッド実行結果の比較結果を評価する
	| result   |
	| <result> |
	Examples:
		| value1			| value2			| result |
		| 水性ボールペン 青	| 水性ボールペン 青	| true   |
		| 水性ボールペン 青	| 油性ボールペン 赤	| false  |
