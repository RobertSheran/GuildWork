using SGBank.Modles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Modles;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        public string _filePath { get; set; }
        public FileAccountRepository(string filePath)
        {
            CheckFilePath(filePath);
            _filePath = filePath;
        }

        public void CheckFilePath(string filepath)
        {
            FileStream file = null;
            try
            {
                file = File.Open(filepath, FileMode.Open);
            }

#pragma warning disable CS0168 // Variable is declared but never used
            catch (FileNotFoundException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine($"The file: {filepath} was not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred reading the file: {ex.Message}");
                Console.WriteLine($"The error happened at: {ex.StackTrace}");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }

        public Account LoadAccount(string accountNumber)
        {
            List<Account> accounts = CreateListOfAccounts();

            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        public List<Account> CreateListOfAccounts()
        {
            List<Account> listAccounts = new List<Account>();
            string line;
            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                streamReader.ReadLine();
                while ((line = streamReader.ReadLine()) != null)
                {
                    listAccounts.Add(GetAccountFromFile(line));
                }
                return listAccounts;
            }
        }

        public Account GetAccountFromFile(string line)
        {
            string[] cSV = line.Split(',');
            Account account = new Account
            {
                AccountNumber = cSV[0],
                Name = cSV[1],
                Balance = decimal.Parse(cSV[2]),
                Type = MatchAccuntType(cSV[3])
            };
            return account;
        }

        public AccountType MatchAccuntType(string typeString)
        {
            AccountType accountType = new AccountType();
            switch (typeString)
            {
                case "F":
                    accountType = AccountType.Free;
                    break;
                case "B":
                    accountType = AccountType.Basic;
                    break;
                case "P":
                    accountType = AccountType.Premium;
                    break;
            }
            return accountType;
        }

        private string AccountTypeToLetter(AccountType type)
        {
            string letter = "";
            switch (type)
            {
                case AccountType.Free:
                    letter = "F";
                    break;
                case AccountType.Basic:
                    letter = "B";
                    break;
                case AccountType.Premium:
                    letter = "P";
                    break;
                default:
                    break;
            }
            return letter;
        }

        private void CreateNewFile()
        {
            File.Create(_filePath);
        }

        public void SaveAccount(Account account)
        {
            List<Account> accounts = CreateListOfAccounts();

            CreateListOfAccounts();

            using (StreamWriter streamWriter = new StreamWriter(_filePath))
            {

                streamWriter.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (var line in accounts)
                {
                    if (line.AccountNumber == account.AccountNumber)
                    {

                        streamWriter.WriteLine(account.AccountNumber + "," + account.Name + "," + account.Balance.ToString() + "," + AccountTypeToLetter(account.Type));
                    }
                    else
                    {
                        streamWriter.WriteLine(line.AccountNumber + "," + line.Name + "," + line.Balance.ToString() + "," + AccountTypeToLetter(line.Type));
                    }
                }
            }
        }
    }
}
