using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	public class XPlayerInfoChildView : XPlayerInfoChildBaseView
	{

		public override void FindFrom(Transform t)
		{
			base.FindFrom(t);
			this.lbPPT = (t.Find("PPT").GetComponent("XUILabel") as IXUILabel);
			this.lbGuildName = (t.Find("guild").GetComponent("XUILabel") as IXUILabel);
			this.uidLab = (t.FindChild("UID").GetComponent("XUILabel") as IXUILabel);
		}

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

		public IXUILabel lbPPT;

		public IXUILabel lbGuildName;

		public IXUILabel uidLab;
	}
}
