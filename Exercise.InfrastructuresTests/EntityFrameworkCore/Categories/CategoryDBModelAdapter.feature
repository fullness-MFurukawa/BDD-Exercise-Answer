@InfraDependency
Feature: CategoryDBModelAdapter
#
# このFeatureは、CategoryとCategoryDBModelの相互変換メソッドの単体テストを⽬的とする
#

#
# CategoryからCategoryDBModelを変換する
#
Scenario: CategoryをCategoryDBModelに変換する
	Given Categoryを⽤意する
	"""
	{
		"Id": "40cffd3bf63645c69a875c87ecb6f200",
		"Name": "⽂房具"
	}
	"""
	When CategoryをCategoryModelに変換する
	Then CategoryDBModelのプロパティを検証する
	"""
	{
		"Id": "40cffd3bf63645c69a875c87ecb6f200",
		"Name": "⽂房具"
	}
	"""
Scenario: CategoryのリストをCategoryDBModelのリストに変換する
	Given Categoryのリストを⽤意する
	"""
	[
		{
			"Id": "40cffd3bf63645c69a875c87ecb6f200",
			"Name": "⽂房具"
		},
		{
			"Id": "0fc3f7819af345009d018c0ded8a94ee",
			"Name": "雑貨"
		},
		{
			"Id": "9a66b0c5c7b0407684fb0a92eca871d9",
			"Name": "PC周辺機器"
		}
	]
	"""
	When CategoryのリストをCategoryModelのリストに変換する
	Then リスト内のCategoryDBModelのプロパティを検証する
	"""
	[
		{
			"Id": "40cffd3bf63645c69a875c87ecb6f200",
			"Name": "⽂房具"
		},
		{
			"Id": "0fc3f7819af345009d018c0ded8a94ee",
			"Name": "雑貨"
		},
		{
			"Id": "9a66b0c5c7b0407684fb0a92eca871d9",
			"Name": "PC周辺機器"
		}
	]
	"""
#
# CategoryDBModelからCategoryを復元する
#
Scenario: CategoryDBModelからCategoryを復元する
	Given CategoryDBModelを⽤意する
	"""
	{
		"Id": "40cffd3bf63645c69a875c87ecb6f200",
		"Name": "⽂房具"
	}
	"""
	When CategoryModelからCategoryを復元する
	Then Categoryのプロパティを検証する
	"""
	{
		"Id": "40cffd3bf63645c69a875c87ecb6f200",
		"Name": "⽂房具"
	}
	"""
Scenario: CategoryDBModelのリストからCategoryのリストを復元する
	Given CategoryDBModelのリストを⽤意する
	"""
	[
		{
			"Id": "40cffd3bf63645c69a875c87ecb6f200",
			"Name": "⽂房具"
		},
		{
			"Id": "0fc3f7819af345009d018c0ded8a94ee",
			"Name": "雑貨"
		},
		{
			"Id": "9a66b0c5c7b0407684fb0a92eca871d9",
			"Name": "PC周辺機器"
		}
	]
	"""
	When CategoryDBModelのリストからCategoryのリストを復元する
	Then リスト内のCategoryのプロパティを検証する
	"""
	[
		{
			"Id": "40cffd3bf63645c69a875c87ecb6f200",
			"Name": "⽂房具"
		},
		{
			"Id": "0fc3f7819af345009d018c0ded8a94ee",
			"Name": "雑貨"
		},
		{
			"Id": "9a66b0c5c7b0407684fb0a92eca871d9",
			"Name": "PC周辺機器"
		}
	]
	"""