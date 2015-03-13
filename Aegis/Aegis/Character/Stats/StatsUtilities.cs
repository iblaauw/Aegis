using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Stats
{
    static class StatsUtilities
    {
        /// <summary>
        /// Does a single pass over a linked list. If a value matches "removePredicate", that
        /// element gets removed from the linked list. Otherwise it is returned as part of the
        /// IEnumerable collection
        /// </summary>
        public static IEnumerable<T> TraverseRemove<T>(this LinkedList<T> list, Func<T, bool> removePredicate)
        {
            LinkedListNode<T> ptr = list.First;
            while (ptr != null)
            {
                if (removePredicate(ptr.Value))
                {
                    //Remove the current adjuster and move to the next value
                    LinkedListNode<T> toRemove = ptr;
                    ptr = ptr.Next;
                    list.Remove(toRemove);
                    continue;
                }

                yield return ptr.Value;
                ptr = ptr.Next;
            }
        }
    }
}
