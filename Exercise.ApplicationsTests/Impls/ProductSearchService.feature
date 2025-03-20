@AppDependency
Feature: ProductSearchService
#
# このFeatureは、商品検索サービスのIProductSearchServiceインターフェイス実装の
# 結合テストを目的とする
#
# 結合対象: IProductRepositoryインターフェイスの実装 
# テスト対象:
# - Execute: 指定されたキーワードで商品検索した結果を返す

#
# - Execute: 指定されたキーワードで商品検索した結果を返す
#
Scenario: 商品が存在するキーワードで、目的の商品を検索できることを検証する
	Given 検索キーワードを用意する '蛍光'
	When キーワード検索する
	Then 検索結果を評価する
| Id                               | Name			| Price | CategoryId						| CategoryName  |
| 522486256c9948ffbe9f344ac7e8aaab | 蛍光ペン 黄		| 180   | 40cffd3bf63645c69a875c87ecb6f200  | 文房具			|
| 1b1ed3388786474c8a7204ca8ceda15c | 蛍光ペン 青		| 180   | 40cffd3bf63645c69a875c87ecb6f200	| 文房具			|
| 56b1b13551fe496290a98fc780b4453b | 蛍光ペン 緑		| 180   | 40cffd3bf63645c69a875c87ecb6f200	| 文房具			|
| 4c24e51b2ecd40579ae7b0a80bfe6162 | 蛍光ペン ピンク	| 180	| 40cffd3bf63645c69a875c87ecb6f200	| 文房具			|

Scenario: 商品が存在しないキーワードで、商品を検索するとNotFoundExceptionがスローされることを検証する
	Given 検索キーワードを用意する 'クリップ'
	When キーワード検索する
	Then NotFoundExceptionがスローされたことを評価する 'キーワード:クリップを含む商品は見つかりませんでした。'