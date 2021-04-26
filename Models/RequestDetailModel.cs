using System;
namespace MyLibraryManager.Models{
    public class RequestDetail{
    public Guid BookID{get;set;}
    public virtual Book Book {get;set;}
    public Guid RequestID{get;set;}
    public virtual Request Request{get;set;}

}
}
