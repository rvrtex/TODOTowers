using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Runtime;
using MJohnsonTODO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJohnsonTODO.EndPoints
{
    public class EditItemEndPoint
    {
        ISessionState _ss;
       
        public EditItemEndPoint(ISessionState ss)
        {
            _ss = ss;
        }

       


        public TODOListElement get_Edit_Element_ID(NewTODOElementInputModel input)
        {
            TODOList tempList = _ss.Get<TODOList>("_theList");
            TODOListElement tempListElement = tempList.getElement(input.ID);          
            return tempListElement;
        }

        public FubuContinuation post_Save_Edit(NewEditInputModel input)
        {
            TODOList tempList = _ss.Get<TODOList>("_theList");
            TODOListElement tempListElement = EditElementOfList(input, tempList);
            tempList.setElement(input.myID, tempListElement);
            _ss.Set<TODOList>("_theList", tempList);

            return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.Index(), "GET");
        }

        public static TODOListElement EditElementOfList(NewEditInputModel input, TODOList tempList)
        {
            TODOListElement tempListElement = tempList.getElement(input.myID);
            tempListElement.Details = input.Details;
            tempListElement.Title = input.Title;
            return tempListElement;
        }
    }
}