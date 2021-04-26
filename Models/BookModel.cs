using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibraryManager.Models{
    
public class Book : BaseEntity{

    public string Name{get;set;}
    public string Author{get;set;}
    public Guid CategoryID{get;set;}
    public bool IsAvailable{get;set;}
    public virtual Category Category{get;set;}
    
    public virtual ICollection<RequestDetail> RequestDetails{get;set;}
     public IEnumerable<Request> GetRequests()
        {
            return RequestDetails.Select(x => x.Request).ToList();
        }
}
}