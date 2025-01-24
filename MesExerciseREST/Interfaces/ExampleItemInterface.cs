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
    }
}
