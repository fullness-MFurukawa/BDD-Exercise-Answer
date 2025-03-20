Feature: ExceptionHandlingMiddleware
# このFeatureは、例外ハンドリングミドルウェアのテストを目的とする
# テスト対象:
# - InternalExceptionが発生した場合にエラーページにリダイレクトされる
# - 例外が発生しない場合に次のデリゲートが呼び出される

# - InternalExceptionが発生した場合にエラーページにリダイレクトされる
Scenario: InternalExceptionが発生した場合にエラーページにリダイレクトされる
    Given ミドルウェアのセットアップ
    When ミドルウェアがInternalExceptionをスローする
    And ミドルウェアを呼び出す
    Then レスポンスはエラーページにリダイレクトされる
# - 例外が発生しない場合に次のデリゲートが呼び出される
Scenario: 例外が発生しない場合に次のデリゲートが呼び出される
    Given ミドルウェアのセットアップ
    When ミドルウェアが例外をスローしない
    And ミドルウェアを呼び出す
    Then 次のデリゲートが呼び出される
