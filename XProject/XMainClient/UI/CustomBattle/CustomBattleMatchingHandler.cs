using System;
using UILib;

namespace XMainClient.UI.CustomBattle
{

	internal class CustomBattleMatchingHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/MatchingFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._cancel = (base.transform.Find("Cancel").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelButtonClicked));
		}

		private bool OnCancelButtonClicked(IXUIButton button)
		{
			this._doc.SendCustomBattleUnMatch();
			base.SetVisible(false);
			return true;
		}

		private XCustomBattleDocument _doc = null;

		private IXUIButton _cancel;
	}
}
