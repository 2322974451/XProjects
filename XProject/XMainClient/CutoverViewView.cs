using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B95 RID: 2965
	internal class CutoverViewView : DlgBase<CutoverViewView, CutoverViewBehaviour>
	{
		// Token: 0x17003035 RID: 12341
		// (get) Token: 0x0600A9D6 RID: 43478 RVA: 0x001E4A2C File Offset: 0x001E2C2C
		public override string fileName
		{
			get
			{
				return "Battle/CutoverViewDlg";
			}
		}

		// Token: 0x17003036 RID: 12342
		// (get) Token: 0x0600A9D7 RID: 43479 RVA: 0x001E4A44 File Offset: 0x001E2C44
		public override bool exclusive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003037 RID: 12343
		// (get) Token: 0x0600A9D8 RID: 43480 RVA: 0x001E4A58 File Offset: 0x001E2C58
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003038 RID: 12344
		// (get) Token: 0x0600A9D9 RID: 43481 RVA: 0x001E4A6C File Offset: 0x001E2C6C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003039 RID: 12345
		// (get) Token: 0x0600A9DA RID: 43482 RVA: 0x001E4A80 File Offset: 0x001E2C80
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700303A RID: 12346
		// (get) Token: 0x0600A9DB RID: 43483 RVA: 0x001E4A94 File Offset: 0x001E2C94
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600A9DC RID: 43484 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Init()
		{
		}

		// Token: 0x0600A9DD RID: 43485 RVA: 0x001E4AA8 File Offset: 0x001E2CA8
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKClicked));
			base.uiBehaviour.m_25D.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X25D));
			base.uiBehaviour.m_25D.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSetView));
			base.uiBehaviour.m_3D.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X3D));
			base.uiBehaviour.m_3D.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSetView));
		}

		// Token: 0x0600A9DE RID: 43486 RVA: 0x001E4B40 File Offset: 0x001E2D40
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

		// Token: 0x0600A9DF RID: 43487 RVA: 0x001E4BD0 File Offset: 0x001E2DD0
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.GausBlur, false);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
			this.IsOpening = false;
		}

		// Token: 0x0600A9E0 RID: 43488 RVA: 0x001E4C20 File Offset: 0x001E2E20
		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.GausBlur, false);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
			this.IsOpening = false;
			base.OnUnload();
		}

		// Token: 0x0600A9E1 RID: 43489 RVA: 0x001E4C6D File Offset: 0x001E2E6D
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0600A9E2 RID: 43490 RVA: 0x001E4C78 File Offset: 0x001E2E78
		public bool OnOKClicked(IXUIButton sp)
		{
			this.SelectView(null);
			return true;
		}

		// Token: 0x0600A9E3 RID: 43491 RVA: 0x001E4C94 File Offset: 0x001E2E94
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

		// Token: 0x0600A9E4 RID: 43492 RVA: 0x001E4D2C File Offset: 0x001E2F2C
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

		// Token: 0x04003EE5 RID: 16101
		private uint _TimerID = 0U;

		// Token: 0x04003EE6 RID: 16102
		public bool IsOpening = false;

		// Token: 0x04003EE7 RID: 16103
		public XOperationMode SelectLook;
	}
}
