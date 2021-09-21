using System;

namespace XUtliPoolLib
{
	// Token: 0x02000063 RID: 99
	public interface ILuaFunction
	{
		// Token: 0x0600032E RID: 814
		object[] Call();

		// Token: 0x0600032F RID: 815
		object[] Call(params object[] args);

		// Token: 0x06000330 RID: 816
		object[] Call(double arg1);

		// Token: 0x06000331 RID: 817
		void Dispose();

		// Token: 0x06000332 RID: 818
		void Release();

		// Token: 0x06000333 RID: 819
		int GetReference();
	}
}
