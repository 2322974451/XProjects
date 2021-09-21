using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000977 RID: 2423
	internal class XGuildQualifierDocument : XDocComponent
	{
		// Token: 0x17002C80 RID: 11392
		// (get) Token: 0x060091F4 RID: 37364 RVA: 0x00150080 File Offset: 0x0014E280
		public override uint ID
		{
			get
			{
				return XGuildQualifierDocument.uuID;
			}
		}

		// Token: 0x060091F5 RID: 37365 RVA: 0x00150098 File Offset: 0x0014E298
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.m_sendState = false;
			bool flag = DlgBase<GuildQualifierDlg, GuildQualifierBehavior>.singleton.IsVisible();
			if (flag)
			{
				this.SendSelectQualifierList();
			}
		}

		// Token: 0x17002C81 RID: 11393
		// (get) Token: 0x060091F6 RID: 37366 RVA: 0x001500C4 File Offset: 0x0014E2C4
		public bool ServerActive
		{
			get
			{
				return this.m_ServerActive;
			}
		}

		// Token: 0x17002C82 RID: 11394
		// (get) Token: 0x060091F7 RID: 37367 RVA: 0x001500DC File Offset: 0x0014E2DC
		public double ActiveTime
		{
			get
			{
				return this.m_activeTime;
			}
		}

		// Token: 0x060091F8 RID: 37368 RVA: 0x001500F4 File Offset: 0x0014E2F4
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

		// Token: 0x060091F9 RID: 37369 RVA: 0x00150138 File Offset: 0x0014E338
		public uint GetLastRewardCount()
		{
			return this.m_lastRewardCount;
		}

		// Token: 0x17002C83 RID: 11395
		// (get) Token: 0x060091FA RID: 37370 RVA: 0x00150150 File Offset: 0x0014E350
		// (set) Token: 0x060091FB RID: 37371 RVA: 0x00150168 File Offset: 0x0014E368
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

		// Token: 0x17002C84 RID: 11396
		// (get) Token: 0x060091FD RID: 37373 RVA: 0x001501A9 File Offset: 0x0014E3A9
		// (set) Token: 0x060091FC RID: 37372 RVA: 0x001501A0 File Offset: 0x0014E3A0
		public GuildQualifierDlg QualifierView { get; set; }

		// Token: 0x17002C85 RID: 11397
		// (get) Token: 0x060091FF RID: 37375 RVA: 0x001501BC File Offset: 0x0014E3BC
		// (set) Token: 0x060091FE RID: 37374 RVA: 0x001501B1 File Offset: 0x0014E3B1
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

		// Token: 0x06009200 RID: 37376 RVA: 0x001501D4 File Offset: 0x0014E3D4
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildQualifierDocument.AsyncLoader.AddTask("Table/GuildPkRankReward", XGuildQualifierDocument.m_GuildPKRankRewardTable, false);
			XGuildQualifierDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009201 RID: 37377 RVA: 0x001501FC File Offset: 0x0014E3FC
		public static bool TryGetRankReward(int index, out GuildPkRankReward.RowData rewardData)
		{
			rewardData = XGuildQualifierDocument.m_GuildPKRankRewardTable.GetByrank((uint)index);
			return rewardData != null;
		}

		// Token: 0x17002C86 RID: 11398
		// (get) Token: 0x06009202 RID: 37378 RVA: 0x00150220 File Offset: 0x0014E420
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

		// Token: 0x06009203 RID: 37379 RVA: 0x00150308 File Offset: 0x0014E508
		private int RankSortCompare(GuildLadderRoleRank r1, GuildLadderRoleRank r2)
		{
			return (int)(r2.wintimes - r1.wintimes);
		}

		// Token: 0x06009204 RID: 37380 RVA: 0x00150328 File Offset: 0x0014E528
		public bool TryGetGuildIcon(ulong guildID, out uint guildIcon)
		{
			return this.m_GuildIconDic.TryGetValue(guildID, out guildIcon);
		}

		// Token: 0x17002C87 RID: 11399
		// (get) Token: 0x06009205 RID: 37381 RVA: 0x00150348 File Offset: 0x0014E548
		public List<GuildLadderRank> GuildRankList
		{
			get
			{
				return this.m_GuildRankList;
			}
		}

		// Token: 0x06009206 RID: 37382 RVA: 0x00150360 File Offset: 0x0014E560
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

		// Token: 0x06009207 RID: 37383 RVA: 0x001504A4 File Offset: 0x0014E6A4
		public void SendSelectQualifierList()
		{
			RpcC2M_ReqGuildLadderInfo rpcC2M_ReqGuildLadderInfo = new RpcC2M_ReqGuildLadderInfo();
			rpcC2M_ReqGuildLadderInfo.oArg.roleId = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ReqGuildLadderInfo);
		}

		// Token: 0x06009208 RID: 37384 RVA: 0x001504E0 File Offset: 0x0014E6E0
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

		// Token: 0x06009209 RID: 37385 RVA: 0x001505A4 File Offset: 0x0014E7A4
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

		// Token: 0x0600920A RID: 37386 RVA: 0x00150634 File Offset: 0x0014E834
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

		// Token: 0x0600920B RID: 37387 RVA: 0x00150684 File Offset: 0x0014E884
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

		// Token: 0x040030A5 RID: 12453
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildQualifierDocument");

		// Token: 0x040030A6 RID: 12454
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040030A7 RID: 12455
		public static GuildPkRankReward m_GuildPKRankRewardTable = new GuildPkRankReward();

		// Token: 0x040030A8 RID: 12456
		private List<GuildLadderRank> m_GuildRankList;

		// Token: 0x040030A9 RID: 12457
		private List<GuildLadderRoleRank> m_GuildRoleRankList;

		// Token: 0x040030AA RID: 12458
		private List<GuildLadderRoleRank> m_SelectRoleRankList = new List<GuildLadderRoleRank>();

		// Token: 0x040030AB RID: 12459
		private Dictionary<ulong, uint> m_GuildIconDic = new Dictionary<ulong, uint>();

		// Token: 0x040030AC RID: 12460
		private GuildQualifierSelect m_qualifierSelect = GuildQualifierSelect.ALL;

		// Token: 0x040030AD RID: 12461
		private uint m_lastRewardCount = 3U;

		// Token: 0x040030AE RID: 12462
		private bool m_sendState = false;

		// Token: 0x040030AF RID: 12463
		private double m_ServerTime = 0.0;

		// Token: 0x040030B0 RID: 12464
		private double m_activeTime = 0.0;

		// Token: 0x040030B1 RID: 12465
		private bool m_ServerActive = false;

		// Token: 0x040030B2 RID: 12466
		private bool m_bHasAvailableLadderIcon;
	}
}
