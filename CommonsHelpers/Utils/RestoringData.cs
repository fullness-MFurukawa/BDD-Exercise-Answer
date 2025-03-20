using Exercise.Infrastructures.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace CommonsHelpers.Utils;
/// <summary>
/// テストデータ復元ユーティリティクラス
/// 提供
/// </summary>
public class RestoringData
{
    private readonly string _sqlFilePath;
    private readonly AppDbContext _appDbContext;
    private readonly ILogger<RestoringData> _logger;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="sqlFilePath">SQLファイルパス</param>
    /// <param name="appDbContext">AppDbContext</param>
    /// <param name="logger">ロガー</param>
    public RestoringData(AppDbContext appDbContext, ILogger<RestoringData> logger)
    {
        // プロジェクトルートディレクトリを基準にパスを組み立てる
        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\CommonsHelpers"));
        _sqlFilePath = Path.Combine(projectRoot, "Utils", "RestoringData.sql");
        _appDbContext = appDbContext;
        _logger = logger;
    }

    /// <summary>
    /// データの復元
    /// </summary>
    public void Restoring()
    {
        try
        {
            if (!File.Exists(_sqlFilePath))
            {
                _logger.LogError($"RestoringData.SQLが見つかりません: {_sqlFilePath}");
                return;
            }
            var sql = File.ReadAllText(_sqlFilePath);
            _appDbContext.Database.ExecuteSqlRaw(sql);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "データ復元中にエラーが発生しました");
        }
    }

    /// <summary>
    /// データの復元（非同期）
    /// </summary>
    public async Task RestoringAsync()
    {
        // プロジェクトルートディレクトリを基準にパスを組み立てる
        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\CommonsHelpers"));
        var path = Path.Combine(projectRoot, "Utils", "RestoringData.sql");
        Console.WriteLine(path);
        try
        {
            if (!File.Exists(_sqlFilePath))
            {
                _logger.LogError($"RestoringData.SQLが見つかりません: {_sqlFilePath}");
                return;
            }
            var sql = await File.ReadAllTextAsync(_sqlFilePath);
            await _appDbContext.Database.ExecuteSqlRawAsync(sql);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "データ復元中にエラーが発生しました");
        }
    }
}
