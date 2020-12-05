using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class ReconstructItinerary
    {
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            if (tickets == null || tickets.Count == 0)
            {
                return new string[0];
            }

            var itinerary = new List<string>(new[] { "JFK" });

            FindItinerary(
                tickets.Count,
                tickets
                    .GroupBy(t => t[0])
                    .ToDictionary(g => g.Key, g => new HashSet<string>(g.OrderBy(t => t[1]).Select(t => t[1]))),
                "JFK",
                itinerary,
                tickets
                    .Select(t => $"{t[0]}-{t[1]}")
                    .GroupBy(t => t)
                    .ToDictionary(g => g.Key, g => g.Count())
            );

            return itinerary;
        }

        bool FindItinerary(
            int total,
            IDictionary<string, HashSet<string>> tickets,
            string current,
            IList<string> itinerary,
            IDictionary<string, int> visited)
        {
            if (itinerary.Count == total + 1)
            {
                return true;
            }

            if (tickets.ContainsKey(current) == false)
            {
                return false;
            }

            var adjacent = tickets[current];

            foreach (var next in adjacent)
            {

                var ticket = $"{current}-{next}";

                if (visited[ticket] <= 0)
                {
                    continue;
                }

                visited[ticket]--;

                itinerary.Add(next);

                if (FindItinerary(total, tickets, next, itinerary, visited))
                {
                    return true;
                }

                itinerary.RemoveAt(itinerary.Count - 1);

                visited[ticket]++;
            }

            return false;
        }
    }
}
