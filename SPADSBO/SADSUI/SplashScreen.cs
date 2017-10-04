using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GR.Net.Maroulis.Library;
using Android.Graphics;

namespace SADSUI
{
    [Activity(Label = "Smartphone Accident Detection System", MainLauncher = true, Icon = "@drawable/icon1")]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            //SplashScreen
            var config = new EasySplashScreen(this)
                .WithFullScreen()
                .WithTargetActivity(Java.Lang.Class.FromType(typeof(MainActivity)))
                .WithSplashTimeOut(4000)
                .WithBackgroundResource(Resource.Drawable.intro_bg)
                .WithFooterText("Copyright 2017")
                .WithBeforeLogoText("WELCOME");
                

           
            config.FooterTextView.SetTextColor(Color.White);
            config.BeforeLogoTextView.TextSize = 50;
            config.BeforeLogoTextView.SetTextColor(Color.Orange);

            View view = config.Create();
            SetContentView(view);
        }
    }
}