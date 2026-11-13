using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static List<ColorChip> chips;
        static bool[] used;
        static int usedcount;
        static List<ColorChip> best;
        static Dictionary<Color,List<int>> adjacency;
        static void Main(string[] args)
        {
            chips = new List<ColorChip> // used to set up color list of the chips
            {
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Orange, Color.Purple)

            };


            //buid color indexxes of chips thouching 
            adjacency = new Dictionary<Color, List< int >> ();
            for (int i = 0; i < chips.Count; i++)
            {
                AddToAdjacenc(chips[i].StartColor, i);
                if (chips[i].EndColor != chips[i].StartColor)
                    AddToAdjacenc(chips[i].EndColor, i);


            }

            used = new bool[chips.Count];
            best = new List<ColorChip>();

            Search(Color.Blue , new List<ColorChip>());
            //if noting is found
            if (best.Count == 0)
            {
                Console.Write(Constants.ErrorMessage);
                return;
            }

            //starts with blue 
            Color current = Color.Blue;
            Console.Write(Color.Blue + " ");
            // print chain in order

            foreach (ColorChip chip in best)
            {

                if (chip.StartColor == current)
                {
                    Console.Write("[" + chip.StartColor + ", " + chip.EndColor + "] ");
                    current = chip.StartColor;
                }
                else
                {
                    Console.Write("[" + chip.StartColor + ", " + chip.EndColor + "] ");
                    current = chip.StartColor;
                }
            }
            // end with green
            Console.Write(Color.Green);
            // so you can see the result when run from exe
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        // addes to list
        static void AddToAdjacenc(Color color, int chipIndex)
        { if (!adjacency.ContainsKey(color))
                adjacency[color] = new List<int>();
                adjacency[color].Add(chipIndex);

        }
        // seach the color list 
        static void Search(Color current, List<ColorChip> Path)
        {
            //check for green 
            if (current == Color.Green && Path.Count > best.Count)
                     best = new List<ColorChip>(Path);

            // runs for each option 
            foreach (int i in adjacency[current])
            {
                if (used[i])
                    continue;

                used[i] = true;
                usedcount++;

                // the flip
                Color next;
                if (chips[i].StartColor == current)
                    next = chips[i].EndColor;
                else
                    next = chips[i].StartColor;

                Path.Add(chips[i]);
                Search(next, Path);
                Path.RemoveAt(Path.Count - 1);


               used[i] = false;
                usedcount--;

            }
        }
    }
}
