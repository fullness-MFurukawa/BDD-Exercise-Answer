@AppDependency
Feature: ProductUpdateService
#
# このFeatureは、商品変更サービスのIProductUpdateServiceインターフェイス実装の
# 結合テストを目的とする
#
# 結合対象: IProductRepositoryインターフェイスの実装 
# テスト対象:
# - GetProduct: 指定された商品Idの商品を返す
# - Execute: 商品を変更する

#
# - GetProduct: 指定されたキーワードで商品検索した結果を返す
#
Scenario: 存在する商品Idの商品を取得する
	Given 商品Idを用意する '6e8e29883c1d43d6b0f67e2808870643'
	When 用意した商品Idで対象商品を取得する
	Then 用意した商品Idで取得した商品を評価する
	"""
    Id: 6e8e29883c1d43d6b0f67e2808870643
    Name: 色鉛筆 12色
    Price: 900
	"""
Scenario: 存在しない商品Idの商品を取得するとNotFoundExceptionがスローされることを検証する
	Given 商品Idを用意する '6e8e29883c1d43d6b0f67e2808870645'
	When 用意した商品Idで対象商品を取得する
	Then NotFoundExceptionがスローされたことを評価する '商品Id:6e8e29883c1d43d6b0f67e2808870645に一致する商品が見つかりませんでした。'

#
# - Execute: 商品を変更する
#
@Restoring
Scenario: 存在する商品の商品名と単価を変更する
	Given 変更商品を用意する
	"""
    Id: 6e8e29883c1d43d6b0f67e2808870643
    Name: 色鉛筆 15色
    Price: 1200
	"""
	When 商品名と単価を変更する
	Then 変更した商品を取得して変更結果を評価する
Scenario: 存在しない商品を変更するとNotFoundExceptionがスローされることを検証する
	Given 変更商品を用意する
	"""
    Id: 6e8e29883c1d43d6b0f67e2808870645
    Name: 色鉛筆 15色
    Price: 1200
	"""
	When 商品名と単価を変更する
	Then NotFoundExceptionがスローされたことを評価する '商品Id:6e8e29883c1d43d6b0f67e2808870645に一致する商品が見つからないため、変更は失敗しました。'