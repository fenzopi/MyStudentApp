using Xunit;

namespace MyStudentApp.Tests
{
    public class PeselValidatorTests
    {
        [Theory]
        [InlineData("12345678901", false)] // Poprawny PESEL
        [InlineData("98765432109", false)] // Poprawny PESEL
        [InlineData("123", false)] // Za krótki PESEL
        [InlineData("123456789012", false)] // Za długi PESEL
        [InlineData("abcdefghijk", false)] // Niepoprawny PESEL (zawiera litery)
        [InlineData("1234567890a", false)] // Niepoprawny PESEL (zawiera literę)
        public void ValidatePesel_ValidAndInvalidPesels_ReturnsExpectedResult(string pesel, bool expectedResult)
        {
            // Arrange & Act
            bool isValid = PeselValidator.ValidatePesel(pesel);

            // Assert
            Assert.Equal(expectedResult, isValid);
        }
    }
}
