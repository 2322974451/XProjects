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

	internal class RadioDlg : DlgBase<RadioDlg, RadioBehaviour>
	{

		private XRadioDocument radioDocument
		{
			get
			{
				return XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			}
		}

		public override string fileName
		{
			get
			{
				return "Common/RadioDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.open_level = XSingleton<XGlobalConfig>.singleton.GetInt("RadioOpen");
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_lblMicro.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnMicroClick));
			base.uiBehaviour.m_btnRadio.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRadioClick));
		}

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

		public bool IsOpen
		{
			get
			{
				this.open_level = XSingleton<XGlobalConfig>.singleton.GetInt("RadioOpen");
				XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
				return xplayerData != null && (ulong)xplayerData.Level >= (ulong)((long)this.open_level);
			}
		}

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

		private int open_level = 2;
	}
}
