using System;
using System.Collections.Generic;
namespace MyLibraryManager.Models{
    public class Category:BaseEntity{

    public string Name{get;set;}
    public ICollection<Book> Books {get;set;} = new List<Book>();
}
}

