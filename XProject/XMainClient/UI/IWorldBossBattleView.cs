using System;

namespace XMainClient.UI
{
	// Token: 0x0200188F RID: 6287
	internal interface IWorldBossBattleView
	{
		// Token: 0x060105D0 RID: 67024
		void SetLeftTime(uint time);

		// Token: 0x060105D1 RID: 67025
		void RefreshEncourage();

		// Token: 0x060105D2 RID: 67026
		bool IsVisible();
	}
}
