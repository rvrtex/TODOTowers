using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace MJohnsonTODO
{
	public class MJohnsonTODOApplication : IApplicationSource
	{
	    public FubuApplication BuildApplication()
	    {
            return FubuApplication.For<MJohnsonTODOFubuRegistry>()
				.StructureMap<MJohnsonTODORegistry>();
	    }
	}
}