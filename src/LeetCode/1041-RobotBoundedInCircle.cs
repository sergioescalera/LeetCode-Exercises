namespace LeetCode
{
    public class RobotBoundedInCircle
    {
        public bool IsRobotBounded(string instructions)
        {
            if (string.IsNullOrEmpty(instructions))
            {
                return true;
            }

            var go = 'G';
            var left = 'L';
            var right = 'R';

            var directions = new[]
            {
                new
                {
                    x = 0,
                    y = 1
                },
                new
                {
                    x = 1,
                    y = 0
                },
                new
                {
                    x = 0,
                    y = -1
                },
                new
                {
                    x = -1,
                    y = 0
                }
            };

            var x = 0;
            var y = 0;

            var d = 0;

            foreach (var i in instructions)
            {
                if (i == go)
                {
                    x += directions[d].x;
                    y += directions[d].y;
                }
                if (i == left)
                {
                    d = d == 0 ? directions.Length - 1 : d - 1;
                }
                if (i == right)
                {
                    d++;
                    d %= directions.Length;
                }
            }

            if (x == 0 && y == 0)
            {
                return true;
            }

            return d != 0;
        }
    }
}
