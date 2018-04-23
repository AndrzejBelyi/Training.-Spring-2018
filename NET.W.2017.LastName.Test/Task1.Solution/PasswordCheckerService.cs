using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class PasswordCheckerService
    {
        private IPasswordRepository repository = new SqlRepository();

        private IEnumerable<IPasswordChecker> checkers;

        public PasswordCheckerService()
        {
        }

        public PasswordCheckerService(IPasswordRepository repository,IEnumerable<IPasswordChecker> checkers)
        {
            this.checkers = checkers;
            this.repository = repository;
        }

        public Tuple<bool, string> VerifyPassword(string password)
        {
            foreach (var checker in checkers)
            {
                if (checker.Check(password).Item1 == false)
                {
                   return checker.Check(password);
                }
            }

            repository.Create(password);

            return Tuple.Create(true, $"{password} is ok!"); ;
        }
    }
}
