// <copyright file="ProcessTest.cs">Copyright ©  2017</copyright>
using System;
using CapitalOne_Interview.BusinessObject;
using CapitalOne_Interview.DataAccess;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapitalOne_Interview.DataAccess.Tests
{
    /// <summary>This class contains parameterized unit tests for Process</summary>
    [PexClass(typeof(Process))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ProcessTest
    {
        /// <summary>Test stub for CalculateTransactions(TransactionCollection)</summary>
        [PexMethod]
        public string CalculateTransactionsTest(
            [PexAssumeUnderTest]Process target,
            TransactionCollection transactions
        )
        {
            string result = target.CalculateTransactions(transactions);
            return result;
            // TODO: add assertions to method ProcessTest.CalculateTransactionsTest(Process, TransactionCollection)
        }
    }
}
