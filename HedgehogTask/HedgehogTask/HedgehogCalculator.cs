
namespace HedgehogTask
{
    public class HedgehogCalculator
    {
        /// <summary>
        /// A solution for hedgehog task. Used BFS (Breadth-First Search) for solving.
        /// </summary>
        /// <param name="start">Start node of color combination</param>
        /// <param name="targetColor">Number (1-2) which represent color all the hedgehogs must unify to</param>
        /// <returns>Returns a value which represents steps count and steps list. -1 means that node is inaccessible</returns>
        public static (int, List<(int red, int green, int blue)>) CalculateMinMeetingsToUnify(int[] start, int targetColor)
        {
            //Validation checks
            if(start.Length != 3)
                throw new Exception("Colors array must contain 3 values");
            if(targetColor < 0 || targetColor > 2)
                throw new Exception("Target color must be between 0 and 2");

            var targetCounts = new[] { 0, 0, 0 };
            targetCounts[targetColor] = start[0] + start[1] + start[2];

            if ((start[0] == targetCounts[0] && start[1] == 0 && start[2] == 0) ||
                (start[0] == 0 && start[1] == targetCounts[1] && start[2] == 0) ||
                (start[0] == 0 && start[1] == 0 && start[2] == targetCounts[2]))
            {
                return (0, new List<(int, int, int)> { (start[0], start[1], start[2]) });
            }

            var visited = new HashSet<(int, int, int)>();
            var queue = new Queue<(int red, int green, int blue, int steps, List<(int, int, int)> path)>();
            var initialPath = new List<(int, int, int)> { (start[0], start[1], start[2]) };
            queue.Enqueue((start[0], start[1], start[2], 0, initialPath));
            visited.Add((start[0], start[1], start[2]));

            while (queue.Count > 0)
            {
                var (r, g, b, steps, path) = queue.Dequeue();
                
                // Generate all possible states from current state
                foreach (var (newR, newG, newB) in GenerateNextStates(r, g, b))
                {
                    if ((newR == targetCounts[0] && newG == 0 && newB == 0) ||
                        (newR == 0 && newG == targetCounts[1] && newB == 0) ||
                        (newR == 0 && newG == 0 && newB == targetCounts[2]))
                    {
                        var finalPath = new List<(int, int, int)>(path) { (newR, newG, newB) };
                        return (steps + 1, finalPath);
                    }

                    var newState = (newR, newG, newB);
                    if (!visited.Contains(newState))
                    {
                        visited.Add(newState);
                        var newPath = new List<(int, int, int)>(path) { (newR, newG, newB) };
                        queue.Enqueue((newR, newG, newB, steps + 1, newPath));
                    }
                }
            }

            return (-1, new List<(int, int, int)>());
        }

        /// <summary>
        /// Method for generating new possible nodes for graph
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns>New nodes list</returns>
        private static IEnumerable<(int, int, int)> GenerateNextStates(int r, int g, int b)
        {
            var states = new List<(int, int, int)>();
            if (r > 0 && g > 0)
                states.Add((r - 1, g - 1, b + 2));
            if (r > 0 && b > 0)
                states.Add((r - 1, g + 2, b - 1));
            if (g > 0 && b > 0)
                states.Add((r + 2, g - 1, b - 1));
            return states;
        }
    }
}
