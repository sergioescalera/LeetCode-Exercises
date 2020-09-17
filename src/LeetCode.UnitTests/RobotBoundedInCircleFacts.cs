using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("1041. Robot Bounded In Circle")]
    public class RobotBoundedInCircleFacts
    {
        [TestMethod]
        public void Example1()
        {
            Assert.IsTrue(new RobotBoundedInCircle().IsRobotBounded("GGLLGG"));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.IsFalse(new RobotBoundedInCircle().IsRobotBounded("GG"));
        }

        [TestMethod]
        public void Example3()
        {
            Assert.IsTrue(new RobotBoundedInCircle().IsRobotBounded("GL"));
        }
    }
}
