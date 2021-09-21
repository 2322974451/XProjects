using System;

namespace XMainClient.UI
{
	// Token: 0x0200188E RID: 6286
	public interface IWorldBossBattleSource
	{
		// Token: 0x060105CB RID: 67019
		void ReqEncourage();

		// Token: 0x060105CC RID: 67020
		void ReqEncourageTwo();

		// Token: 0x060105CD RID: 67021
		void ReqBattleInfo();

		// Token: 0x170039D8 RID: 14808
		// (get) Token: 0x060105CE RID: 67022
		uint EncourageCount { get; }

		// Token: 0x060105CF RID: 67023
		uint GetEncourageCount(int index);
	}
}
