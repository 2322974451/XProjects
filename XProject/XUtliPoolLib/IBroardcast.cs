using System;

namespace XUtliPoolLib
{
	// Token: 0x02000056 RID: 86
	public interface IBroardcast
	{
		// Token: 0x060002D6 RID: 726
		bool IsBroadState();

		// Token: 0x060002D7 RID: 727
		void SetAccount(int platf, string openid, string token);

		// Token: 0x060002D8 RID: 728
		void StartLiveBroadcast(string title, string desc);

		// Token: 0x060002D9 RID: 729
		void StopBroadcast();

		// Token: 0x060002DA RID: 730
		int GetState();

		// Token: 0x060002DB RID: 731
		void EnterHall();

		// Token: 0x060002DC RID: 732
		bool ShowCamera(bool show);
	}
}
