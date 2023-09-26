using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DREXKeynoteCheck.Data
{
    public class Keynote
    {
        private string _number;

        public string Number
        {
            get
            {
                return _number;
            }
            private set
            {
                _number = value;
            }
        }

        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }
            private set
            {
                _description = value;
            }
        }

        private string _parentNumber;

        public string ParentNumber
        {
            get
            {
                return _parentNumber;
            }
            private set
            {
                _parentNumber = value;
            }
        }

        public Keynote(string keynote, string description, string parentKeynote)
        {
            this.Number = keynote;
            this.Description = description;
            this.ParentNumber = parentKeynote;
        }
    }
}