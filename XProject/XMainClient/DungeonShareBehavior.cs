using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C91 RID: 3217
	internal class DungeonShareBehavior : DlgBehaviourBase
	{
		// Token: 0x0600B5C1 RID: 46529 RVA: 0x0023F520 File Offset: 0x0023D720
		private void Awake()
		{
			this._logoQQ = base.transform.Find("Bg/LogoQQ");
			this._logoWechat = base.transform.Find("Bg/LogoWC");
			this._wechatShare = base.transform.Find("Bg/Wc");
			this._wechat_SpecialTarget = (this._wechatShare.Find("Wc1").GetComponent("XUIButton") as IXUIButton);
			this._wechat_ZoneTarget = (this._wechatShare.Find("Wc2").GetComponent("XUIButton") as IXUIButton);
			this._QQShare = base.transform.Find("Bg/QQ");
			this._QQ_specialTarget = (this._QQShare.Find("QQ1").GetComponent("XUIButton") as IXUIButton);
			this._QQ_ZoneTarget = (this._QQShare.Find("QQ2").GetComponent("XUIButton") as IXUIButton);
			this._shareBtn = (base.transform.Find("Bg/ShareBtn").GetComponent("XUIButton") as IXUIButton);
			this._nameLabel = (base.transform.Find("Bg/label/name").GetComponent("XUILabel") as IXUILabel);
			this._serverLabel = (base.transform.Find("Bg/label/fuwuqi").GetComponent("XUILabel") as IXUILabel);
			this._noteLabel = (base.transform.Find("Bg/Note").GetComponent("XUILabel") as IXUILabel);
			this._uiDummy = (base.transform.Find("Bg/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this._bgTexture = (base.transform.Find("Bg/pHanging").GetComponent("XUITexture") as IXUITexture);
			this._closeBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this._bgText = (base.transform.Find("Bg/cxlbfont").GetComponent("XUISprite") as IXUISprite);
			this._firstLabel = (base.transform.Find("Bg/cxlbfont/t").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04004729 RID: 18217
		public Transform _logoQQ;

		// Token: 0x0400472A RID: 18218
		public Transform _logoWechat;

		// Token: 0x0400472B RID: 18219
		public Transform _wechatShare;

		// Token: 0x0400472C RID: 18220
		public Transform _QQShare;

		// Token: 0x0400472D RID: 18221
		public IXUIButton _QQ_specialTarget;

		// Token: 0x0400472E RID: 18222
		public IXUIButton _QQ_ZoneTarget;

		// Token: 0x0400472F RID: 18223
		public IXUIButton _wechat_SpecialTarget;

		// Token: 0x04004730 RID: 18224
		public IXUIButton _wechat_ZoneTarget;

		// Token: 0x04004731 RID: 18225
		public IXUIButton _shareBtn;

		// Token: 0x04004732 RID: 18226
		public IXUIButton _closeBtn;

		// Token: 0x04004733 RID: 18227
		public IXUILabel _nameLabel;

		// Token: 0x04004734 RID: 18228
		public IXUILabel _serverLabel;

		// Token: 0x04004735 RID: 18229
		public IXUILabel _noteLabel;

		// Token: 0x04004736 RID: 18230
		public IXUILabel _firstLabel;

		// Token: 0x04004737 RID: 18231
		public IUIDummy _uiDummy;

		// Token: 0x04004738 RID: 18232
		public IXUITexture _bgTexture;

		// Token: 0x04004739 RID: 18233
		public IXUISprite _bgText;
	}
}
