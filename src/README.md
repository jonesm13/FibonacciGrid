# Fibonacci Grid

## Requirement

Create a grid of 50x50. When you click on a cell, all values in the cells in the
same row and column are increased by 1 or, if a cell was empty, it will get a
value of 1.

After each change a cell will briefly turn yellow.

If 5 consecutive numbers in the Fibonacci sequence are next to each other, these
cells will briefly turn green and will be cleared.

## Implementation

The solution is implemented as a .NET Core project with an MVC-style single-page
app at the front, a Web API and a Domain library in the back-end. It's certainly
the case that this could all be implemented in JS however this is not my
strength (especially testing JavaScript) so I have elected to structure the
solution in this way.

Domain logic is contained within the Domain project. The `Grid` type is the
location of the main state storage for each Grid, for identifying sequences
and raising events.

Instead of working out each Fibonacci number as square values change, I have
chosen to store the Fibonacci index of each value in an integer array. This is
a trade-off between memory and performance; doubling the memory usage of each
Grid in order to save time working out the Fibonacci number index of each square
as it is clicked.

The Fibonacci method used differs slightly from the cardinal Fibonacci sequence
because the zero and first 1 digit of the sequence are ignored. This is because
values in the grid squares are compared by value rather than by ordinal position
in the sequence. Thus, the Fibonacci sequence which is normally
`{ 0, 1, 1, 2, 3, 5 ... }` is actually considered as `{ 1, 2, 3, 5 ... }`. The
zero is ignored as this is used to denote that a square is empty.

## Optimisations/refactoring

With each click, the whole grid (each row and column and in each direction) is
examined to see whether it contains a sequence. This is not efficient and can be
optimised by only examining the rows and columns that have been changed by a
given click. This will require no change to the tests because the aggregate
result will be the same.