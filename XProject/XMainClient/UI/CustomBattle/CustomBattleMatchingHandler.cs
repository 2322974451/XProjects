using System;
using UILib;

namespace XMainClient.UI.CustomBattle
{
	// Token: 0x02001935 RID: 6453
	internal class CustomBattleMatchingHandler : DlgHandlerBase
	{
		// Token: 0x17003B2B RID: 15147
		// (get) Token: 0x06010F7A RID: 69498 RVA: 0x004513D4 File Offset: 0x0044F5D4
		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/MatchingFrame";
			}
		}

		// Token: 0x06010F7B RID: 69499 RVA: 0x004513EB File Offset: 0x0044F5EB
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._cancel = (base.transform.Find("Cancel").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x06010F7C RID: 69500 RVA: 0x0045142A File Offset: 0x0044F62A
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelButtonClicked));
		}

		// Token: 0x06010F7D RID: 69501 RVA: 0x0045144C File Offset: 0x0044F64C
		private bool OnCancelButtonClicked(IXUIButton button)
		{
			this._doc.SendCustomBattleUnMatch();
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04007D09 RID: 32009
		private XCustomBattleDocument _doc = null;

		// Token: 0x04007D0A RID: 32010
		private IXUIButton _cancel;
	}
}
