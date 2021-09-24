using System;

namespace XMainClient
{

	internal class GuildApproveSetting
	{

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

		public int PPT;

		public bool autoApprove;
	}
}
