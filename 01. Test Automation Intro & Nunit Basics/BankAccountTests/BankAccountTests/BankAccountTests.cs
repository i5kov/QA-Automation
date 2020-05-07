using NUnit.Framework;
using SeleniumBasicDemo;
using System;

namespace BankAccountTests
{
    public class Tests
    {
        [Test]
        public void Deposit_WhenAmountGraterThanZero_ShouldUpdateBalance()
        {
            decimal initBalance = 1000;
            decimal depositAmount = 999;
            BankAccount bankAccount = new BankAccount(initBalance);
            bankAccount.Deposit(depositAmount);
            decimal expectedResult = 1999;
            decimal actualResult = bankAccount.Amount;
            Assert.AreEqual(expectedResult, actualResult, 
                $"Expected amount: {expectedResult} is not equal to actual amount: {actualResult}");
        }

        [Test]
        public void Deposit_WhenAmoutLessThanZero_ShouldThrowException()
        {
            decimal initAmount = 1500;
            decimal depositAmount = -30;
            BankAccount bankAccount = new BankAccount(initAmount);
            Assert.Throws<System.ArgumentException>(() => bankAccount.Deposit(depositAmount));
        }

        [Test]
        public void Withdraw_WhenWithdrawAmountLessThanInitBalanceAndLessThan1000_ShouldWithdrawAmountWithFivePercentTax()
        {
            decimal initAmount = 50;
            //amount less than init bank account amount and less than 1000
            decimal withdrawAmount = 10;
            BankAccount bankAccount = new BankAccount(initAmount);
            bankAccount.Withdraw(withdrawAmount);
            decimal expectedAmountAfterWithdraw = 39.5m;
            decimal actualAmountAfterWithdraw = bankAccount.Amount;
            Assert.AreEqual(expectedAmountAfterWithdraw, actualAmountAfterWithdraw,
                $"Expected amount after withdraw: {expectedAmountAfterWithdraw} is not equal to actual amount after withdraw {actualAmountAfterWithdraw}");
        }

        [Test]
        public void Withdraw_WhenWithdrawAmountLessThanInitBalanceAndGraterThan1000_ShouldDecreaseInitBalanceWithWithdrawAmountAndTwoPercentTax()
        {
            decimal initAmount = 2000;
            //amount less than init bank account balance and grater than 1000
            decimal withdrawAmount = 1001;
            BankAccount bankAccount = new BankAccount(initAmount);
            bankAccount.Withdraw(withdrawAmount);
            decimal expectedAmount = 979.98m;
            decimal actualAmount = bankAccount.Amount;
            //compare two decimals - expected and actual result
            bool result = Math.Abs(expectedAmount - actualAmount) >= 0.000001M;
            Assert.IsTrue(result, $"Expected amount: {expectedAmount} not equal to actual amount{actualAmount}");
        }


        //The test fails because in the code there is a bug for withdraw operation.
        //Currently, it's possible to withdraw amount which is grater than init amount, whic is not correct.
        //Check that withdraw amount must be less than init amout must be added.

        // The check has been added, so if you want this test passed - please uncomment
        // if statement placed into BankAccount class -> Withdraw method
        [Test]
        public void Withdraw_WhenWithdrawAmountGratertThanInitBalance_ShouldNotBePossibleToWithdraw()
        {
            decimal initAmount = 100;
            decimal withdrawAmount = 200;
            BankAccount bankAccount = new BankAccount(initAmount);
            Assert.Throws<System.ArgumentException>(() => bankAccount.Withdraw(withdrawAmount));
        }

        [Test]
        public void CreateBankAccount_WhenInitBalanceLessThanZero_ShouldThrowException()
        {
            decimal initBalance = -1;
            Assert.Throws<System.ArgumentException>(() => new BankAccount(initBalance));
        }

        [Test]
        public void CreateBankAccount_WhenInitBalanceGraterThanZero_ShouldCreateBankAcountWithGivenInitBalance()
        {
            decimal initBalance = 100;
            BankAccount bankAccount = new BankAccount(initBalance);
            decimal actualAmount = bankAccount.Amount;
            Assert.AreEqual(initBalance, actualAmount,
                $"Expected amount {initBalance} not equal to actual amount {actualAmount}");
        }
    }
}