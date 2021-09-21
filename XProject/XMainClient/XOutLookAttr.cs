using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000B2B RID: 2859
	public class XOutLookAttr
	{
		// Token: 0x0600A778 RID: 42872 RVA: 0x001D9EBC File Offset: 0x001D80BC
		public XOutLookAttr(OutLook outlook)
		{
			this.guild = ((outlook != null) ? outlook.guild : null);
			this.designationID = ((outlook != null && outlook.designation != null) ? outlook.designation.id : 0U);
			this.specialDesignation = ((outlook != null && outlook.designation != null) ? outlook.designation.name : "");
			this.titleID = ((outlook != null && outlook.title != null) ? outlook.title.titleID : 0U);
			this.militaryRank = ((outlook != null && outlook.military != null) ? outlook.military.military_rank : 0U);
			bool flag = outlook == null || outlook.pre == null;
			if (flag)
			{
				this.prerogativeScore = 0U;
				this.prerogativeSetID = null;
			}
			else
			{
				this.prerogativeScore = outlook.pre.score;
				this.prerogativeSetID = outlook.pre.setid;
			}
		}

		// Token: 0x0600A779 RID: 42873 RVA: 0x001D9FDC File Offset: 0x001D81DC
		public XOutLookAttr(uint title, MilitaryRecord military)
		{
			this.titleID = title;
			this.militaryRank = ((military != null) ? military.military_rank : 0U);
		}

		// Token: 0x0600A77A RID: 42874 RVA: 0x001DA038 File Offset: 0x001D8238
		public XOutLookAttr(OutLookGuild outguild)
		{
			this.guild = outguild;
		}

		// Token: 0x04003DEC RID: 15852
		public OutLookGuild guild = null;

		// Token: 0x04003DED RID: 15853
		public uint designationID = 0U;

		// Token: 0x04003DEE RID: 15854
		public string specialDesignation = "";

		// Token: 0x04003DEF RID: 15855
		public uint titleID = 0U;

		// Token: 0x04003DF0 RID: 15856
		public uint militaryRank = 0U;

		// Token: 0x04003DF1 RID: 15857
		public uint prerogativeScore = 0U;

		// Token: 0x04003DF2 RID: 15858
		public List<uint> prerogativeSetID;
	}
}
