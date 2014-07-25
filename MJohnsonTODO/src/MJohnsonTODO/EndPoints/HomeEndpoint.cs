using MJohnsonTODO.Model;
using MJohnsonTODO.EndPoints;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Runtime;
using System.Web;

namespace MJohnsonTODO.EndPoints
{
    public class HomeEndpoint
    {
        private static TODOList _theList = new TODOList { WelcomeMessage = "Matt's TODO List" };
        ISessionState _ss;
        public HomeEndpoint(ISessionState state)
        {
            _ss = state;
            _ss.Set<TODOList>("_theList",_theList);
           
        }
        public TODOList Index()
        {           
            return _ss.Get<TODOList>("_theList");
        }

        public FubuContinuation post_save_todo(NewTodoInputModel input)
        {
            TODOList tempList = _ss.Get<TODOList>("_theList");
           // HttpContext.Current.Session write test for this to see why it is not a good as ISessionState
            tempList.AddElement(input.Title, input.Details);
            _ss.Set<TODOList>("_theList", tempList);
            return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.Index(), "GET");
          
        }
    }
    

}