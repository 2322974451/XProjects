using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class DragonCrusadeGateBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.mClosedBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.mRwdBtn = (base.transform.FindChild("Bg/ContentFrame/btm/rwdBtn").GetComponent("XUIButton") as IXUIButton);
			this.mBuff = (base.transform.transform.Find("Bg/ContentFrame/FightValue/Buff").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUISprite mBuff = null;

		public IXUIButton mClosedBtn = null;

		public IXUIButton mRwdBtn = null;
	}
}
