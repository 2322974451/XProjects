using System;

namespace XUtliPoolLib
{
	// Token: 0x02000061 RID: 97
	public interface ILuaEngine
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000317 RID: 791
		IHotfixManager hotfixMgr { get; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000318 RID: 792
		ILuaUIManager luaUIManager { get; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000319 RID: 793
		ILuaGameInfo luaGameInfo { get; }

		// Token: 0x0600031A RID: 794
		void InitLua();
	}
}
