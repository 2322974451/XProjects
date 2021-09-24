using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XArtifactItem : XAttrItem
	{

		public override bool bHasPPT
		{
			get
			{
				return true;
			}
		}

		public override string ToPPTString(XAttributes attributes = null)
		{
			uint ppt = this.GetPPT(attributes);
			string empty = string.Empty;
			return string.Format("{0} - {1}", 0, ppt);
		}

		public override void Init()
		{
			base.Init();
			this.RandAttrInfo.Init();
			bool flag = this.EffectInfoList == null;
			if (flag)
			{
				this.EffectInfoList = new List<XArtifactEffectInfo>();
			}
			else
			{
				this.EffectInfoList.Clear();
			}
			bool flag2 = this.UnSavedAttr == null;
			if (flag2)
			{
				this.UnSavedAttr = new List<XItemChangeAttr>();
			}
			else
			{
				this.UnSavedAttr.Clear();
			}
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Init();
			XDataPool<XArtifactItem>.Recycle(this);
		}

		public XRandAttrInfo RandAttrInfo = default(XRandAttrInfo);

		public List<XArtifactEffectInfo> EffectInfoList;

		public List<XItemChangeAttr> UnSavedAttr;
	}
}
