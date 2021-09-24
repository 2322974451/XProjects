using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildQualifierDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildQualifierDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.m_sendState = false;
			bool flag = DlgBase<GuildQualifierDlg, GuildQualifierBehavior>.singleton.IsVisible();
			if (flag)
			{
				this.SendSelectQualifierList();
			}
		}

		public bool ServerActive
		{
			get
			{
				return this.m_ServerActive;
			}
		}

		public double ActiveTime
		{
			get
			{
				return this.m_activeTime;
			}
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this.m_activeTime > (double)fDeltaT;
			if (flag)
			{
				this.m_activeTime -= (double)fDeltaT;
			}
			else
			{
				this.m_activeTime = 0.0;
			}
		}

		public uint GetLastRewardCount()
		{
			return this.m_lastRewardCount;
		}

		public bool bHasAvailableLadderIcon
		{
			get
			{
				return this.m_bHasAvailableLadderIcon;
			}
			set
			{
				bool flag = this.m_bHasAvailableLadderIcon != value;
				if (flag)
				{
					this.m_bHasAvailableLadderIcon = value;
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildQualifier, true);
				}
			}
		}

		public GuildQualifierDlg QualifierView { get; set; }

		public GuildQualifierSelect Select
		{
			get
			{
				return this.m_qualifierSelect;
			}
			set
			{
				this.m_qualifierSelect = value;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildQualifierDocument.AsyncLoader.AddTask("Table/GuildPkRankReward", XGuildQualifierDocument.m_GuildPKRankRewardTable, false);
			XGuildQualifierDocument.AsyncLoader.Execute(callback);
		}

		public static bool TryGetRankReward(int index, out GuildPkRankReward.RowData rewardData)
		{
			rewardData = XGuildQualifierDocument.m_GuildPKRankRewardTable.GetByrank((uint)index);
			return rewardData != null;
		}

		public List<GuildLadderRoleRank> GuildRoleRankList
		{
			get
			{
				this.m_SelectRoleRankList.Clear();
				bool flag = this.m_GuildRoleRankList != null;
				if (flag)
				{
					bool flag2 = this.Select == GuildQualifierSelect.SELF;
					if (flag2)
					{
						XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
						ulong uid = specificDocument.BasicData.uid;
						int i = 0;
						int count = this.m_GuildRoleRankList.Count;
						while (i < count)
						{
							bool flag3 = this.m_GuildRoleRankList[i].guildid == uid;
							if (flag3)
							{
								this.m_SelectRoleRankList.Add(this.m_GuildRoleRankList[i]);
							}
							i++;
						}
					}
					else
					{
						this.m_SelectRoleRankList.AddRange(this.m_GuildRoleRankList);
					}
					this.m_SelectRoleRankList.Sort(new Comparison<GuildLadderRoleRank>(this.RankSortCompare));
				}
				return this.m_SelectRoleRankList;
			}
		}

		private int RankSortCompare(GuildLadderRoleRank r1, GuildLadderRoleRank r2)
		{
			return (int)(r2.wintimes - r1.wintimes);
		}

		public bool TryGetGuildIcon(ulong guildID, out uint guildIcon)
		{
			return this.m_GuildIconDic.TryGetValue(guildID, out guildIcon);
		}

		public List<GuildLadderRank> GuildRankList
		{
			get
			{
				return this.m_GuildRankList;
			}
		}

		public bool CheckActive()
		{
			bool flag = this.m_ServerTime <= 0.0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				DateTime dateTime = XSingleton<UiUtility>.singleton.TimeNow(this.m_ServerTime, true);
				int num = dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second;
				XSingleton<XDebug>.singleton.AddGreenLog(XSingleton<XCommon>.singleton.StringCombine("ServerTime:", num.ToString()), null, null, null, null, null);
				SeqList<int> sequence3List = XSingleton<XGlobalConfig>.singleton.GetSequence3List("GuildLadderTime", true);
				int i = 0;
				int count = (int)sequence3List.Count;
				while (i < count)
				{
					int num2 = sequence3List[i, 0];
					int num3 = sequence3List[i, 1];
					int num4 = sequence3List[i, 2];
					bool flag2 = XFastEnumIntEqualityComparer<DayOfWeek>.ToInt(dateTime.DayOfWeek) == num2;
					if (flag2)
					{
						int num5 = num3 / 100 * 3600 + num3 % 100 * 60;
						int num6 = num4 / 100 * 3600 + num4 % 100 * 60;
						bool flag3 = num >= num5 && num < num6;
						if (flag3)
						{
							return true;
						}
					}
					i++;
				}
				result = false;
			}
			return result;
		}

		public void SendSelectQualifierList()
		{
			RpcC2M_ReqGuildLadderInfo rpcC2M_ReqGuildLadderInfo = new RpcC2M_ReqGuildLadderInfo();
			rpcC2M_ReqGuildLadderInfo.oArg.roleId = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ReqGuildLadderInfo);
		}

		public void ReceiveSelectQualifierList(ReqGuildLadderInfoAgr oArg, ReqGuildLadderInfoRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				this.m_ServerActive = false;
			}
			else
			{
				this.m_ServerActive = true;
				this.m_activeTime = oRes.lastTime;
				this.m_lastRewardCount = oRes.lestRewardTimes;
				this.m_GuildRoleRankList = oRes.roleRanks;
				this.m_GuildRankList = oRes.guildRanks;
				this.m_ServerTime = oRes.nowTime;
				XSingleton<XDebug>.singleton.AddGreenLog("ServerTime:", XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)oRes.nowTime, "yyyy年MM月dd日HH点", true), null, null, null, null);
				this.SetGuildIconDic(this.m_GuildRankList);
			}
			bool flag2 = DlgBase<GuildQualifierDlg, GuildQualifierBehavior>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<GuildQualifierDlg, GuildQualifierBehavior>.singleton.RefreshData();
			}
		}

		private void SetGuildIconDic(List<GuildLadderRank> list)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				bool flag = this.m_GuildIconDic.ContainsKey(list[i].guildid);
				if (flag)
				{
					this.m_GuildIconDic[list[i].guildid] = list[i].icon;
				}
				else
				{
					this.m_GuildIconDic.Add(list[i].guildid, list[i].icon);
				}
				i++;
			}
		}

		public void SendGuildLadderRankInfo()
		{
			bool sendState = this.m_sendState;
			if (!sendState)
			{
				RpcC2M_ReqGuildLadderRnakInfo rpcC2M_ReqGuildLadderRnakInfo = new RpcC2M_ReqGuildLadderRnakInfo();
				rpcC2M_ReqGuildLadderRnakInfo.oArg.roleid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ReqGuildLadderRnakInfo);
				this.m_sendState = true;
			}
		}

		public void ReceiveGuildLandderRankList(ReqGuildLadderRnakInfoArg arg, ReqGuildLadderRnakInfoRes res)
		{
			this.m_sendState = false;
			bool flag = res.errorcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				this.m_activeTime = res.lastTime;
				this.m_ServerActive = true;
				this.m_GuildRankList = res.guildrank;
				this.SetGuildIconDic(this.m_GuildRankList);
			}
			else
			{
				bool flag2 = res.errorcode == ErrorCode.ERR_GUILD_LADDER_NOT_OPEN;
				if (!flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode, "fece00");
					return;
				}
				this.m_ServerActive = false;
			}
			bool flag3 = DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.RefreshGuildQualifier();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildQualifierDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static GuildPkRankReward m_GuildPKRankRewardTable = new GuildPkRankReward();

		private List<GuildLadderRank> m_GuildRankList;

		private List<GuildLadderRoleRank> m_GuildRoleRankList;

		private List<GuildLadderRoleRank> m_SelectRoleRankList = new List<GuildLadderRoleRank>();

		private Dictionary<ulong, uint> m_GuildIconDic = new Dictionary<ulong, uint>();

		private GuildQualifierSelect m_qualifierSelect = GuildQualifierSelect.ALL;

		private uint m_lastRewardCount = 3U;

		private bool m_sendState = false;

		private double m_ServerTime = 0.0;

		private double m_activeTime = 0.0;

		private bool m_ServerActive = false;

		private bool m_bHasAvailableLadderIcon;
	}
}
