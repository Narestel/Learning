using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace MWWM1._0.Model
{
    public class EmployeeDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        int id;

        public int Id
        {
            get { return id; }
            set { id = value; onPropertyChanged("Id"); }
        }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; onPropertyChanged("Name"); }
        }

        int age;
        public int Age
        {
            get { return age; }
            set { age = value; onPropertyChanged("Age"); }
        }

    }
}
