using Microsoft.FxCop.Sdk;

namespace FxCopExample.Rules
{
    public abstract class BaseRule : BaseIntrospectionRule
    {
        protected BaseRule(string name)
            : base( name,
                typeof(BaseRule).Assembly.GetName().Name + ".Rules",
                typeof(BaseRule).Assembly)
        {
        }
    }
}