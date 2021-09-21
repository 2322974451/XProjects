using System;
using System.Text;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018B5 RID: 6325
	internal class XMISystemAnnounceHandler : DlgHandlerBase
	{
		// Token: 0x17003A3A RID: 14906
		// (get) Token: 0x060107C5 RID: 67525 RVA: 0x00409708 File Offset: 0x00407908
		protected override string FileName
		{
			get
			{
				return "GameSystem/ForeshowDlg";
			}
		}

		// Token: 0x060107C6 RID: 67526 RVA: 0x00409720 File Offset: 0x00407920
		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.FindChild("Bg");
			this.m_closedSpr = (transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_iconSpr = (transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
			transform = transform.FindChild("SkillFrame").transform;
			this.m_nameLab = (transform.FindChild("AttrName").GetComponent("XUILabel") as IXUILabel);
			this.m_levelLab = (transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_describeLab = (transform.FindChild("Describe").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x060107C7 RID: 67527 RVA: 0x004097FC File Offset: 0x004079FC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClosedSpr));
		}

		// Token: 0x060107C8 RID: 67528 RVA: 0x0040981E File Offset: 0x00407A1E
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x060107C9 RID: 67529 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x060107CA RID: 67530 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x060107CB RID: 67531 RVA: 0x00209F22 File Offset: 0x00208122
		public override void RefreshData()
		{
			base.RefreshData();
		}

		// Token: 0x060107CC RID: 67532 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x060107CD RID: 67533 RVA: 0x0040982F File Offset: 0x00407A2F
		public void RefreshUI()
		{
			this.FillContent();
		}

		// Token: 0x060107CE RID: 67534 RVA: 0x0040983C File Offset: 0x00407A3C
		private void FillContent()
		{
			SystemAnnounce.RowData sysAnnounceData = XSingleton<XGameSysMgr>.singleton.GetSysAnnounceData(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			bool flag = sysAnnounceData == null;
			if (!flag)
			{
				this.m_iconSpr.SetSprite(sysAnnounceData.IconName);
				this.m_nameLab.SetText(sysAnnounceData.SystemDescription);
				this.m_levelLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKILL_LEARN"), sysAnnounceData.OpenAnnounceLevel));
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < sysAnnounceData.AnnounceDesc.Length; i++)
				{
					stringBuilder.Append(sysAnnounceData.AnnounceDesc[i]);
					bool flag2 = i != sysAnnounceData.AnnounceDesc.Length - 1;
					if (flag2)
					{
						stringBuilder.Append("{n}");
					}
				}
				this.m_describeLab.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(stringBuilder.ToString()));
			}
		}

		// Token: 0x060107CF RID: 67535 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		protected void OnClickClosedSpr(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		// Token: 0x0400772E RID: 30510
		private IXUISprite m_closedSpr;

		// Token: 0x0400772F RID: 30511
		private IXUISprite m_iconSpr;

		// Token: 0x04007730 RID: 30512
		private IXUILabel m_nameLab;

		// Token: 0x04007731 RID: 30513
		private IXUILabel m_levelLab;

		// Token: 0x04007732 RID: 30514
		private IXUILabel m_describeLab;
	}
}
