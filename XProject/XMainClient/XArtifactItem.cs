using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DEB RID: 3563
	internal class XArtifactItem : XAttrItem
	{
		// Token: 0x170033E6 RID: 13286
		// (get) Token: 0x0600C0FD RID: 49405 RVA: 0x0028E09C File Offset: 0x0028C29C
		public override bool bHasPPT
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C0FE RID: 49406 RVA: 0x0028E0B0 File Offset: 0x0028C2B0
		public override string ToPPTString(XAttributes attributes = null)
		{
			uint ppt = this.GetPPT(attributes);
			string empty = string.Empty;
			return string.Format("{0} - {1}", 0, ppt);
		}

		// Token: 0x0600C0FF RID: 49407 RVA: 0x0028E0E8 File Offset: 0x0028C2E8
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

		// Token: 0x0600C100 RID: 49408 RVA: 0x0028E155 File Offset: 0x0028C355
		public override void Recycle()
		{
			base.Recycle();
			this.Init();
			XDataPool<XArtifactItem>.Recycle(this);
		}

		// Token: 0x04005123 RID: 20771
		public XRandAttrInfo RandAttrInfo = default(XRandAttrInfo);

		// Token: 0x04005124 RID: 20772
		public List<XArtifactEffectInfo> EffectInfoList;

		// Token: 0x04005125 RID: 20773
		public List<XItemChangeAttr> UnSavedAttr;
	}
}
