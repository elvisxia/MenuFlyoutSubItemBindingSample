using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MenuFlyoutSubItemBindingSample
{
    //public static class MenuExtension
    //{
    //    public static List<MenuFlyoutItem> GetMyItems(DependencyObject obj)
    //    { return (List<MenuFlyoutItem>)obj.GetValue(MyItemsProperty); }

    //    public static void SetMyItems(DependencyObject obj, List<MenuFlyoutItem> value)
    //    { obj.SetValue(MyItemsProperty, value); }

    //    public static readonly DependencyProperty MyItemsProperty =
    //        DependencyProperty.Register("MyItems", typeof(List<MenuFlyoutItem>), typeof(MenuExtension),
    //        new PropertyMetadata(new List<MenuFlyoutItem>(), (sender, e) =>
    //        {
    //            Debug.WriteLine("Filling collection");
    //            var menu = sender as MenuFlyoutSubItem;
    //            menu.Items.Clear();
    //            foreach (var item in e.NewValue as List<MenuFlyoutItem>) menu.Items.Add(item);
    //        }));
    //}

    public static class FlyoutMenuExtension
    {
        public static List<MenuFlyoutItemBase> GetMyItems(DependencyObject obj)
        {
            return (List<MenuFlyoutItemBase>)obj.GetValue(MyItemsProperty);
        }
        public static void SetMyItems(DependencyObject obj, List<MenuFlyoutItemBase> value)
        {
            obj.SetValue(MyItemsProperty, value);
        }
        public static readonly DependencyProperty MyItemsProperty =
            DependencyProperty.Register("MyItems",
                typeof(List<MenuFlyoutItemBase>),
                typeof(FlyoutMenuExtension),
                new PropertyMetadata(new List<MenuFlyoutItemBase>(), (sender, e) => {
                    var menu = sender as MenuFlyout;
                    menu.Items.Clear();
                    foreach (var item in e.NewValue as List<MenuFlyoutItemBase>)
                    {
                        menu.Items.Add(item);
                    }
                }));
    }
}
