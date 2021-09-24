using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XAttrItem : XItem
	{

		public IEnumerable<XItemChangeAttr> BasicAttr()
		{
			return this.changeAttr;
		}

		public override void Init()
		{
			base.Init();
			this.changeAttr.Clear();
		}

		public override uint GetPPT(XAttributes attributes = null)
		{
			double num = 0.0;
			for (int i = 0; i < this.changeAttr.Count; i++)
			{
				num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(this.changeAttr[i], attributes, -1);
			}
			return (uint)num;
		}

		public List<XItemChangeAttr> changeAttr = new List<XItemChangeAttr>();
	}
}
