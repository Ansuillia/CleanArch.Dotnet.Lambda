using Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class HelloWorld : EntityBase<Guid>, IAgreggateRoot
  {
    private readonly string _name;
    private readonly DateTime _date = DateTime.Now;

    public HelloWorld(string name)
    {
      _name = name;
    }

    public string GetHello() => $"Olá ${_name}! Data e hora: {_date}";

  }
}
