# Chapter 4
Review again:
4.9, 4.12

1) BFS & refresher
2) Objects can be built recursively rather than constructing the reference first and passing that through the recursive method
3) Iterative is not always faster. Wait to create the object until it's needed/
4) Do work on the way "up" the recursive call stack, after the recursive method completes
5) Changing param values as a "window" down a recursive call stack
6) Just keep doing examples. Nail each sub-part of the problem.
7)
    1) When dealing with directed graphs, use two for O(1) lookup in both directions
    2) Change the words to change the arrow direction if it's not making sense ("depends on" or "built before")
    3) Topological sort
8)
    1) know when to fall back to less preformat solution
    2) Enumerate possible cases for recursive function doing work on the way back up.
9) TODO
10) Don't use recursive `yield return`
11) Pay attention to the restrictions imposed by the question. Don't implement stuff for testing until the testing is required.
12) Think about what it means to "restart" the recursion in order to find every path

# Chapter 5
1) Clear bit i -> n & ~(1 << i)
2) Binary representation of floating point numbers are inverted fractions
3) Greedy approach - think about what you really need when going through the problem
4) What happens to a binary number when it's made smaller or larger
5) n/a
6) XOR is a difference detector
7)
    1) Masks can be made from HEX digits
    2) Isolate even digits with 0xAA
    3) Isolate odd digits with 0x55
    4) 2 HEX digits per byte, 8 HEX digits per 32bit integer
8) Draw out examples
