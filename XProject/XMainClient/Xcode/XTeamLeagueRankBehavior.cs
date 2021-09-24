using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XTeamLeagueRankBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.WrapContent = (base.transform.Find("Panel/wrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.NoRankTrans = base.transform.Find("NoRank");
		}

		public IXUIButton CloseBtn;

		public IXUIWrapContent WrapContent;

		public Transform NoRankTrans;
	}
}
