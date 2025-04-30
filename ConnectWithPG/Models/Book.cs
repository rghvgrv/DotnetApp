using System;
using System.Collections.Generic;

namespace ConnectWithPG.Models;

public partial class Book
{
    public int Bookid { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Author { get; set; } = null!;
}
