using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal struct XReinforceInfo
	{

		public void Init()
		{
			bool flag = this.ReinforceAttr == null;
			if (flag)
			{
				this.ReinforceAttr = new List<XItemChangeAttr>();
			}
			else
			{
				this.ReinforceAttr.Clear();
			}
			this.ReinforceLevel = 0U;
		}

		public void Clone(ref XReinforceInfo other)
		{
			this.Init();
			this.ReinforceLevel = other.ReinforceLevel;
			bool flag = other.ReinforceAttr != null;
			if (flag)
			{
				for (int i = 0; i < other.ReinforceAttr.Count; i++)
				{
					this.ReinforceAttr.Add(other.ReinforceAttr[i]);
				}
			}
		}

		public uint ReinforceLevel;

		public List<XItemChangeAttr> ReinforceAttr;
	}
}
