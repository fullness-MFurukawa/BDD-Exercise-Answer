﻿Feature: ProductSearch
# このFeatureは、商品検索機能のE2Eテストを目的とする
# テスト対象:
# - 検索画面が正しく表示される
# - 検索結果が正しく表示される
# - キーワードを入力ぜずに[検索]ボタンをクリックするとエラーメッセージが表示される
# - 存在しないキーワードを入力して[検索]ボタンをクリックするとエラーメッセージが表示される
# - [終了]ボタンをクリックしてメニュー(トップ)に遷移する

Background: 
	Given 検索画面を表示するリクエストを送信する 'https://localhost:7066/exercise/product/search'

# 検索画面が正しく表示される
Scenario: 検索画面が提供されることを検証する
	When 検索画面が表示される
	Then キーワード入力項目と[検索]ボタンが表示されたことを評価する
# 検索結果が正しく表示される
@PDF
Scenario: 検索結果が正しく表示されることを検証する
	When キーワードを入力し [検索] ボタンをクリックする 'ボールペン' 
	Then 検索結果として以下の内容が表示されたことを評価する
	| Id								| Name				| Price	|
	| 69af403817e44691b748f6cde073f80c	| 水性ボールペン 赤	| 150	|
	| a4e942db87434d4985900ba14593e55f	| 水性ボールペン 黒	| 150	|
	| 6cb3976468344a71a6a5debe05abc5aa	| 水性ボールペン 青	| 150	|
	| fccb979a0d0b4c909a1898ada46fb2b1	| 油性ボールペン 赤	| 130	|
	| 18d30718efec45cbb644af2cf50c286f	| 油性ボールペン 黒	| 130	|
	| f073f7c3f35744ffbbdb3815e1d4b6c2	| 油性ボールペン 青	| 130	|
# キーワードを入力ぜずに[検索]ボタンをクリックするとエラーメッセージが表示される
@PDF
Scenario: キーワードを入力せずに[検索]ボタンをクリックした場合、エラーメッセージが表示されることを検証する
	When キーワードを入力せずに [検索] ボタンをクリックする
	Then エラーメッセージが表示されたことを評価する 'キーワードを入力してください。'

# 存在しないキーワードを入力して[検索]ボタンをクリックするとエラーメッセージが表示される
# 実装なし(他のステップと共通)
@PDF
Scenario: 存在しないキーワードを入力して検索ボタンをクリックした場合、エラーメッセージが表示されることを検証する
	When キーワードを入力し [検索] ボタンをクリックする 'ゴム' 
	Then エラーメッセージが表示されたことを評価する 'キーワード:ゴムを含む商品は見つかりませんでした。'

# [終了]ボタンをクリックしてメニュー(トップ)に遷移する
# 共通ステップ
@PDF
Scenario: [終了]ボタンをクリックしたら、メニュー画面に遷移することを検証する
	Given テスト対象のページリクエストを送信する 'https://localhost:7066/exercise/product/search'
	When [終了]ボタンをクリックする
	Then メニュー画⾯が表⽰されたことを評価する
