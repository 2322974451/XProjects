using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	public class ChatInfo : LoopItemData
	{

		public bool isPlayOver()
		{
			bool flag = this.autoStartPlayTime == 0f;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = Time.realtimeSinceStartup - this.autoStartPlayTime > (float)this.AudioIntTime;
				result = flag2;
			}
			return result;
		}

		public ChatVoiceInfo GetVoice(ulong audid, uint aulen)
		{
			bool flag = audid <= 0UL;
			ChatVoiceInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new ChatVoiceInfo
				{
					voiceTime = (int)aulen,
					txt = this.mContent
				};
			}
			return result;
		}

		public string GetChannelName()
		{
			return "";
		}

		public bool isAudioChat
		{
			get
			{
				return this.mAudioId > 0UL;
			}
		}

		public string AudioUrl
		{
			get
			{
				bool flag = this.url == "";
				if (flag)
				{
					string[] array = this.mContent.Split(new char[]
					{
						'#'
					});
					bool flag2 = array.Length >= 5;
					if (flag2)
					{
						this.url = array[2];
						this.time = array[3];
						this.tag = int.Parse(array[4]);
					}
					else
					{
						this.url = "";
						this.time = "0";
						this.tag = 0;
					}
				}
				return this.url;
			}
		}

		public int AudioIntTime
		{
			get
			{
				return (int)this.mAudioTime;
			}
		}

		private int tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				bool flag = value > 0;
				if (flag)
				{
					this._tag = value;
				}
			}
		}

		public void SetAudioText(string text)
		{
			this.mContent = text;
			bool flag = DlgBase<XChatView, XChatBehaviour>.singleton.activeChannelType != this.mChannelId;
			if (!flag)
			{
				IXUILabelSymbol ixuilabelSymbol = this.mUIObject.transform.FindChild("voice/content").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				ixuilabelSymbol.InputText = text;
			}
		}

		public bool isAutoPlaying = false;

		public float autoStartPlayTime = 0f;

		public int id;

		public ChatChannelType mChannelId;

		public ulong mSenderId;

		public int mSenderTeamId = 0;

		public bool isFriend = false;

		public bool isSelfSender;

		public string mSenderName;

		public string mContent;

		public ulong mReceiverId = 0UL;

		public string mReceiverName = "test";

		public bool mRegression = false;

		public uint CampDuelID = 0U;

		public ChatType mChatType;

		public GameObject mUIObject;

		public uint mSenderVip;

		public uint mSenderPaymemberid;

		public uint mReceiverVip = 1U;

		public uint mServerProfession;

		public uint mRecieverProfession = 1U;

		public uint mSenderPowerPoint;

		public uint mReciverPowerPoint = 100U;

		public bool isAudioPlayed = false;

		public bool isUIShowed = false;

		public DateTime mTime = DateTime.Now;

		public ulong mAudioId = 0UL;

		public uint mAudioTime = 0U;

		public uint mHeroID = 0U;

		public GroupChatTeamInfo group;

		public uint mCoverDesignationID;

		public string mSpecialDesignation;

		public uint militaryRank;

		public PayConsume payConsume;

		public ChatVoiceInfo voice = null;

		private string url = "";

		private string time = "";

		private int _tag = 0;

		public byte[] AudioData;
	}
}
