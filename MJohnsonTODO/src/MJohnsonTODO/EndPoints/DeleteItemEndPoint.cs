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
        public AjaxContinuation post_delete_element(NewDeleteItemInputModel input)
        {
            TODOList tempList = _ss.Get<TODOList>("_theList");
            SetIsDoneOnElement(input, tempList);            
            _ss.Set<TODOList>("_theList", tempList);
            return AjaxContinuation.Successful();
           
        }

        public static void SetIsDoneOnElement(NewDeleteItemInputModel input, TODOList tempList)
        {
            TODOListElement tempListElement = tempList.getElement(input.myID);
            tempListElement.IsDone = true;
            tempList.setElement(input.myID, tempListElement);
        }
    }
}