namespace Sample.DP.Factory.Domain
{
    internal abstract class Pizza
    {
        public abstract string Name { get; }

        public Sauce Sauce { get; protected set; }

        public List<Cheese> Cheeses { get; protected set; } = new List<Cheese>();

        public abstract void Prepare();
    }
}
