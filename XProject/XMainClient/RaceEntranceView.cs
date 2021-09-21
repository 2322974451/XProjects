using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CAC RID: 3244
	internal class RaceEntranceView : DlgBase<RaceEntranceView, RaceEntranceBehaviour>
	{
		// Token: 0x17003247 RID: 12871
		// (get) Token: 0x0600B69F RID: 46751 RVA: 0x00243888 File Offset: 0x00241A88
		public override string fileName
		{
			get
			{
				return "GameSystem/Race/RaceEntranceDlg";
			}
		}

		// Token: 0x17003248 RID: 12872
		// (get) Token: 0x0600B6A0 RID: 46752 RVA: 0x002438A0 File Offset: 0x00241AA0
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003249 RID: 12873
		// (get) Token: 0x0600B6A1 RID: 46753 RVA: 0x002438B4 File Offset: 0x00241AB4
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700324A RID: 12874
		// (get) Token: 0x0600B6A2 RID: 46754 RVA: 0x002438C8 File Offset: 0x00241AC8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700324B RID: 12875
		// (get) Token: 0x0600B6A3 RID: 46755 RVA: 0x002438DC File Offset: 0x00241ADC
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700324C RID: 12876
		// (get) Token: 0x0600B6A4 RID: 46756 RVA: 0x002438F0 File Offset: 0x00241AF0
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700324D RID: 12877
		// (get) Token: 0x0600B6A5 RID: 46757 RVA: 0x00243904 File Offset: 0x00241B04
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_MulActivity_Race);
			}
		}

		// Token: 0x0600B6A6 RID: 46758 RVA: 0x00243920 File Offset: 0x00241B20
		protected override void Init()
		{
			base.uiBehaviour.m_GameRule.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("RACE_RULE")));
		}

		// Token: 0x0600B6A7 RID: 46759 RVA: 0x00243948 File Offset: 0x00241B48
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_SingleJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartSingleClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x0600B6A8 RID: 46760 RVA: 0x002439B0 File Offset: 0x00241BB0
		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B6A9 RID: 46761 RVA: 0x002439CC File Offset: 0x00241BCC
		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_MulActivity_Race);
			return true;
		}

		// Token: 0x0600B6AA RID: 46762 RVA: 0x002439F0 File Offset: 0x00241BF0
		private bool OnStartSingleClicked(IXUIButton btn)
		{
			bool flag = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnStartSingleClicked), btn);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
				ptcC2G_EnterSceneReq.Data.sceneID = 50U;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
				result = true;
			}
			return result;
		}

		// Token: 0x0600B6AB RID: 46763 RVA: 0x00243A3D File Offset: 0x00241C3D
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshPage();
		}

		// Token: 0x0600B6AC RID: 46764 RVA: 0x00243A4E File Offset: 0x00241C4E
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B6AD RID: 46765 RVA: 0x00243A58 File Offset: 0x00241C58
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B6AE RID: 46766 RVA: 0x00243A62 File Offset: 0x00241C62
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0600B6AF RID: 46767 RVA: 0x00243A6C File Offset: 0x00241C6C
		public void RefreshPage()
		{
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("RaceShowRaward").Split(new char[]
			{
				'|'
			});
			base.uiBehaviour.m_RewardPool.FakeReturnAll();
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(i * base.uiBehaviour.m_RewardPool.TplWidth), 0f, 0f);
				uint num = uint.Parse(array[i]);
				Transform transform = gameObject.transform.Find("Item");
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform.gameObject, (int)num, 0, false);
				IXUISprite ixuisprite = transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)num;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
			}
			base.uiBehaviour.m_RewardPool.ActualReturnAll(false);
		}

		// Token: 0x0600B6B0 RID: 46768 RVA: 0x001EECC3 File Offset: 0x001ECEC3
		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		// Token: 0x0600B6B1 RID: 46769 RVA: 0x00243B89 File Offset: 0x00241D89
		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_MulActivity_Race, true);
		}

		// Token: 0x0400477C RID: 18300
		public bool MainInterfaceState = false;
	}
}
