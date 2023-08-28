using AepCore;
using AepIdentity;
using AepLifecycle;
using AepServices;
using AepSignal;
using Adobe.AepSdk.Analytics.Net.iOS;
using System.Diagnostics;
using Foundation;
using ObjCRuntime;

namespace test;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();


    public override bool FinishedLaunching(UIKit.UIApplication application, NSDictionary launchOptions)
    {
        InitializeAdobeMobile();
        return base.FinishedLaunching(application, launchOptions);
    }

    private void InitializeAdobeMobile()
    {
        try
        {
            // set the wrapper type
            AEPMobileCore.SetWrapperType(AEPWrapperType.Xamarin);
            AEPMobileCore.SetLogLevel(AEPLogLevel.Debug);

            // set your configuration
            var keys = new[]
            {
                new NSString("analytics.timezone"),
                new NSString("analytics.timezoneOffset"),
                new NSString("analytics.referrerTimeout"),
                new NSString("analytics.backdatePreviousSessionInfo"),
                new NSString("lifecycle.sessionTimeout")
            };
            var objects = new NSObject[]
            {
                new NSString("UTC"),
                new NSNumber(0),
                new NSNumber(5),
                new NSNumber(false),
                new NSNumber(300)
            };
            NSDictionary<NSString, NSObject> dict = new(keys, objects);
            AEPMobileCore_AEPCore_Swift_863.UpdateConfiguration(null, dict);

            // register any extensions being used with adobe mobile.
            AEPMobileCore.RegisterExtensions(
                new Class[]
                {
                    new Class(typeof(AEPMobileIdentity)),
                    new Class(typeof(AEPMobileLifecycle)),
                    new Class(typeof(AEPMobileSignal)),
                    new Class(typeof(AEPMobileAnalytics)),
                },
                OnRegistrationComplete);
        }
        catch (Exception exception)
        {
            Debug.WriteLine($"Unable to complete initialization of Adobe.{Environment.NewLine}{exception.Message}{exception.StackTrace}");
        }
    }

    private void OnRegistrationComplete()
    {
        Debug.WriteLine($"Extension registrations complete.");
        // configure with your app id.
        AEPMobileCore_AEPCore_Swift_863.ConfigureWithAppId(null, "com.companyname.test");
        // start the analytics collection lifecycle for the initial app open.
        AEPMobileCore_AEPCore_Swift_832.LifecycleStart(null, null);
        Debug.WriteLine($"Adobe initialized successfully.");
    }
}