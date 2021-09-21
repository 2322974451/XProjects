using System;

namespace XMainClient
{
	// Token: 0x020008FF RID: 2303
	internal class DragonGuildApproveSetting
	{
		// Token: 0x06008B36 RID: 35638 RVA: 0x00129668 File Offset: 0x00127868
		public string GetStrPPT()
		{
			bool flag = this.PPT == 0U;
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

		// Token: 0x04002C80 RID: 11392
		public uint PPT;

		// Token: 0x04002C81 RID: 11393
		public bool autoApprove;
	}
}
