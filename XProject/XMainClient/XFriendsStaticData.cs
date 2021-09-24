using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class XFriendsStaticData : XStaticDataBase<XFriendsStaticData>
	{

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

		public override void Uninit()
		{
			this.CommonCountTotalFmt = null;
			base.Uninit();
		}

		public uint SendGiftMinDegree;

		public uint SendGiftMaxTimes;

		public uint ReceiveGifMaxTimes;

		public uint MaxFriendlyEvaluation;

		public int RefreshAddListCD;

		public string CommonCountTotalFmt;

		public string CommonCountTotalEnoughFmt;

		public string CommonCountTotalNotEnoughFmt;

		public string CannotSendGiftToFriendHintText;

		public string GiftAlreadySentToFriendHintText;

		public string GiftSuccessfullySentHintText;

		public string GiftSuccessfullyReceiveHintText;

		public string Second;

		public string Minute;

		public string Hour;

		public string Day;

		public string Month;

		public string Ago;
	}
}
