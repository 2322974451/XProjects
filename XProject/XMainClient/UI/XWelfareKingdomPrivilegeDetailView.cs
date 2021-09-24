using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWelfareKingdomPrivilegeDetailView : DlgBase<XWelfareKingdomPrivilegeDetailView, XWelfareKingdomPrivilegeDetailBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/Welfare/KingdomPrivilegeDetail";
			}
		}

		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.uiBehaviour.m_Icon.SetTexturePath("");
		}

		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}
	}
}
