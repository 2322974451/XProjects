using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A2F RID: 2607
	internal class RecruitNameBehaviour : DlgBehaviourBase
	{
		// Token: 0x06009F08 RID: 40712 RVA: 0x001A4C34 File Offset: 0x001A2E34
		private void Awake()
		{
			this._Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this._Submit = (base.transform.Find("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this._NameInput = (base.transform.Find("Bg/Input").GetComponent("XUIInput") as IXUIInput);
		}

		// Token: 0x040038AE RID: 14510
		public IXUIButton _Close;

		// Token: 0x040038AF RID: 14511
		public IXUIButton _Submit;

		// Token: 0x040038B0 RID: 14512
		public IXUIInput _NameInput;
	}
}
