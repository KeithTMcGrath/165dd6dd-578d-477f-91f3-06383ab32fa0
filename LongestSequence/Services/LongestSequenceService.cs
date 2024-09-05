using System.Text.RegularExpressions;

namespace LongestSequence.Services;

/// <summary>
/// Service class to perform sequence operations
/// </summary>
public class LongestSequenceService : ILongestSequenceService
{
    private readonly Regex _whiteSpaceRegex = new(@"\s+");
    private const string SingleSpace = " ";

    /// <summary>
    /// Return the longest uninterrupted sequence of integers from the input
    /// </summary>
    public string GetLongestSequence(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input));
        }
        
        var formattedInput = FormatText(input);

        var list = formattedInput.Split(SingleSpace).Select(int.Parse).ToList();

        var prev = 0; 
        
        var currentSequence = new List<int>();
        var longestSequence = new List<int>();
        for (var i = 0 ; i < list.Count ; i++)
        {
            var current = list[i];
            var runHasEnded = current < prev; 
            if (!runHasEnded)
            {
                currentSequence.Add(current);

                // If we are on the last element, ensure the longest sequence is set
                if (i == list.Count - 1)
                {
                    if (currentSequence.Count > longestSequence.Count)
                    {
                        longestSequence = currentSequence;                    
                    }
                }
            }
            else
            {
                // If the run of sequentially increasing integers has ended, update the longest sequence if this is strictly the longest one so far
                if (currentSequence.Count > longestSequence.Count)
                {
                    longestSequence = currentSequence;                    
                }

                currentSequence = [current];
            }
            
            prev = current;
        }
        
        return string.Join(SingleSpace, longestSequence);
    }

    /// <summary>
    /// Ensure that the string is correctly formatted, and any duplicated white space is removed.
    /// This should be expanded as required as user input can be full of formatting issues. 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private string FormatText(string? input)
    {
        return _whiteSpaceRegex.Replace(input, SingleSpace);
    }
}