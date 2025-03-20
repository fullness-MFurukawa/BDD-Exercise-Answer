@AppDependency
Feature: ProductRegisterService
#
# このFeatureは、商品登録サービスのIProductRegistererviceインターフェイス実装の
# 結合テストを目的とする
#
# 結合対象: 
#	IProductRepositoryインターフェイスの実装 
#	ICategoryRepositoryインターフェイスの実装
# テスト対象:
# - GetCategories: すべてのカテゴリを返す
# - GetCategory: 指定されたカテゴリIDのカテゴリを返す
# - Exists: 商品の有無を調べる
# - Register: 新商品を登録する

#
# - GetCategories: すべてのカテゴリを返す
#
Scenario: すべての商品カテゴリが取得できることを確認する
	Given 取得する商品カテゴリを準備する
	"""
    - Id: 40cffd3bf63645c69a875c87ecb6f200
      Name: 文房具
    - Id: 0fc3f7819af345009d018c0ded8a94ee
      Name: 雑貨
    - Id: 9a66b0c5c7b0407684fb0a92eca871d9
      Name: PC周辺機器
	"""
	When すべての商品カテゴリを取得する
	Then すべての商品カテゴリが取得できたことを評価する

#
# - GetCategory: 指定された商品カテゴリIdの商品カテゴリを返す
#
Scenario: 存在する商品カテゴリIdでカテゴリが取得できることを検証する
    Given 商品カテゴリIdを用意する '0fc3f7819af345009d018c0ded8a94ee'
    When 用意した商品カテゴリIdでカテゴリを取得する
    Then 取得した商品カテゴリを評価する
    """
    Id: 0fc3f7819af345009d018c0ded8a94ee
    Name: 雑貨
	"""
Scenario: 存在しない商品カテゴリIdで取得するとNotFoundExceptionがスローされることを検証する
    Given 商品カテゴリIdを用意する '0fc3f7819af345009d018c0ded8a94ea'
    When 用意した商品カテゴリIdでカテゴリを取得する
    Then NotFoundExceptionがスローされたことを評価する '商品カテゴリId:0fc3f7819af345009d018c0ded8a94eaの商品カテゴリは見つかりませんでした。'
#
# - Exists: 商品の有無を調べる
#
Scenario: 存在しない商品名を指定するとExistsExceptionがスローされないことを検証する
    Given 商品名を用意する '砂消しゴム'
    When 商品名の有無を調べる
    Then ExistsExceptionがスローされないことを評価する
Scenario: 存在する商品名を指定するとExistsExceptionがスローされることを検証する
    Given 商品名を用意する '色鉛筆 36色'
    When 商品名の有無を調べる
    Then ExistsExceptionがスローされたことを評価する '商品名:色鉛筆 36色は、既に登録済みです。'

#
# - Register: 新商品を登録する
#
@Restoring
Scenario: 存在しない商品が登録できることを検証する
    Given 新商品を用意する
    """
    Id: d4c3b32d292b40b1bc2533fc5f1ec330
    Name: 消しゴム
    Price: 120
    CategoryId: 40cffd3bf63645c69a875c87ecb6f200
    CategoryName: 文房具
	"""
    When 新商品を登録する
    Then 商品が登録されていることを商品名の有無で評価する

