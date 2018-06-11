using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JuneApp
{
    public class AboutPageModel : FreshBasePageModel
    {
        #region Default Override functions  
        public override void Init(object initData)
        {
            base.Init(initData);

        }

        public override void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }
        #endregion

        public ICommand PopCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PopPageModel();
                    //await CoreMethods.PopToRoot(animate: false);
                });
            }
        }

        public ICommand AlertCommand
        {
            get
            {
                return new Command(async () =>
                {
                    bool isUserAccept = await CoreMethods.DisplayAlert("Alert!", "Would you like some coffee?", "OK", "Dismiss");

                });
            }
        }
    }
}
