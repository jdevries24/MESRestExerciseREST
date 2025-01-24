namespace MesExerciseREST.Interfaces
{
    interface InterfaceBase
    {
        public bool DoesItemExist(string Key);
        public ExampleItem GetItem(string Key);
        public void AddItem(ExampleItem NewItem);
        public void DeleteItem(string key);
        public void UpdateItem(ExampleItem UpdatedItem);
        public IEnumerable<ExampleItem> SearchItemsByValue(string value);
    }
}
