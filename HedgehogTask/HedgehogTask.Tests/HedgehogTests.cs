namespace HedgehogTask.Tests
{
    public class Tests
    {
        [Test]
        public void Test_050_color1_equals_0()
        {
            //

            int[] colors = { 0, 5, 0 };
            int color = 1;
            int expected = 0;

            //

            var (result, path) = HedgehogCalculator.CalculateMinMeetingsToUnify(colors, color);

            //

            Assert.AreEqual(result, expected);
        }
        [Test]
        public void Test_512_color1_equals_5()
        {
            //

            int[] colors = { 5,1,2 };
            int color = 1;
            int expected = 5;

            //

            var (result, path) = HedgehogCalculator.CalculateMinMeetingsToUnify(colors, color);

            //

            Assert.AreEqual(result, expected);
        }
        [Test]
        public void Test_BigData_color0_equals_minus1()
        {
            //

            int[] colors = { 678, 100, 983 };
            int color = 0;
            int expected = -1;

            //

            var (result, path) = HedgehogCalculator.CalculateMinMeetingsToUnify(colors, color);

            //

            Assert.AreEqual(result, expected);
        }
    }
}