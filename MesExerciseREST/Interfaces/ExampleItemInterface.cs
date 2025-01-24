namespace MesExerciseREST.Interfaces
{
    public class ExampleItemInterface
    {
        AplicationDBContext _context;
        public ExampleItemInterface()
        {
            _context = new AplicationDBContext();
            _context.Database.EnsureCreated();
        }

        public bool DoesItemExist(string Key)
        {
            return _context.ItemTable.Where(item => item.Key == Key).Any();
        }

        public ExampleItem GetItem(string Key)
        {
            return _context.ItemTable.Where(item => item.Key == Key).First();
        }

        public void AddItem(ExampleItem newItem)
        {
            _context.ItemTable.Add(newItem);
        }
    }
}
