//**************************************************
// Utility.cs
//
// Battle Crafters LLC 2023
//**************************************************

using System.Text;

namespace BattleCrafters
{
	public class Utility
	{
        public static int XORKEY = 20230131;

        //Simple XOR en/de-cryption
        public static string XOREncryptDecrypt(string inputData)
        {
            StringBuilder outSB = new StringBuilder(inputData.Length);
            for (int i = 0; i < inputData.Length; i++)
            {
                char ch = (char)(inputData[i] ^ XORKEY);
                outSB.Append(ch);
            }
            return outSB.ToString();
        }
    }
}
