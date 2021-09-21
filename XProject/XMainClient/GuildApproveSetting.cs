using System;

namespace XMainClient
{
	// Token: 0x02000A77 RID: 2679
	internal class GuildApproveSetting
	{
		// Token: 0x0600A2F1 RID: 41713 RVA: 0x001BD09C File Offset: 0x001BB29C
		public string GetStrPPT()
		{
			bool flag = this.PPT == 0;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				result = this.PPT.ToString();
			}
			return result;
		}

		// Token: 0x04003ADC RID: 15068
		public int PPT;

		// Token: 0x04003ADD RID: 15069
		public bool autoApprove;
	}
}
