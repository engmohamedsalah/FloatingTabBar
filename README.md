FloatingTabBar
========================

FloatingTabBarController is a view controller that works similarly to the UITabBarController, where the tabs float above the corresponding view controllers.

![screenshot](http://jonathannesbitt.com/images/FloatingTabBarSample_Map.png "Sample") 

Usage:

```c#
using FloatingTabBar;
...
public override ViewDidLoad ()
{
    base.ViewDidLoad ();

    var ftbc = new FloatingTabBarController () {
        TabTitles = new List<string> () {
            "Tab 1",
            "Tab 2",
            "Tab 3"
        },
        ViewControllers = new List<UIViewController> () {
            new UIViewController (), // Tab 1
            new UIViewController (), // Tab 2
            new UIViewController ()  // Tab 3
        }
    };

    View.AddSubview (ftbc.View);
}
```
