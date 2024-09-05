using LongestSequence.Services;

namespace LongestSequenceServiceTests;

[TestFixture]
public class LongestSequenceServiceTests
{
    private ILongestSequenceService Service { get; set; }

    [SetUp]
    public void SetUp()
    {
        Service = new LongestSequenceService();
    }
    
    [TestCase("TestCase1")]
    [TestCase("TestCase2")]
    [TestCase("TestCase3")]
    [TestCase("TestCase4")]
    [TestCase("TestCase5")]
    [TestCase("TestCase6")]
    [TestCase("TestCase7")]
    [TestCase("TestCase8")]
    [TestCase("TestCase9")]
    [TestCase("TestCase10")]
    [TestCase("TestCase11")]
    public void Should_Return_Longest_Sequence_For_Test_Case(string testCaseName)
    {
        var data = LoadTestCaseFile($"{testCaseName}.txt");
        var expected = LoadTestCaseFile($"{testCaseName}Results.txt");
        
        var result = Service.GetLongestSequence(data);
        
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Should_Throw_ArgumentNullException_For_Null_Input()
    {
        Assert.Throws<ArgumentNullException>(() => Service.GetLongestSequence(null));
    }
    
    [Test]
    public void Should_Throw_ArgumentNullException_For_Non_Integer_Input()
    {
        Assert.Throws<FormatException>(() => Service.GetLongestSequence("these are not ints"));
    }
    
    private static string? LoadTestCaseFile(string fileName)
    {
        return File.ReadAllText($"TestData/{fileName}");
    }
}