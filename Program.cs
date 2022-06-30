List<int> dividers = new (Console.ReadLine().Trim().Split().Select(int.Parse));
ICollection<int> indecies = new List<int>();

Arg0Exc(dividers);

for (int i = 0; i < dividers.Count; i++) dividers[i] = Math.Abs(dividers[i]);

var LCM = 1;

// Divider which is incramented if is too small to dividers and 
// set to two if greater than the biggest number in the sequence
var div = 2;

do
{
    // Scans sequence for numbers that are devisable to the 'div' number and stores them in a collection
    for (int i = 0; i < dividers.Count; i++) 
        if (dividers[i] % div == 0) 
            indecies.Add(i);

    Div(dividers, indecies, ref LCM, ref div);

    // Possible 'TODO' if only one item remains just multiply it to the LCM and break the loop 
    div = div == dividers.Max() + 1 ? dividers.Min() : div;

    indecies.Clear();
    // Removing all elements ends the loop
    dividers.RemoveAll(i => i == 1);
} while (dividers.Any()); 

Console.WriteLine(LCM);

///<summary>
///If any elements are present in indecies it divides by div else increases div so division is possible
///</summary>
static int Div(List<int> dividers, ICollection<int> indecies, ref int LCM, ref int div) {
    if (indecies.Count != 0) {
        for (int j = 0; j < indecies.Count; j++) dividers[indecies.ElementAt(j)] /= div;
        return LCM *= div;
    }

    return div++;
}

static ArgumentException Arg0Exc (List<int> dividers) => dividers.Contains(0) ? 
    throw new ArgumentException("Argument of zero impossible becuase it would imply invalid arithmetic operation") : null;