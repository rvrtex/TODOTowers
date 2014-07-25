using StructureMap.Configuration.DSL;

namespace MJohnsonTODO
{
	public class MJohnsonTODORegistry : Registry
	{
		public MJohnsonTODORegistry()
		{
			// make any StructureMap configuration here
			
            // Sets up the default "IFoo is Foo" naming convention
            // for auto-registration within this assembly
            Scan(x => {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });
		}
	}
}