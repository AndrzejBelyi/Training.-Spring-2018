using System;
using System.Linq;

namespace Task1
{
    public class PasswordCheckerService
    {
        private IPasswordRepository repository = new SqlRepository();

        private IPasswordChecker checker = new CheckPassword();

        public PasswordCheckerService()
        {
        }

        public PasswordCheckerService(IPasswordRepository repository, IPasswordChecker checker)
        {
            this.checker = checker;
            this.repository = repository;
        }

        public Tuple<bool, string> VerifyPassword(string password)
        {
            Tuple<bool,string> tuple = checker.VerifyPassword(password);
            
            repository.Create(password);

            return tuple;           
        }
    }
}
