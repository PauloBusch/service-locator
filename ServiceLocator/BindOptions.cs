namespace ServiceLocatorFramework
{
    public class BindOptions<TInterface> : IBindOptions<TInterface>
    {
        private IBindObject _bind;
        public BindOptions(IBindObject bind) { 
            this._bind = bind;
        }
        public IScopeOptions Implements<TImplements>() where TImplements : TInterface
        {
            _bind.Implements(typeof(TImplements));
            return new ScopeOptions(_bind);
        }
    }
}
