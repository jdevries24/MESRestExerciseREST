namespace MesExerciseREST.Interfaces
{
    interface InterfaceBase
    {
        /*There are two versions of the database interfaces. one source uses the entry framework.
         * however to demostrate knowlage of sql there is also a seprate version of interfaces for using
         * raw SQL strings to work with the database*/
        public bool DoesItemExist(string Key);
        public ExampleItem GetItem(string Key);
        public void AddItem(ExampleItem NewItem);
        public void DeleteItem(string key);
        public void UpdateItem(ExampleItem UpdatedItem);
        public IEnumerable<ExampleItem> SearchItemsByValue(string value);
    }
}
