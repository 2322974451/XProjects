using System;

namespace XMainClient
{

	public class CPacketBreaker : IPacketBreaker
	{

		public int BreakPacket(byte[] data, int index, int len)
		{
			bool flag = len < 4;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = BitConverter.ToInt32(data, index);
				bool flag2 = len < 4 + num;
				if (flag2)
				{
					result = 0;
				}
				else
				{
					result = num + 4;
				}
			}
			return result;
		}
	}
}
