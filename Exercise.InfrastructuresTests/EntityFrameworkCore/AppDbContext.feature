Feature: AppDbContext
#
# このFeatureは、AppDbContextのテストを⽬的とする
# 提供
#
Background:
	Given テスト⽤のデータベースコンテキストを初期化する
Scenario: カテゴリと商品を保存する
	When 新しいカテゴリと商品を保存する
	Then カテゴリと商品がデータベースに正しく保存されることを評価する
Scenario: 保存したカテゴリと商品を取得する
	Given 既存のカテゴリと商品がデータベースに存在する
	When カテゴリと商品を取得する
	Then カテゴリと商品が正しく取得されることを評価する
