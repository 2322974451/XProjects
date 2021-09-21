using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E1D RID: 3613
	public class ChatInfo : LoopItemData
	{
		// Token: 0x0600C234 RID: 49716 RVA: 0x0029BA20 File Offset: 0x00299C20
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

		// Token: 0x0600C235 RID: 49717 RVA: 0x0029BA68 File Offset: 0x00299C68
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

		// Token: 0x0600C236 RID: 49718 RVA: 0x0029BAA8 File Offset: 0x00299CA8
		public string GetChannelName()
		{
			return "";
		}

		// Token: 0x17003408 RID: 13320
		// (get) Token: 0x0600C237 RID: 49719 RVA: 0x0029BAC0 File Offset: 0x00299CC0
		public bool isAudioChat
		{
			get
			{
				return this.mAudioId > 0UL;
			}
		}

		// Token: 0x17003409 RID: 13321
		// (get) Token: 0x0600C238 RID: 49720 RVA: 0x0029BADC File Offset: 0x00299CDC
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

		// Token: 0x1700340A RID: 13322
		// (get) Token: 0x0600C239 RID: 49721 RVA: 0x0029BB74 File Offset: 0x00299D74
		public int AudioIntTime
		{
			get
			{
				return (int)this.mAudioTime;
			}
		}

		// Token: 0x1700340B RID: 13323
		// (get) Token: 0x0600C23A RID: 49722 RVA: 0x0029BB8C File Offset: 0x00299D8C
		// (set) Token: 0x0600C23B RID: 49723 RVA: 0x0029BBA4 File Offset: 0x00299DA4
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

		// Token: 0x0600C23C RID: 49724 RVA: 0x0029BBC4 File Offset: 0x00299DC4
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

		// Token: 0x0400531F RID: 21279
		public bool isAutoPlaying = false;

		// Token: 0x04005320 RID: 21280
		public float autoStartPlayTime = 0f;

		// Token: 0x04005321 RID: 21281
		public int id;

		// Token: 0x04005322 RID: 21282
		public ChatChannelType mChannelId;

		// Token: 0x04005323 RID: 21283
		public ulong mSenderId;

		// Token: 0x04005324 RID: 21284
		public int mSenderTeamId = 0;

		// Token: 0x04005325 RID: 21285
		public bool isFriend = false;

		// Token: 0x04005326 RID: 21286
		public bool isSelfSender;

		// Token: 0x04005327 RID: 21287
		public string mSenderName;

		// Token: 0x04005328 RID: 21288
		public string mContent;

		// Token: 0x04005329 RID: 21289
		public ulong mReceiverId = 0UL;

		// Token: 0x0400532A RID: 21290
		public string mReceiverName = "test";

		// Token: 0x0400532B RID: 21291
		public bool mRegression = false;

		// Token: 0x0400532C RID: 21292
		public uint CampDuelID = 0U;

		// Token: 0x0400532D RID: 21293
		public ChatType mChatType;

		// Token: 0x0400532E RID: 21294
		public GameObject mUIObject;

		// Token: 0x0400532F RID: 21295
		public uint mSenderVip;

		// Token: 0x04005330 RID: 21296
		public uint mSenderPaymemberid;

		// Token: 0x04005331 RID: 21297
		public uint mReceiverVip = 1U;

		// Token: 0x04005332 RID: 21298
		public uint mServerProfession;

		// Token: 0x04005333 RID: 21299
		public uint mRecieverProfession = 1U;

		// Token: 0x04005334 RID: 21300
		public uint mSenderPowerPoint;

		// Token: 0x04005335 RID: 21301
		public uint mReciverPowerPoint = 100U;

		// Token: 0x04005336 RID: 21302
		public bool isAudioPlayed = false;

		// Token: 0x04005337 RID: 21303
		public bool isUIShowed = false;

		// Token: 0x04005338 RID: 21304
		public DateTime mTime = DateTime.Now;

		// Token: 0x04005339 RID: 21305
		public ulong mAudioId = 0UL;

		// Token: 0x0400533A RID: 21306
		public uint mAudioTime = 0U;

		// Token: 0x0400533B RID: 21307
		public uint mHeroID = 0U;

		// Token: 0x0400533C RID: 21308
		public GroupChatTeamInfo group;

		// Token: 0x0400533D RID: 21309
		public uint mCoverDesignationID;

		// Token: 0x0400533E RID: 21310
		public string mSpecialDesignation;

		// Token: 0x0400533F RID: 21311
		public uint militaryRank;

		// Token: 0x04005340 RID: 21312
		public PayConsume payConsume;

		// Token: 0x04005341 RID: 21313
		public ChatVoiceInfo voice = null;

		// Token: 0x04005342 RID: 21314
		private string url = "";

		// Token: 0x04005343 RID: 21315
		private string time = "";

		// Token: 0x04005344 RID: 21316
		private int _tag = 0;

		// Token: 0x04005345 RID: 21317
		public byte[] AudioData;
	}
}
