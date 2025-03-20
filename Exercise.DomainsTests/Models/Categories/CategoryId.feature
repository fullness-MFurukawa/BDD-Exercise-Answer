Feature: CategoryId
#
# このFeatureは、商品カテゴリIdを表す値オブジェクトの単体テストを目的とする
#

#
# インスタンス生成(コンストラクタ)のテストシナリオ
#
Scenario: 有効なUUIDを保持したインスタンスが生成される
    Given 商品カテゴリId '40cffd3bf63645c69a875c87ecb6f200' を用意する
    When CategoryIdを生成する
    Then CategoryIdの値は '40cffd3bf63645c69a875c87ecb6f200' である

Scenario: 空文字を用いてインスタンス生成するとValidateException例外をスローする
    Given 商品カテゴリId '' を用意する
    When CategoryIdを生成する
    Then ValidateExceptionがスローされる "CategoryIdは必須です。"

Scenario: nullを用いてインスタンス生成するとValidateException例外をスローする
    Given 商品カテゴリId 'null' を用意する
    When CategoryIdを生成する
    Then ValidateExceptionがスローされる "CategoryIdは必須です。"

Scenario: 32文字でない文字列でインスタンス生成するとValidateException例外をスローする
    Given 商品カテゴリId '40cffd3bf63645c69a875c87ecb6f' を用意する
    When CategoryIdを生成する
    Then ValidateExceptionがスローされる "CategoryIdは32文字である必要があります。"

Scenario: UUID形式でない文字列でインスタンス生成するとValidateException例外をスローする
    Given 商品カテゴリId 'abcd-1234-efgh-5678-ijkl-9012xzy' を用意する
    When CategoryIdを生成する
    Then ValidateExceptionがスローされる "CategoryIdは有効なUUID形式である必要があります。"
#
#	Equals()メソッド共通ステップのシナリオ
#
Scenario Outline: CategoryIdのEqualsメソッド()を検証する
	Given カテゴリIdを比較する値を用意する
		| value1	| value2	|
		| <value1>  | <value2>  |
	When Equalsメソッドを実行する
	And object型でEqualsメソッドを実行する
	Then Equalsメソッド実行結果を評価する
		| result   |
		| <result> |
	Examples: 
		| value1                           | value2                           | result |
		| 40cffd3bf63645c69a875c87ecb6f200 | 40cffd3bf63645c69a875c87ecb6f200 | true   |
		| 40cffd3bf63645c69a875c87ecb6f201 | 40cffd3bf63645c69a875c87ecb6f200 | false  |
#
#	GetHashCode()メソッド共通ステップのシナリオ
#
Scenario Outline: CategoryIdのGetHashCode()メソッドを検証する
    Given 商品カテゴリIdのハッシュ値を生成する値を用意する
        | value1	| value2	|
        | <value1>	| <value2>	|
    When GetHashCodeメソッドを実行する
    Then GetHashCodeメソッド実行結果の比較結果を評価する
		| result   |
		| <result> |
	Examples:
		| value1							| value2							| result |
		| 40cffd3bf63645c69a875c87ecb6f200	| 40cffd3bf63645c69a875c87ecb6f200	| true   |
		| 40cffd3bf63645c69a875c87ecb6f201	| 40cffd3bf63645c69a875c87ecb6f200	| false  |