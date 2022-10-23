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
                DancasDAB.Add(new Model.Danca() { Nome = "Ariana Grande - 35 + 34", ImageSource = "Dancas/Imagens/69.jpg", Carroussel = 1 });
                DancasDAB.Add(new Model.Danca() { Nome = "Kim Petras - Coconuts", ImageSource = "Dancas/Imagens/coconuts.jpg", Carroussel = 2 });
                DancasDAB.Add(new Model.Danca() { Nome = "K/DA - POP/STARS", ImageSource = "Dancas/Imagens/KDA.jpg", Carroussel = 3 });
                //DancasDAB.Add(new Model.Danca() { Nome = "Moodai - Among Us Remix", ImageSource = "Dancas/Imagens/amogus.jpg", Carroussel = 4 });


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
