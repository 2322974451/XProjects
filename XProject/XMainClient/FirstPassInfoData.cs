using System;

namespace XMainClient
{
	// Token: 0x02000D04 RID: 3332
	internal class FirstPassInfoData
	{
		// Token: 0x0600BA5A RID: 47706 RVA: 0x0025FAF0 File Offset: 0x0025DCF0
		public FirstPassInfoData(ulong id, string name, uint titleId, bool isFirstPassRank)
		{
			this.m_id = id;
			if (isFirstPassRank)
			{
				this.m_name = XTitleDocument.GetTitleWithFormat(titleId, name);
			}
			else
			{
				this.m_name = name;
			}
		}

		// Token: 0x170032D7 RID: 13015
		// (get) Token: 0x0600BA5B RID: 47707 RVA: 0x0025FB3C File Offset: 0x0025DD3C
		public ulong Id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x170032D8 RID: 13016
		// (get) Token: 0x0600BA5C RID: 47708 RVA: 0x0025FB54 File Offset: 0x0025DD54
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x04004A8F RID: 19087
		private ulong m_id = 0UL;

		// Token: 0x04004A90 RID: 19088
		private string m_name = "";
	}
}
