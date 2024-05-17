using Todolist.Models;

namespace Todolist.Models;

public class Status
{
    public static Status New;

    public static Status Done { get; set; }
    public string StatusId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}