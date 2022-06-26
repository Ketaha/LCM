var dividers = new List<int>(Console.ReadLine().Split().Select(int.Parse));
ICollection<int> indecies = new List<int>();

// Exceptions
if (dividers.Contains(0)) throw new ArgumentException("Argument of zero impossible becuase it would imply invalid arithmetic opperation");
if (dividers.Min() < 0) throw new ArgumentException("Sequence contains negative value");

// Least common multiplier
var LCM = 1;

// Divider which is incramented if is too small to dividers and 
// set to two if greater than the biggest number in the sequence
var div = 2;

do
{
    // Scans sequence for numbers that are devisable to the 'div' number
    // and stores them to a collection
    for (int i = 0; i < dividers.Count; i++) if (dividers[i] % div == 0) indecies.Add(i);

    if (indecies.Count != 0) {
        // Divides numbers at index
        for (int j = 0; j < indecies.Count; j++) dividers[indecies.ElementAt(j)] /= div;
        
        LCM *= div;
    }
    // incraments div if no divisions have ocrred
    else div++;

    // Possible 'TODO' if only one item remains just multiply it to the LCM and break the loop 
    if (div == dividers.Max() + 1) div = 2;

    // Clears collection of indecies for next itteration
    indecies.Clear();
    // Removes numbers that are equal to 1 which optimizes scan speed
    dividers.RemoveAll(i => i == 1);
} while (dividers.Any()); // ... and when all elements have been set to one and removed the loop

Console.WriteLine(LCM);