using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal struct XRandAttrInfo
	{

		public void Init()
		{
			this.bPreview = false;
			bool flag = this.RandAttr == null;
			if (flag)
			{
				this.RandAttr = new List<XItemChangeAttr>();
			}
			else
			{
				this.RandAttr.Clear();
			}
		}

		public bool bPreview;

		public List<XItemChangeAttr> RandAttr;
	}
}
