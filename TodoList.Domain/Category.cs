using Todolist.Models;

namespace Todolist.Models;

public class Category
{
    public Category Adventure;

    public string CategoryId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
//public enum Category
//{
//    SciFi,
//    Horror,
//    Adventure,
//    Romance,
//    SliceOfLife
//}