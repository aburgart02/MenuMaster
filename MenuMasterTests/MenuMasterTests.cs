using System;
using System.Collections.Generic;
using System.Linq;
using MenuMaster;
using NUnit.Framework;

namespace MenuMasterTests;

public class Tests
{
    [Test]
    public void MenuMaster_ThrowInvalidArgumentException_CreateMenuMasterWhenDishesIsNull()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var menuMaster = new MenuMaster.MenuMaster(null, 1);
        });
        Assert.That(exception?.Message, Is.EqualTo("Dishes shouldn't be null"));
    }
    
    [Test]
    public void MenuMaster_ThrowInvalidArgumentException_CreateMenuMasterWhenDishesOnPageLesserThanOne()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var menuMaster = new MenuMaster.MenuMaster(new List<Dish>(), 0);
        });
        Assert.That(exception?.Message, Is.EqualTo("Dishes on page number should be greater than or equal to 1"));
    }
    
    [Test]
    public void MenuMaster_ThrowInvalidArgumentException_GetDataByInvalidPageNumber()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var menuMaster = new MenuMaster.MenuMaster(new List<Dish>(), 1);
            menuMaster.GetDishesCountOnPage(2);
        });
        Assert.That(exception?.Message, Is.EqualTo("Invalid page number"));
        
        exception = Assert.Throws<ArgumentException>(() =>
        {
            var menuMaster = new MenuMaster.MenuMaster(new List<Dish>(), 1);
            menuMaster.GetDishesOnPage(2);
        });
        Assert.That(exception?.Message, Is.EqualTo("Invalid page number"));
    }
    
    [TestCaseSource(typeof(MenuMasterTestCaseSource), nameof(MenuMasterTestCaseSource.MenuMasterGetDishesCountCases))]
    public void MenuMaster_Success_GetDishesCount(List<Dish> dishes, int dishesOnPage, int expectedDishesCount)
    {
        var menuMaster = new MenuMaster.MenuMaster(dishes, dishesOnPage);
        Assert.That(menuMaster.GetDishesCount(), Is.EqualTo(expectedDishesCount));
    }
    
    [TestCaseSource(typeof(MenuMasterTestCaseSource), nameof(MenuMasterTestCaseSource.MenuMasterGetPagesCountCases))]
    public void MenuMaster_Success_GetPagesCount(List<Dish> dishes, int dishesOnPage, int expectedPagesCount)
    {
        var menuMaster = new MenuMaster.MenuMaster(dishes, dishesOnPage);
        Assert.That(menuMaster.GetPagesCount(), Is.EqualTo(expectedPagesCount));
    }
    
    [TestCaseSource(typeof(MenuMasterTestCaseSource), nameof(MenuMasterTestCaseSource.MenuMasterGetDishesCountOnPageCases))]
    public void MenuMaster_Success_GetDishesCountOnPage(List<Dish> dishes, int dishesOnPage, 
        int pageNumber, int expectedDishesCount)
    {
        var menuMaster = new MenuMaster.MenuMaster(dishes, dishesOnPage);
        Assert.That(menuMaster.GetDishesCountOnPage(pageNumber), Is.EqualTo(expectedDishesCount));
    }
    
    [TestCaseSource(typeof(MenuMasterTestCaseSource), nameof(MenuMasterTestCaseSource.MenuMasterGetDishesOnPageCases))]
    public void MenuMaster_Success_GetDishesOnPage(List<Dish> dishes, int dishesOnPage,
        int pageNumber, List<Dish> expectedDishes)
    {
        var menuMaster = new MenuMaster.MenuMaster(dishes, dishesOnPage);
        Assert.That(menuMaster.GetDishesOnPage(pageNumber).Select(x => x.Name), Is.EqualTo(expectedDishes.Select(x => x.Name)));
    }
    
    [TestCaseSource(typeof(MenuMasterTestCaseSource), nameof(MenuMasterTestCaseSource.MenuMasterGetFirstDishesOnEachPageCases))]
    public void MenuMaster_Success_GetFirstDishesOnEachPage(List<Dish> dishes, int dishesOnPage, List<Dish> expectedDishes)
    {
        var menuMaster = new MenuMaster.MenuMaster(dishes, dishesOnPage);
        Assert.That(menuMaster.GetFirstDishesOnEachPage().Select(x => x.Name), Is.EqualTo(expectedDishes.Select(x => x.Name)));
    }
}