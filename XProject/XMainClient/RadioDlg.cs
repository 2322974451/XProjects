using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BE1 RID: 3041
	internal class RadioDlg : DlgBase<RadioDlg, RadioBehaviour>
	{
		// Token: 0x17003097 RID: 12439
		// (get) Token: 0x0600AD45 RID: 44357 RVA: 0x00201950 File Offset: 0x001FFB50
		private XRadioDocument radioDocument
		{
			get
			{
				return XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			}
		}

		// Token: 0x17003098 RID: 12440
		// (get) Token: 0x0600AD46 RID: 44358 RVA: 0x0020196C File Offset: 0x001FFB6C
		public override string fileName
		{
			get
			{
				return "Common/RadioDlg";
			}
		}

		// Token: 0x17003099 RID: 12441
		// (get) Token: 0x0600AD47 RID: 44359 RVA: 0x00201984 File Offset: 0x001FFB84
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700309A RID: 12442
		// (get) Token: 0x0600AD48 RID: 44360 RVA: 0x00201998 File Offset: 0x001FFB98
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700309B RID: 12443
		// (get) Token: 0x0600AD49 RID: 44361 RVA: 0x002019AC File Offset: 0x001FFBAC
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AD4A RID: 44362 RVA: 0x002019BF File Offset: 0x001FFBBF
		protected override void Init()
		{
			base.Init();
			this.open_level = XSingleton<XGlobalConfig>.singleton.GetInt("RadioOpen");
		}

		// Token: 0x0600AD4B RID: 44363 RVA: 0x002019E0 File Offset: 0x001FFBE0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_lblMicro.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnMicroClick));
			base.uiBehaviour.m_btnRadio.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRadioClick));
		}

		// Token: 0x0600AD4C RID: 44364 RVA: 0x00201A30 File Offset: 0x001FFC30
		protected void SetPos()
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible();
			if (flag)
			{
				int type = 103;
				ChatOpen.RowData yuyinRaw = specificDocument.GetYuyinRaw(type);
				base.uiBehaviour.transform.localPosition = new Vector3((float)yuyinRaw.radioX, (float)yuyinRaw.radioY, 0f);
			}
			else
			{
				bool fakeShow = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.fakeShow;
				if (fakeShow)
				{
					int type2 = 1;
					ChatOpen.RowData yuyinRaw2 = specificDocument.GetYuyinRaw(type2);
					base.uiBehaviour.transform.localPosition = new Vector3((float)yuyinRaw2.radioX, (float)yuyinRaw2.radioY, 0f);
				}
			}
		}

		// Token: 0x0600AD4D RID: 44365 RVA: 0x00201ADC File Offset: 0x001FFCDC
		public void Show(bool show)
		{
			if (show)
			{
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				bool flag = (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.fakeShow || DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible()) && specificDocument != null && specificDocument.GetValue(XOptionsDefine.OD_RADIO) == 1 && this.IsOpen;
				if (flag)
				{
					this.SetVisible(true, true);
					this.Refresh(this.radioDocument.roomState == XRadioDocument.BigRoomState.InRoom);
					this.UpdateHostInfo();
					this.SetPos();
				}
				else
				{
					this.SetVisible(false, true);
				}
			}
			else
			{
				this.SetVisible(false, true);
			}
		}

		// Token: 0x1700309C RID: 12444
		// (get) Token: 0x0600AD4E RID: 44366 RVA: 0x00201B78 File Offset: 0x001FFD78
		public bool IsOpen
		{
			get
			{
				this.open_level = XSingleton<XGlobalConfig>.singleton.GetInt("RadioOpen");
				XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
				return xplayerData != null && (ulong)xplayerData.Level >= (ulong)((long)this.open_level);
			}
		}

		// Token: 0x0600AD4F RID: 44367 RVA: 0x00201BC4 File Offset: 0x001FFDC4
		public void Process(bool open)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage != null && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.Show(open);
				bool flag2 = !open;
				if (flag2)
				{
					this.QuitRoom();
				}
			}
		}

		// Token: 0x0600AD50 RID: 44368 RVA: 0x00201C10 File Offset: 0x001FFE10
		public void Refresh(bool open)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				if (open)
				{
					bool flag2 = this.radioDocument.roomState == XRadioDocument.BigRoomState.InRoom;
					if (flag2)
					{
						base.uiBehaviour.m_lblMicro.SetText(XStringDefineProxy.GetString("RADIO_HOST") + ":  ");
						base.uiBehaviour.m_sprPlay.SetSprite("icon_pause");
					}
				}
				else
				{
					bool flag3 = this.radioDocument.roomState == XRadioDocument.BigRoomState.OutRoom || this.radioDocument.roomState == XRadioDocument.BigRoomState.Processing;
					if (flag3)
					{
						base.uiBehaviour.m_lblMicro.SetText(XStringDefineProxy.GetString("RADIO_LISTEN"));
						base.uiBehaviour.m_sprPlay.SetSprite("icon_play");
					}
				}
			}
		}

		// Token: 0x0600AD51 RID: 44369 RVA: 0x00201CDC File Offset: 0x001FFEDC
		public void JoinRoom()
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

		// Token: 0x0600AD52 RID: 44370 RVA: 0x00201D38 File Offset: 0x001FFF38
		public void QuitRoom()
		{
			bool flag = this.radioDocument.roomState == XRadioDocument.BigRoomState.InRoom;
			if (flag)
			{
				this.radioDocument.QuitBigRoom();
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_LEAVE_SUCCESS"), "fece00");
				this.Refresh(false);
			}
		}

		// Token: 0x0600AD53 RID: 44371 RVA: 0x00201D88 File Offset: 0x001FFF88
		public void UpdateHostInfo()
		{
			bool flag = base.IsVisible() && this.radioDocument.roomState == XRadioDocument.BigRoomState.InRoom;
			if (flag)
			{
				List<string> hostlist = this.radioDocument.hostlist;
				bool flag2 = hostlist.Count <= 0;
				if (flag2)
				{
					base.uiBehaviour.m_lblMicro.SetText(XStringDefineProxy.GetString("ERR_FM_NOANCHOR_STRING"));
				}
				else
				{
					XSingleton<XCommon>.singleton.CleanStringCombine();
					XSingleton<XCommon>.singleton.AppendString(XStringDefineProxy.GetString("RADIO_HOST"), ": ");
					for (int i = 0; i < hostlist.Count; i++)
					{
						XSingleton<XCommon>.singleton.AppendString(hostlist[i], " ");
					}
					base.uiBehaviour.m_lblMicro.SetText(XSingleton<XCommon>.singleton.GetString());
				}
			}
		}

		// Token: 0x0600AD54 RID: 44372 RVA: 0x00201E68 File Offset: 0x00200068
		private bool OnRadioClick(IXUIButton sp)
		{
			bool flag = this.radioDocument.roomState == XRadioDocument.BigRoomState.InRoom;
			if (flag)
			{
				this.QuitRoom();
			}
			else
			{
				bool flag2 = this.radioDocument.roomState == XRadioDocument.BigRoomState.Processing;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_CLICKTOOFAST"), "fece00");
				}
				else
				{
					bool flag3 = this.radioDocument.roomState == XRadioDocument.BigRoomState.OutRoom;
					if (flag3)
					{
						this.JoinRoom();
					}
				}
			}
			return true;
		}

		// Token: 0x0600AD55 RID: 44373 RVA: 0x00201EE4 File Offset: 0x002000E4
		private void OnMicroClick(IXUILabel lbl)
		{
			bool isHost = this.radioDocument.isHost;
			if (isHost)
			{
				bool flag = this.radioDocument.roomState == XRadioDocument.BigRoomState.InRoom;
				if (flag)
				{
					bool openSpeak = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager.openSpeak;
					XSingleton<XUpdater.XUpdater>.singleton.XApolloManager.openSpeak = !openSpeak;
					PtcC2M_HandleMicphone ptcC2M_HandleMicphone = new PtcC2M_HandleMicphone();
					bool openSpeak2 = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager.openSpeak;
					if (openSpeak2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_OPENMIC"), "fece00");
						ptcC2M_HandleMicphone.Data.param = true;
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_CLOSEMIC"), "fece00");
						ptcC2M_HandleMicphone.Data.param = false;
					}
					XSingleton<XClientNetwork>.singleton.Send(ptcC2M_HandleMicphone);
				}
			}
		}

		// Token: 0x04004147 RID: 16711
		private int open_level = 2;
	}
}
