using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kinectinho.ViewModel
{
    
        public class MenuModel : System.ComponentModel.INotifyPropertyChanged
        {

            public MenuModel()
            {
                DancasDAB = new System.Collections.ObjectModel.ObservableCollection<Model.Danca>();
                DancasDAB.Add(new Model.Danca() { Nome = "Dança da Mãozinha", ImageSource = new Uri(System.Environment.CurrentDirectory + "/resources/mao.jpg"), Carroussel = 1 });
                DancasDAB.Add(new Model.Danca() { Nome = "Dança 2", ImageSource = new Uri(System.Environment.CurrentDirectory + "/resources/psy.jpg"), Carroussel = 2 });
                DancasDAB.Add(new Model.Danca() { Nome = "Dança 3", ImageSource = new Uri(System.Environment.CurrentDirectory + "/resources/dinamite.jpg"), Carroussel = 3 });


                SelectedDancaDAB = DancasDAB[0];
            }


        private System.Collections.ObjectModel.ObservableCollection<Model.Danca> _dancasDAB;
            public System.Collections.ObjectModel.ObservableCollection<Model.Danca> DancasDAB
            {
                get
                {
                    return _dancasDAB;
                }
                set
                {
                    _dancasDAB = value;
                    NotifyPropertyChanged("DancasDAB");
                }
            }

            private Model.Danca _selectedDancaDAB;
            public Model.Danca SelectedDancaDAB
            {
                get
                {
                    return _selectedDancaDAB;
                }
                set
                {
                    _selectedDancaDAB = value;
                    NotifyPropertyChanged("SelectedDancaDAB");
                }
            }



          
        #region INotifyPropertyChanged

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected virtual void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }

            #endregion INotifyPropertyChanged
        }
    }
