using System;
using System.Text;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class AnnounceView : DlgBase<AnnounceView, AnnounceBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ForeshowDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClosedSpr));
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		public void RefreshUI()
		{
			this.FillContent();
		}

		private void FillContent()
		{
			bool flag = base.uiBehaviour.m_playerTween != null;
			if (flag)
			{
				base.uiBehaviour.m_playerTween.ResetTween(true);
				base.uiBehaviour.m_playerTween.PlayTween(true, -1f);
			}
			SystemAnnounce.RowData sysAnnounceData = XSingleton<XGameSysMgr>.singleton.GetSysAnnounceData(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			bool flag2 = sysAnnounceData == null;
			if (!flag2)
			{
				base.uiBehaviour.m_iconSpr.SetSprite(sysAnnounceData.IconName);
				base.uiBehaviour.m_nameLab.SetText(sysAnnounceData.SystemDescription);
				base.uiBehaviour.m_levelLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKILL_LEARN"), sysAnnounceData.OpenAnnounceLevel));
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < sysAnnounceData.AnnounceDesc.Length; i++)
				{
					stringBuilder.Append(sysAnnounceData.AnnounceDesc[i]);
					bool flag3 = i != sysAnnounceData.AnnounceDesc.Length - 1;
					if (flag3)
					{
						stringBuilder.Append("{n}");
					}
				}
				base.uiBehaviour.m_describeLab.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(stringBuilder.ToString()));
			}
		}

		protected void OnClickClosedSpr(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}
	}
}
