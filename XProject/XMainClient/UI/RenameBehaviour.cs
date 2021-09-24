using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class RenameBehaviour : DlgBehaviourBase
	{

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

		public IXUISprite mClose;

		public IXUILabel mMessage;

		public IXUILabel mTitle;

		public IXUIInput mInput;

		public IXUILabel mInputText;

		public IXUIButton mOk;
	}
}
