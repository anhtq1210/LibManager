using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibraryManager.Models
{
public class Request:BaseEntity{
    public RequestStatus Status{get;set;}
    public Guid UserID{get;set;}
    public virtual User User{get;set;}
    public virtual ICollection<RequestDetail> RequestDetail {get;set;} 

    public IEnumerable<Book> GetBooks()
        {
            return RequestDetail.Select(x => x.Book);
        }
}
}