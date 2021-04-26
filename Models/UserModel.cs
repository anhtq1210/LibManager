using System;
using System.Collections.Generic;

namespace MyLibraryManager.Models{
public class User:BaseEntity{

    public string UserName{get;set;}
    public string Passwords{get;set;}
    public UserRole Role{get;set;}
    public virtual ICollection<Request> Requests { get; set; }

}
}