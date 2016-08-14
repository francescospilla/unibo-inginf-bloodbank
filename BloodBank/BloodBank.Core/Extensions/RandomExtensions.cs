using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodBank.Core.Extensions {

    public static class RandomExtensions {
        private static Random _rand;

        public static List<T> PickRandom<T>(this T[] values, int numValues) {
            // Create the Random object if it doesn't exist.
            if (_rand == null) _rand = new Random();

            // Don't exceed the array's length.
            if (numValues >= values.Length)
                numValues = values.Length - 1;

            // Make an array of indexes 0 through values.Length - 1.
            int[] indexes = Enumerable.Range(0, values.Length).ToArray();

            // Build the return list.
            List<T> results = new List<T>();

            // Randomize the first num_values indexes.
            for (int i = 0; i < numValues; i++) {
                // Pick a random entry between i and values.Length - 1.
                int j = _rand.Next(i, values.Length);

                // Swap the values.
                int temp = indexes[i];
                indexes[i] = indexes[j];
                indexes[j] = temp;

                // Save the ith value.
                results.Add(values[indexes[i]]);
            }

            // Return the selected items.
            return results;
        }
    }
}