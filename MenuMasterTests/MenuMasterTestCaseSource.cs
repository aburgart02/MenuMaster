using System.Collections.Generic;
using System.Linq;
using MenuMaster;
using NUnit.Framework;

namespace MenuMasterTests;

public class MenuMasterTestCaseSource
{
    private const int DishesOnPage = 4;

    private static readonly List<string> DishNames = new()
    {
        "bacon", "beef", "chicken", "duck", "ham",
        "lamb", "liver", "cabbage", "mutton", "beans",
        "carrot", "onion", "potato", "apple", "cherry",
        "melon", "orange"
    };

    private static readonly List<Dish> DishesWith0Items = new();
    private static readonly List<Dish> DishesWith1Items = DishNames.Take(1).Select(name => new Dish(name)).ToList();
    private static readonly List<Dish> DishesWith3Items = DishNames.Take(3).Select(name => new Dish(name)).ToList();
    private static readonly List<Dish> DishesWith4Items = DishNames.Take(4).Select(name => new Dish(name)).ToList();
    private static readonly List<Dish> DishesWith5Items = DishNames.Take(5).Select(name => new Dish(name)).ToList();
    private static readonly List<Dish> DishesWith10Items = DishNames.Take(10).Select(name => new Dish(name)).ToList();
    private static readonly List<Dish> DishesWith15Items = DishNames.Take(15).Select(name => new Dish(name)).ToList();
    private static readonly List<Dish> DishesWith16Items = DishNames.Take(16).Select(name => new Dish(name)).ToList();
    private static readonly List<Dish> DishesWith17Items = DishNames.Select(name => new Dish(name)).ToList();

    public static TestCaseData[] MenuMasterGetDishesCountCases =
    {
        new TestCaseData(DishesWith0Items, DishesOnPage, 0).SetName("Dishes with 0 elements"),
        new TestCaseData(DishesWith1Items, DishesOnPage, 1).SetName("Dishes with 1 element"),
        new TestCaseData(DishesWith3Items, DishesOnPage, 3).SetName("Dishes with 3 elements"),
        new TestCaseData(DishesWith4Items, DishesOnPage, 4).SetName("Dishes with 4 elements"),
        new TestCaseData(DishesWith5Items, DishesOnPage, 5).SetName("Dishes with 5 elements"),
        new TestCaseData(DishesWith10Items, DishesOnPage, 10).SetName("Dishes with 10 element"),
        new TestCaseData(DishesWith15Items, DishesOnPage, 15).SetName("Dishes with 15 elements"),
        new TestCaseData(DishesWith16Items, DishesOnPage, 16).SetName("Dishes with 16 elements"),
        new TestCaseData(DishesWith17Items, DishesOnPage, 17).SetName("Dishes with 17 elements"),
    };
    
    public static TestCaseData[] MenuMasterGetPagesCountCases =
    {
        new TestCaseData(DishesWith0Items, DishesOnPage, 0).SetName("Dishes with 0 elements"),
        new TestCaseData(DishesWith1Items, DishesOnPage, 1).SetName("Dishes with 1 element"),
        new TestCaseData(DishesWith3Items, DishesOnPage, 1).SetName("Dishes with 3 elements"),
        new TestCaseData(DishesWith4Items, DishesOnPage, 1).SetName("Dishes with 4 elements"),
        new TestCaseData(DishesWith5Items, DishesOnPage, 2).SetName("Dishes with 5 elements"),
        new TestCaseData(DishesWith10Items, DishesOnPage, 3).SetName("Dishes with 10 element"),
        new TestCaseData(DishesWith15Items, DishesOnPage, 4).SetName("Dishes with 15 elements"),
        new TestCaseData(DishesWith16Items, DishesOnPage, 4).SetName("Dishes with 16 elements"),
        new TestCaseData(DishesWith17Items, DishesOnPage, 5).SetName("Dishes with 17 elements"),
    };
    
    public static TestCaseData[] MenuMasterGetDishesCountOnPageCases =
    {
        new TestCaseData(DishesWith1Items, DishesOnPage, 1, 1).SetName("Dishes with 1 element"),
        new TestCaseData(DishesWith3Items, DishesOnPage, 1, 3).SetName("Dishes with 3 elements"),
        new TestCaseData(DishesWith4Items, DishesOnPage, 1, 4).SetName("Dishes with 4 elements"),
        
        new TestCaseData(DishesWith5Items, DishesOnPage, 1, 4).SetName("Dishes with 5 elements"),
        new TestCaseData(DishesWith5Items, DishesOnPage, 2, 1).SetName("Dishes with 5 elements"),
        
        new TestCaseData(DishesWith10Items, DishesOnPage, 1, 4).SetName("Dishes with 10 element"),
        new TestCaseData(DishesWith10Items, DishesOnPage, 3, 2).SetName("Dishes with 10 element"),
        
        new TestCaseData(DishesWith15Items, DishesOnPage, 1, 4).SetName("Dishes with 15 elements"),
        new TestCaseData(DishesWith15Items, DishesOnPage, 4, 3).SetName("Dishes with 15 elements"),
        
        new TestCaseData(DishesWith16Items, DishesOnPage, 1, 4).SetName("Dishes with 16 elements"),
        new TestCaseData(DishesWith16Items, DishesOnPage, 4, 4).SetName("Dishes with 16 elements"),
        
        new TestCaseData(DishesWith17Items, DishesOnPage, 1, 4).SetName("Dishes with 17 elements"),
        new TestCaseData(DishesWith17Items, DishesOnPage, 5, 1).SetName("Dishes with 17 elements"),
    };
    
    public static TestCaseData[] MenuMasterGetDishesOnPageCases =
    {
        new TestCaseData(DishesWith1Items, DishesOnPage, 1, new List<Dish>()
        {
            new("bacon")
        }).SetName("Dishes with 1 element"),
        new TestCaseData(DishesWith3Items, DishesOnPage, 1, new List<Dish>()
        {
            new("bacon"), new("beef"), new("chicken")
        }).SetName("Dishes with 3 elements"),
        new TestCaseData(DishesWith4Items, DishesOnPage, 1, new List<Dish>()
        {
            new("bacon"), new("beef"), new("chicken"), new("duck")
        }).SetName("Dishes with 4 elements"),
        
        new TestCaseData(DishesWith5Items, DishesOnPage, 2, new List<Dish>()
        {
            new("ham")
        }).SetName("Dishes with 5 elements"),
        
        new TestCaseData(DishesWith10Items, DishesOnPage, 3, new List<Dish>()
        {
            new("mutton"), new("beans")
        }).SetName("Dishes with 10 element"),
        
        new TestCaseData(DishesWith15Items, DishesOnPage, 4, new List<Dish>()
        {
            new("potato"), new("apple"), new("cherry")
        }).SetName("Dishes with 15 elements"),
        
        new TestCaseData(DishesWith16Items, DishesOnPage, 4, new List<Dish>()
        {
            new("potato"), new("apple"), new("cherry"), new("melon")
        }).SetName("Dishes with 16 elements"),
        
        new TestCaseData(DishesWith17Items, DishesOnPage, 5, new List<Dish>()
        {
            new("orange"),
        }).SetName("Dishes with 17 elements"),
    };
    
    public static TestCaseData[] MenuMasterGetFirstDishesOnEachPageCases =
    {
        new TestCaseData(DishesWith0Items, DishesOnPage, new List<Dish>()).SetName("Dishes with 0 elements"),
        new TestCaseData(DishesWith1Items, DishesOnPage, new List<Dish>() {
                new("bacon")
            })
            .SetName("Dishes with 1 element"),
        new TestCaseData(DishesWith3Items, DishesOnPage, new List<Dish>() {
                new("bacon")
            })
            .SetName("Dishes with 3 elements"),
        new TestCaseData(DishesWith4Items, DishesOnPage, new List<Dish>() { 
                new("bacon")
            })
            .SetName("Dishes with 4 elements"),
        new TestCaseData(DishesWith5Items, DishesOnPage, new List<Dish>() {
            new("bacon"), new("ham")})
            .SetName("Dishes with 5 elements"),
        new TestCaseData(DishesWith10Items, DishesOnPage, new List<Dish>() {
            new("bacon"), new("ham"), new("mutton")})
            .SetName("Dishes with 10 element"),
        new TestCaseData(DishesWith15Items, DishesOnPage, new List<Dish>() {
            new("bacon"), new("ham"), new("mutton"), new("potato")})
            .SetName("Dishes with 15 elements"),
        new TestCaseData(DishesWith16Items, DishesOnPage, new List<Dish>() {
            new("bacon"), new("ham"), new("mutton"), new("potato")})
            .SetName("Dishes with 16 elements"),
        new TestCaseData(DishesWith17Items, DishesOnPage, new List<Dish>() {
            new("bacon"), new("ham"), new("mutton"), new("potato"), new("orange")})
            .SetName("Dishes with 17 elements"),
    };
}