var dividers = new List<int>(Console.ReadLine().Split().Select(int.Parse));
ICollection<int> indecies = new List<int>();

if (dividers.Contains(0)) throw new 
    ArgumentException("Argument of zero impossible becuase it would imply invalid arithmetic opperation");
if (dividers.Min() < 0) throw new ArgumentException("Sequence contains negative value");

var LCM = 1;

var div = 2;

do
{
    for (int i = 0; i < dividers.Count; i++) if (dividers[i] % div == 0) indecies.Add(i);

    if (indecies.Count != 0) {
        for (int j = 0; j < indecies.Count; j++) dividers[indecies.ElementAt(j)] /= div;
        
        LCM *= div;
    }
    else div++;

    if (div == dividers.Max() + 1) div = 2;

    indecies.Clear();
    dividers.RemoveAll(i => i == 1);
} while (dividers.Any());

Console.WriteLine(LCM);