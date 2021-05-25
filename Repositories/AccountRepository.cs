using System;
using System.Data;
using Dapper;
using spring21_burgershack.Models;

namespace spring21_burgershack.Repositories
{
  public class AccountRepository
  {
    private readonly IDbConnection _db;

    public AccountRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Account GetById(string id)
    {
      string sql = "SELECT * FROM accounts WHERE id = @id;";
      return _db.QueryFirstOrDefault<Account>(sql, new { id });
    }

    internal Account Create(Account userInfo)
    {
      string sql = @"
      INSERT INTO accounts
      (id, name, picture, email)
      VALUES
      (@Id, @Name, @Picture, @Email);";
      _db.Execute(sql, userInfo);
      return userInfo;
    }
  }
}