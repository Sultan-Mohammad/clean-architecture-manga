// <copyright file="DepositOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Deposit
{
    using System;
    using Domain.Accounts.Credits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Deposit Output Message.
    /// </summary>
    public sealed class DepositOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DepositOutput" /> class.
        /// </summary>
        /// <param name="credit">Credit object.</param>
        /// <param name="updatedBalance">The updated balance.</param>
        public DepositOutput(
            ICredit credit,
            Money updatedBalance)
        {
            if (credit is Credit creditEntity)
            {
                this.Transaction = new Transaction(
                    Credit.Description,
                    creditEntity.Amount,
                    creditEntity.TransactionDate);

                this.UpdatedBalance = updatedBalance;
            }
            else
                throw new ArgumentNullException(nameof(credit));
        }

        /// <summary>
        ///     Gets the Transaction object.
        /// </summary>
        public Transaction Transaction { get; }

        /// <summary>
        ///     Gets the updated balance.
        /// </summary>
        public Money UpdatedBalance { get; }
    }
}
