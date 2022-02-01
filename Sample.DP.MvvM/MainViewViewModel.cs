using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DP.MvvM
{
    internal class MainViewViewModel : INotifyPropertyChanged
    {
        private int operator1 = 10;
        public int Operator1
        {
            get
            {
                return operator1;
            }
            set
            {
                operator1 = value;
                NotifyPropertyChanged();
            }
        }

        private int operator2 = 25;
        public int Operator2
        {
            get
            {
                return operator2;
            }
            set
            {
                operator2 = value;
                NotifyPropertyChanged();
                result = Calculate();
                NotifyPropertyChanged(nameof(Result));
            }
        }

        private int result;
        public int Result
        {
            get
            {
                return result;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int Calculate()
        {
            return Operator1 + Operator2;
        }
    }
}
