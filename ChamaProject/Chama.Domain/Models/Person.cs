using System;
using Chama.Domain.Core.Models;

namespace Chama.Domain.Models
{
    public class Person : Entity
    {
        public Person(Guid id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        protected Person() { }

        public string Name { get;  set; }

        public int Age { get; set; }
        
    }
}
