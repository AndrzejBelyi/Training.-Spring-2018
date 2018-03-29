using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    /// <summary>
    /// Account Types
    /// </summary>
    public enum AccountType
    {
        Base = 1, Silver, Gold, Platinum
    }

    /// <summary>
    /// Account class 
    /// </summary>
    public sealed class Account
    {
        /// <summary>
        /// Amount on current account
        /// </summary>
        private int sum;

        /// <summary>
        /// Bonus points on current account
        /// </summary>
        private int bonusPoints;

        /// <summary>
        /// Constructor of the Account class
        /// </summary>
        /// <param name="accountClient">Whose account</param>
        /// <param name="accType">Type of account</param>
        public Account(Client accountClient, AccountType accType = AccountType.Base)
        {
            AccountClient = accountClient ?? throw new ArgumentNullException(nameof(accountClient));
            Type = accType;
            AccountNumber = "12F8912";
        }

        /// <summary>
        /// Whose account
        /// </summary>
        public Client AccountClient { get; }

        /// <summary>
        /// Account id number
        /// </summary>
        public string AccountNumber { get; }

        /// <summary>
        /// Account type
        /// </summary>
        public AccountType Type { get; private set; }

        /// <summary>
        /// Activity of account
        /// </summary>
        public bool Activity { get; private set; } = true;

        /// <summary>
        /// Bonus point of account
        /// </summary>
        public int BonusPoints
        {
            get
            {
                return bonusPoints;
            }

            private set
            {
                if (value < 0)
                {
                    bonusPoints = 0;
                }
                else
                {
                    bonusPoints = value;
                }
            }
        }

        /// <summary>
        /// Amount on current account
        /// </summary>
        public int Sum
        {
            get
            {
                return sum;
            }

            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(nameof(sum) + " < 0 ");
                }
                else
                {
                    sum = value;
                }
            }
        }

        /// <summary>
        ///  Replenishment of the account for the specified amount
        /// </summary>
        /// <param name="amount">amount to put</param>
        public void Put(int amount)
        {
            if (!this.Activity)
            {
                throw new InvalidOperationException(AccountNumber + " is closed!");
            }

            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount) + " < 0 ");
            }
            else
            {
                BonusPointsUp(amount);
                Sum += amount;                
            }
        }

        /// <summary>
        /// Withdraw of the account for the specified amount
        /// </summary>
        /// <param name="amount">amount to withdraw</param>
        public void Withdraw(int amount)
        {
            if (!this.Activity)
            {
                throw new InvalidOperationException(AccountNumber + " is closed!");
            }

            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount) + " < 0 ");
            }
            else
            {
                BonusPointsDown(amount);
                Sum -= amount;
            }
        }

        /// <summary>
        /// Makes it impossible to replenish or withdraw from the account
        /// </summary>
        public void CloseAccount()
        {
            if (Sum != 0)
            {
                throw new InvalidOperationException(AccountNumber + " can not be closed");
            }
            else
            {
                Activity = !Activity;
            }
        }

        /// <summary>
        /// Adds bonus points
        /// </summary>
        /// <param name="amount"></param>
        private void BonusPointsUp(int amount)
        {
            BonusPoints = BonusPoints + (int)(((sum * (int)Type) + (amount * (int)Type)) * 0.01);
        }

        /// <summary>
        /// Removes the bonus
        /// </summary>
        /// <param name="amount"></param>
        private void BonusPointsDown(int amount)
        {
            BonusPoints = BonusPoints - (int)(((sum * (int)Type) + (amount * (int)Type)) * 0.01);
        }
    }
}
