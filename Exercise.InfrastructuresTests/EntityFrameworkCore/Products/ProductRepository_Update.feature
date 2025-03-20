@InfraDependency
Feature: ProductRepository_Update
#
# このFeatureは、商品をCRUD操作するRepositoryインターフェイスの実装の更新メソッドの単体テストを目的とする
# テスト対象:
# - Create():商品を永続化する
# - UpdateById():指定された商品Idの商品を変更する
# - DeleteById():指定された商品Idの商品を削除する

#
# - Create():商品を永続化する
#
@Transaction
Scenario: 新しい商品を永続化し、永続化結果を返すことを検証する
	Given 新しい商品を用意する
	"""
    Id: d4c3b32d292b40b1bc2533fc5f1ec335
    Name: 消しゴム
    Price: 120
    CategoryId: 40cffd3bf63645c69a875c87ecb6f200
    CategoryName: 文房具
	"""
	When 新しい商品を永続化する
	Then 商品が永続化されたことを評価する
#
# - UpdateById():指定された商品Idの商品を変更する
#
@Transaction
Scenario: 存在する商品を変更し、変更結果を返すことを検証する
	Given 変更商品を用意する
    """
    Id: 522486256c9948ffbe9f344ac7e8aaab
    Name: 蛍光ペン 黄
    Price: 150
    CategoryId: 40cffd3bf63645c69a875c87ecb6f200
    CategoryName: 文房具
    """
	When 商品を変更する
	Then 商品名と単価が変更されたことを評価する '蛍光ペン 黄' '150'　
@Transaction
Scenario: 存在しない商品を変更するとnullが返されることを検証する
	Given 変更商品を用意する
    """
    Id: 522486256c9948ffbe9f344ac7e8aaaa
    Name: 蛍光ペン 黄
    Price: 150
    CategoryId: 40cffd3bf63645c69a875c87ecb6f200
    CategoryName: 文房具
    """
	When 商品を変更する
	Then 変更されずnullが返されることを評価する
#
# - DeleteById():指定された商品Idの商品を削除する
#
@Transaction
Scenario: 存在する商品Idの商品を削除し、削除した商品を返すことを検証する
	Given 削除対象の商品Idを用意する 'f073f7c3f35744ffbbdb3815e1d4b6c2'
	When 商品を削除する
	Then 削除された商品が返されることを評価する
    """
    Id: f073f7c3f35744ffbbdb3815e1d4b6c2
    Name: 油性ボールペン 青
    Price: 130
    """
@Transaction
Scenario: 存在しない商品Idの商品を削除するとnullがことを検証する
	Given 削除対象の商品Idを用意する 'f073f7c3f35744ffbbdb3815e1d4b6c5'
	When 商品を削除する
    Then 削除されずnullが返されることを評価する