﻿using System;
using System.Collections.Generic;
using NetcoreTemplate.Domain.Entity;

namespace NetcoreTemplate.Domain.Core.User.Commamd.CreateUser
{
    public static class CreateUserCommandExtension
    {
        public static Entity.User ToUserEntity(this CreateUserCommand command)
        {
            return new Entity.User
            {
                Id = command.UserId,
                Profile = new Profile
                {
                    Id = new Guid(),
                    UserId = command.UserId
                }
            };
        }
    }
}