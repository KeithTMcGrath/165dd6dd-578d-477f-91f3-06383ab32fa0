using LongestSequence.Services;

ILongestSequenceService service = new LongestSequenceService();

Console.WriteLine("Enter a list of numbers:");
var input = Console.ReadLine();

var result = service.GetLongestSequence(input);

Console.WriteLine("The longest sequence is:");
Console.WriteLine(string.Join(" ", result));
