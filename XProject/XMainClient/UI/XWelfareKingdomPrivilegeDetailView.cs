using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018E4 RID: 6372
	internal class XWelfareKingdomPrivilegeDetailView : DlgBase<XWelfareKingdomPrivilegeDetailView, XWelfareKingdomPrivilegeDetailBehaviour>
	{
		// Token: 0x17003A79 RID: 14969
		// (get) Token: 0x06010999 RID: 67993 RVA: 0x00417F64 File Offset: 0x00416164
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A7A RID: 14970
		// (get) Token: 0x0601099A RID: 67994 RVA: 0x00417F78 File Offset: 0x00416178
		public override string fileName
		{
			get
			{
				return "GameSystem/Welfare/KingdomPrivilegeDetail";
			}
		}

		// Token: 0x17003A7B RID: 14971
		// (get) Token: 0x0601099B RID: 67995 RVA: 0x00417F90 File Offset: 0x00416190
		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A7C RID: 14972
		// (get) Token: 0x0601099C RID: 67996 RVA: 0x00417FA4 File Offset: 0x004161A4
		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601099D RID: 67997 RVA: 0x00417FB8 File Offset: 0x004161B8
		public void ShowDetail(PayMemberTable.RowData info, bool showDetail = true)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
			base.uiBehaviour.m_Title.SetText(info.Name);
			base.uiBehaviour.m_Content.SetText(info.Detail.Replace("|", "\n"));
			base.uiBehaviour.m_Icon.SetTexturePath(info.Icon);
			base.uiBehaviour.m_Name.SetVisible(showDetail);
			base.uiBehaviour.m_Notice.SetVisible(!showDetail);
			base.uiBehaviour.m_Notice.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(info.BuyNtf));
		}

		// Token: 0x0601099E RID: 67998 RVA: 0x0041807A File Offset: 0x0041627A
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
		}

		// Token: 0x0601099F RID: 67999 RVA: 0x004180A1 File Offset: 0x004162A1
		protected override void OnHide()
		{
			base.OnHide();
			base.uiBehaviour.m_Icon.SetTexturePath("");
		}

		// Token: 0x060109A0 RID: 68000 RVA: 0x004180C4 File Offset: 0x004162C4
		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}
	}
}
