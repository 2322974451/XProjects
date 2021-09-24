using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal struct XForgeAttrInfo
	{

		public void Init()
		{
			this.bPreview = false;
			this.UnSavedAttrid = 0U;
			this.UnSavedAttrValue = 0U;
			bool flag = this.ForgeAttr == null;
			if (flag)
			{
				this.ForgeAttr = new List<XItemChangeAttr>();
			}
			else
			{
				this.ForgeAttr.Clear();
			}
		}

		public bool bPreview;

		public uint UnSavedAttrid;

		public uint UnSavedAttrValue;

		public List<XItemChangeAttr> ForgeAttr;
	}
}
