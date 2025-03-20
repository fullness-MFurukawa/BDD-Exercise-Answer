Feature: Category
#
# このFeatureは、Categoryエンティティの単体テストを目的とする
#

#
# インスタンス生成テストシナリオ
#
Scenario: 新しい商品カテゴリの生成を検証する
	Given 新しい商品カテゴリを用意する '食品'
	When 新しいCategoryを生成する
	Then 新しい商品カテゴリIdを持ったカテゴリが生成されていることを評価する '食品'

Scenario: 商品カテゴリ名をnullで新しいカテゴリの生成を検証する
	Given 新しい商品カテゴリを用意する 'null'
	When 新しいCategoryを生成する
	Then ValidateExceptionがスローされる 'CategoryNameは必須です。'

Scenario: 既存商品カテゴリの生成を検証する
	Given 既存商品カテゴリを用意する
	| id								| name	|
	| 40cffd3bf63645c69a875c87ecb6f200	| 文房具	|
	When 既存のCategoryを生成する
	Then 商品カテゴリIdと商品カテゴリ名は以下と等価であることを評価する
	| id								| name	|
	| 40cffd3bf63645c69a875c87ecb6f200	| 文房具	|
Scenario: カテゴリIdをnullで既存カテゴリの生成を検証する
	Given 既存商品カテゴリを用意する
	| id	| name	|
	| null	| 文房具	|
	When 既存のCategoryを生成する
	Then ValidateExceptionがスローされる 'CategoryIdは必須です。'
Scenario: 商品カテゴリ名をnullで既存カテゴリの生成を検証する
	Given 既存商品カテゴリを用意する
	| id								| name	|
	| 40cffd3bf63645c69a875c87ecb6f200	| null	|
	When 既存のCategoryを生成する
	Then ValidateExceptionがスローされる 'CategoryNameは必須です。'

#
#	ChangeName()メソッドのテストシナリオ
#
Scenario: 新しい商品カテゴリの生成し、カテゴリ名変更を検証する
	Given 新しい商品カテゴリを用意する '食品'
	When 商品カテゴリ名を変更する '台所用品'
	Then 商品カテゴリ名が変更されていることを検証する '台所用品'
Scenario: 新しい商品カテゴリの生成し、カテゴリ名をnullで変更する
	Given 新しい商品カテゴリを用意する '食品'
	When 商品カテゴリ名を変更する 'null'
	Then ValidateExceptionがスローされる 'CategoryNameは必須です。'

Scenario: 既存商品カテゴリの生成し、カテゴリ名変更を検証する
	Given 既存商品カテゴリを用意する
	| id								| name	|
	| 40cffd3bf63645c69a875c87ecb6f200	| 文房具	|
	When 商品カテゴリ名を変更する '台所用品'
	Then 商品カテゴリ名が変更されていることを検証する '台所用品'
Scenario: 既存商品カテゴリの生成し、カテゴリ名をnullで変更する
	Given 既存商品カテゴリを用意する
	| id								| name	|
	| 40cffd3bf63645c69a875c87ecb6f200	| 文房具	|
	When 商品カテゴリ名を変更する 'null'
	Then ValidateExceptionがスローされる 'CategoryNameは必須です。'

#
# Equals()メソッドのテストシナリオ
#
Scenario Outline: CategoryのEqualsメソッド()を検証する
	Given 比較対象の商品カテゴリを用意する
	| id1   | name1   | id2   | name2   |
	| <id1> | <name1> | <id2> | <name2> |
	When Equalsメソッドを実行する
	And object型でEqualsメソッドを実行する
	Then Equalsメソッド実行結果を評価する
	| result   |
	| <result> |
Examples: 
| id1								| name1 | id2								| name2 | result|
| 40cffd3bf63645c69a875c87ecb6f200	| 文房具	| 40cffd3bf63645c69a875c87ecb6f200	| 文房具	| true	|
| 40cffd3bf63645c69a875c87ecb6f201	| 文房具	| 40cffd3bf63645c69a875c87ecb6f200	| 文房具	| false	|
#
# GetHashCode()メソッドのテストシナリオ
#
Scenario Outline: CategoryのGetHashCode()メソッドを検証する
    Given ハッシュ値を生成する商品カテゴリを用意する
    | id1   | name1   | id2   | name2   |
	| <id1> | <name1> | <id2> | <name2> |
    When GetHashCodeメソッドを実行する
    Then GetHashCodeメソッド実行結果の比較結果を評価する
	| result   |
	| <result> |
Examples: 
| id1								| name1 | id2								| name2 | result|
| 40cffd3bf63645c69a875c87ecb6f200	| 文房具	| 40cffd3bf63645c69a875c87ecb6f200	| 文房具	| true	|
| 40cffd3bf63645c69a875c87ecb6f201	| 文房具	| 40cffd3bf63645c69a875c87ecb6f200	| 文房具	| false	|
