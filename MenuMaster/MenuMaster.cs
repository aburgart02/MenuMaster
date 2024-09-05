namespace MenuMaster;

public class MenuMaster
{
    private readonly List<Dish> _dishes;
    private readonly int _dishesOnPage;

    public MenuMaster(List<Dish> dishes, int dishesOnPage)
    {
        if (dishesOnPage < 1)
        {
            throw new ArgumentException("Dishes on page number should be greater than or equal to 1");
        } 
        _dishes = dishes ?? throw new ArgumentException("Dishes shouldn't be null");
        _dishesOnPage = dishesOnPage;
    }

    public int GetDishesCount() => _dishes.Count;

    public int GetPagesCount() => _dishes.Count / _dishesOnPage + (_dishes.Count % _dishesOnPage != 0 ? 1 : 0);

    public int GetDishesCountOnPage(int pageNumber)
    {
        ValidatePageNumber(pageNumber);

        return Math.Min(_dishes.Count - (pageNumber - 1) * _dishesOnPage, _dishesOnPage);
    }

    public List<Dish> GetDishesOnPage(int pageNumber)
    {
        ValidatePageNumber(pageNumber);
        
        return _dishes.Skip((pageNumber - 1) * _dishesOnPage).Take(_dishesOnPage).ToList();
    }

    public List<Dish> GetFirstDishesOnEachPage() => Enumerable.Range(0, GetPagesCount())
        .Select(i => _dishes[i * _dishesOnPage]).ToList();

    private void ValidatePageNumber(int pageNumber)
    {
        var pagesCount = GetPagesCount();
        if (pageNumber < 1 || pageNumber > pagesCount)
        {
            throw new ArgumentException("Invalid page number");
        }
    }
}