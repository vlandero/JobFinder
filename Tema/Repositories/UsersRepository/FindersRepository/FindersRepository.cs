﻿using Tema.Models;
using Tema.Models.Users.Finder;
using Tema.Repositories.UsersRepository.GenericUsersRepository;

namespace Tema.Repositories.UsersRepository.FindersRepository
{
    public class FindersRepository : GenericUsersRepository<Finder>, IFindersRepository
    {
        public FindersRepository(MyAppContext context) : base(context)
        {

        }
    }
}
