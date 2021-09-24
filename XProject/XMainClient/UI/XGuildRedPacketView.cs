using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildRedPacketView : DlgBase<XGuildRedPacketView, XGuildRedPacketBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildRedPacketDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			this._Doc.GuildRedPacketView = this;
			this._MainDoc = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Empty.SetActive(false);
			this._Doc.bHasShowIconRedPacket = 0;
			this._Doc.ReqList();
			base.uiBehaviour.m_ScrollView.ResetPosition();
			this.m_ClickedRP = null;
		}

		protected override void OnHide()
		{
			base.OnHide();
			this._MainDoc.SetBlockItemsChange(false);
		}

		protected override void OnUnload()
		{
			this._Doc.GuildRedPacketView = null;
			this._MainDoc.SetBlockItemsChange(false);
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			for (int i = 0; i < this.m_LeftTimeList.Count; i++)
			{
				this.m_LeftTimeList[i].Update();
			}
		}

		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildRedPacket);
			return true;
		}

		public void Refresh(bool bResetPosition = true)
		{
			List<XGuildRedPacketBrief> packetList = this._Doc.PacketList;
			int count = packetList.Count;
			base.uiBehaviour.m_WrapContent.SetContentCount(count, false);
			if (bResetPosition)
			{
				base.uiBehaviour.m_ScrollView.ResetPosition();
			}
			base.uiBehaviour.m_Empty.SetActive(count == 0);
		}

		private void _WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._Doc.PacketList.Count;
			if (!flag)
			{
				XGuildRedPacketBrief xguildRedPacketBrief = this._Doc.PacketList[index];
				IXUISprite ixuisprite = t.FindChild("RedPacket").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("Count").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = t.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite3 = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite4 = t.FindChild("Title").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = (ulong)((long)index);
				bool flag2 = xguildRedPacketBrief.itemid == 7;
				if (flag2)
				{
					ixuisprite.SetSprite(XGuildRedPacketView.RedPacketBg[1]);
				}
				else
				{
					ixuisprite.SetSprite(XGuildRedPacketView.RedPacketBg[0]);
				}
				ixuisprite4.SetSprite("gh_hb_word_" + xguildRedPacketBrief.itemid);
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnRedPacketClick));
				ixuilabel.SetText(xguildRedPacketBrief.senderName);
				ixuilabel2.SetText(string.Format("{0}/{1}", xguildRedPacketBrief.maxCount - xguildRedPacketBrief.fetchedCount, xguildRedPacketBrief.maxCount));
				ixuisprite3.SetSprite(XBagDocument.GetItemSmallIcon(xguildRedPacketBrief.itemid, 0U));
				this._SetupState(t, xguildRedPacketBrief);
			}
		}

		private void _SetupState(Transform t, XGuildRedPacketBrief data)
		{
			IXUILabel ixuilabel = t.FindChild("LeftTime").GetComponent("XUILabel") as IXUILabel;
			Transform transform = t.FindChild("State/CanFetch");
			Transform transform2 = t.FindChild("State/CantFetch");
			Transform transform3 = t.FindChild("State/Fetched");
			Transform transform4 = t.FindChild("State/Expired");
			Transform transform5 = t.FindChild("Icon/Highlight");
			Transform transform6 = t.FindChild("Icon/UI_ghhb_cd_02");
			transform5.gameObject.SetActive(data.fetchState == FetchState.FS_CAN_FETCH);
			transform6.gameObject.SetActive(data.fetchState == FetchState.FS_CAN_FETCH);
			float time = Time.time;
			transform2.gameObject.SetActive(data.fetchState == FetchState.FS_FETCHED);
			transform.gameObject.SetActive(data.fetchState == FetchState.FS_CAN_FETCH && time < data.endTime);
			transform3.gameObject.SetActive(data.fetchState == FetchState.FS_ALREADY_FETCH);
			transform4.gameObject.SetActive(data.fetchState == FetchState.FS_CAN_FETCH && time >= data.endTime);
			bool flag = time < data.endTime;
			if (flag)
			{
				XLeftTimeCounter xleftTimeCounter = null;
				bool flag2 = !this.m_ActivePackets.TryGetValue(t, out xleftTimeCounter);
				if (flag2)
				{
					xleftTimeCounter = new XLeftTimeCounter(ixuilabel, false);
					this.m_ActivePackets.Add(t, xleftTimeCounter);
					this.m_LeftTimeList.Add(xleftTimeCounter);
				}
				xleftTimeCounter.SetLeftTime(data.endTime - time, -1);
				xleftTimeCounter.SetFinishEventHandler(new TimeOverFinishEventHandler(this._OnLeftTimeOver), null);
				ixuilabel.SetVisible(true);
			}
			else
			{
				ixuilabel.SetVisible(false);
			}
		}

		public void ShowResult(XGuildRedPacketBrief brief)
		{
			bool flag = brief == null;
			if (flag)
			{
				this.m_ClickedRP = null;
				this._MainDoc.SetBlockItemsChange(false);
			}
			else
			{
				bool flag2 = this.m_ClickedRP == null;
				if (flag2)
				{
					this._MainDoc.SetBlockItemsChange(false);
					this.m_ClickedRP = null;
				}
				else
				{
					this.m_ClickedRP = null;
				}
			}
		}

		private void _OnLeftTimeOver(object o)
		{
			base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
			this._Doc.ReqList();
		}

		private void _OnRedPacketClick(IXUISprite iSp)
		{
			bool flag = this.m_ClickedRP != null;
			if (!flag)
			{
				XGuildRedPacketBrief xguildRedPacketBrief = this._Doc.PacketList[(int)iSp.ID];
				bool flag2 = xguildRedPacketBrief.fetchState == FetchState.FS_CAN_FETCH;
				if (flag2)
				{
					this._Doc.ReqFetch((uint)xguildRedPacketBrief.uid);
					this.m_ClickedRP = iSp;
				}
				else
				{
					bool flag3 = xguildRedPacketBrief.fetchState == FetchState.FS_CANNOT_FETCH;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_BONUS_NOTFETCH"), "fece00");
					}
					else
					{
						DlgBase<XGuildRedPacketDetailView, GuildRedPackageDetailBehaviour>.singleton.ShowEffect(false, (uint)xguildRedPacketBrief.uid);
					}
				}
			}
		}

		private static string[] RedPacketBg = new string[]
		{
			"gh_hb_ui1",
			"gh_hb_ui2"
		};

		private static Color[] OutterLightColor = new Color[]
		{
			new Color(0.8f, 0.6f, 0.2f),
			new Color(0.2f, 0.3f, 0.9f)
		};

		private XGuildRedPacketDocument _Doc;

		private XMainInterfaceDocument _MainDoc;

		private Dictionary<Transform, XLeftTimeCounter> m_ActivePackets = new Dictionary<Transform, XLeftTimeCounter>();

		private List<XLeftTimeCounter> m_LeftTimeList = new List<XLeftTimeCounter>();

		private IXUISprite m_ClickedRP = null;
	}
}
