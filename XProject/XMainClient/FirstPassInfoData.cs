using System;

namespace XMainClient
{

	internal class FirstPassInfoData
	{

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

		public ulong Id
		{
			get
			{
				return this.m_id;
			}
		}

		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		private ulong m_id = 0UL;

		private string m_name = "";
	}
}
