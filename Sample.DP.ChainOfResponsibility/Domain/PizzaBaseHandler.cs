namespace Sample.DP.ChainOfResponsibility.Domain
{
    internal interface IPizzaHandler
    {
        void nextHandler(IPizzaHandler nextHandler);

        void Handle(Pizza pizza);
    }

    internal class PizzaBaseHandler : IPizzaHandler
    {
        private IPizzaHandler _nextHandler;

        public void nextHandler(IPizzaHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public virtual void Handle(Pizza pizza)
        {
            _nextHandler?.Handle(pizza);
        }
    }

    internal class PizzaHandler : PizzaBaseHandler
    {
        public virtual void Handle(Pizza pizza)
        {
            pizza.Ingredients.Add("Dough");
            base.Handle(pizza);
        }
    }

    internal class PizzaCheeseHandler : PizzaBaseHandler
    {
        public override void Handle(Pizza pizza)
        {
            pizza.Ingredients.Add("Cheese");
            base.Handle(pizza);
        }
    }

    internal class PizzaTomatoHandler : PizzaBaseHandler
    {
        public override void Handle(Pizza pizza)
        {
            pizza.Ingredients.Add("Tomato");
            base.Handle(pizza);
        }
    }

    internal class PizzaMushroomHandler : PizzaBaseHandler
    {
        public override void Handle(Pizza pizza)
        {
            pizza.Ingredients.Add("Mushroom");
            base.Handle(pizza);
        }
    }
}
