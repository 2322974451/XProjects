using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class DungeonShareBehavior : DlgBehaviourBase
	{

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

		public Transform _logoQQ;

		public Transform _logoWechat;

		public Transform _wechatShare;

		public Transform _QQShare;

		public IXUIButton _QQ_specialTarget;

		public IXUIButton _QQ_ZoneTarget;

		public IXUIButton _wechat_SpecialTarget;

		public IXUIButton _wechat_ZoneTarget;

		public IXUIButton _shareBtn;

		public IXUIButton _closeBtn;

		public IXUILabel _nameLabel;

		public IXUILabel _serverLabel;

		public IXUILabel _noteLabel;

		public IXUILabel _firstLabel;

		public IUIDummy _uiDummy;

		public IXUITexture _bgTexture;

		public IXUISprite _bgText;
	}
}
