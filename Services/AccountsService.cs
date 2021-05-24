using System;
using spring21_burgershack.Models;

namespace spring21_burgershack.Services
{
  public class AccountsService
  {
    private readonly AccountsRepository _accountsRepository;

    public AccountsService(AccountsRepository accountsRepository)
    {
      _accountsRepository = accountsRepository;
    }

    internal Account GetOrCreateAccount(Account userInfo)
    {
      Account account = _accountsRepository.GetById(userInfo.Id);
      if (account == null)
      {
        return _accountsRepository.Create(userInfo);
      }
      return account;
    }
  }
}