using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.CoreLocation;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.MapKit;
using MonoTouch.UIKit;
using FloatingTabBar;

namespace FloatingTabBarControllerDemo
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;
        FloatingTabBarController ftbc;
        DialogViewController dvc1, dvc2;
        UIViewController mapViewController;

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            window = new UIWindow (UIScreen.MainScreen.Bounds);

            // Create the 'Shows' tab.
            dvc1 = new DialogViewController (null) {
                Root = new RootElement ("") {
                    new Section (), new Section (), new Section (),
                    new Section () {
                        new StringElement ("House of Cards"),
                        new StringElement ("Game of Thrones"),
                        new StringElement ("Person of Interest")
                    }
                }
            };

            // Create the 'Games' tab.
            dvc2 = new DialogViewController (null) {
                Root = new RootElement ("") {
                    new Section (), new Section (), new Section (),
                    new Section () {
                        new StringElement ("Braid"),
                        new StringElement ("Super Meat Boy"),
                        new StringElement ("Fez")
                    }
                }
            };

            // Create the 'Atlanta' tab.
            var mapView = new MKMapView (new RectangleF (0, -20, window.Bounds.Width, window.Bounds.Height));
            var atlanta = new MKCoordinateRegion (new CLLocationCoordinate2D (33.748893, -84.388046), new MKCoordinateSpan (0.35, 0.35));
            mapView.SetRegion (atlanta, false);
            mapViewController = new UIViewController ();
            mapViewController.View.AddSubview (mapView);

            // Create and display the floating tab bar controller.
            ftbc = new FloatingTabBarController () {
                TabTitles = new List<string> () { "Shows", "Games", "Atlanta" },
                ViewControllers = new List<UIViewController> () { dvc1, dvc2, mapViewController }
            };
            window.RootViewController = ftbc;
            window.MakeKeyAndVisible ();
            
            return true;
        }
    }
}

