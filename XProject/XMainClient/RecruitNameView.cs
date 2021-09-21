using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A35 RID: 2613
	internal class RecruitNameView : DlgBase<RecruitNameView, RecruitNameBehaviour>
	{
		// Token: 0x17002ED6 RID: 11990
		// (get) Token: 0x06009F30 RID: 40752 RVA: 0x001A590C File Offset: 0x001A3B0C
		public override string fileName
		{
			get
			{
				return "Team/RecruitNameView";
			}
		}

		// Token: 0x06009F31 RID: 40753 RVA: 0x001A5924 File Offset: 0x001A3B24
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._doc = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			base.uiBehaviour._Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour._Submit.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSubmitClick));
		}

		// Token: 0x06009F32 RID: 40754 RVA: 0x001A5983 File Offset: 0x001A3B83
		protected override void OnShow()
		{
			base.OnShow();
			this.Setup();
		}

		// Token: 0x06009F33 RID: 40755 RVA: 0x001A5994 File Offset: 0x001A3B94
		private void Setup()
		{
			base.uiBehaviour._NameInput.SetText(string.Empty);
		}

		// Token: 0x06009F34 RID: 40756 RVA: 0x001A59B0 File Offset: 0x001A3BB0
		private bool OnCloseClick(IXUIButton btn = null)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06009F35 RID: 40757 RVA: 0x001A59CC File Offset: 0x001A3BCC
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

		// Token: 0x040038C7 RID: 14535
		private GroupChatDocument _doc;
	}
}
