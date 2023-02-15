using System;

using SB.CoreTest;

/// <summary>
/// SchoolsBuddy Technical Test.
///
/// Your task is to find the highest floor of the building from which it is safe
/// to drop a marble without the marble breaking, and to do so using the fewest
/// number of marbles. You can break marbles in the process of finding the answer.
///
/// The method Building.DropMarble should be used to carry out a marble drop. It
/// returns a boolean indicating whether the marble dropped without breaking.
/// Use Building.NumberFloors for the total number of floors in the building.
///
/// A very basic solution has already been implemented but it is up to you to
/// find your own, more efficient solution.
///
/// Please use the function Attempt2 for your answer.
/// </summary>
namespace SB.TechnicalTest
{

    class fakeBuilding {
        
    }
    class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine($"Attempt 1 Highest Safe Floor: {Attempt1()}");
            Console.WriteLine($"Attempt 1 Total Drops: {Building.TotalDrops}");

            Console.WriteLine();
            Building.Reset();

            Console.WriteLine($"Attempt 2 Highest Safe Floor: {Attempt2()}");
            Console.WriteLine($"Attempt 2 Total Drops: {Building.TotalDrops}");
        }

        /// <summary>
        /// First attempt - start at first floor and work up one floor at a time
        /// until you reach a floor at which marble breaks.
        /// The highest safe floor is one below this.
        /// </summary>
        /// <returns>Highest safe floor.</returns>
        static int Attempt1()
        {
            var i = 0;
            while (++i <= Building.NumberFloors && Building.DropMarble(i));

            return i - 1;
        }

        /// <summary>
        /// Second attempt - 
        /// Given that the heights to breaking mapping is basically an ordered array
        /// A bianry search can be used to find the floor at which the marble breaks
        /// The floor before this can then be returned.
        /// This will have a Log2(N) time complexity
        /// Given we are not looking for a specific answer, but rather the first instance of false (to get the last instance of true), the search needs to keep looking until
        /// !Building.DropMarble(middleIndex) and Building.DropMarble(middleIndex-1) is satisfied.
        /// </summary>
        /// <returns>Highest safe floor.</returns>


        ////
        ////  * * * * * *
        static int Attempt2()
        {
            int bottomIndex = 0;
            int topIndex = Building.NumberFloors-1;

            while(bottomIndex < topIndex){
                int middleIndex = (bottomIndex + topIndex) / 2;

                bool bouncedForMiddleIndex = Building.DropMarble(middleIndex);
                if(middleIndex != 0 && !bouncedForMiddleIndex && Building.DropMarble(middleIndex-1)){
                    return middleIndex-1;
                }
                if(bouncedForMiddleIndex){
                    bottomIndex = middleIndex+1;
                }else{
                    topIndex = middleIndex-1;
                }
            }
            
            return -1;
        }
    }
}
