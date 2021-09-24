using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class SystemHelpDlg : DlgBase<SystemHelpDlg, SystemHelpBehaviour>, IModalDlg, IXInterface
	{

		public override string fileName
		{
			get
			{
				return "Common/SystemHelpDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 100;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public bool Deprecated { get; set; }

		protected override void OnShow()
		{
			base.OnShow();
		}

		public void SetPanelDepth(int depth)
		{
			base.uiBehaviour.m_Panel.SetDepth(depth);
		}

		public void LuaShow(string content, ButtonClickEventHandler handler, ButtonClickEventHandler handler2)
		{
			this.SetVisible(true, true);
			this.SetLabelsWithSymbols(content, "OK", "Cancel");
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(handler);
		}

		public void SetLabels(string mainLabel, string titleLabel, string frLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = "";
			base.uiBehaviour.m_TitleSymbol.InputText = "";
			base.uiBehaviour.m_Label.SetText(mainLabel);
			base.uiBehaviour.m_Title.SetText(titleLabel);
			base.uiBehaviour.m_OKButton.SetCaption(frLabel);
		}

		public void SetLabelsWithSymbols(string mainLabel, string titleLabel, string frLabel)
		{
			base.uiBehaviour.m_LabelSymbol.InputText = mainLabel;
			base.uiBehaviour.m_TitleSymbol.InputText = titleLabel;
			base.uiBehaviour.m_OKButton.SetCaption(frLabel);
		}

		public void SetTweenTargetAndPlay(GameObject go)
		{
			this.SetVisible(true, true);
			base.uiBehaviour.m_PlayTween.SetTargetGameObject(go);
			base.uiBehaviour.m_PlayTween.PlayTween(true, -1f);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoCancel));
		}

		public bool DoCancel(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		public void DoCancel(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

		public bool _bHasGrey = true;
	}
}
