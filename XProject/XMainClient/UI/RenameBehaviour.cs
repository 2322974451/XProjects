using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001874 RID: 6260
	internal class RenameBehaviour : DlgBehaviourBase
	{
		// Token: 0x060104B4 RID: 66740 RVA: 0x003F12E8 File Offset: 0x003EF4E8
		private void Awake()
		{
			this.mClose = (base.transform.Find("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.mMessage = (base.transform.Find("Bg/T").GetComponent("XUILabel") as IXUILabel);
			this.mTitle = (base.transform.Find("Bg/pp/T").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/p");
			XSingleton<XDebug>.singleton.AddGreenLog("T = NULL?" + (transform == null).ToString(), null, null, null, null, null);
			this.mInput = (base.transform.Find("Bg/p").GetComponent("XUIInput") as IXUIInput);
			this.mInputText = (base.transform.Find("Bg/p/T").GetComponent("XUILabel") as IXUILabel);
			this.mOk = (base.transform.Find("Bg/ok").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0400752D RID: 29997
		public IXUISprite mClose;

		// Token: 0x0400752E RID: 29998
		public IXUILabel mMessage;

		// Token: 0x0400752F RID: 29999
		public IXUILabel mTitle;

		// Token: 0x04007530 RID: 30000
		public IXUIInput mInput;

		// Token: 0x04007531 RID: 30001
		public IXUILabel mInputText;

		// Token: 0x04007532 RID: 30002
		public IXUIButton mOk;
	}
}
