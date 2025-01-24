using System.ComponentModel.DataAnnotations;
namespace MesExerciseREST
{
    public class ExampleItem
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
