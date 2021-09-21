using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009A9 RID: 2473
	public class XFriendsStaticData : XStaticDataBase<XFriendsStaticData>
	{
		// Token: 0x060095C8 RID: 38344 RVA: 0x00168218 File Offset: 0x00166418
		protected override void OnInit()
		{
			this.RefreshAddListCD = XSingleton<XGlobalConfig>.singleton.GetInt("FriendSystemRefreshAddListCD");
			this.SendGiftMinDegree = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("FriendSystemSendGiftMinDegree");
			this.SendGiftMaxTimes = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("FriendSystemSendGifMaxTimes");
			this.ReceiveGifMaxTimes = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("FriendSystemAcceptGifMaxTimes");
			this.MaxFriendlyEvaluation = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("FriendSystemMaxFriendlyEvaluation");
			this.CannotSendGiftToFriendHintText = XStringDefineProxy.GetString("FRIEND_CANNOT_SEND_GIFT_FMT", new object[]
			{
				this.SendGiftMinDegree
			});
			this.CommonCountTotalFmt = XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_FMT");
			this.CommonCountTotalNotEnoughFmt = XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_NOTENOUGH_FMT");
			this.CommonCountTotalEnoughFmt = XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_ENOUGH_FMT");
			this.GiftAlreadySentToFriendHintText = XStringDefineProxy.GetString("FRIEND_GIFT_ALREADY_SENT");
			this.GiftSuccessfullyReceiveHintText = XStringDefineProxy.GetString("FRIEND_RECEIVE_GIFT_HINT_FMT");
			this.GiftSuccessfullySentHintText = XStringDefineProxy.GetString("FRIEND_SEND_GIFT_HINT_FMT");
			this.Second = XStringDefineProxy.GetString("SECOND_DUARATION");
			this.Minute = XStringDefineProxy.GetString("MINUTE_DUARATION");
			this.Hour = XStringDefineProxy.GetString("HOUR_DUARATION");
			this.Day = XStringDefineProxy.GetString("DAY_DUARATION");
			this.Month = XStringDefineProxy.GetString("MONTH_DUARATION");
			this.Ago = XStringDefineProxy.GetString("AGO");
		}

		// Token: 0x060095C9 RID: 38345 RVA: 0x00168373 File Offset: 0x00166573
		public override void Uninit()
		{
			this.CommonCountTotalFmt = null;
			base.Uninit();
		}

		// Token: 0x040032CD RID: 13005
		public uint SendGiftMinDegree;

		// Token: 0x040032CE RID: 13006
		public uint SendGiftMaxTimes;

		// Token: 0x040032CF RID: 13007
		public uint ReceiveGifMaxTimes;

		// Token: 0x040032D0 RID: 13008
		public uint MaxFriendlyEvaluation;

		// Token: 0x040032D1 RID: 13009
		public int RefreshAddListCD;

		// Token: 0x040032D2 RID: 13010
		public string CommonCountTotalFmt;

		// Token: 0x040032D3 RID: 13011
		public string CommonCountTotalEnoughFmt;

		// Token: 0x040032D4 RID: 13012
		public string CommonCountTotalNotEnoughFmt;

		// Token: 0x040032D5 RID: 13013
		public string CannotSendGiftToFriendHintText;

		// Token: 0x040032D6 RID: 13014
		public string GiftAlreadySentToFriendHintText;

		// Token: 0x040032D7 RID: 13015
		public string GiftSuccessfullySentHintText;

		// Token: 0x040032D8 RID: 13016
		public string GiftSuccessfullyReceiveHintText;

		// Token: 0x040032D9 RID: 13017
		public string Second;

		// Token: 0x040032DA RID: 13018
		public string Minute;

		// Token: 0x040032DB RID: 13019
		public string Hour;

		// Token: 0x040032DC RID: 13020
		public string Day;

		// Token: 0x040032DD RID: 13021
		public string Month;

		// Token: 0x040032DE RID: 13022
		public string Ago;
	}
}
