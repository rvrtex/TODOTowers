using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MJohnsonTODO.Model;


namespace MJohnsonTODO.EndPoints
{
    public class NewTodoInputModel
    {
        public string Details { get; set; }
        public string Title { get; set; }
    }
}