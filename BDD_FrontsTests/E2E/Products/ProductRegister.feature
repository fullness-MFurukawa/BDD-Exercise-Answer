﻿Feature: ProductRegister
# このFeatureは、商品登録機能の⼊⼒画⾯につてのE2Eテストを⽬的とする
# テスト対象:
# - 登録画⾯が正しく表⽰される
# - 存在しない商品を⼊⼒して[登録]ボタンをクリックすると、登録完了画⾯に遷移する
# - バリデーションメッセージが正しく表⽰される
# - 存在する商品を⼊⼒して[登録]ボタンをクリックすると、エラーメッセージが表⽰される
# - [終了]ボタンをクリックしてメニュー(トップ)に遷移する

Background:
Given 商品登録画⾯を表⽰するリクエストを送信する'https://localhost:7066/exercise/product/register/Enter'

@Video
Scenario: 商品登録画⾯が提供されることを検証する
When 商品登録画⾯が表⽰される
Then ⼊⼒に必要な項⽬が表⽰されていることを評価する
	| pageTitle					| 商品登録		|
	| titleText					| 商品登録		|
	| productName_placeholder	| 商品名を入力	|
	| productPrice_placeholder	| 単価を入力		|
	| register_btn				| 登録			|
	| end_btn					| 終了			|
	| category_options			| カテゴリを選択,文房具,雑貨,PC周辺機器 |
@Restoring @Video
Scenario: 登録されていない商品を登録すると完了画⾯に遷移することを検証する
When すべての⼊⼒項⽬に値を⼊⼒して[登録]ボタンをクリックする '消しゴム' '120' '文房具'
Then 以下のメッセージが表⽰される
	| 以下の商品を登録しました。	|
	| 商品:消しゴム 単価:120		|
#
# - [終了]ボタンをクリックしてメニュー(トップ)に遷移する
#
@Video
Scenario: 終了ボタンをクリックしたら、メニュー画⾯に遷移することを検証する
Given テスト対象のページリクエストを送信する 'https://localhost:7066/exercise/product/register/Enter'
When [終了]ボタンをクリックする
Then メニュー画⾯が表⽰されたことを評価する

#
# - バリデーションメッセージが正しく表示される
#
@Video
Scenario: 必須入力項目のすべてが未入力で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する
    When 何も入力せずに[登録]ボタンをクリックする
    Then 以下のエラーメッセージが表示される
    | 商品名を入力してください		|
    | 単価を入力してください		|
    | カテゴリを選択してください	|
@Video
Scenario: 商品名が未入力で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する
	When 単価を入力してカテゴリを選択たら[登録]ボタンをクリックする　'100' '文房具'
	Then 以下のエラーメッセージが表示される
    | 商品名を入力してください		|
@Video
Scenario: 単価が未入力で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する
	When 商品名を入力してカテゴリを選択たら[登録]ボタンをクリックする　'消しゴム' '文房具'
	Then 以下のエラーメッセージが表示される
    | 単価を入力してください		|
@Video
Scenario: カテゴリが未選択で[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する
	When 商品名と単価を入力して[登録]ボタンをクリックする　'消しゴム' '100'
	Then 以下のエラーメッセージが表示される
    | カテゴリを選択してください	|
#
# 存在する商品を入力して[登録]ボタンをクリックすると、エラーメッセージが表示される
# 
@Video
Scenario: 登録済みの商品名を入力して[登録]ボタンをクリックすると、エラーメッセージが表示されることを検証する
	When すべての⼊⼒項⽬に値を⼊⼒して[登録]ボタンをクリックする '蛍光ペン 黄' '180' '文房具'
	Then 以下のエラーメッセージが表示される
    | 商品名:蛍光ペン 黄は、既に登録済みです。	|