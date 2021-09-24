using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RecruitNameView : DlgBase<RecruitNameView, RecruitNameBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/RecruitNameView";
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._doc = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			base.uiBehaviour._Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour._Submit.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSubmitClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.Setup();
		}

		private void Setup()
		{
			base.uiBehaviour._NameInput.SetText(string.Empty);
		}

		private bool OnCloseClick(IXUIButton btn = null)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnSubmitClick(IXUIButton btn)
		{
			string text = base.uiBehaviour._NameInput.GetText();
			bool flag = string.IsNullOrEmpty(text) || text.Contains(" ");
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RenameInputNullString"), "fece00");
				result = false;
			}
			else
			{
				bool flag2 = text.Length > 8;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RenamePlayerSizeErr"), "fece00");
					result = false;
				}
				else
				{
					bool flag3 = this._doc.ReqCreateGroupChat(text, 1U);
					if (flag3)
					{
						this.OnCloseClick(null);
					}
					result = true;
				}
			}
			return result;
		}

		private GroupChatDocument _doc;
	}
}
