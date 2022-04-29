using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace KIT206
{
    public class Unit
    {
        public string UnitCode { get; set; } // e.g. KIT206
        public string UnitTitle { get; set; } // e.g. Software Design & Development
        public int UnitCoordinator { get; set; } // Staff Class / foreign key
        private List<UnitClass> units;
        public List<UnitClass> UnitItems { get { return units; } set { } }
        private ObservableCollection<UnitClass> viewableUnits;
        public ObservableCollection<UnitClass> VisibleUnits { get { return viewableUnits; } set { } }

        // constructor for returning full unit string

        public Unit()
        {
            units = Program.LoadAll();
            viewableUnits = new ObservableCollection<UnitClass>(units);
        }

        public ObservableCollection<UnitClass> GetList()
        {
            return VisibleUnits;
        }
        public override string ToString()
        { 
            return $"{UnitCode} {UnitTitle}";
        }


    }
}
