using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200189D RID: 6301
	internal class XGuildRedPacketView : DlgBase<XGuildRedPacketView, XGuildRedPacketBehaviour>
	{
		// Token: 0x170039F6 RID: 14838
		// (get) Token: 0x0601067E RID: 67198 RVA: 0x0040079C File Offset: 0x003FE99C
		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildRedPacketDlg";
			}
		}

		// Token: 0x170039F7 RID: 14839
		// (get) Token: 0x0601067F RID: 67199 RVA: 0x004007B4 File Offset: 0x003FE9B4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039F8 RID: 14840
		// (get) Token: 0x06010680 RID: 67200 RVA: 0x004007C8 File Offset: 0x003FE9C8
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039F9 RID: 14841
		// (get) Token: 0x06010681 RID: 67201 RVA: 0x004007DC File Offset: 0x003FE9DC
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039FA RID: 14842
		// (get) Token: 0x06010682 RID: 67202 RVA: 0x004007F0 File Offset: 0x003FE9F0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039FB RID: 14843
		// (get) Token: 0x06010683 RID: 67203 RVA: 0x00400804 File Offset: 0x003FEA04
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010684 RID: 67204 RVA: 0x00400817 File Offset: 0x003FEA17
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			this._Doc.GuildRedPacketView = this;
			this._MainDoc = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
		}

		// Token: 0x06010685 RID: 67205 RVA: 0x00400850 File Offset: 0x003FEA50
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Empty.SetActive(false);
			this._Doc.bHasShowIconRedPacket = 0;
			this._Doc.ReqList();
			base.uiBehaviour.m_ScrollView.ResetPosition();
			this.m_ClickedRP = null;
		}

		// Token: 0x06010686 RID: 67206 RVA: 0x004008A8 File Offset: 0x003FEAA8
		protected override void OnHide()
		{
			base.OnHide();
			this._MainDoc.SetBlockItemsChange(false);
		}

		// Token: 0x06010687 RID: 67207 RVA: 0x004008BF File Offset: 0x003FEABF
		protected override void OnUnload()
		{
			this._Doc.GuildRedPacketView = null;
			this._MainDoc.SetBlockItemsChange(false);
			base.OnUnload();
		}

		// Token: 0x06010688 RID: 67208 RVA: 0x004008E4 File Offset: 0x003FEAE4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
		}

		// Token: 0x06010689 RID: 67209 RVA: 0x00400950 File Offset: 0x003FEB50
		public override void OnUpdate()
		{
			base.OnUpdate();
			for (int i = 0; i < this.m_LeftTimeList.Count; i++)
			{
				this.m_LeftTimeList[i].Update();
			}
		}

		// Token: 0x0601068A RID: 67210 RVA: 0x00400994 File Offset: 0x003FEB94
		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0601068B RID: 67211 RVA: 0x004009B0 File Offset: 0x003FEBB0
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildRedPacket);
			return true;
		}

		// Token: 0x0601068C RID: 67212 RVA: 0x004009D0 File Offset: 0x003FEBD0
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

		// Token: 0x0601068D RID: 67213 RVA: 0x00400A30 File Offset: 0x003FEC30
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

		// Token: 0x0601068E RID: 67214 RVA: 0x00400BE0 File Offset: 0x003FEDE0
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

		// Token: 0x0601068F RID: 67215 RVA: 0x00400D84 File Offset: 0x003FEF84
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

		// Token: 0x06010690 RID: 67216 RVA: 0x00400DDC File Offset: 0x003FEFDC
		private void _OnLeftTimeOver(object o)
		{
			base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
			this._Doc.ReqList();
		}

		// Token: 0x06010691 RID: 67217 RVA: 0x00400DFC File Offset: 0x003FEFFC
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

		// Token: 0x04007668 RID: 30312
		private static string[] RedPacketBg = new string[]
		{
			"gh_hb_ui1",
			"gh_hb_ui2"
		};

		// Token: 0x04007669 RID: 30313
		private static Color[] OutterLightColor = new Color[]
		{
			new Color(0.8f, 0.6f, 0.2f),
			new Color(0.2f, 0.3f, 0.9f)
		};

		// Token: 0x0400766A RID: 30314
		private XGuildRedPacketDocument _Doc;

		// Token: 0x0400766B RID: 30315
		private XMainInterfaceDocument _MainDoc;

		// Token: 0x0400766C RID: 30316
		private Dictionary<Transform, XLeftTimeCounter> m_ActivePackets = new Dictionary<Transform, XLeftTimeCounter>();

		// Token: 0x0400766D RID: 30317
		private List<XLeftTimeCounter> m_LeftTimeList = new List<XLeftTimeCounter>();

		// Token: 0x0400766E RID: 30318
		private IXUISprite m_ClickedRP = null;
	}
}
