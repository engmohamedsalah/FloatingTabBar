using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.UIKit;

namespace FloatingTabBar
{
    public class FloatingTabBarController : UIViewController
    {
        List<string> tabTitles;
        List<UIButton> tabButtons;
        List<UIViewController> viewControllers;
        UIView tabView;
        float tabWidth;
        UIFont font;
        int selectedTabIndex = 0;
        
        public List<string> TabTitles {
            get {
                return tabTitles;
            }
            set {
                tabTitles = value;
                Refresh ();
            }
        }
        
        public List<UIViewController> ViewControllers {
            get {
                return viewControllers;
            }
            set {
                viewControllers = value;
                SelectTab (0);
            }
        }
        
        public int SelectedIndex {
            get;
            private set;
        }
        
        public UIViewController SelectedViewController {
            get;
            private set;
        }
        
        public UIFont Font {
            get {
                return font;
            }
            set {
                this.font = value;
                Refresh ();
            }
        }
        
        UIView SelectedView {
            get {
                if (SelectedViewController != null)
                    return SelectedViewController.View;
                else
                    return null;
            }
        }
        
        void Refresh ()
        {
            if ((tabTitles != null) && (tabTitles.Count > 0)) {

                // Clear tabs.
                foreach (var view in tabView.Subviews) {
                    view.RemoveFromSuperview ();
                }

                // Create tab buttons.
                tabButtons.Clear ();
                tabWidth = 0;
                int tabIndex = 0;
                foreach (var title in tabTitles) {
                    var button = new UIButton (UIButtonType.Custom);
                    button.ContentEdgeInsets = new UIEdgeInsets (5, 10, 5, 10);
                    button.BackgroundColor = UIColor.White;
                    button.SetTitleColor (UIColor.FromRGB (71, 71, 71), UIControlState.Normal);
                    button.SetTitle (title, UIControlState.Normal);
                    if (font != null)
                        button.Font = font;
                    button.SizeToFit ();
                    button.Tag = tabIndex++;
                    button.TouchUpInside += (sender, e) => {
                        SelectTab (button.Tag);
                    };
                    tabButtons.Add (button);
                    tabView.AddSubview (button);
                    tabWidth += button.Frame.Width;
                }
                
                // Update tab button locations.
                float currentWidth = 0;
                foreach (var button in tabButtons) {
                    button.Frame = new RectangleF (currentWidth, 0, button.Frame.Width, button.Frame.Height);
                    currentWidth += button.Frame.Width;
                }
                
                tabView.Frame = new RectangleF ((View.Center.X - (tabWidth / 2)), 20, tabWidth, tabButtons [0].Frame.Height);
                
                SelectTab (selectedTabIndex);
            }
        }
        
        void SelectTab (int index)
        {
            if ((viewControllers == null) || (viewControllers.Count <= index) || (index < 0) || (viewControllers [index] == null))
                return;
            
            SelectedIndex = index;
            SelectedViewController = viewControllers [index];
            View.InsertSubviewBelow (SelectedView, tabView);
            
            // Update selected tab.
            foreach (var button in tabButtons) {
                button.BackgroundColor = UIColor.White;
                button.SetTitleColor (UIColor.FromRGB (71, 71, 71), UIControlState.Normal);
            }
            tabButtons [SelectedIndex].BackgroundColor = UIColor.FromRGB (71, 71, 71);
            tabButtons [SelectedIndex].SetTitleColor (UIColor.White, UIControlState.Normal);
        }
        
        public FloatingTabBarController ()
        {
            tabView = new UIView (new RectangleF (View.Center.X, 20, 0, 0));
            View.AddSubview (tabView);
            tabButtons = new List<UIButton> ();
        }
    }
}

