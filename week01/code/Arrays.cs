public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of doubles with the specified length
        double[] result = new double[length];
        
        // Step 2: Populate the array with multiples
        // For each index i from 0 to length-1, the value is number * (i+1)
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        
        // Step 3: Return the populated array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 
    /// then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the starting index of the right part (last 'amount' elements)
        int startRightIndex = data.Count - amount;
        
        // Step 2: Extract the right part (last 'amount' elements) and the left part (remaining elements)
        List<int> rightPart = data.GetRange(startRightIndex, amount);
        List<int> leftPart = data.GetRange(0, startRightIndex);
        
        // Step 3: Clear the original list to rebuild it with rotated elements
        data.Clear();
        
        // Step 4: Add the right part (moved to the front) followed by the left part
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}