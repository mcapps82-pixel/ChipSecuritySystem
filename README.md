# Chip Security System

A C# console app that finds the longest chain of bi-colours chips linking  Blue to Green, with matching adjacent colours. 

## How it works 

colours are modelled as a graph and chips as edges. The program uses backtracking search from Blue trying every unused  chip that matches the current colour, and keeps the logest chin that ends at green .

## How it run

Open 'ChipSecuritySystem.sln' in Visual Studio and press start, or run:

dotnet run

## Example 
input chips:
[Blue, Yellow], [Red, Green], [Yellow, Red] , [Orange, Purple]

Output:
Blue, [Blue, Yellow] [Yellow, Red] [Red, Green] Green

 

