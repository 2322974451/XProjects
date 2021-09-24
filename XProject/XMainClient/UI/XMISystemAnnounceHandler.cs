using System;
using System.Text;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XMISystemAnnounceHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/ForeshowDlg";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClosedSpr));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public override void RefreshData()
		{
			base.RefreshData();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public void RefreshUI()
		{
			this.FillContent();
		}

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

		protected void OnClickClosedSpr(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		private IXUISprite m_closedSpr;

		private IXUISprite m_iconSpr;

		private IXUILabel m_nameLab;

		private IXUILabel m_levelLab;

		private IXUILabel m_describeLab;
	}
}
