using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x0200182B RID: 6187
	public class XPlayerInfoChildBaseView
	{
		// Token: 0x06010112 RID: 65810 RVA: 0x003D59D8 File Offset: 0x003D3BD8
		public virtual void FindFrom(Transform t)
		{
			Transform transform = t.Find("name");
			bool flag = null != transform;
			if (flag)
			{
				this.lbName = (transform.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			}
			transform = t.Find("level");
			bool flag2 = null != transform;
			if (flag2)
			{
				this.lbLevel = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			transform = t.Find("head");
			bool flag3 = null != transform;
			if (flag3)
			{
				this.sprHead = (transform.GetComponent("XUISprite") as IXUISprite);
			}
		}

		// Token: 0x04007293 RID: 29331
		public IXUILabelSymbol lbName;

		// Token: 0x04007294 RID: 29332
		public IXUILabel lbLevel;

		// Token: 0x04007295 RID: 29333
		public IXUISprite sprHead;
	}
}
