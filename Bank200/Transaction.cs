using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank200
{
    internal class Transaction : AccountService
    {

        Dictionary<String, String[]> currentAccount = new Dictionary<String, String[]>();
        String[] accountDetails;
        Dictionary<String, String[]> savingsAccount = new Dictionary<String, String[]>();
        String[] savingsDetails;
        Dictionary<String, String[]> Accounts = new Dictionary<String, String[]>();
        public void deposit(long accountId, int amountToDeposit)
        {
            

            Accounts = SingletonDB.AccountInstance.getAccounts();

            int accType = verifyAccount(accountId);

            switch (accType) {
                case 1:
                    String[] savingAccount = Accounts[accountId.ToString()];
                    String name = savingAccount[0];
                    long balance = long.Parse(savingAccount[1]);
                    long total = balance + amountToDeposit;

                    Console.WriteLine(total); 
                    break;
                case 2:

                    String[] currentAccount = Accounts[accountId.ToString()];
                    long cbalance = long.Parse(currentAccount[1]);
                    long ctotal = cbalance + amountToDeposit;

                    Console.WriteLine(ctotal);

                    break; 
                    default: throw new Exception("AccountDoesNotExist"); 
            
            }
         
        }

        public void openCurrentAccount(long accountId)
        {
            String id = accountId.ToString();


            accountDetails = new string[] { "customerNumn", "0", "0"};
            currentAccount.Add(id, accountDetails);
            Console.WriteLine("Account Opened");

            String[] acc = currentAccount[id];

            Console.WriteLine("Account Details........................\n");
            Console.WriteLine("Client Name:" + acc[0]+ "\n");
            Console.WriteLine("Account Balance:" + acc[1] + "\n");
            Console.WriteLine("Account Overdraft:" + acc[2] + "\n");
        }

        public void openSavingsAccount(long accountId, long amountToDeposit)
        {
            String id = accountId.ToString();


            if (amountToDeposit >= 1000) {

                savingsDetails = new string[] {"customerNumn", amountToDeposit.ToString()}; 
                savingsAccount.Add(id,savingsDetails);

                Console.WriteLine("Account Opened");
            }
            else if (amountToDeposit < 1000) {

                Console.WriteLine("Deposit Amount tooo low"); 
            }
            
        
        }

        public void withdraw(long accountId, int amountToWithdarw)
        {
           

            Accounts = SingletonDB.AccountInstance.getAccounts();

            int accType = verifyAccount(accountId);

            switch (accType)
            {
                case 1:
                    String[] savingAccount = Accounts[accountId.ToString()];
             
                    long balance = long.Parse(savingAccount[1]);


                    long total = 0;
                    
                    try {

                        if (amountToWithdarw > balance)
                        {

                            throw new Exception("WithdrawalAmountTooLarge");
                        }
                        else
                        {
                            total = balance - amountToWithdarw;

                            if (total < 1000)
                            {

                                throw new Exception("WithdrawalAmountTooLarge");
                            }

                        }

                        Console.WriteLine(total);


                    } catch (Exception e) { Console.WriteLine(e.Message); }


                    break;

                case 2:

                    String[] currentAccount = Accounts[accountId.ToString()];
                    long cbalance = long.Parse(currentAccount[1]);
                    long overdraft = long.Parse(currentAccount[2]);
                    long ctotal = 0;
                    long maxWithDraw = 0;

                    try {

                        if (cbalance < 0) {

                            maxWithDraw = cbalance + overdraft;

                            if (amountToWithdarw > maxWithDraw) {

                                throw new Exception("WithdrawalAmountTooLarge");

                            } else
                            {

                                ctotal = maxWithDraw - amountToWithdarw;
                            }
                        } else if (cbalance > 0 && amountToWithdarw < (overdraft + cbalance)) {

                            maxWithDraw = overdraft + cbalance;

                            ctotal = maxWithDraw - amountToWithdarw;
                        }else if (amountToWithdarw > (overdraft + cbalance)) { throw new Exception("WithdrawalAmountTooLarge"); }


                    } catch (Exception e) { Console.WriteLine(e.Message); }

                    Console.WriteLine(ctotal);

                    break;
                default: throw new Exception("AccountDoesNotExist");

            }
        }

        /**
         * Verify the type of account 
         * if starts with '569' -> Savings account {return 1}
         * if starts with '489' -> Current Account {return 2}
         */
        private int verifyAccount(long accountId) {

            /**
             * Will store value for the account type
             *  0 -> Account does not exist 
             *  1 -> Savings Account 
             *  2 -> Current Account
             */
            int acctype = 0;

            String id = accountId.ToString();

            if (id.Contains("569")) {

                acctype = 1; 

            }else if (id.Contains("489")) {
            
                acctype = 2;
            }


            return acctype; 
        
        }
    }
}
