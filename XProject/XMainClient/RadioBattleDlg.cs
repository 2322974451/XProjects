using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BDE RID: 3038
	internal class RadioBattleDlg : DlgBase<RadioBattleDlg, RadioBattleBahaviour>
	{
		// Token: 0x17003092 RID: 12434
		// (get) Token: 0x0600AD33 RID: 44339 RVA: 0x00201414 File Offset: 0x001FF614
		private XRadioDocument radioDocument
		{
			get
			{
				return XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			}
		}

		// Token: 0x17003093 RID: 12435
		// (get) Token: 0x0600AD34 RID: 44340 RVA: 0x00201430 File Offset: 0x001FF630
		public override string fileName
		{
			get
			{
				return "Common/RadioBattleDlg";
			}
		}

		// Token: 0x17003094 RID: 12436
		// (get) Token: 0x0600AD35 RID: 44341 RVA: 0x00201448 File Offset: 0x001FF648
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003095 RID: 12437
		// (get) Token: 0x0600AD36 RID: 44342 RVA: 0x0020145C File Offset: 0x001FF65C
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003096 RID: 12438
		// (get) Token: 0x0600AD37 RID: 44343 RVA: 0x00201470 File Offset: 0x001FF670
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600AD38 RID: 44344 RVA: 0x00201483 File Offset: 0x001FF683
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600AD39 RID: 44345 RVA: 0x00201490 File Offset: 0x001FF690
		public void Show(bool show)
		{
			if (show)
			{
				XApolloDocument specificDocument = XDocuments.GetSpecificDocument<XApolloDocument>(XApolloDocument.uuID);
				XOptionsDocument specificDocument2 = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				bool flag = specificDocument != null && specificDocument2 != null;
				if (flag)
				{
					bool isRealVoice = specificDocument.IsRealVoice;
					bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible() && !isRealVoice && XSingleton<XScene>.singleton.SceneID != 100U && (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (ulong)((long)this.open_level) && specificDocument2.GetValue(XOptionsDefine.OD_RADIO) == 1;
					if (flag2)
					{
						this.SetVisible(true, true);
					}
				}
			}
			else
			{
				this.SetVisible(false, true);
			}
		}

		// Token: 0x0600AD3A RID: 44346 RVA: 0x0020153C File Offset: 0x001FF73C
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_objSelect.SetActive(false);
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			int type = XFastEnumIntEqualityComparer<SceneType>.ToInt(XSingleton<XScene>.singleton.SceneType);
			ChatOpen.RowData yuyinRaw = specificDocument.GetYuyinRaw(type);
			XPlayerAttributes xplayerAttributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
			int num = 0;
			bool flag = !XSingleton<XSceneMgr>.singleton.CanAutoPlay(XSingleton<XScene>.singleton.SceneID) && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible() && yuyinRaw.id == 2U;
			if (flag)
			{
				num = -60;
			}
			base.uiBehaviour.m_objSelect.transform.localPosition = new Vector3((float)(yuyinRaw.radioX + num), (float)yuyinRaw.radioY, 0f);
			base.uiBehaviour.m_btnRadio.gameObject.transform.transform.localPosition = new Vector3((float)(yuyinRaw.radioX + num), (float)yuyinRaw.radioY, 0f);
		}

		// Token: 0x0600AD3B RID: 44347 RVA: 0x00201644 File Offset: 0x001FF844
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnRadio.RegisterClickEventHandler(new ButtonClickEventHandler(this.Toggle));
			base.uiBehaviour.m_btnOpen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OpenRadio));
			base.uiBehaviour.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.CloseRadio));
		}

		// Token: 0x0600AD3C RID: 44348 RVA: 0x002016B0 File Offset: 0x001FF8B0
		private bool Toggle(IXUIButton btn)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				bool activeSelf = base.uiBehaviour.m_objSelect.activeSelf;
				if (activeSelf)
				{
					base.uiBehaviour.m_objSelect.SetActive(false);
				}
				else
				{
					base.uiBehaviour.m_objSelect.SetActive(true);
				}
			}
			return true;
		}

		// Token: 0x0600AD3D RID: 44349 RVA: 0x00201710 File Offset: 0x001FF910
		private bool CloseRadio(IXUIButton btn)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				base.uiBehaviour.m_objSelect.SetActive(false);
				this.Refresh(false);
			}
			return true;
		}

		// Token: 0x0600AD3E RID: 44350 RVA: 0x0020174C File Offset: 0x001FF94C
		private bool OpenRadio(IXUIButton btn)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				base.uiBehaviour.m_objSelect.SetActive(false);
				this.Refresh(true);
			}
			return true;
		}

		// Token: 0x0600AD3F RID: 44351 RVA: 0x00201788 File Offset: 0x001FF988
		private void Refresh(bool open)
		{
			if (open)
			{
				bool isBroadcast = DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.isBroadcast;
				if (isBroadcast)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_FM_FORBID2"), "fece00");
				}
				else
				{
					bool flag = this.radioDocument.roomState == XRadioDocument.BigRoomState.OutRoom;
					if (flag)
					{
						this.radioDocument.JoinBigRoom();
					}
				}
			}
			else
			{
				bool flag2 = this.radioDocument.roomState == XRadioDocument.BigRoomState.InRoom;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_LEAVE_SUCCESS"), "fece00");
					this.radioDocument.QuitBigRoom();
				}
			}
		}

		// Token: 0x0400413F RID: 16703
		private int open_level = 2;
	}
}
