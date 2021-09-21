using System;

namespace XUtliPoolLib
{
	// Token: 0x02000067 RID: 103
	public interface ILuaNetSender
	{
		// Token: 0x0600034E RID: 846
		bool Send(uint _type, bool isRpc, uint tagID, byte[] _reqBuff);
	}
}
