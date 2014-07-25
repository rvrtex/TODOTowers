using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MJohnsonTODO.Model;

namespace MJohnsonTODO
{
    public class TODOList
    {
        private Dictionary<int,TODOListElement> ElementsTODO { get; set; }
        public string WelcomeMessage { get; set; }

        public TODOList()
        {
            ElementsTODO = new Dictionary<int,TODOListElement>();
        }
        public void AddElement(string itemName, string itemDesription)
        {
            TODOListElement tempElement = new TODOListElement { Details = itemDesription, Title = itemName };
            ElementsTODO.Add(tempElement.getMyId(), tempElement);
        }
        public void AddElement(TODOListElement element)
        {
            
            ElementsTODO.Add(element.getMyId(),element);
        }
        public TODOListElement getElement(int id)
        {
            return ElementsTODO[id];
        }

        public void setElement(int key,TODOListElement value)
        {
            ElementsTODO[key] = value;

        }

        public Dictionary<int,TODOListElement> getElementList()
        {
            return ElementsTODO;
        }
       
    }
}