using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200189F RID: 6303
	internal class XGuildMemberInfoDisplay
	{
		// Token: 0x06010697 RID: 67223 RVA: 0x004014E0 File Offset: 0x003FF6E0
		public void Init(Transform go, bool bFirstInit)
		{
			this.Root = go;
			Transform transform = this.Root.FindChild("Name");
			bool flag = transform != null;
			if (flag)
			{
				this.Name = (transform.GetComponent("XUILabelSymbol") as IXUILabelSymbol);
				if (bFirstInit)
				{
					this.Name.InputText = "";
				}
			}
			else
			{
				this.Name = null;
			}
			transform = this.Root.FindChild("Position");
			bool flag2 = transform != null;
			if (flag2)
			{
				this.Position = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.Position.SetText("");
				}
			}
			else
			{
				this.Position = null;
			}
			transform = this.Root.FindChild("Level");
			bool flag3 = transform != null;
			if (flag3)
			{
				this.Level = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.Level.SetText("");
				}
			}
			else
			{
				this.Level = null;
			}
			transform = this.Root.FindChild("PPT");
			bool flag4 = transform != null;
			if (flag4)
			{
				this.PPT = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.PPT.SetText("");
				}
			}
			else
			{
				this.PPT = null;
			}
			transform = this.Root.FindChild("Portrait");
			bool flag5 = transform != null;
			if (flag5)
			{
				this.Portrait = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.Portrait = null;
			}
			transform = this.Root.FindChild("Profession");
			bool flag6 = transform != null;
			if (flag6)
			{
				this.Profession = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.Profession = null;
			}
			transform = this.Root.FindChild("Liveness");
			bool flag7 = transform != null;
			if (flag7)
			{
				this.Liveness = (transform.GetComponent("XUILabel") as IXUILabel);
				if (bFirstInit)
				{
					this.Liveness.SetText(string.Empty);
				}
			}
			transform = this.Root.FindChild("Title");
			bool flag8 = transform != null;
			if (flag8)
			{
				this.Title = (transform.GetComponent("XUISpriteAnimation") as IXUISpriteAnimation);
			}
		}

		// Token: 0x06010698 RID: 67224 RVA: 0x0040174C File Offset: 0x003FF94C
		public void Set(XGuildMemberBasicInfo data)
		{
			bool flag = this.Name != null;
			if (flag)
			{
				this.Name.InputText = data.name + XWelfareDocument.GetMemberPrivilegeIconString(data.paymemberid) + XRechargeDocument.GetVIPIconString(data.vip);
			}
			bool flag2 = this.Position != null;
			if (flag2)
			{
				this.Position.SetText(XGuildDocument.GuildPP.GetPositionName(data.position, false));
			}
			bool flag3 = this.Level != null;
			if (flag3)
			{
				this.Level.SetText("Lv." + data.level);
			}
			bool flag4 = this.PPT != null;
			if (flag4)
			{
				this.PPT.SetText(data.ppt.ToString());
			}
			bool flag5 = this.Portrait != null;
			if (flag5)
			{
				this.Portrait.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(data.profession));
			}
			bool flag6 = this.Profession != null;
			if (flag6)
			{
				this.Profession.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(data.profession));
			}
			bool flag7 = this.Liveness != null;
			if (flag7)
			{
				this.Liveness.SetText(data.GetLiveness());
			}
			bool flag8 = this.Title != null;
			if (flag8)
			{
				TitleTable.RowData title = XTitleDocument.GetTitle(data.titleID);
				bool flag9 = title != null;
				if (flag9)
				{
					this.Title.SetNamePrefix(title.RankAtlas, title.RankIcon);
					this.Title.SetFrameRate(XTitleDocument.TITLE_FRAME_RATE);
					this.Title.MakePixelPerfect();
				}
			}
		}

		// Token: 0x0400767C RID: 30332
		public Transform Root;

		// Token: 0x0400767D RID: 30333
		public IXUILabelSymbol Name;

		// Token: 0x0400767E RID: 30334
		public IXUILabel Position;

		// Token: 0x0400767F RID: 30335
		public IXUILabel Level;

		// Token: 0x04007680 RID: 30336
		public IXUILabel PPT;

		// Token: 0x04007681 RID: 30337
		public IXUISprite Portrait;

		// Token: 0x04007682 RID: 30338
		public IXUISprite Profession;

		// Token: 0x04007683 RID: 30339
		public IXUILabel Liveness;

		// Token: 0x04007684 RID: 30340
		public IXUISpriteAnimation Title;
	}
}
