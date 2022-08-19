using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank200
{
    internal interface AccountService
    {
        /**
         * Function to open savings account 
         */
        public void openSavingsAccount(long accountId, long amountToDeposit);

        /**
         * Function to open Current Account
         * throws AccountNotFoundException,
         * throws WithdrawalAmountTooLargeException 
         */
        public void openCurrentAccount(long accountId);

        public void withdraw(long accountId, int amountToWithdarw);

        /**
         * Function to deposit 
         * throws AccountNotFoundException
         */
        public void deposit(long accountId, int amountToDeposit); 
    }

}
