using System;

namespace XMainClient
{
	// Token: 0x02000EB7 RID: 3767
	public interface ILuaNetProcess
	{
		// Token: 0x0600C866 RID: 51302
		void OnLuaProcessBuffer(NetEvent evt);

		// Token: 0x0600C867 RID: 51303
		void OnLuaProcess(NetEvent evt);
	}
}
