using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CutoverViewView : DlgBase<CutoverViewView, CutoverViewBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/CutoverViewDlg";
			}
		}

		public override bool exclusive
		{
			get
			{
				return true;
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

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKClicked));
			base.uiBehaviour.m_25D.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X25D));
			base.uiBehaviour.m_25D.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSetView));
			base.uiBehaviour.m_3D.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X3D));
			base.uiBehaviour.m_3D.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSetView));
		}

		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.GausBlur, true);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(false);
			this.IsOpening = true;
			base.uiBehaviour.m_25D.bChecked = true;
			this.SelectLook = XOperationMode.X25D;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = XSingleton<XTimerMgr>.singleton.SetTimer(float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CutoverViewDeadLine")), new XTimerMgr.ElapsedEventHandler(this.SelectView), null);
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.GausBlur, false);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
			this.IsOpening = false;
		}

		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.GausBlur, false);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
			this.IsOpening = false;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		public bool OnOKClicked(IXUIButton sp)
		{
			this.SelectView(null);
			return true;
		}

		private void SelectView(object param)
		{
			XSingleton<XTutorialHelper>.singleton.SelectView = true;
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_VIEW, XFastEnumIntEqualityComparer<XOperationMode>.ToInt(this.SelectLook), true);
			specificDocument.SetBattleOptionValue();
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetView(XSingleton<XOperationData>.singleton.OperationMode);
			XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_BattleDlg_Clip01", DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_canvas, Vector3.zero, Vector3.one, 1f, true, 9f, true);
			this.SetVisibleWithAnimation(false, null);
		}

		private bool OnSetView(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.SelectLook = (XOperationMode)box.ID;
				result = true;
			}
			return result;
		}

		private uint _TimerID = 0U;

		public bool IsOpening = false;

		public XOperationMode SelectLook;
	}
}
