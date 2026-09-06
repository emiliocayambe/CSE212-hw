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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // create List to 0
        // Step 1: Create an array of doubles with the size of 'length'.
        double[] result = new double[length];

        // Step 2: Use a loop to fill the array with multiples of 'number'.
        //         - For each index i in the array, calculate the multiple as number * (i + 1) and assign it to the array at index i.

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // Step 3: Return the filled array.

        return result; // replace this return statement with your own
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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a temporary list to hold the last elements that will be rotated to the front.
        List<int> temp = new List<int>();

        // Step 2: Use a loop to add the last elements of the data list to the temporary list. The number of elements to add is equal to 'amount'.

        for (int i = data.Count - amount; i < data.Count; i++)
        {
            temp.Add(data[i]);
        }
        // Step 3: Use another loop to shift the remaining elements of the data list to the right by 'amount' positions.
        for (int i = data.Count - 1; i >= amount; i--)
        {
            data[i] = data[i - amount];
        }
        // Step 4: Use a final loop to copy the elements from the temporary list back to the front of the data list.
        for (int i = 0; i < temp.Count; i++)
        {
            data[i] = temp[i];
        }

    }
}
