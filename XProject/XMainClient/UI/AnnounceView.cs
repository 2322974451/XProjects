using System;
using System.Text;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001780 RID: 6016
	internal class AnnounceView : DlgBase<AnnounceView, AnnounceBehaviour>
	{
		// Token: 0x17003834 RID: 14388
		// (get) Token: 0x0600F84E RID: 63566 RVA: 0x0038BEC0 File Offset: 0x0038A0C0
		public override string fileName
		{
			get
			{
				return "GameSystem/ForeshowDlg";
			}
		}

		// Token: 0x17003835 RID: 14389
		// (get) Token: 0x0600F84F RID: 63567 RVA: 0x0038BED8 File Offset: 0x0038A0D8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003836 RID: 14390
		// (get) Token: 0x0600F850 RID: 63568 RVA: 0x0038BEEC File Offset: 0x0038A0EC
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003837 RID: 14391
		// (get) Token: 0x0600F851 RID: 63569 RVA: 0x0038BF00 File Offset: 0x0038A100
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F852 RID: 63570 RVA: 0x0038BF13 File Offset: 0x0038A113
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600F853 RID: 63571 RVA: 0x0038BF1D File Offset: 0x0038A11D
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClosedSpr));
		}

		// Token: 0x0600F854 RID: 63572 RVA: 0x0038BF44 File Offset: 0x0038A144
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F855 RID: 63573 RVA: 0x0038BF4E File Offset: 0x0038A14E
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600F856 RID: 63574 RVA: 0x0038BF58 File Offset: 0x0038A158
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x17003838 RID: 14392
		// (get) Token: 0x0600F857 RID: 63575 RVA: 0x0038BF64 File Offset: 0x0038A164
		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F858 RID: 63576 RVA: 0x0038BF77 File Offset: 0x0038A177
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600F859 RID: 63577 RVA: 0x0038BF88 File Offset: 0x0038A188
		public void RefreshUI()
		{
			this.FillContent();
		}

		// Token: 0x0600F85A RID: 63578 RVA: 0x0038BF94 File Offset: 0x0038A194
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

		// Token: 0x0600F85B RID: 63579 RVA: 0x0038C0DD File Offset: 0x0038A2DD
		protected void OnClickClosedSpr(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}
	}
}
