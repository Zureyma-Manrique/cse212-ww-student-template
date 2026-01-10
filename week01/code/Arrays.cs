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
                // 1. Create a new array of doubles with the size specified by 'length'.
                // 2. Use a for loop to iterate from 0 up to length - 1.
                // 3. Inside the loop, calculate the multiple by multiplying 'number' by (index + 1).
                // 4. Assign this calculated value to the current index in the array.
                // 5. After the loop finishes, return the filled array.
        
                double[] result = new double[length];
                
                for (int i = 0; i < length; i++)
                {
                    result[i] = number * (i + 1);
                }
        
                return result;
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
        // 1. Calculate the effective rotation amount using modulo (amount % data.Count). 
        //    This handles cases where amount is larger than the list size, though the problem says it won't be.
        //    It also handles the case where amount equals data.Count (result 0).
        // 2. Identify the cut point (pivot) in the list. The items to move to the front start at index: data.Count - effectiveAmount.
        // 3. Use GetRange to create a sub-list of the items that need to move (the suffix).
        // 4. Use RemoveRange to remove those items from the end of the original list.
        // 5. Use InsertRange to insert the sub-list at the beginning (index 0) of the original list.

        // Standard check to ensure we don't operate on empty lists
        if (data.Count < 2) return;

        int effectiveAmount = amount % data.Count;

        // If rotation is 0 (or a multiple of Count), the list stays the same.
        if (effectiveAmount == 0) return;

        // Calculate where the slice begins
        int pivotIndex = data.Count - effectiveAmount;

        // Get the slice of items from the end
        List<int> slice = data.GetRange(pivotIndex, effectiveAmount);

        // Remove them from the end
        data.RemoveRange(pivotIndex, effectiveAmount);

        // Insert them at the beginning
        data.InsertRange(0, slice);
    }
}
