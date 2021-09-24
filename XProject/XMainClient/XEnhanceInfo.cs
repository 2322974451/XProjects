using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal struct XEnhanceInfo
	{

		public void Init()
		{
			bool flag = this.EnhanceAttr == null;
			if (flag)
			{
				this.EnhanceAttr = new List<XItemChangeAttr>();
			}
			else
			{
				this.EnhanceAttr.Clear();
			}
			this.EnhanceLevel = 0U;
			this.EnhanceTimes = 0U;
		}

		public uint EnhanceLevel;

		public uint EnhanceTimes;

		public List<XItemChangeAttr> EnhanceAttr;
	}
}
