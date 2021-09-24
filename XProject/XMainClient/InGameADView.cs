using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class InGameADView : DlgBase<InGameADView, InGameADBehaviour>
	{

		private uint npcID
		{
			get
			{
				return uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("InGameADNPCID"));
			}
		}

		private string tex
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetValue("InGameADTex");
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/InGameAD";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_BtnGo.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGoClick));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public void OnGoClick(IXUISprite btn)
		{
			XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc(this.npcID);
			this.SetVisibleWithAnimation(false, null);
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Tex.SetTexturePath(this.tex);
		}

		protected override void OnHide()
		{
			base.uiBehaviour.m_Tex.SetTexturePath("");
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}
	}
}
