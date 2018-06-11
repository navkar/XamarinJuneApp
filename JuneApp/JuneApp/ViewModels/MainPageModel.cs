using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FreshMvvm;
using System;
using System.Windows.Input;
using System.ComponentModel;

namespace JuneApp
{
    public class MainPageModel : FreshBasePageModel
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
            onTabPressed("1");
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }
        #endregion

        ContentView contentA = null;
        ContentView contentB = null;

        public MainPageModel()
        {
            contentA = new ContentView
            {
                Content = new ContentA()
            };

            contentB = new ContentView
            {
                Content = new ContentB()
            };
        }

        public ICommand TabButtonPressed
        {
            get
            {
                return new Command((object componentIdentifier) =>
                {
                    onTabPressed(componentIdentifier);
                });
            }
        }

        public ICommand OpenDialogCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<AboutPageModel>();
                });
            }
        }

        //ShowMeCommand

        #region Properties  
        int _selectedColumnIndex = 0;
        public int SelectedColumnIndex
        {
            get
            {
                return _selectedColumnIndex;
            }
            set
            {
                if (_selectedColumnIndex != value)
                {
                    _selectedColumnIndex = value;
                    RaisePropertyChanged(nameof(SelectedColumnIndex));
                }
            }
        }

        ContentView _viewContent = null;
        public ContentView ViewContent
        {
            get
            {
                return _viewContent;
            }
            set
            {
                if (_viewContent != value)
                {
                    _viewContent = value;
                    RaisePropertyChanged(nameof(ViewContent));
                }
            }
        }

        string _caption = null;
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                if (_caption != value)
                {
                    _caption = value;
                    RaisePropertyChanged(nameof(Caption));
                }
            }
        }
        #endregion


        public void onTabPressed(object componentIdentifier)
        {
            if (componentIdentifier is string)
            {
                switch ((string)componentIdentifier)
                {
                    case "1":
                        ViewContent = contentA;
                        SelectedColumnIndex = 0;
                        break;
                    case "2":
                        ViewContent = contentB;
                        SelectedColumnIndex = 1;
                        break;
                    default:
                        ViewContent = contentA;
                        SelectedColumnIndex = 0;
                        break;
                }

                RaisePropertyChanged(nameof(ViewContent));
                RaisePropertyChanged(nameof(SelectedColumnIndex));
            }
        }
    }
}
