using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009E8 RID: 2536
	internal class XLoginRewardDocument : XDocComponent
	{
		// Token: 0x17002E1F RID: 11807
		// (get) Token: 0x06009AFF RID: 39679 RVA: 0x00189DF0 File Offset: 0x00187FF0
		public override uint ID
		{
			get
			{
				return XLoginRewardDocument.uuID;
			}
		}

		// Token: 0x17002E20 RID: 11808
		// (get) Token: 0x06009B00 RID: 39680 RVA: 0x00189E08 File Offset: 0x00188008
		// (set) Token: 0x06009B01 RID: 39681 RVA: 0x00189E20 File Offset: 0x00188020
		public XLoginRewardView View
		{
			get
			{
				return this._LoginRewardView;
			}
			set
			{
				this._LoginRewardView = value;
			}
		}

		// Token: 0x17002E21 RID: 11809
		// (get) Token: 0x06009B02 RID: 39682 RVA: 0x00189E2C File Offset: 0x0018802C
		public uint DayChecked
		{
			get
			{
				return this._DayChecked;
			}
		}

		// Token: 0x17002E22 RID: 11810
		// (get) Token: 0x06009B03 RID: 39683 RVA: 0x00189E44 File Offset: 0x00188044
		public uint DayCanCheck
		{
			get
			{
				return this._DayCanCheck;
			}
		}

		// Token: 0x17002E23 RID: 11811
		// (get) Token: 0x06009B04 RID: 39684 RVA: 0x00189E5C File Offset: 0x0018805C
		public uint Bonus
		{
			get
			{
				return this._Bonus;
			}
		}

		// Token: 0x17002E24 RID: 11812
		// (get) Token: 0x06009B05 RID: 39685 RVA: 0x00189E74 File Offset: 0x00188074
		public uint ReplenishCount
		{
			get
			{
				return this._ReplenishCount;
			}
		}

		// Token: 0x17002E25 RID: 11813
		// (get) Token: 0x06009B06 RID: 39686 RVA: 0x00189E8C File Offset: 0x0018808C
		public List<uint> ItemIDs
		{
			get
			{
				return this._ItemIDs;
			}
		}

		// Token: 0x17002E26 RID: 11814
		// (get) Token: 0x06009B07 RID: 39687 RVA: 0x00189EA4 File Offset: 0x001880A4
		public List<uint> ItemCounts
		{
			get
			{
				return this._ItemCounts;
			}
		}

		// Token: 0x17002E27 RID: 11815
		// (get) Token: 0x06009B08 RID: 39688 RVA: 0x00189EBC File Offset: 0x001880BC
		public int DoubleTQ
		{
			get
			{
				return this._doubleTQ;
			}
		}

		// Token: 0x17002E28 RID: 11816
		// (set) Token: 0x06009B09 RID: 39689 RVA: 0x00189ED4 File Offset: 0x001880D4
		private uint CheckInfo
		{
			set
			{
				this._CheckInfo = value;
				this._UpdateDayChecked();
			}
		}

		// Token: 0x06009B0A RID: 39690 RVA: 0x00189EE8 File Offset: 0x001880E8
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.m_bWaitForResult = false;
			this._ReplenishCost.Clear();
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("SignCost").Split(XGlobalConfig.ListSeparator);
			foreach (string s in array)
			{
				this._ReplenishCost.Add(uint.Parse(s));
			}
		}

		// Token: 0x06009B0B RID: 39691 RVA: 0x00189F54 File Offset: 0x00188154
		public uint GetReplenishCost()
		{
			bool flag = (ulong)this._ReplenishCount >= (ulong)((long)this._ReplenishCost.Count);
			uint result;
			if (flag)
			{
				result = this._ReplenishCost[this._ReplenishCost.Count - 1];
			}
			else
			{
				result = this._ReplenishCost[(int)this._ReplenishCount];
			}
			return result;
		}

		// Token: 0x06009B0C RID: 39692 RVA: 0x00189FB0 File Offset: 0x001881B0
		public bool IsTodayChecked()
		{
			return (1L << (int)(this._DayCanCheck - 1U + this._CheckOffset & 31U) & (long)((ulong)this._CheckInfo)) != 0L;
		}

		// Token: 0x06009B0D RID: 39693 RVA: 0x00189FF0 File Offset: 0x001881F0
		private void _UpdateDayChecked()
		{
			this._DayChecked = 0U;
			for (uint num = this._CheckInfo; num > 0U; num &= num - 1U)
			{
				this._DayChecked += 1U;
			}
		}

		// Token: 0x06009B0E RID: 39694 RVA: 0x0018A02C File Offset: 0x0018822C
		public void OnCheckinInfoNotify(CheckinInfoNotify data)
		{
			this._CheckOffset = data.StartDay - 1U;
			this._DayCanCheck = data.DayCanCheck;
			this._ReplenishCount = data.DayMakeUp;
			this.CheckInfo = data.DayCheckInfo;
			bool flag = data.ItemId.Count != data.ItemCount.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("data.ItemId.Count != data.ItemCount.Count", null, null, null, null, null);
			}
			else
			{
				this._ItemIDs = data.ItemId;
				this._ItemCounts = data.ItemCount;
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				PayMemberTable.RowData memberPrivilegeConfig = specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Commerce);
				this._doubleTQ = 0;
				bool isOddMonth = data.IsOddMonth;
				if (isOddMonth)
				{
					bool flag2 = memberPrivilegeConfig.CheckinDoubleDays != null;
					if (flag2)
					{
						for (int i = 0; i < memberPrivilegeConfig.CheckinDoubleDays.Length; i++)
						{
							this._doubleTQ |= 1 << memberPrivilegeConfig.CheckinDoubleDays[i];
						}
					}
				}
				else
				{
					bool flag3 = memberPrivilegeConfig.CheckinDoubleEvenDays != null;
					if (flag3)
					{
						for (int j = 0; j < memberPrivilegeConfig.CheckinDoubleEvenDays.Length; j++)
						{
							this._doubleTQ |= 1 << memberPrivilegeConfig.CheckinDoubleEvenDays[j];
						}
					}
				}
				bool flag4 = this.View != null && this.View.active;
				if (flag4)
				{
					this.View.RefreshPage();
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward_Login, true);
			}
		}

		// Token: 0x06009B0F RID: 39695 RVA: 0x0018A1BC File Offset: 0x001883BC
		public void ReqCheckin()
		{
			bool bWaitForResult = this.m_bWaitForResult;
			if (!bWaitForResult)
			{
				RpcC2G_Checkin rpc = new RpcC2G_Checkin();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
				this.m_bWaitForResult = true;
			}
		}

		// Token: 0x06009B10 RID: 39696 RVA: 0x0018A1F0 File Offset: 0x001883F0
		public void OnCheckin(CheckinRes oRes)
		{
			this.m_bWaitForResult = false;
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				this._Bonus = oRes.Bonus;
				this._DayCanCheck = oRes.DayCanCheck;
				this.CheckInfo = oRes.DayCheckInfo;
				this._ReplenishCount = oRes.DayMakeUp;
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				bool flag2 = specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce) && (this._doubleTQ & 1 << (int)this._DayChecked) != 0;
				if (flag2)
				{
					bool flag3 = this.View.IsVisible();
					if (flag3)
					{
						this.View.ShowTQFx();
					}
				}
				bool flag4 = this.View != null && this.View.active;
				if (flag4)
				{
					this.View.RefreshStates();
					this.View.SignTweenPlay();
					bool flag5 = this._Bonus > 1U;
					if (flag5)
					{
						this.View.ShowCritical();
					}
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward_Login, true);
				bool flag6 = DlgBase<XWelfareView, XWelfareBehaviour>.singleton.IsVisible();
				if (flag6)
				{
					DlgBase<XWelfareView, XWelfareBehaviour>.singleton.RefreshRedpoint();
				}
			}
		}

		// Token: 0x06009B11 RID: 39697 RVA: 0x0018A329 File Offset: 0x00188529
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.m_bWaitForResult = false;
		}

		// Token: 0x0400357D RID: 13693
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("LoginRewardDocument");

		// Token: 0x0400357E RID: 13694
		private XLoginRewardView _LoginRewardView = null;

		// Token: 0x0400357F RID: 13695
		private List<uint> _ReplenishCost = new List<uint>();

		// Token: 0x04003580 RID: 13696
		private bool m_bWaitForResult = false;

		// Token: 0x04003581 RID: 13697
		private uint _DayChecked;

		// Token: 0x04003582 RID: 13698
		private uint _DayCanCheck;

		// Token: 0x04003583 RID: 13699
		private uint _Bonus = 0U;

		// Token: 0x04003584 RID: 13700
		private uint _ReplenishCount = 0U;

		// Token: 0x04003585 RID: 13701
		private List<uint> _ItemIDs = new List<uint>();

		// Token: 0x04003586 RID: 13702
		private List<uint> _ItemCounts = new List<uint>();

		// Token: 0x04003587 RID: 13703
		private int _doubleTQ;

		// Token: 0x04003588 RID: 13704
		private uint _CheckOffset = 0U;

		// Token: 0x04003589 RID: 13705
		private uint _CheckInfo = 0U;
	}
}
