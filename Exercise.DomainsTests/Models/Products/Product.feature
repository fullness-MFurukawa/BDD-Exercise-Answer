Feature: Product
#
# このFeatureは、エンティティProductの単体テストを目的とする
#

#
# インスタンス生成テストシナリオ
#
Scenario: 新しい商品の生成を検証する
	Given 新しい商品名、単価、カテゴリを用意する
	| name		| price		| category_id	| category_name		|
	| <name>	| <price>	| <category_id>	| <category_name>	|
	When 新しいProductを生成する
	Then 新しい商品Idを持った商品が生成されていることを評価する
	| name		| price		| category_id	| category_name		|
	| <name>	| <price>	| <category_id>	| <category_name>	|
Examples:
	| name		| price | category_id						| category_name |
	|  消しゴム	| 130   | 40cffd3bf63645c69a875c87ecb6f200	| 文房具			|
Scenario: 商品名をnullで新しい商品の生成を検証する
	Given 新しい商品名、単価、カテゴリを用意する
	| name		| price | category_id						| category_name |
	|  null		| 130   | 40cffd3bf63645c69a875c87ecb6f200	| 文房具			|
	When 新しいProductを生成する
	Then ValidateExceptionがスローされる 'ProductNameは必須です。'
Scenario: 商品単価をnullで新しい商品の生成を検証する
	Given 新しい商品名、単価、カテゴリを用意する
	| name		| price | category_id						| category_name |
	| 消しゴム	| null  | 40cffd3bf63645c69a875c87ecb6f200	| 文房具			|
	When 新しいProductを生成する
	Then ValidateExceptionがスローされる 'ProductPriceは必須です。'

Scenario: 既存商品の生成を検証する
	Given 既存商品のId、商品名、単価、カテゴリを用意する
	| id	| name	| price		| category_id	| category_name		|
	| <id>	| <name>| <price>	| <category_id> | <category_name>	|
	When 既存の商品を生成する
	Then 商品ID、商品名、単価、カテゴリは以下と等価であることを評価する
	| id	| name	| price		| category_id	| category_name		|
	| <id>	| <name>| <price>	| <category_id> | <category_name>	|	
Examples:
| id                               | name				| price | category_id                      | category_name |
| a4e942db87434d4985900ba14593e55f | 水性ボールペン 赤	| 150   | 40cffd3bf63645c69a875c87ecb6f200 | 文房具			|
Scenario: 商品IDをnullで既存商品の生成を検証する
	Given 既存商品のId、商品名、単価、カテゴリを用意する
	| id   | name				| price | category_id                      | category_name |
	| null | 水性ボールペン 赤	| 150   | 40cffd3bf63645c69a875c87ecb6f200 | 文房具		   |
	When 既存の商品を生成する
	Then ValidateExceptionがスローされる 'ProductIdは必須です。'


Rule: ChangeName()メソッド、ChangePrice()メソッド共有テストデータの作成
	Background: 
		Given 新しい商品名、単価、カテゴリを用意する
		| name		| price | category_id						| category_name |
		| 消しゴム	| 130	| 40cffd3bf63645c69a875c87ecb6f200	| 文房具			|
#
#	ChangeName()メソッドのテストシナリオ
#
	Scenario: 新しい商品を生成し、商品名変更を検証する
		When 商品名を変更する '砂消しゴム'
		Then 商品名が変更されていることを検証する '砂消しゴム'
	Scenario: 新しい商品を生成し、商品名をnullで変更を検証する
		When 商品名を変更する 'null'
		Then ValidateExceptionがスローされる 'ProductNameは必須です。'
#
#	ChangePrice()メソッドのテストシナリオ
#
	Scenario: 新しい商品を生成し、商品単価変更を検証する
		When 商品単価を変更する '140'
		Then 商品単価が変更されていることを検証する '140'
	Scenario: 新しい商品を生成し、商品単価をnullで変更を検証する
		When 商品単価を変更する 'null'
		Then ValidateExceptionがスローされる 'ProductPriceは必須です。'

#
# Equals()メソッドのテストシナリオ
#
Scenario Outline: ProductのEqualsメソッド()を検証する
	Given 比較対象の商品を用意する
	| id1   | name1   | price1   | id2   | name2   | price2   |
	| <id1> | <name1> | <price1> | <id2> | <name2> | <price2> |
	When Equalsメソッドを実行する
	And object型でEqualsメソッドを実行する
	Then Equalsメソッド実行結果を評価する
	| result   |
	| <result> |
Examples: 
| id1                              | name1	 | price1 | id2                              | name2	   | price2 | result |
| 522486256c9948ffbe9f344ac7e8aaab | 消しゴム | 120	  | 522486256c9948ffbe9f344ac7e8aaab | 消しゴム  | 120   | true   |
| 522486256c9948ffbe9f344ac7e8aaab | 消しゴム | 120	  | 522486256c9948ffbe9f344ac7e8aaac | 鉛筆	   | 100  | false  |

#
# GetHashCode()メソッドのテストシナリオ
#
Scenario Outline: ProductのGetHashCode()メソッドを検証する
    Given ハッシュ値を生成する商品を用意する
	| id1   | name1   | price1   | id2   | name2   | price2   |
	| <id1> | <name1> | <price1> | <id2> | <name2> | <price2> |
    When GetHashCodeメソッドを実行する
    Then GetHashCodeメソッド実行結果の比較結果を評価する
		| result   |
		| <result> |
Examples: 
| id1                              | name1	 | price1 | id2                              | name2	   | price2 | result |
| 522486256c9948ffbe9f344ac7e8aaab | 消しゴム | 120	  | 522486256c9948ffbe9f344ac7e8aaab | 消しゴム  | 120   | true   |
| 522486256c9948ffbe9f344ac7e8aaab | 消しゴム | 120	  | 522486256c9948ffbe9f344ac7e8aaac | 鉛筆	   | 100  | false  |
