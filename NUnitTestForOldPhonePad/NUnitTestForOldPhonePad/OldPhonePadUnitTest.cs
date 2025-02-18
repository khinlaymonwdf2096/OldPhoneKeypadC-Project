namespace NUnitTestForSum;

public class Tests
{
    private OldPhonePadClass _oldPhonePad;
    [SetUp]
    public void Setup()
    {
        _oldPhonePad = new OldPhonePadClass();
    }

    [Test]
    [TestCase("*#", "")]
    [TestCase("33#", "E")]
    [TestCase("3333#", "D")]
    [TestCase("227*#", "B")]
    [TestCase("4433555 555666#", "HELLO")]
    [TestCase("4433555 555666096667775553#", "HELLO WORLD")]
    [TestCase("8 88777444666*664#", "TURING")]
    [TestCase("2 34567892233445566778899222333444555666777888999 9999*664#", "ADGJMPTWBEHKNQUXCFILORVYNG")]
    [TestCase("1 11 111 2 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 9999 9999*66*4#", "&'(ABCDEFGHIJKLMNOPQRSTUVWXYZG")]

    public void Add_ShouldReturnCorrectSum(string input, string expectedResult)
    {
        // Act
        string result = _oldPhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
