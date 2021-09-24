using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class RecruitAuthorizeBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this._info = (base.transform.Find("Info/Info").GetComponent("XUILabel") as IXUILabel);
			this._Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this._Empty = base.transform.Find("Empty");
			this._MemberScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this._MemberWrapContent = (base.transform.Find("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		public IXUILabel _info;

		public IXUIButton _Close;

		public Transform _Empty;

		public IXUIScrollView _MemberScrollView;

		public IXUIWrapContent _MemberWrapContent;
	}
}
