using System;
using System.Collections.Generic;
using Plugin.Toasts;
using Xamarin.Forms;

namespace firebasedemo
{
    public partial class MyPage : ContentPage
    {
        IUserNotificationService userNotificationService;
        public MyPage()
        {
            InitializeComponent();
            userNotificationService = DependencyService.Get<IUserNotificationService>();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            userNotificationService.Snack("Default notify without action");
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            ShowToast(new NotificationOptions()
            {
                Title = "The Title Line",
                Description = "The Description Content",
                IsClickable = true,
                WindowsOptions = new WindowsOptions() { LogoUri = "icon.png" },
                ClearFromHistory = false,
                AllowTapInNotificationCenter = false,
                AndroidOptions = new AndroidOptions()
                {
                    HexColor = "#F99D1C",
                    ForceOpenAppOnNotificationTap = true
                }
            });
        }

        void ShowToast(INotificationOptions options)
        {
            var notificator = DependencyService.Get<IToastNotificator>();

            // await notificator.Notify(options);

            notificator.Notify((INotificationResult result) =>
            {
                System.Diagnostics.Debug.WriteLine("Notification [" + result.Id + "] Result Action: " + result.Action);
            }, options);
        }
    }
}
