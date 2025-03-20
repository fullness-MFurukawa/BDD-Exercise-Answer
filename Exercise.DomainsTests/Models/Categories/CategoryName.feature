Feature: CategoryName
#
# このFeatureは、商品カテゴリ名を表す値オブジェクトの単体テストを目的とする
#

#
# インスタンス生成(コンストラクタ)のテストシナリオ
#
Scenario: 30文字以内のカテゴリ名を保持したインスタンスが生成される
	Given 商品カテゴリ名を用意する '文房具'
	When CategoryNameを生成する
	Then CategoryNameの値は '文房具' である
Scenario: 空文字を用いてインスタンス生成するとValidateException例外をスローする
	Given 商品カテゴリ名を用意する '' 
	When CategoryNameを生成する
	Then ValidateExceptionがスローされる 'CategoryNameは必須です。'
Scenario: nullを用いてインスタンス生成するとValidateException例外をスローする
	Given 商品カテゴリ名を用意する 'null' 
	When CategoryNameを生成する
	Then ValidateExceptionがスローされる 'CategoryNameは必須です。'
Scenario: 30文字より大きい文字列でインスタンス生成するとValidateException例外をスローする
	Given 商品カテゴリ名を用意する '40cffd3bf63645c69a875c87ecb6f0000' 
	When CategoryNameを生成する
	Then ValidateExceptionがスローされる 'CategoryNameは30文字以内である必要があります。'
#
#	Equals()メソッド共通ステップのシナリオ
#
Scenario Outline: CategoryNameのEquals()メソッドを検証する
	Given 商品カテゴリ名を比較する値を用意する
		| value1	| value2	|
		| <value1>  | <value2>  |
	When Equalsメソッドを実行する
	And object型でEqualsメソッドを実行する
	Then Equalsメソッド実行結果を評価する
		| result   |
		| <result> |
	Examples:
		| value1  | value2	| result |
		| 文房具	  | 文房具	| true   |
		| 文房具	  | 雑貨		| false  |
#
#	GetHashCode()メソッド共通ステップのシナリオ
#
Scenario Outline: CategoryNameのGetHashCodeメソッドを検証する
    Given 商品カテゴリ名のハッシュ値を生成する値を用意する
        | value1	| value2	|
        | <value1>	| <value2>	|
    When GetHashCodeメソッドを実行する
    Then GetHashCodeメソッド実行結果の比較結果を評価する
		| result   |
		| <result> |
	Examples:
		| value1  | value2	| result |
		| 文房具	  | 文房具	| true   |
		| 文房具	  | 雑貨		| false  |

