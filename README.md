FloatingTabBarController
========================

A view controller that works similarly to the UITabBarController, where the tabs float above the corresponding view controllers.

Usage:

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
                new UIViewController (),
                new UIViewController (),
                new UIViewController ()
            }
        };

        View.AddSubview (ftbc.View);
    }