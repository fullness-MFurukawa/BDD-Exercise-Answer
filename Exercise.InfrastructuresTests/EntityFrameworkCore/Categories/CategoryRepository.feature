@InfraDependency
Feature: CategoryRepository
#
# このFeatureは、永続化層から商品カテゴリをCRUD操作する
# Repositoryインターフェイスの実装の単体テストを⽬的とする
# テスト対象:
# - FindById: 指定されたIdの商品カテゴリを取得する
# - FindAll: すべての商品カテゴリを取得する

#
# 指定されたIdの商品カテゴリを取得する
# テストデータや評価データはYAML形式になっている
#
Scenario: 存在する商品カテゴリIdでカテゴリを取得できることを検証する
    Given 商品カテゴリIdを⽤意する '40cffd3bf63645c69a875c87ecb6f200'
	When ⽤意した商品カテゴリIdで商品カテゴリを取得する
	Then 取得した商品カテゴリを評価する
    """
      Id: "40cffd3bf63645c69a875c87ecb6f200"
      Name: "文房具"
    """
Scenario: 存在しない商品カテゴリIdで商品カテゴリを取得するとnullが返されることを検証する
	Given 商品カテゴリIdを⽤意する '40cffd3bf63645c69a875c87ecb6f201'
	When ⽤意した商品カテゴリIdで商品カテゴリを取得する
	Then 取得した商品カテゴリがnullであることを評価する
#
# すべての商品カテゴリを取得する
#
Scenario: すべての商品カテゴリを取得できることを検証する
    Given 取得する商品カテゴリを⽤意する
    """ 
    - Id: "40cffd3bf63645c69a875c87ecb6f200"
      Name: "文房具"
    - Id: "0fc3f7819af345009d018c0ded8a94ee"
      Name: "雑貨"
    - Id: "9a66b0c5c7b0407684fb0a92eca871d9"
      Name: "PC周辺機器"
    """
    When すべての商品カテゴリを取得する
    Then すべての商品カテゴリが取得されたことを評価する
