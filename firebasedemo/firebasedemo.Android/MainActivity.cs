using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.FirebasePushNotification;
using Xamarin.Forms;
using Plugin.Toasts;

namespace firebasedemo.Droid
{
    [Activity(Label = "firebasedemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            FirebasePushNotificationManager.ProcessIntent(this, Intent);
            DependencyService.Register<ToastNotification>();
            ToastNotification.Init(this, new PlatformOptions() { SmallIconDrawable = Android.Resource.Drawable.IcDialogInfo });

            XamEffects.Droid.Effects.Init();
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}