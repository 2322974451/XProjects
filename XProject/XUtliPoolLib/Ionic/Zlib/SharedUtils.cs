using System;
using System.IO;
using System.Text;

namespace Ionic.Zlib
{

	internal class SharedUtils
	{

		public static int URShift(int number, int bits)
		{
			return (int)((uint)number >> bits);
		}

		public static int ReadInput(TextReader sourceTextReader, byte[] target, int start, int count)
		{
			bool flag = target.Length == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				char[] array = new char[target.Length];
				int num = sourceTextReader.Read(array, start, count);
				bool flag2 = num == 0;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					for (int i = start; i < start + num; i++)
					{
						target[i] = (byte)array[i];
					}
					result = num;
				}
			}
			return result;
		}

		internal static byte[] ToByteArray(string sourceString)
		{
			return Encoding.UTF8.GetBytes(sourceString);
		}

		internal static char[] ToCharArray(byte[] byteArray)
		{
			return Encoding.UTF8.GetChars(byteArray);
		}
	}
}
