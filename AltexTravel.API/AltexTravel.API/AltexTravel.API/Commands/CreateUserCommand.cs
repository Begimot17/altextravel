using AltexTravel.API.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AltexTravel.API.Commands
{
    [DataContract]

    public class CreateUserCommand : IRequest
    {

        [DataMember]
        private readonly List<UserViewModel> _userItems;

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        public CreateUserCommand()
        {
            _userItems = new List<UserViewModel>();
        }

        public CreateUserCommand(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
