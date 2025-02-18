using System;
namespace NUnitTestForSum
{
    public class OldPhonePadClass
    {
        public Dictionary<char, char> charaterDictionary = new();//delcare global variable to access from OldPhonePad function to avoid reassigning again and again under function

        public OldPhonePadClass()
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
        }

        public string OldPhonePad(string input)
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
                    
                }
                #endregion Convert input number to specific character

            }

            return resultString;
        }
    }
}

