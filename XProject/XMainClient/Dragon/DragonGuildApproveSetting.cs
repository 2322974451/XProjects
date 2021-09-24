using System;

namespace XMainClient
{

	internal class DragonGuildApproveSetting
	{

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

		public uint PPT;

		public bool autoApprove;
	}
}
