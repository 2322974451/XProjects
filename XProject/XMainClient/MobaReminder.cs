using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200095A RID: 2394
	public class MobaReminder
	{
		// Token: 0x06009014 RID: 36884 RVA: 0x0014676C File Offset: 0x0014496C
		public void Recycle()
		{
			this.killer = null;
			this.deader = null;
			bool flag = this.assists != null;
			if (flag)
			{
				this.assists.Clear();
			}
			this.assists = null;
			this.AudioName = "";
			this.ReminderText = "";
			MobaInfoPool.Recycle(this);
		}

		// Token: 0x04002FAD RID: 12205
		public MobaReminderEnum reminder;

		// Token: 0x04002FAE RID: 12206
		public HeroKillUnit killer;

		// Token: 0x04002FAF RID: 12207
		public HeroKillUnit deader;

		// Token: 0x04002FB0 RID: 12208
		public List<HeroKillUnit> assists;

		// Token: 0x04002FB1 RID: 12209
		public int type;

		// Token: 0x04002FB2 RID: 12210
		public string AudioName;

		// Token: 0x04002FB3 RID: 12211
		public string ReminderText;
	}
}
