using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MenuFlyoutSubItemBindingSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page,INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public List<MenuFlyoutItemBase> OptionItems { get; set; }

        public List<MenuFlyoutItemBase> InitFlyoutItems()
        {
            var list = new List<MenuFlyoutItemBase>
            {
                new MenuFlyoutItem {Text="Start item 1" },
                new MenuFlyoutItem {Text="Start item 2" },
                new MenuFlyoutItem {Text="Start item 3" },
                new MenuFlyoutSubItem { Text="Start Item 4"  }
            };
            ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 1" });
            ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 2" });
            ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 3" });
            ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 4" });
            return list;
        }

        public List<MenuFlyoutItemBase> UpdateFlyoutItems()
        {
            var list = new List<MenuFlyoutItemBase>
            {
                new MenuFlyoutItem {Text="Start item 1" },
                new MenuFlyoutItem {Text="Start item 2" },
                new MenuFlyoutItem {Text="Start item 3" },
                new MenuFlyoutSubItem { Text="Start Item 4"  }
            };
            ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "New Sub Item 1" });
            ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "New Sub Item 2" });
            ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "New Sub Item 3" });
            ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "New Sub Item 4" });
            return list;
        }

        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            OptionItems = InitFlyoutItems();
            RaiseProperty(nameof(OptionItems));
            base.OnNavigatedTo(e);
        }


        //int index = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OptionItems=UpdateFlyoutItems();
            RaiseProperty(nameof(OptionItems));
            
            //mysub.Items.Add(new MenuFlyoutItem { Text = "modified" }); 
            //int count = mysub.Items.Count;
            //if (index >= 3)
            //{
            //    var subitem = new MenuFlyoutSubItem();
            //    subitem.Items.Add(new MenuFlyoutItem { Text = "New Text" });
            //    ((MenuFlyout)myBtn.Flyout).Items[2] = subitem;
            //    index++;
            //}
            //index++;
        }
    }
}
