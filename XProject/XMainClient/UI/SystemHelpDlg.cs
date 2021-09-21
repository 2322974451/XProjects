using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001879 RID: 6265
	public class SystemHelpDlg : DlgBase<SystemHelpDlg, SystemHelpBehaviour>, IModalDlg, IXInterface
	{
		// Token: 0x170039C4 RID: 14788
		// (get) Token: 0x060104DD RID: 66781 RVA: 0x003F2228 File Offset: 0x003F0428
		public override string fileName
		{
			get
			{
				return "Common/SystemHelpDlg";
			}
		}

		// Token: 0x170039C5 RID: 14789
		// (get) Token: 0x060104DE RID: 66782 RVA: 0x003F2240 File Offset: 0x003F0440
		public override int layer
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x170039C6 RID: 14790
		// (get) Token: 0x060104DF RID: 66783 RVA: 0x003F2254 File Offset: 0x003F0454
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039C7 RID: 14791
		// (get) Token: 0x060104E0 RID: 66784 RVA: 0x003F2267 File Offset: 0x003F0467
		// (set) Token: 0x060104E1 RID: 66785 RVA: 0x003F226F File Offset: 0x003F046F
		public bool Deprecated { get; set; }

		// Token: 0x060104E2 RID: 66786 RVA: 0x003F2278 File Offset: 0x003F0478
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x060104E3 RID: 66787 RVA: 0x003F2282 File Offset: 0x003F0482
		public void SetPanelDepth(int depth)
		{
			base.uiBehaviour.m_Panel.SetDepth(depth);
		}

		// Token: 0x060104E4 RID: 66788 RVA: 0x003F2297 File Offset: 0x003F0497
		public void LuaShow(string content, ButtonClickEventHandler handler, ButtonClickEventHandler handler2)
		{
			this.SetVisible(true, true);
			this.SetLabelsWithSymbols(content, "OK", "Cancel");
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(handler);
		}

		// Token: 0x060104E5 RID: 66789 RVA: 0x003F22C8 File Offset: 0x003F04C8
		public void SetLabels(string mainLabel, string titleLabel, string frLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = "";
			base.uiBehaviour.m_TitleSymbol.InputText = "";
			base.uiBehaviour.m_Label.SetText(mainLabel);
			base.uiBehaviour.m_Title.SetText(titleLabel);
			base.uiBehaviour.m_OKButton.SetCaption(frLabel);
		}

		// Token: 0x060104E6 RID: 66790 RVA: 0x003F2338 File Offset: 0x003F0538
		public void SetLabelsWithSymbols(string mainLabel, string titleLabel, string frLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = mainLabel;
			base.uiBehaviour.m_TitleSymbol.InputText = titleLabel;
			base.uiBehaviour.m_OKButton.SetCaption(frLabel);
		}

		// Token: 0x060104E7 RID: 66791 RVA: 0x003F2371 File Offset: 0x003F0571
		public void SetTweenTargetAndPlay(GameObject go)
		{
			this.SetVisible(true, true);
			base.uiBehaviour.m_PlayTween.SetTargetGameObject(go);
			base.uiBehaviour.m_PlayTween.PlayTween(true, -1f);
		}

		// Token: 0x060104E8 RID: 66792 RVA: 0x003F23A6 File Offset: 0x003F05A6
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoCancel));
		}

		// Token: 0x060104E9 RID: 66793 RVA: 0x003F23C8 File Offset: 0x003F05C8
		public bool DoCancel(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x060104EA RID: 66794 RVA: 0x003F23E4 File Offset: 0x003F05E4
		public void DoCancel(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0400754B RID: 30027
		public bool _bHasGrey = true;
	}
}
