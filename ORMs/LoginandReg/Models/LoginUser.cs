#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace LoginandReg.Models;


public class LoginUser
{
    [Required]
    public string UserEmail {get;set;}

    [Required]
    public string UserPassword {get;set;}
}