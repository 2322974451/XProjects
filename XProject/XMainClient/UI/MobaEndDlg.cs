using System;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class MobaEndDlg : DlgBase<MobaEndDlg, MobaBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/MobaEndDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		public void SetPic(bool isWin)
		{
			if (isWin)
			{
				base.uiBehaviour.m_Texture.SetTexturePath("atlas/UI/Battle/victery");
			}
			else
			{
				base.uiBehaviour.m_Texture.SetTexturePath("atlas/UI/Battle/failure");
			}
		}

		protected override void OnHide()
		{
			base.uiBehaviour.m_Texture.SetTexturePath("");
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}
	}
}
