public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Plan:
        // 1. Create a new array of doubles with 'length' boxes to hold the results.
        // 2. Loop through every position (index) in the array, from 0 up to (length - 1).
        // 3. At each position, calculate the multiple as: number * (index + 1).
        // 4. Store that value in the array at the current position.
        // 5. After the loop finishes, return the filled array.

        var results = new double[length];
        for (var i = 0; i < length; i++)
        {
            results[i] = number * (i + 1);
        }

        return results; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Plan:
        // 1. Find where the last 'amount' numbers start: startIndex = data.Count - amount.
        // 2. Copy the numbers from startIndex to the end into a separate list, so they aren't lost.
        // 3. Remove those same numbers from 'data'.
        // 4. Insert the copied numbers at the beginning of 'data' (index 0), keeping their order.
        
        var startIndex = data.Count - amount;
        var lastItems = data.GetRange(startIndex, amount);
        data.RemoveRange(startIndex, amount);
        data.InsertRange(0, lastItems);
    }
}
