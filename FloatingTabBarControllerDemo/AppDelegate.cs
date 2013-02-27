using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.MapKit;
using MonoTouch.UIKit;
using FloatingTabBar;

namespace FloatingTabBarControllerDemo
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		FloatingTabBarController ftbc;
		DialogViewController dvc1, dvc2, dvc3;
		UIViewController mapViewController;
		MKMapView mapView;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			dvc1 = new DialogViewController (null) {
				Root = new RootElement ("Tab 1 DVC") {
					new Section (), new Section (), new Section (),
					new Section () {
						new StringElement ("House of Cards"),
						new StringElement ("Zombieland")
					}
				}
			};

			dvc2 = new DialogViewController (null) {
				Root = new RootElement ("Tab 2 DVC") {
					new Section (), new Section (), new Section (),
					new Section () {
						new StringElement ("Adventure Time"),
						new StringElement ("Bob's Burgers")
					}
				}
			};

			dvc3 = new DialogViewController (null) {
				Root = new RootElement ("Tab 3 DVC") {
					new Section (), new Section (), new Section (),
					new Section () {
						new StringElement ("Braid"),
						new StringElement ("Super Meat Boy")
					}
				}
			};

			mapViewController = new UIViewController ();
			mapView = new MKMapView (new RectangleF (0, -20, window.Bounds.Width, window.Bounds.Height));
			mapViewController.View.AddSubview (mapView);

			ftbc = new FloatingTabBarController () {
				TabTitles = new List<string> () { "Tab 1", "Tab 2", "Tab 3", "Map" },
				ViewControllers = new List<UIViewController> () { dvc1, dvc2, dvc3, mapViewController }
			};

			window.RootViewController = ftbc;
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

