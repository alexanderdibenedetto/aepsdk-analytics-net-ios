using System;
using Foundation;
using ObjCRuntime;
using AepCore;

namespace Adobe.AepSdk.Analytics.Net.iOS
{
    // @interface AnalyticsBase : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC12AEPAnalytics13AnalyticsBase")]
    [DisableDefaultCtor]
    interface AnalyticsBase
    {
        // @property (readonly, nonatomic, strong) id<AEPExtensionRuntime> _Nonnull runtime;
        //[Export("runtime", ArgumentSemantic.Strong)]
        //AEPExtensionRuntime Runtime { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull friendlyName;
        [Export("friendlyName")]
        string FriendlyName { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull extensionVersion;
        [Static]
        [Export("extensionVersion")]
        string ExtensionVersion { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable metadata;
        [NullAllowed, Export("metadata", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> Metadata { get; }

        // -(instancetype _Nullable)initWithRuntime:(id<AEPExtensionRuntime> _Nonnull)runtime __attribute__((objc_designated_initializer));
        [Export("initWithRuntime:")]
        [DesignatedInitializer]
        NativeHandle Constructor(AEPExtensionRuntime runtime);

        // -(void)onRegistered;
        [Export("onRegistered")]
        void OnRegistered();

        // -(void)onUnregistered;
        [Export("onUnregistered")]
        void OnUnregistered();

        // -(BOOL)readyForEvent:(AEPEvent * _Nonnull)event __attribute__((warn_unused_result("")));
        [Export("readyForEvent:")]
        bool ReadyForEvent(AEPEvent @event);
    }

    // @interface AEPMobileAnalytics : AnalyticsBase
    //[Unavailable(PlatformName.TvOSAppExtension)]
    //[Unavailable(PlatformName.iOSAppExtension)]
    [BaseType(typeof(AnalyticsBase))]
    interface AEPMobileAnalytics
    {
        // -(instancetype _Nullable)initWithRuntime:(id<AEPExtensionRuntime> _Nonnull)runtime __attribute__((objc_designated_initializer));
        [Export("initWithRuntime:")]
        [DesignatedInitializer]
        NativeHandle Constructor(AEPExtensionRuntime runtime);
    }

    // @interface AEPMobileAnalyticsAppExtension : AnalyticsBase
    [BaseType(typeof(AnalyticsBase))]
    interface AEPMobileAnalyticsAppExtension
    {
        // -(instancetype _Nullable)initWithRuntime:(id<AEPExtensionRuntime> _Nonnull)runtime __attribute__((objc_designated_initializer));
        [Export("initWithRuntime:")]
        [DesignatedInitializer]
        NativeHandle Constructor(AEPExtensionRuntime runtime);
    }

    // @interface AEPAnalytics_Swift_354 (AnalyticsBase)
    [Category]
    [BaseType(typeof(AnalyticsBase))]
    interface AnalyticsBase_AEPAnalytics_Swift_354
    {
        // +(void)clearQueue;
        [Static]
        [Export("clearQueue")]
        void ClearQueue();

        // +(void)getQueueSize:(void (^ _Nonnull)(NSInteger, NSError * _Nullable))completion;
        [Static]
        [Export("getQueueSize:")]
        void GetQueueSize(Action<nint, NSError> completion);

        // +(void)sendQueuedHits;
        [Static]
        [Export("sendQueuedHits")]
        void SendQueuedHits();

        // +(void)getTrackingIdentifier:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))completion;
        [Static]
        [Export("getTrackingIdentifier:")]
        void GetTrackingIdentifier(Action<NSString, NSError> completion);

        // +(void)getVisitorIdentifier:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))completion;
        [Static]
        [Export("getVisitorIdentifier:")]
        void GetVisitorIdentifier(Action<NSString, NSError> completion);

        // +(void)setVisitorIdentifier:(NSString * _Nonnull)visitorIdentifier;
        [Static]
        [Export("setVisitorIdentifier:")]
        void SetVisitorIdentifier(string visitorIdentifier);
    }
}