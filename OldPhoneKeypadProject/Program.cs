internal class Program
{
    public static Dictionary<char, char> charaterDictionary = new();//delcare global variable to access from OldPhonePad function to avoid reassigning again and again under function
    private static void Main(string[] args)
    {
        charaterDictionary = new()//assign the global variable=> key-value pairs
        {
            {'0',' ' },
            {'1','&' },//&,',(
            {'2','A' },//A, B, C
            {'3','D' },
            {'4','G' },
            {'5','J' },
            {'6','M' },
            {'7','P' },
            {'8','T' },
            {'9','W' }
        };


        /*Test Case
         Input: *#
         Press ony deletion and send and no data won't return
         Expected Output : none
         */
        Console.WriteLine(OldPhonePad("*#"));//no output


        /*Test Case
         Input: 3333#
         Press 3 1st time = D
         Press 3 2nd time = E
         Press 3 3rd time = F
         Press 3 4th time = D
         Expected Output : D
         */
        Console.WriteLine(OldPhonePad("3333#"));//D


        /*Test Case
         Input: 33#
         Press 3 1st time = D
         Press 3 2nd time = E
         Expected Output : D
         */
        Console.WriteLine(OldPhonePad("33#"));//E


        /*Test Case
         Input: 227*#
         Press 2 1st time = A
         Press 2 2nd time = B
         Press 7 1st time and press * delete it
         Expected Output : B
         */
        Console.WriteLine(OldPhonePad("227*#"));


        /*Test Case
         Input: 4433555 555666#
         Assume space from input string as pause in keypad
         Expected Output : HELLO
         */
        Console.WriteLine(OldPhonePad("4433555 555666#"));



        /*Test Case
        Input: 4433555 555666096667775553#
        Assume space from input string as pause in keypad
        Expected Output : HELLO WORLD
        */
        Console.WriteLine(OldPhonePad("4433555 555666096667775553#"));


        /*Test Case
        Input: 4433555 555666096667775553#
        Assume space from input string as pause in keypad
        Expected Output : TURING
        */
        Console.WriteLine(OldPhonePad("8 88777444666*664#"));



        /*Test Case
        Input: 8 88777444666*664#
        Assume space from input string as pause in keypad
        Expected Output : ADGJMPTWBEHKNQUXCFILORVYNG
        */
        Console.WriteLine(OldPhonePad("2 34567892233445566778899222333444555666777888999 9999*664#"));


        /*Test Case
        Input: 2 34567892233445566778899222333444555666777888999 9999*664#
        Assume space from input string as pause in keypad
        Expected Output : &'(ABCDEFGHIJKLMNOPQRSTUVWXYZG
        */
        Console.WriteLine(OldPhonePad("1 11 111 2 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 9999 9999*66*4#"));
    }


    //
    // Summary:
    //     Gets the letters converted from number pressing input string.
    //
    // Parameters:
    //   input:
    //     The number of characters from the keys pressing.
    //
    // Returns:
    //     The letters output converted from number pressing input string.
    public static string OldPhonePad(string input)
    {
        List<char> inputCharList = input.ToList();
        string resultString = "";
        string currentString = "";
        for (var i = 0; i < inputCharList.Count() - 1; i++)
        {

            var currentChar = inputCharList.ElementAt(i); //get char at current index
            var nextChar = inputCharList.ElementAt(i + 1); // get char at next index
            #region overrid the collected character once found * to perform as delete action
            if (currentChar == '*' || nextChar == '*')
            {
                i++;//to start after next index and to reduce loop count
                currentString = "";//override the current string to perform delete action
                continue; // to jump further iteration and not to continue
            }
            #endregion overrid the collected character once found * to perform as delete action

            if (currentChar == ' ')//mark as space entering after pausing 
            {
                continue; // no need to continue onward code and to jump up
            }

            #region Convert input number to specific character
            currentString += currentChar; //collect the number
            if (currentChar != nextChar)
            {
                var strLength = currentString.Length - 1; // subtract - 1 due to starting char remain the same and no need to do anything eg. A + 0 = A, A +1 = B
                if (currentString.Length > 2) //to satisfy continuous entering input like 2222 or 77777
                {
                    if (currentChar == '7' || currentChar == '9') // as only 7 and 9 keys gererate 4 characters
                    {
                        strLength %= 4; // eg. 77777, total length=5, 5-1=4 % 4 =0, to cycle again and it will be the same with 1st time press (P)
                    }
                    else //otherwise only 3 characters
                    {
                        strLength %= 3; //, eg. 22222, 5-1 = 4 % 3 = 1, will be the same with 2nd time press (B)
                    }
                }

                resultString += (char)(charaterDictionary[currentChar] + strLength); //get char value for specific key and added length to get the char per pressing times and assigned to output string
                currentString = "";//override to fill over for another character
                continue;
            }
            #endregion Convert input number to specific character

        }

        return resultString;
    }
}