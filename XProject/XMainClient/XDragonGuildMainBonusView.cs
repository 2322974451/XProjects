using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A4F RID: 2639
	internal class XDragonGuildMainBonusView : DlgHandlerBase
	{
		// Token: 0x0600A00F RID: 40975 RVA: 0x001AA5E8 File Offset: 0x001A87E8
		protected override void Init()
		{
			base.Init();
			this.m_btnClose = (base.PanelObject.transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_CurrentBuff = base.PanelObject.transform.Find("Active/CurrentBuff").gameObject;
			this.m_NextBuff = base.PanelObject.transform.FindChild("Active/NextBuff").gameObject;
			this.m_doc = XDragonGuildDocument.Doc;
		}

		// Token: 0x0600A010 RID: 40976 RVA: 0x001AA672 File Offset: 0x001A8872
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseBtnClick));
		}

		// Token: 0x0600A011 RID: 40977 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void _OnCloseBtnClick(IXUISprite go)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600A012 RID: 40978 RVA: 0x001AA694 File Offset: 0x001A8894
		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
		}

		// Token: 0x0600A013 RID: 40979 RVA: 0x001AA6A8 File Offset: 0x001A88A8
		public void Refresh()
		{
			uint level = this.m_doc.BaseData.level;
			bool flag = this.m_doc.IsMaxLevel();
			if (flag)
			{
				this._RefreshBuff(this.m_CurrentBuff, level);
				this._SetFinalBuff(this.m_NextBuff);
			}
			else
			{
				this._RefreshBuff(this.m_CurrentBuff, level);
				this._RefreshBuff(this.m_NextBuff, level + 1U);
			}
		}

		// Token: 0x0600A014 RID: 40980 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600A015 RID: 40981 RVA: 0x001AA718 File Offset: 0x001A8918
		private void _SetFinalBuff(GameObject go)
		{
			IXUILabel ixuilabel = go.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.Find("Buff1").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText("--");
			ixuilabel2.SetText(XStringDefineProxy.GetString("DRAGON_GUILD_MAX_LEVEL"));
		}

		// Token: 0x0600A016 RID: 40982 RVA: 0x001AA784 File Offset: 0x001A8984
		private void _RefreshBuff(GameObject go, uint level)
		{
			DragonGuildTable.RowData bylevel = XDragonGuildDocument.DragonGuildBuffTable.GetBylevel(level);
			bool flag = bylevel == null;
			if (!flag)
			{
				IXUILabel ixuilabel = go.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = go.transform.Find("Buff1").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(bylevel.level.ToString());
				BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(bylevel.buf[0], bylevel.buf[1]);
				bool flag2 = buffData == null;
				if (flag2)
				{
					ixuilabel2.SetText(string.Empty);
				}
				else
				{
					ixuilabel2.SetText(buffData.BuffName);
				}
			}
		}

		// Token: 0x0400394E RID: 14670
		private IXUISprite m_btnClose;

		// Token: 0x0400394F RID: 14671
		private GameObject m_CurrentBuff;

		// Token: 0x04003950 RID: 14672
		private GameObject m_NextBuff;

		// Token: 0x04003951 RID: 14673
		private XDragonGuildDocument m_doc;
	}
}
