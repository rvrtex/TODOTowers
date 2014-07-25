using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MJohnsonTODO.EndPoints
{
   public class NewEditInputModel
    {
        public int myID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
