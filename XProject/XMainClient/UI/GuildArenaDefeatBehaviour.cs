using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200174F RID: 5967
	internal class GuildArenaDefeatBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F697 RID: 63127 RVA: 0x0037F3D0 File Offset: 0x0037D5D0
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

		// Token: 0x04006B0A RID: 27402
		public GameObject mRoundResult;

		// Token: 0x04006B0B RID: 27403
		public GameObject mFinalResult;

		// Token: 0x04006B0C RID: 27404
		public IXUISprite blueSprite;

		// Token: 0x04006B0D RID: 27405
		public IXUISprite redSprite;

		// Token: 0x04006B0E RID: 27406
		public IXUISprite uiBlueAvatar;

		// Token: 0x04006B0F RID: 27407
		public IXUISprite uiRedAvatar;

		// Token: 0x04006B10 RID: 27408
		public IXUISprite mReturnSpr;

		// Token: 0x04006B11 RID: 27409
		protected internal IXUISprite mBlueGuildHeadSprite;

		// Token: 0x04006B12 RID: 27410
		protected internal IXUISprite mRedGuildHeadSprite;
	}
}
