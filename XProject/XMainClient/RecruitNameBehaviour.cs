using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class RecruitNameBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this._Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this._Submit = (base.transform.Find("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this._NameInput = (base.transform.Find("Bg/Input").GetComponent("XUIInput") as IXUIInput);
		}

		public IXUIButton _Close;

		public IXUIButton _Submit;

		public IXUIInput _NameInput;
	}
}
