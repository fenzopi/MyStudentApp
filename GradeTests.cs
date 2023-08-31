using System;
using System.Diagnostics;
using Xunit;

namespace MyStudentApp.Tests
{
    public class GradeTests
    {
        [Fact]
        public void CalculateClassAverage_NoStudents_ReturnsZero()
        {
            // Arrange
            Grade grade = new Grade();

            // Act
            double average = grade.CalculateClassAverage();

            // Assert
            Assert.Equal(0, average);
        }

     


        [Fact]
        public void GetStudentWithHighestAverage_NoStudents_ReturnsNull()
        {
            // Arrange
            Grade grade = new Grade();

            // Act
            Student student = grade.GetStudentWithHighestAverage();

            // Assert
            Assert.Null(student);
        }

        // Add more test methods for other Grade methods...

    }
}
