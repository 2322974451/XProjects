using System;

namespace XMainClient.UI
{
	// Token: 0x02001754 RID: 5972
	public class MyBattleKillInfo
	{
		// Token: 0x0600F6B2 RID: 63154 RVA: 0x0037FEC1 File Offset: 0x0037E0C1
		public void SetInfo(int _contiKillCount, bool _isRevenge = false)
		{
			this.contiKillCount = _contiKillCount;
			this.isRevenge = _isRevenge;
		}

		// Token: 0x04006B2F RID: 27439
		public int contiKillCount;

		// Token: 0x04006B30 RID: 27440
		public bool isRevenge;
	}
}
