namespace FxCopExample
{
    [Singleton]
    class LoadBalancer
    {
        public static LoadBalancer instance;

        public LoadBalancer()
        {
            
        }

        protected object GetInstance()
        {
            return null;
        }
    }
}
