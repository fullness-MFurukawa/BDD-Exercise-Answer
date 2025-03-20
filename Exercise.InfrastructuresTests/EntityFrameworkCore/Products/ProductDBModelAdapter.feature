@InfraDependency
Feature: ProductDBModelAdapter
#
# このFeatureは、ProductとEntityFramework CoreのProductDBModelの相互変換メソッドの
# 単体テストを目的とする
# テスト対象:
# - Convert:ProductをProductDBModelに変換する
# - ConvertList:List<Product>をList<ProductDBModel>に変換する
# - Restore:ProductDBModelからProductを復元する
# - RestoreList:List<ProductDBModel>からList<Product>を復元する

#
# - Convert:ProductをProductDBModelに変換する
#
Scenario: ProductをProductDBModelへの変換を検証する
	Given Categoryを保持したProductを用意する
	"""
	{
		"Id": "69af403817e44691b748f6cde073f80c",
        "Name": "水性ボールペン 赤",
		"Price": "150",
		"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
		"CategoryName":"文房具"
    }
	"""
	When ProductDBModelを生成する
	Then ProductDBModelのプロパティを検証する
	"""
	{
		"Id": "69af403817e44691b748f6cde073f80c",
        "Name": "水性ボールペン 赤",
		"Price": "150",
		"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
		"CategoryName":"文房具"
    }
	"""
Scenario: Product（Categoryを持たない）をProductDBModelへの変換を検証する
	Given Categoryを保持しないProductを用意する
	"""
	{
		"Id": "69af403817e44691b748f6cde073f80c",
        "Name": "水性ボールペン 赤",
		"Price": "150"
    }
	""" 
	When ProductDBModelを生成する
	Then CategoryDBModelを持たないProductDBModelのプロパティを検証する
	"""
	{
		"Id": "69af403817e44691b748f6cde073f80c",
        "Name": "水性ボールペン 赤",
		"Price": "150"
    }
	"""
#
# - Restore:ProductDBModelからProductを復元する
#
Scenario: ProductDBModelからProductを復元できることを検証する
	Given ProductDBModelを用意する
	"""
	{
		"Id": "69af403817e44691b748f6cde073f80c",
        "Name": "水性ボールペン 赤",
		"Price": "150",
		"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
		"CategoryName":"文房具"
    }
	"""
	When Productを復元する
	Then Productのプロパティを評価する
	"""
	{
		"Id": "69af403817e44691b748f6cde073f80c",
        "Name": "水性ボールペン 赤",
		"Price": "150",
		"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
		"CategoryName":"文房具"
    }
	"""
Scenario: ProductDBModelからProduct（Categoryを持たない)を復元できることを検証する
	Given CategoryDBModelを保持しないProductDBModelを用意する
	"""
	{
		"Id": "69af403817e44691b748f6cde073f80c",
        "Name": "水性ボールペン 赤",
		"Price": "150"
    }
	"""
	When Productを復元する
	Then Categoryを持たないProductのプロパティを評価する
	"""
	{
		"Id": "69af403817e44691b748f6cde073f80c",
        "Name": "水性ボールペン 赤",
		"Price": "150"
    }
	"""
#
# - ConvertList:List<Product>をList<ProductDBModel>に変換する
#
Scenario: ProductのリストをProductDBModelのリストへの変換を検証する
	Given Categoryを保持したProductのリストを用意する
	"""
	[
		{
			"Id": "69af403817e44691b748f6cde073f80c",
			"Name": "水性ボールペン 赤",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		},
		{
			"Id": "a4e942db87434d4985900ba14593e55f",
			"Name": "水性ボールペン 黒",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		},
		{
			"Id": "6cb3976468344a71a6a5debe05abc5aa",
			"Name": "水性ボールペン 青",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		}
	]
	"""
	When ProductのリストをProductDBModelのリストに変換する
	Then リスト内のProductDBModelのプロパティを評価する
	"""
	[
		{
			"Id": "69af403817e44691b748f6cde073f80c",
			"Name": "水性ボールペン 赤",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		},
		{
			"Id": "a4e942db87434d4985900ba14593e55f",
			"Name": "水性ボールペン 黒",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		},
		{
			"Id": "6cb3976468344a71a6a5debe05abc5aa",
			"Name": "水性ボールペン 青",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		}
	]
	"""
Scenario: ドメインProduct（Categoryを持たない）のリストをProductDBModelのリストへの変換を検証する
	Given Categoryを保持しないProductのリストを用意する
	"""
	[
		{
			"Id": "69af403817e44691b748f6cde073f80c",
			"Name": "水性ボールペン 赤",
			"Price": "150"
		},
		{
			"Id": "a4e942db87434d4985900ba14593e55f",
			"Name": "水性ボールペン 黒",
			"Price": "150"
		},
		{
			"Id": "6cb3976468344a71a6a5debe05abc5aa",
			"Name": "水性ボールペン 青",
			"Price": "150"
		}
	]
	"""
	When ProductのリストをProductDBModelのリストに変換する
	Then リスト内のCategoryDBModelを持たないProductDBModelのプロパティを評価する
	"""
	[
		{
			"Id": "69af403817e44691b748f6cde073f80c",
			"Name": "水性ボールペン 赤",
			"Price": "150"
		},
		{
			"Id": "a4e942db87434d4985900ba14593e55f",
			"Name": "水性ボールペン 黒",
			"Price": "150"
		},
		{
			"Id": "6cb3976468344a71a6a5debe05abc5aa",
			"Name": "水性ボールペン 青",
			"Price": "150"
		}
	]
	"""
#
# - RestoreList:List<ProductDBModel>からList<Product>を復元する
#
Scenario: ProductDBModelのリストからProductのリストへの復元を検証する
	Given CategoryDBModelを保持したProductDBModelのリストを用意する
	"""
	[
		{
			"Id": "69af403817e44691b748f6cde073f80c",
			"Name": "水性ボールペン 赤",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		},
		{
			"Id": "a4e942db87434d4985900ba14593e55f",
			"Name": "水性ボールペン 黒",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		},
		{
			"Id": "6cb3976468344a71a6a5debe05abc5aa",
			"Name": "水性ボールペン 青",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		}
	]
	"""
	When ProductDBModelのリストからProductのリストを復元する
	Then リスト内のドメインモデルProductのプロパティを評価する
	"""
	[
		{
			"Id": "69af403817e44691b748f6cde073f80c",
			"Name": "水性ボールペン 赤",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		},
		{
			"Id": "a4e942db87434d4985900ba14593e55f",
			"Name": "水性ボールペン 黒",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		},
		{
			"Id": "6cb3976468344a71a6a5debe05abc5aa",
			"Name": "水性ボールペン 青",
			"Price": "150",
			"CategoryId":"40cffd3bf63645c69a875c87ecb6f200",
			"CategoryName":"文房具"
		}
	]
	"""
Scenario: ProductDBModelのリスト（CategoryDBModelを持たない）からProductのリストへの復元を検証する
	Given CategoryDBModelを保持しないProductDBModelのリストを用意する
	"""
	[
		{
			"Id": "69af403817e44691b748f6cde073f80c",
			"Name": "水性ボールペン 赤",
			"Price": "150"
		},
		{
			"Id": "a4e942db87434d4985900ba14593e55f",
			"Name": "水性ボールペン 黒",
			"Price": "150"
		},
		{
			"Id": "6cb3976468344a71a6a5debe05abc5aa",
			"Name": "水性ボールペン 青",
			"Price": "150"
		}
	]
	"""
	When ProductDBModelのリストからProductのリストを復元する
	Then リスト内のCategoryを持たないProductのプロパティを評価する
	"""
	[
		{
			"Id": "69af403817e44691b748f6cde073f80c",
			"Name": "水性ボールペン 赤",
			"Price": "150"
		},
		{
			"Id": "a4e942db87434d4985900ba14593e55f",
			"Name": "水性ボールペン 黒",
			"Price": "150"
		},
		{
			"Id": "6cb3976468344a71a6a5debe05abc5aa",
			"Name": "水性ボールペン 青",
			"Price": "150"
		}
	]
	"""