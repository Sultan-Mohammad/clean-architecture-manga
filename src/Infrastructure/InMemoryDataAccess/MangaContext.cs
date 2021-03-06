// <copyright file="MangaContext.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.InMemoryDataAccess
{
    using System.Collections.ObjectModel;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public sealed class MangaContext
    {
        public MangaContext()
        {
            var entityFactory = new EntityFactory();
            this.Customers = new Collection<Customer>();
            this.Accounts = new Collection<Account>();
            this.Credits = new Collection<Credit>();
            this.Debits = new Collection<Debit>();
            this.Users = new Collection<User>();

            var customer = new Customer(
                new SSN("8608179999"),
                new Name("Ivan Paulovich"));
            var user1 = new User(
                customer.Id,
                new ExternalUserId("github/ivanpaulovich"));
            var account = new Account(customer.Id);
            var credit = account.Deposit(
                entityFactory,
                new PositiveMoney(800));
            var debit = account.Withdraw(
                entityFactory,
                new PositiveMoney(100));
            customer.Register(account.Id);

            this.Customers.Add(customer);
            this.Accounts.Add(account);
            this.Credits.Add((Credit)credit);
            this.Debits.Add((Debit)debit);
            this.Users.Add(user1);

            this.DefaultCustomerId = customer.Id;
            this.DefaultAccountId = account.Id;

            var secondCustomer = new Customer(
                new SSN("8408319999"),
                new Name("Andre Paulovich"));
            var secondUser = new User(
                secondCustomer.Id,
                new ExternalUserId("github/andrepaulovich"));
            var secondAccount = new Account(secondCustomer.Id);

            this.Customers.Add(secondCustomer);
            this.Accounts.Add(secondAccount);
            this.Users.Add(secondUser);

            this.SecondCustomerId = secondCustomer.Id;
            this.SecondAccountId = secondAccount.Id;
        }

        public Collection<User> Users { get; set; }

        public Collection<Customer> Customers { get; set; }

        public Collection<Account> Accounts { get; set; }

        public Collection<Credit> Credits { get; set; }

        public Collection<Debit> Debits { get; set; }

        public CustomerId DefaultCustomerId { get; }

        public AccountId DefaultAccountId { get; }

        public CustomerId SecondCustomerId { get; }

        public AccountId SecondAccountId { get; }
    }
}
