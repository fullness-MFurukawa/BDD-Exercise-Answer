Feature: ProductId
#
# このFeatureは、値オブジェクトProductIdの単体テストを目的とする
#

#
# インスタンス生成(コンストラクタ)のテストシナリオ
#
Scenario: 有効なUUIDを保持したインスタンスが生成される
	Given 商品Idを用意する 'f073f7c3f35744ffbbdb3815e1d4b6c2'
	When ProductIdを生成する
	Then ProductIdの値は 'f073f7c3f35744ffbbdb3815e1d4b6c2' である
## 演習-02　追加
Scenario: 空文字を用いてインスタンス生成するとValidateException例外をスローする
	Given 商品Idを用意する '' 
	When ProductIdを生成する
	Then ValidateExceptionがスローされる 'ProductIdは必須です。'
Scenario: nullを用いてインスタンス生成するとValidateException例外をスローする
	Given 商品Idを用意する 'null' 
	When ProductIdを生成する
	Then ValidateExceptionがスローされる 'ProductIdは必須です。'
Scenario: 32文字でない文字列でインスタンス生成するとValidateException例外をスローする
	Given 商品Idを用意する '40cffd3bf63645c69a875c87ecb6f' 
	When ProductIdを生成する
	Then ValidateExceptionがスローされる 'ProductIdは32文字である必要があります。'
Scenario: UUID形式でない文字列でインスタンス生成するとValidateException例外をスローする
	Given 商品Idを用意する 'abcd-1234-efgh-5678-ijkl-9012xzy'
	When ProductIdを生成する
	Then ValidateExceptionがスローされる 'ProductIdは有効なUUID形式である必要があります。'
#
#	Equals()メソッド共通ステップのシナリオ
#
Scenario Outline: ProductIdのEqualsメソッド()を検証する
	Given 商品Idを比較する値を用意する
	| value1	| value2	|
	| <value1>  | <value2>  |
	When Equalsメソッドを実行する
	And object型でEqualsメソッドを実行する
	Then Equalsメソッド実行結果を評価する
	| result   |
	| <result> |
Examples: 
	| value1                           | value2                           | result |
	| f073f7c3f35744ffbbdb3815e1d4b6c2 | f073f7c3f35744ffbbdb3815e1d4b6c2 | true   |
	| 18d30718efec45cbb644af2cf50c286f | f073f7c3f35744ffbbdb3815e1d4b6c2 | false  |
#
#	GetHashCode()メソッド共通ステップのシナリオ
#
Scenario Outline: ProductIdのGetHashCode()メソッドを検証する
    Given 商品Idのハッシュ値を生成する値を用意する
	| value1	| value2	|
    | <value1>	| <value2>	|
    When GetHashCodeメソッドを実行する
    Then GetHashCodeメソッド実行結果の比較結果を評価する
	| result   |
	| <result> |
Examples: 
	| value1                           | value2                           | result |
	| f073f7c3f35744ffbbdb3815e1d4b6c2 | f073f7c3f35744ffbbdb3815e1d4b6c2 | true   |
	| 18d30718efec45cbb644af2cf50c286f | f073f7c3f35744ffbbdb3815e1d4b6c2 | false  |
