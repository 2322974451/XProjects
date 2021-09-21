using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x0200182C RID: 6188
	public class XPlayerInfoChildView : XPlayerInfoChildBaseView
	{
		// Token: 0x06010114 RID: 65812 RVA: 0x003D5A70 File Offset: 0x003D3C70
		public override void FindFrom(Transform t)
		{
			base.FindFrom(t);
			this.lbPPT = (t.Find("PPT").GetComponent("XUILabel") as IXUILabel);
			this.lbGuildName = (t.Find("guild").GetComponent("XUILabel") as IXUILabel);
			this.uidLab = (t.FindChild("UID").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x06010115 RID: 65813 RVA: 0x003D5AE8 File Offset: 0x003D3CE8
		public void SetGuildName(string name)
		{
			bool flag = (string.Empty + name).Length > 0;
			if (flag)
			{
				this.lbGuildName.Alpha = 1f;
				this.lbGuildName.SetText(name);
			}
			else
			{
				this.lbGuildName.SetText(string.Empty);
				this.lbGuildName.Alpha = 0f;
			}
		}

		// Token: 0x04007296 RID: 29334
		public IXUILabel lbPPT;

		// Token: 0x04007297 RID: 29335
		public IXUILabel lbGuildName;

		// Token: 0x04007298 RID: 29336
		public IXUILabel uidLab;
	}
}
