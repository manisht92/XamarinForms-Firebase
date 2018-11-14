using System;
using Android.App;
using Xamarin.Forms;

[assembly: Dependency(typeof(firebasedemo.Droid.UserNotificationService))]
namespace firebasedemo.Droid
{
    public class UserNotificationService : IUserNotificationService
    {
        public void Snack(string message, int duration, string actionText = null, Action<object> action = null)
        {
            var contentView = (Forms.Context as Activity)?.FindViewById(Android.Resource.Id.Content);
            var snackbar = Android.Support.Design.Widget.Snackbar.Make(contentView, message, duration);

            if (actionText != null)
                snackbar.SetAction(actionText, action);

            snackbar.Show();
        }
    }
}
