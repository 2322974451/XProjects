using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RadioBattleDlg : DlgBase<RadioBattleDlg, RadioBattleBahaviour>
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
				return "Common/RadioBattleDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isMainUI
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

		protected override void Init()
		{
			base.Init();
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnRadio.RegisterClickEventHandler(new ButtonClickEventHandler(this.Toggle));
			base.uiBehaviour.m_btnOpen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OpenRadio));
			base.uiBehaviour.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.CloseRadio));
		}

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

		private int open_level = 2;
	}
}
