using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildArenaDefeatBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.mRoundResult = base.transform.FindChild("RoundResult").gameObject;
			this.mFinalResult = base.transform.FindChild("FinalResult").gameObject;
			this.uiBlueAvatar = (base.transform.FindChild("RoundResult/Blue/head").GetComponent("XUISprite") as IXUISprite);
			this.uiRedAvatar = (base.transform.FindChild("RoundResult/Red/head").GetComponent("XUISprite") as IXUISprite);
			this.blueSprite = (base.transform.FindChild("FinalResult/Blue/Portrait").GetComponent("XUISprite") as IXUISprite);
			this.redSprite = (base.transform.FindChild("FinalResult/Red/Portrait").GetComponent("XUISprite") as IXUISprite);
			this.mBlueGuildHeadSprite = (base.transform.FindChild("FinalResult/Blue/Portrait").GetComponent("XUISprite") as IXUISprite);
			this.mRedGuildHeadSprite = (base.transform.FindChild("FinalResult/Red/Portrait").GetComponent("XUISprite") as IXUISprite);
			this.mReturnSpr = (base.transform.FindChild("FinalResult/return").GetComponent("XUISprite") as IXUISprite);
		}

		public GameObject mRoundResult;

		public GameObject mFinalResult;

		public IXUISprite blueSprite;

		public IXUISprite redSprite;

		public IXUISprite uiBlueAvatar;

		public IXUISprite uiRedAvatar;

		public IXUISprite mReturnSpr;

		protected internal IXUISprite mBlueGuildHeadSprite;

		protected internal IXUISprite mRedGuildHeadSprite;
	}
}
