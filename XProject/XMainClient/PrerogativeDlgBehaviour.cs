using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class PrerogativeDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this._ruleBtn = (base.transform.Find("Bg/RuleBtn").GetComponent("XUIButton") as IXUIButton);
			this._shopBtn = (base.transform.Find("Bg/ShopBtn").GetComponent("XUIButton") as IXUIButton);
			this._setting = base.transform.Find("Bg/Setting");
			this._desc = (base.transform.Find("Bg/Intro").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_Close;

		public IXUIButton _ruleBtn;

		public IXUIButton _shopBtn;

		public Transform _setting;

		public IXUILabel _desc;
	}
}
