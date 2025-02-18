﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using Android.Content;
using Android.Net;
using Android.OS;
using Android.Telephony;
using Java.Util;
using MvvmCross.Platforms.Android;

namespace MvvmCross.Plugin.PhoneCall.Platforms.Android
{
    [Preserve(AllMembers = true)]
    public class MvxPhoneCallTask
        : MvxAndroidTask, IMvxPhoneCallTask
    {
        public void MakePhoneCall(string name, string number)
        {
            string phoneNumber;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
                phoneNumber = PhoneNumberUtils.FormatNumber(number, Locale.GetDefault(Locale.Category.Format).Country);
            else
                phoneNumber = PhoneNumberUtils.FormatNumber(number, Locale.Default.Country);

            var newIntent = new Intent(Intent.ActionDial, Uri.Parse("tel:" + phoneNumber));
            StartActivity(newIntent);
        }
    }
}
