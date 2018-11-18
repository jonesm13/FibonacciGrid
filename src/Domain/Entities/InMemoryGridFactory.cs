namespace Domain.Entities
{
    using System.Collections.Generic;
    using Aggregates;

    public class InMemoryGridFactory
    {
        static readonly Dictionary<string, Grid> innerDictionary;

        static InMemoryGridFactory()
        {
            innerDictionary = new Dictionary<string, Grid>();
        }

        public Grid GetOrCreate(string name)
        {
            if (!innerDictionary.ContainsKey(name))
            {
                innerDictionary[name] = new Grid(name);
            }

            return innerDictionary[name];
        }
    }
}