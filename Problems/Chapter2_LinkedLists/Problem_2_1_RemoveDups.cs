using System.Collections.Generic;
using CrackingTheCodingInterview.Problems.DataStructures;

namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists
{
    public static class Problem_2_1_RemoveDups
    {
        /*
        1 -> 2 -> 3
             ^    ^
        */
        public static void Execute(AListNode<int> head)
        {
            var hashSet = new HashSet<int>() { head.Data };
            AListNode<int> prev = head;
            AListNode<int> cur = prev.Next;

            while (cur != null)
            {
                if (hashSet.Contains(cur.Data))
                {
                    prev.Next = cur.Next;
                }
                else
                {
                    prev = cur;
                }

                hashSet.Add(cur.Data);
                cur = cur.Next;
            }
        }
    }
}
