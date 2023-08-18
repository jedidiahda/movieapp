using MovieWebApp.Models;

namespace MovieWebApp.Service.DTO
{
    public class AccountAdaptor
    {
        public static AccountDTO GetAccountDTO(Account account)
        {
            if (account == null) return null;
            AccountDTO accountDTO = new AccountDTO();
            accountDTO.Email = account.Email;
            accountDTO.Password = account.Password;
            accountDTO.Active = account.Active;
            accountDTO.Role = account.Role;
            return accountDTO;
        }

        public static Account GetAccount(AccountDTO accountDTO)
        {
            if (accountDTO == null) return null;
            Account account = new Account();
            account.Email = accountDTO.Email??"";
            account.Password = accountDTO.Password??"";
            account.Active = accountDTO.Active;
            account.Role = accountDTO.Role;
            return account;
        }
    }
}
