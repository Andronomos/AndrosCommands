using System.Collections.Generic;

namespace AndrosCommands;

public static class ItemIdUtils
{
    public static List<int> GetItemsInSet(bool[] set)
    {
        List<int> items = [];

        for (int i = 0; i < set.Length; i++)
        {
            if (set[i])
            {
                items.Add(i);
            }
        }

        return items;
    }
}