using System;
using System.Collections.Generic;
using FormsApp.PascalCase;
using FormsApp.Primes;
using Xunit;

namespace FormsApp.Test
{
    public class PrimesTests
    {
        [Theory]
        [InlineData(1, 2, new[] {2})]
        [InlineData(2, 2, new[] {2})]
        [InlineData(2, 3, new[] {2, 3})]
        [InlineData(2, 4, new[] {2, 3})]
        [InlineData(2, 10, new[] {2, 3, 5, 7})]
        [InlineData(2, 22, new[] {2, 3, 5, 7, 11, 13, 17, 19})]
        public void ShouldCalculatePrimeNumbers(int start, int end, int[] primes)
        {
            var calculatedPrimes = new PrimeProgram().GetPrimeNumbers(start, end);
            Assert.Equal(calculatedPrimes, primes);
        }
    }

    public class PascalCaseTests
    {
        [Theory]
        [InlineData("Face book", new[] {'F'})]
        [InlineData("FaceBook", new[] {'F', 'B'})]
        [InlineData("This iS a PascalCase3 eXample.", new[] {'T', 'P', 'C', '3'})]
        public void ShouldFindPascalCaseLetters(string sentence, IEnumerable<char> expected)
        {
            var letters = new PascalCaseProgram().GetUpperChars(sentence);
            Assert.Equal(expected, letters);
        }
    }
}