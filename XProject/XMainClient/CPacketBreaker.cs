using System;

namespace XMainClient
{
	// Token: 0x02000EBC RID: 3772
	public class CPacketBreaker : IPacketBreaker
	{
		// Token: 0x0600C872 RID: 51314 RVA: 0x002CE6FC File Offset: 0x002CC8FC
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
