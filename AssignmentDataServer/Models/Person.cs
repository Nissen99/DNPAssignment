using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AssignmentDataServer.Models {
public class Person {


    [Key] public int Id { get; set; }
    [NotNull] public string FirstName { get; set; }
    [NotNull] public string LastName { get; set; }
    [NotNull] public string HairColor { get; set; }
    [NotNull] public string EyeColor { get; set; }
    [NotNull] public int Age { get; set; }
    [NotNull] public float Weight { get; set; }
    [NotNull] public int Height { get; set; }
    [NotNull] public string Sex { get; set; }
}


}