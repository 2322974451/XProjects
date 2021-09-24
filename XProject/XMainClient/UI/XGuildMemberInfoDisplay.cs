using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildMemberInfoDisplay
	{

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

		public Transform Root;

		public IXUILabelSymbol Name;

		public IXUILabel Position;

		public IXUILabel Level;

		public IXUILabel PPT;

		public IXUISprite Portrait;

		public IXUISprite Profession;

		public IXUILabel Liveness;

		public IXUISpriteAnimation Title;
	}
}
