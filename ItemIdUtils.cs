using System.Collections.Generic;

namespace AndrosCommands;

public static class ItemIdUtils
{
    /// <summary>
    /// Retrieves the item ids from a set
    /// </summary>
    /// <param name="set"></param>
    /// <returns></returns>
    public static List<int> GetItemsInSet(bool[] set)
    {
        return GetItemsInSets([set]);
    }

    /// <summary>
    /// Retrieves the item ids from multiple sets
    /// </summary>
    /// <param name="sets"></param>
    /// <returns></returns>
    public static List<int> GetItemsInSets(List<bool[]> sets)
    {
        List<int> items = [];

        foreach (bool[] set in sets)
        {
            for (int i = 0; i < set.Length; i++)
            {
                if (set[i])
                {
                    items.Add(i);
                }
            }
        }

        return items;
    }
}