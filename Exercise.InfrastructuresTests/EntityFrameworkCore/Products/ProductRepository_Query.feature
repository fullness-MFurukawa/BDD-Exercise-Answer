@InfraDependency
Feature: ProductRepository_Query
#
# このFeatureは、永続化層から商品をCRUD操作するRepositoryインターフェイスの実装の
# 問合せメソッドの単体テストを目的とする
# テスト対象:
# - FindById(): 指定されたIdの商品を取得する
# - FindByNameContains(): 指定された商品キーワードに該当する商品を取得する
# - Exists():指定された商品名の存在有無を取得する

#
# - FindById(): 指定されたIdの商品を取得する
#
Scenario: 存在する商品Idで商品を取得できることを検証する
	Given 商品Idを用意する 'f073f7c3f35744ffbbdb3815e1d4b6c2'
	When 商品Idで商品を取得する
	Then 商品Idで取得した結果を評価する
	"""
    Id: f073f7c3f35744ffbbdb3815e1d4b6c2
    Name: 油性ボールペン 青
    Price: 130
	"""
Scenario: 存在しない商品Idで商品を検索するとnullであることを検証する
	Given 商品Idを用意する 'f073f7c3f35744ffbbdb3815e1d4b6c3'
	When 商品Idで商品を取得する
	Then 商品Idで取得した結果がnullであることを評価する
#
# - FindByNameContains(): 指定された商品キーワードに該当する商品を取得する
#
Scenario: 存在する商品のキーワードで商品を取得できることを検証する
	Given キーワードを用意する '色鉛筆'
	When キーワードで商品を取得する
	Then キーワードで取得した結果を評価する
	"""
    - Id: 6e8e29883c1d43d6b0f67e2808870643
      Name: 色鉛筆 12色
      Price: 900
      CategoryId: 40cffd3bf63645c69a875c87ecb6f200
      CategoryName: 文房具
    - Id: 292ceaf0f03546e1b20b723244c1f67f
      Name: 色鉛筆 24色
      Price: 1800
      CategoryId: 40cffd3bf63645c69a875c87ecb6f200
      CategoryName: 文房具
    - Id: d4c3b32d292b40b1bc2533fc5f1ec332
      Name: 色鉛筆 36色
      Price: 2600
      CategoryId: 40cffd3bf63645c69a875c87ecb6f200
      CategoryName: 文房具
	"""
Scenario: 存在しない商品のキーワードで商品を検索するとnullであることを検証する
	Given キーワードを用意する '消しゴム'
	When キーワードで商品を取得する
	Then キーワードで取得した結果がnullであることを評価する
#
# - Exists():指定された商品名の存在有無を取得する
#
Scenario: 指定された商品名が存在することを検証する
	Given 商品名を用意する '蛍光ペン 黄'
	When 存在を調べる
	Then 結果が返されることを評価する 'true'
Scenario: 指定された商品名が存在しないことを検証する
	Given 商品名を用意する '蛍光ペン 黒'
	When 存在を調べる
	Then 結果が返されることを評価する 'false'
