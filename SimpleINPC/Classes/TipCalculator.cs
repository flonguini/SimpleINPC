using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleINPC.Classes
{
    public class TipCalculator : INotifyPropertyChanged
    {
        #region Private Fields

        private double _bill;
        private double _percentage;

        private readonly string _tip;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the Bill price
        /// </summary>
        public double Bill
        {
            get { return _bill; }
            set
            {
                _bill = value;
                OnPropertyChanged();
                OnPropertyChanged("Tip");
            }
        }

        /// <summary>
        /// Gets or sets the tip percentage
        /// </summary>
        public double Percentage
        {
            get { return _percentage; }
            set
            {
                _percentage = value;
                OnPropertyChanged();
                OnPropertyChanged("Tip");}
        }

        /// <summary>
        /// Get the tip value
        /// </summary>
        public string Tip
        {
            get { return CalculateTip(); }
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Methods
        
        //INPC Helper Method
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Evaluate the total tip
        private string CalculateTip()
        {
            return (Percentage * Bill / 100).ToString();
        }

        #endregion
    }
}
