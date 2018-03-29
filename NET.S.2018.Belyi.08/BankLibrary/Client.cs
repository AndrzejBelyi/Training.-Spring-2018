using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    /// <summary>
    /// Gender of client
    /// </summary>
    public enum Gender
    {
        Women = 0,
        Man,
        Other,
        NoData = -1
    }

    public class Client
    {    
        /// <summary>
        /// Constructor of the Client class
        /// </summary>
        /// <param name="firstName">First name of client</param>
        /// <param name="lastName">Last name of client</param>
        /// <param name="clientGender">Gender</param>
        public Client(string firstName, string lastName, Gender clientGender = Gender.NoData)
        {
            FirstName = firstName;
            LastName = lastName;
            ClientGender = clientGender;
        }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gender
        /// </summary>
        public Gender ClientGender { get; private set; }
    }
}
