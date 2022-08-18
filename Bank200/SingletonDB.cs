using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank200
{
    internal sealed class SingletonDB
    {
        //Creating the singlton instance 
        private static SingletonDB account_instance = new SingletonDB();
        /**
         * Account details will store: 
         * savingsAccount{1 & 2} Information {Client Name, Balance}
         * currentAccount{1 & 2} Information {Client Name,Balance,Overdraft}
         */
        private String[] savingsAccount1, savingsAccount2, currentAccount1, currentAccount2;
        /**
         * Accounts will store the {account id, array of account details}
         * The savings account id - will start with '569'
         * The current account id - will start with '489'
         * 
         * Both the accounts will consist of 8 digits 
         */
        private Dictionary<String, String[]> Accounts = new Dictionary<String, String[]>(); 

        //DB constructor to initialise the account information
        private SingletonDB() {

            /**
             * savingsAccount array will store the {client name, Balance}
             * 
             */
            savingsAccount1 = new String[] {"customerNum1","2000"};
            savingsAccount2 = new String[] { "customerNum2", "5000" };
            Accounts.Add("56984578",savingsAccount1);
            Accounts.Add("56985231",savingsAccount2);

            /**
             * currentAccount {1 & 2} will store the {client name, balance, overdraft}
             * 
             */
            currentAccount1 = new String[] {"customerNum3","+1000","10000"};
            currentAccount2 = new String[] { "customerNum4", "-5000", "20000"};
            Accounts.Add("48965231",currentAccount1);
            Accounts.Add("48920156", currentAccount2);

        }

        //Static Method to provide access to the instance 
        public static SingletonDB AccountInstance
        {
            get { return account_instance; }
        }

        public Dictionary<String, String[]> getAccounts()
        {
            return Accounts; 
        }
    }
}
