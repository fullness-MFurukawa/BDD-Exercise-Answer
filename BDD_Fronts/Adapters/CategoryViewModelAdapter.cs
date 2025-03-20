using BDD_Fronts.Models.Categories;
using Exercise.Domains.Models.Categories;

namespace BDD_Fronts.Adapters;
/// <summary>
/// CategoryからCategoryViewModelの変換と
/// Categoryへ復元するAdapterインターフェイスの実装
/// 提供
/// </summary>
public class CategoryViewModelAdapter : ICategoryAdapter<CategoryViewModel>
{
    public CategoryViewModel Convert(Category category)
    {
        var model = new CategoryViewModel();
        model.CategoryId = category.Id.Value;
        model.CategoryName = category.Name.Value;
        return model;
    }
    public List<CategoryViewModel> ConvertList(List<Category> categories)
    {
        var list = new List<CategoryViewModel>();
        foreach (var category in categories)
        {
            list.Add(Convert(category));
        }
        return list;
    }
    public Category Restore(CategoryViewModel model)
    {
        var categoryId = new CategoryId(model.CategoryId!);
        var categoryName = new CategoryName(model.CategoryName!);
        return new Category(categoryId, categoryName);
    }
    public List<Category> RestoreList(List<CategoryViewModel> models)
    {
        var list = new List<Category>();
        foreach (var model in models)
        {
            list.Add(Restore(model));
        }
        return list;
    }
}
