using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MJohnsonTODO.Model
{
    public class TODOListElement
    {
        private static int id = 0;
        private int myID;
        public string Details { get; set; }
        public bool IsDone { get; set; }
        public string Title { get; set; }

        public TODOListElement()
        {
            id++;
            myID = id;

        }

        public int getMyId()
        {
            return myID;
        }

    }
}
