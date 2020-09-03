using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("766. Toeplitz Matrix")]
    public class ToeplitzMatrixFacts
    {
        [TestMethod]
        public void ShouldReturnTrue1x1()
        {
            var sol = new ToeplitzMatrix();

            Assert.IsTrue(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1 }
            }));

            Assert.IsTrue(sol.IsToeplitzMatrix(new[]
            {
                new[] { int.MinValue }
            }));
        }

        [TestMethod]
        public void ShouldReturnFalse2x2()
        {
            var sol = new ToeplitzMatrix();

            Assert.IsFalse(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1, 2 },
                new[] { 2, 2 }
            }));

            Assert.IsFalse(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1, 3 },
                new[] { 2, 2 }
            }));
        }

        [TestMethod]
        public void ShouldReturnTrue2x2()
        {
            var sol = new ToeplitzMatrix();

            Assert.IsTrue(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1, 2 },
                new[] { 2, 1 }
            }));

            Assert.IsTrue(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1, 3 },
                new[] { 2, 1 }
            }));
        }

        [TestMethod]
        public void ShouldReturnTrue3x2()
        {
            var sol = new ToeplitzMatrix();

            Assert.IsTrue(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1, 2 },
                new[] { 2, 1 },
                new[] { 4, 2 }
            }));
        }

        [TestMethod]
        public void ShouldReturnFalse3x2()
        {
            var sol = new ToeplitzMatrix();

            Assert.IsFalse(sol.IsToeplitzMatrix(new[]
            {
                new[] { 2, 2 },
                new[] { 2, 1 },
                new[] { 4, 2 }
            }));

            Assert.IsFalse(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1, 2 },
                new[] { 2, 1 },
                new[] { 4, 3 }
            }));
        }

        [TestMethod]
        public void ShouldReturnTrue4x3()
        {
            var sol = new ToeplitzMatrix();

            var matrix = new[]
            {
                new[] { 1, 2, 3, 4 },
                new[] { 5, 1, 2, 3 },
                new[] { 9, 5, 1, 2 }
            };

            var result = sol.IsToeplitzMatrix(matrix);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnFalse4x3()
        {
            var sol = new ToeplitzMatrix();

            Assert.IsFalse(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1, 2, 3, 4 },
                new[] { 5, 1, 2, 3 },
                new[] { 9, 5, 2, 2 }
            }));

            Assert.IsFalse(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1, 2, 3, 4 },
                new[] { 5, 1, 5, 3 },
                new[] { 9, 5, 1, 2 }
            }));

            Assert.IsFalse(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1, 2, 3, 4 },
                new[] { 5, 1, 2, 4 },
                new[] { 9, 5, 1, 2 }
            }));

            Assert.IsFalse(sol.IsToeplitzMatrix(new[]
            {
                new[] { 1, 2, 3, 4 },
                new[] { 5, 1, 2, 3 },
                new[] { 9, 6, 1, 2 }
            }));
        }
    }
}
