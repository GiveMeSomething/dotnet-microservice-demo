using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusinessObjects.Utils
{
    public static class UpdateMN
    {
        public static void TryUpdateManyToMany<T, TKey>(
            this DbContext db,
                IEnumerable<T> currentItems,
                IEnumerable<T> newItems,
                Func<T, TKey> getKey
            ) where T : class
        {
            // Remove all items from the base set, except those appeared in new set
            db.Set<T>().RemoveRange(currentItems.Except(newItems, getKey));

            // Add all item from the new set, except those have appeared in base set
            db.Set<T>().AddRange(newItems.Except(currentItems, getKey));
        }

        public static IEnumerable<T> Except<T, TKey>(
                this IEnumerable<T> items,
                IEnumerable<T> other,
                Func<T, TKey> getKeyFunc
            )
        {
            return items
                // Group join between old key list and new key list
                .GroupJoin(
                    other, getKeyFunc, getKeyFunc, (item, tempItems) => new { item, tempItems } 
                )
                // Flatten the data inside in each group
                .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
                // Get all item that data is null
                // empty list, ...
                // IOW, different item compared to base items
                .Where(t => ReferenceEquals(null, t.temp) || t.temp.Equals(default(T)))
                // Return different item
                .Select(t => t.t.item);
        }
    }
}

