using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLoginRewardDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XLoginRewardDocument.uuID;
			}
		}

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

		public uint DayChecked
		{
			get
			{
				return this._DayChecked;
			}
		}

		public uint DayCanCheck
		{
			get
			{
				return this._DayCanCheck;
			}
		}

		public uint Bonus
		{
			get
			{
				return this._Bonus;
			}
		}

		public uint ReplenishCount
		{
			get
			{
				return this._ReplenishCount;
			}
		}

		public List<uint> ItemIDs
		{
			get
			{
				return this._ItemIDs;
			}
		}

		public List<uint> ItemCounts
		{
			get
			{
				return this._ItemCounts;
			}
		}

		public int DoubleTQ
		{
			get
			{
				return this._doubleTQ;
			}
		}

		private uint CheckInfo
		{
			set
			{
				this._CheckInfo = value;
				this._UpdateDayChecked();
			}
		}

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

		public bool IsTodayChecked()
		{
			return (1L << (int)(this._DayCanCheck - 1U + this._CheckOffset & 31U) & (long)((ulong)this._CheckInfo)) != 0L;
		}

		private void _UpdateDayChecked()
		{
			this._DayChecked = 0U;
			for (uint num = this._CheckInfo; num > 0U; num &= num - 1U)
			{
				this._DayChecked += 1U;
			}
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.m_bWaitForResult = false;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("LoginRewardDocument");

		private XLoginRewardView _LoginRewardView = null;

		private List<uint> _ReplenishCost = new List<uint>();

		private bool m_bWaitForResult = false;

		private uint _DayChecked;

		private uint _DayCanCheck;

		private uint _Bonus = 0U;

		private uint _ReplenishCount = 0U;

		private List<uint> _ItemIDs = new List<uint>();

		private List<uint> _ItemCounts = new List<uint>();

		private int _doubleTQ;

		private uint _CheckOffset = 0U;

		private uint _CheckInfo = 0U;
	}
}
