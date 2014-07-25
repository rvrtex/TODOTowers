using FubuMVC.Core.Ajax;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Runtime;
using MJohnsonTODO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJohnsonTODO.EndPoints
{
    public class DeleteItemEndPoint
    {

        ISessionState _ss;

        public DeleteItemEndPoint(ISessionState ss)
        {
            _ss = ss;
        }
        public FubuContinuation get_delete_element_ID(NewDeleteItemInputModel input)
        {
            TODOList tempList = _ss.Get<TODOList>("_theList");
            SetIsDoneOnElement(input, tempList);            
            _ss.Set<TODOList>("_theList", tempList);
            return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.Index(), "GET");
           // return AjaxContinuation.Successful();
           
        }

        public static void SetIsDoneOnElement(NewDeleteItemInputModel input, TODOList tempList)
        {
            TODOListElement tempListElement = tempList.getElement(input.ID);
            tempListElement.IsDone = true;
            tempList.setElement(input.ID, tempListElement);
        }
    }
}