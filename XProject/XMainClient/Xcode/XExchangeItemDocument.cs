using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XExchangeItemDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XExchangeItemDocument.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void QuerySelectItem(ulong uid)
		{
			RpcC2G_GuildCampExchangeOperate rpcC2G_GuildCampExchangeOperate = new RpcC2G_GuildCampExchangeOperate();
			rpcC2G_GuildCampExchangeOperate.oArg.operate_type = ((uid == 0UL) ? GuildCampItemOperate.SWINGDOWNITEM : GuildCampItemOperate.SWINGUPITEM);
			rpcC2G_GuildCampExchangeOperate.oArg.item_uid = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GuildCampExchangeOperate);
		}

		public void QueryEnsureExchange(bool state)
		{
			RpcC2G_GuildCampExchangeOperate rpcC2G_GuildCampExchangeOperate = new RpcC2G_GuildCampExchangeOperate();
			rpcC2G_GuildCampExchangeOperate.oArg.operate_type = GuildCampItemOperate.CONFIRM;
			rpcC2G_GuildCampExchangeOperate.oArg.confirm = state;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GuildCampExchangeOperate);
		}

		public void QueryCloseUI()
		{
			RpcC2G_GuildCampExchangeOperate rpcC2G_GuildCampExchangeOperate = new RpcC2G_GuildCampExchangeOperate();
			rpcC2G_GuildCampExchangeOperate.oArg.operate_type = GuildCampItemOperate.CANCEL;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GuildCampExchangeOperate);
		}

		public void Init(ItemType type, string name, uint prof)
		{
			this.MyAudioID = 0UL;
			this.MyAudioTime = 0U;
			this.MyInputText = "";
			this.OtherAudioID = 0UL;
			this.OtherAudioTime = 0U;
			this.OtherInputText = "";
			this.CurrentSelectUid = 0UL;
			this.OtherSelectId = 0;
			this.MyEnsureState = false;
			this.OtherEnsureState = false;
			this.TipsState = 0;
			this.ExchangeType = XFastEnumIntEqualityComparer<ItemType>.ToInt(type);
			this.ExchangeItemStr = XStringDefineProxy.GetString(string.Format("ExchangeType_{0}", this.ExchangeType));
			DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>.singleton.InitShow(name, prof);
		}

		public void OnServerDataGet(GuildCampPartyTradeNotifyArg data)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			if (!flag)
			{
				bool flag2 = data.open_trade && data.lauch_role_id != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID && data.target_role_id != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("message error. 2 roleid not me. id :", data.lauch_role_id.ToString(), " --- ", data.target_role_id.ToString(), null, null);
				}
				else
				{
					bool flag3 = this.ExchangeState != data.open_trade;
					if (flag3)
					{
						this.ExchangeState = data.open_trade;
						bool exchangeState = this.ExchangeState;
						if (exchangeState)
						{
							bool flag4 = data.lauch_role_id == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
							if (flag4)
							{
								this.Init(ItemType.GuildCollectCard, data.target_name, data.target_profession);
							}
							else
							{
								this.Init(ItemType.GuildCollectCard, data.lauch_name, data.lauch_profession);
							}
						}
						else
						{
							DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>.singleton.SetVisible(false, true);
						}
					}
					bool exchangeState2 = this.ExchangeState;
					if (exchangeState2)
					{
						bool flag5 = data.lauch_role_id == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (flag5)
						{
							this.OnStateChange(data.lauch_item_uid, (int)data.target_item_id, data.lauch_confirm, data.target_confirm, data.lauch_chat_info, data.target_chat_info);
						}
						else
						{
							this.OnStateChange(data.target_item_uid, (int)data.lauch_item_id, data.target_confirm, data.lauch_confirm, data.target_chat_info, data.lauch_chat_info);
						}
					}
				}
			}
		}

		public void OnStateChange(ulong mySelect, int otherSelect, bool myEnsureState, bool otherEnsureState, GuildCampChatInfo myAudio, GuildCampChatInfo otherAudio)
		{
			bool flag = false;
			bool flag2 = !DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>.singleton.IsVisible();
			if (!flag2)
			{
				bool flag3 = mySelect != this.CurrentSelectUid;
				if (flag3)
				{
					this.CurrentSelectUid = mySelect;
					DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>.singleton.OnMySelectChange(this.CurrentSelectUid);
					DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>.singleton.RefreshMyItemList();
				}
				bool flag4 = otherSelect != this.OtherSelectId;
				if (flag4)
				{
					this.OtherSelectId = otherSelect;
					DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>.singleton.OnOtherSelectChange(this.OtherSelectId);
					bool myEnsureState2 = this.MyEnsureState;
					if (myEnsureState2)
					{
						flag = true;
					}
				}
				bool flag5 = myEnsureState != this.MyEnsureState || otherEnsureState != this.OtherEnsureState;
				if (flag5)
				{
					this.MyEnsureState = myEnsureState;
					this.OtherEnsureState = otherEnsureState;
					DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>.singleton.OnEnsureStateChange();
				}
				bool flag6 = myAudio != null && (this.MyAudioID != myAudio.audio_id || this.MyInputText != myAudio.chat_text);
				if (flag6)
				{
					this.MyAudioID = myAudio.audio_id;
					this.MyInputText = myAudio.chat_text;
					this.MyAudioTime = myAudio.audio_time;
					DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>.singleton.RefreshMyChat();
				}
				bool flag7 = otherAudio != null && (this.OtherAudioID != otherAudio.audio_id || this.OtherInputText != otherAudio.chat_text);
				if (flag7)
				{
					this.OtherAudioID = otherAudio.audio_id;
					this.OtherInputText = otherAudio.chat_text;
					this.OtherAudioTime = otherAudio.audio_time;
					DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>.singleton.RefreshOtherChat();
				}
				bool flag8 = flag;
				if (flag8)
				{
					this.TipsState = 2;
				}
				else
				{
					bool myEnsureState3 = this.MyEnsureState;
					if (myEnsureState3)
					{
						this.TipsState = 3;
					}
					else
					{
						bool flag9 = this.CurrentSelectUid == 0UL;
						if (flag9)
						{
							this.TipsState = 0;
						}
						else
						{
							this.TipsState = 1;
						}
					}
				}
				DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>.singleton.OnTipsChange();
			}
		}

		public void SendChat(string ans, ulong audioID, uint audioTime)
		{
			bool flag = audioID == 0UL && ans.Length == 0;
			if (!flag)
			{
				RpcC2G_GuildCampExchangeOperate rpcC2G_GuildCampExchangeOperate = new RpcC2G_GuildCampExchangeOperate();
				rpcC2G_GuildCampExchangeOperate.oArg.operate_type = ((audioID == 0UL) ? GuildCampItemOperate.TEXTCHAT : GuildCampItemOperate.AUDIOCHAT);
				rpcC2G_GuildCampExchangeOperate.oArg.audio_id = audioID;
				rpcC2G_GuildCampExchangeOperate.oArg.chat_text = ans;
				rpcC2G_GuildCampExchangeOperate.oArg.audio_time = audioTime;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GuildCampExchangeOperate);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ExchangeItemDocument");

		public List<XItem> ItemList = new List<XItem>();

		public ulong CurrentSelectUid;

		public int OtherSelectId;

		public bool MyEnsureState;

		public bool OtherEnsureState;

		public ulong MyAudioID;

		public uint MyAudioTime;

		public string MyInputText;

		public ulong OtherAudioID;

		public uint OtherAudioTime;

		public string OtherInputText;

		public int TipsState;

		public int ExchangeType;

		public string ExchangeItemStr;

		public bool ExchangeState = false;
	}
}
