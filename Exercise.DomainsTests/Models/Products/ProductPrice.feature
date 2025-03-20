Feature: ProductPrice
#
# このFeatureは、商品単価を表す値オブジェクトの単体テストを目的とする
#

#
# インスタンス生成(コンストラクタ)のテストシナリオ
#
Scenario: 有効な商品単価を保持したインスタンスが生成される
	Given 商品単価を用意する 150
	When ProductPriceを生成する
	Then ProductPriceの値は 150 である
Scenario: 50より小さい商品単価でインスタンス生成するとValidateException例外をスローする
	Given 商品単価を用意する 49 
	When ProductPriceを生成する
	Then ValidateExceptionがスローされる 'ProductPriceは50以上10000以下である必要があります。'
Scenario: 10000より大きい商品単価でインスタンス生成するとValidateException例外をスローする
	Given 商品単価を用意する 10001 
	When ProductPriceを生成する
	Then ValidateExceptionがスローされる 'ProductPriceは50以上10000以下である必要があります。'
#
#	Equals()メソッド共通ステップのシナリオ
#
Scenario Outline: ProductPriceのEqualsメソッド()を検証する
	Given 商品単価を比較する値を用意する
		| value1	| value2	|
		| <value1>  | <value2>  |
	When Equalsメソッドを実行する
	And object型でEqualsメソッドを実行する
	Then Equalsメソッド実行結果を評価する
		| result   |
		| <result> |
	Examples: 
		| value1	| value2	| result |
		| 150		| 150		| true   |
		| 150		| 160		| false  |
#
#	GetHashCode()メソッド共通ステップのシナリオ
#
Scenario Outline: CategoryPriceのGetHashCodeメソッドを検証する
    Given 商品単価のハッシュ値を生成する値を用意する
        | value1	| value2	|
        | <value1>	| <value2>	|
    When GetHashCodeメソッドを実行する
    Then GetHashCodeメソッド実行結果の比較結果を評価する
		| result   |
		| <result> |
	Examples: 
		| value1	| value2	| result |
		| 150		| 150		| true   |
		| 150		| 160		| false  |
