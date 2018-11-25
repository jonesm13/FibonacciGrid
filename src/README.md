# Fibonacci Grid

## Requirement

Create a grid of 50x50. When you click on a cell, all values in the cells in the same row and column are increased by 1 or, if a cell was empty, it will get a value of 1.

After each change a cell will briefly turn yellow.

If 5 consecutive numbers in the Fibonacci sequence are next to each other, these cells will briefly turn green and will be cleared.

## Implementation

The solution is implemented as a .NET Core project. Domain logic is contained within 
the Domain project.

## Optimisations

With each click, the whole grid (each row and column) is examined to see whether
it contains a sequence. This is not efficient.