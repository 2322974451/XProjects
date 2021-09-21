using System;

namespace XMainClient
{
	// Token: 0x02000EB9 RID: 3769
	public interface IPacketBreaker
	{
		// Token: 0x0600C86A RID: 51306
		int BreakPacket(byte[] data, int index, int len);
	}
}
