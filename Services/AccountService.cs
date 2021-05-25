using System;
using spring21_burgershack.Models;
using spring21_burgershack.Repositories;

namespace spring21_burgershack.Services
{
  public class AccountService
  {
    private readonly AccountRepository _accountRepository;

    public AccountService(AccountRepository accountRepository)
    {
      _accountRepository = accountRepository;
    }

    internal Account GetOrCreateAccount(Account userInfo)
    {
      Account account = _accountRepository.GetById(userInfo.Id);
      if (account == null)
      {
        return _accountRepository.Create(userInfo);
      }
      return account;
    }
  }
}