using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class FirstPassDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return FirstPassDocument.uuID;
			}
		}

		public int NeedPassTeamCount
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("PassTeamCount");
			}
		}

		public static FirstPassDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(FirstPassDocument.uuID) as FirstPassDocument;
			}
		}

		public FirstPassMainHandler View { get; set; }

		public static void Execute(OnLoadedCallback callback = null)
		{
			FirstPassDocument.AsyncLoader.AddTask("Table/FirstPass", FirstPassDocument.sFirstPassTable, false);
			FirstPassDocument.AsyncLoader.AddTask("Table/FirstPassReward", FirstPassDocument.sFirstPassReward, false);
			FirstPassDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			bool flag = this.m_FirstPassData != null;
			if (flag)
			{
				for (int i = 0; i < this.m_FirstPassData.Count; i++)
				{
					this.m_FirstPassData[i] = null;
				}
				this.m_FirstPassData.Clear();
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<FirstPassRankView, FitstpassRankBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.ReqRankList(this.CurData.Id);
			}
			else
			{
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					bool flag3 = this.View.TeamInfoHandler != null && this.View.TeamInfoHandler.IsVisible();
					if (flag3)
					{
						this.ReqFirstPassTopRoleInfo(this.CurData.Id);
					}
					else
					{
						this.ReqFirstPassInfo();
					}
				}
			}
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public List<FirstPassAuxData> FirstPassData
		{
			get
			{
				bool flag = this.m_FirstPassData == null;
				if (flag)
				{
					this.m_FirstPassData = new List<FirstPassAuxData>();
					for (int i = 0; i < FirstPassDocument.sFirstPassTable.Table.Length; i++)
					{
						FirstPassAuxData item = new FirstPassAuxData(FirstPassDocument.sFirstPassTable.Table[i]);
						this.m_FirstPassData.Add(item);
					}
				}
				return this.m_FirstPassData;
			}
		}

		public bool IsHadOutRedDot
		{
			get
			{
				return this.m_isHadOutRedDot;
			}
			set
			{
				bool flag = this.m_isHadOutRedDot != value;
				if (flag)
				{
					this.m_isHadOutRedDot = value;
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_OperatingActivity, true);
					bool flag2 = DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.IsVisible();
					if (flag2)
					{
						DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.RefreshRedpoint();
					}
				}
			}
		}

		public FirstPassAuxData CurData { get; set; }

		public FirstPassRankList RankList
		{
			get
			{
				return this.m_rankList;
			}
		}

		public bool IsHadNextData
		{
			get
			{
				int index = this.GetIndex();
				bool flag = index == this.FirstPassData.Count - 1;
				return !flag && this.FirstPassData[index + 1].IsOpen();
			}
		}

		public bool IsHadLastData
		{
			get
			{
				int index = this.GetIndex();
				bool flag = index == 0;
				return !flag && this.FirstPassData[index - 1].IsOpen();
			}
		}

		public FirstPassAuxData AutoSelectFirstPassData
		{
			get
			{
				bool flag = this.FirstPassData.Count == 0;
				FirstPassAuxData result;
				if (flag)
				{
					result = null;
				}
				else
				{
					bool flag2 = this.FirstPassData.Count == 1;
					if (flag2)
					{
						result = this.FirstPassData[0];
					}
					else
					{
						for (int i = 0; i < this.FirstPassData.Count; i++)
						{
							bool flag3 = i == 0;
							if (flag3)
							{
								bool flag4 = !this.FirstPassData[i].IsOpen();
								if (flag4)
								{
									return this.FirstPassData[i];
								}
							}
							bool flag5 = i == this.FirstPassData.Count - 1;
							if (flag5)
							{
								return this.FirstPassData[i];
							}
							bool flag6 = this.FirstPassData[i].PassTeamCount < this.NeedPassTeamCount;
							if (flag6)
							{
								return this.FirstPassData[i];
							}
							bool flag7 = !this.FirstPassData[i + 1].IsOpen();
							if (flag7)
							{
								return this.FirstPassData[i];
							}
						}
						result = this.FirstPassData[0];
					}
				}
				return result;
			}
		}

		public void SetCurDataByNestType(int nestType)
		{
			bool flag = this.FirstPassData.Count <= 0;
			if (!flag)
			{
				for (int i = 0; i < this.FirstPassData.Count; i++)
				{
					bool flag2 = this.FirstPassData[i] != null;
					if (flag2)
					{
						bool flag3 = (ulong)this.FirstPassData[i].FirstPassRow.NestType == (ulong)((long)nestType);
						if (flag3)
						{
							this.CurData = this.FirstPassData[i];
							return;
						}
					}
				}
				this.CurData = this.FirstPassData[0];
			}
		}

		public FirstPassAuxData GetNextFirstPassData()
		{
			int index = this.GetIndex();
			bool flag = index == this.FirstPassData.Count - 1;
			FirstPassAuxData result;
			if (flag)
			{
				result = this.CurData;
			}
			else
			{
				bool flag2 = !this.FirstPassData[index + 1].IsOpen();
				if (flag2)
				{
					result = this.CurData;
				}
				else
				{
					result = this.FirstPassData[index + 1];
				}
			}
			return result;
		}

		public FirstPassAuxData GetLastFirstPassData()
		{
			int index = this.GetIndex();
			bool flag = index == 0;
			FirstPassAuxData result;
			if (flag)
			{
				result = this.CurData;
			}
			else
			{
				bool flag2 = !this.FirstPassData[index - 1].IsOpen();
				if (flag2)
				{
					result = this.CurData;
				}
				else
				{
					result = this.FirstPassData[index - 1];
				}
			}
			return result;
		}

		private int GetIndex()
		{
			for (int i = 0; i < this.FirstPassData.Count; i++)
			{
				bool flag = this.FirstPassData[i].Id == this.CurData.Id;
				if (flag)
				{
					return i;
				}
			}
			return 0;
		}

		public bool MainArrowRedDot(ArrowDirection direction)
		{
			bool flag = this.CurData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int index = this.GetIndex();
				if (direction != ArrowDirection.Left)
				{
					if (direction == ArrowDirection.Right)
					{
						for (int i = index + 1; i < this.FirstPassData.Count; i++)
						{
							bool flag2 = this.FirstPassData[i].IsCanPrise | this.FirstPassData[i].IsHadReward;
							if (flag2)
							{
								return true;
							}
						}
					}
				}
				else
				{
					for (int j = 0; j < index; j++)
					{
						bool flag3 = this.FirstPassData[j].IsCanPrise | this.FirstPassData[j].IsHadReward;
						if (flag3)
						{
							return true;
						}
					}
				}
				result = false;
			}
			return result;
		}

		public bool InfoArrowRedDot(ArrowDirection direction)
		{
			bool flag = this.CurData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int index = this.GetIndex();
				if (direction != ArrowDirection.Left)
				{
					if (direction == ArrowDirection.Right)
					{
						for (int i = index + 1; i < this.FirstPassData.Count; i++)
						{
							bool isCanPrise = this.FirstPassData[i].IsCanPrise;
							if (isCanPrise)
							{
								return true;
							}
						}
					}
				}
				else
				{
					for (int j = 0; j < index; j++)
					{
						bool isCanPrise2 = this.FirstPassData[j].IsCanPrise;
						if (isCanPrise2)
						{
							return true;
						}
					}
				}
				result = false;
			}
			return result;
		}

		public void ReqFirstPassInfo()
		{
			RpcC2G_FirstPassInfoReq rpc = new RpcC2G_FirstPassInfoReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqFirstPassReward(int firstPassId)
		{
			RpcC2G_GetFirstPassReward rpcC2G_GetFirstPassReward = new RpcC2G_GetFirstPassReward();
			rpcC2G_GetFirstPassReward.oArg.firstPassID = firstPassId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetFirstPassReward);
		}

		public void ReqCommendFirstPass(int firstPassId)
		{
			RpcC2G_CommendFirstPass rpcC2G_CommendFirstPass = new RpcC2G_CommendFirstPass();
			rpcC2G_CommendFirstPass.oArg.firstPassID = firstPassId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_CommendFirstPass);
		}

		public void ReqFirstPassTopRoleInfo(int firstPassId)
		{
			RpcC2G_FirstPassGetTopRoleInfo rpcC2G_FirstPassGetTopRoleInfo = new RpcC2G_FirstPassGetTopRoleInfo();
			rpcC2G_FirstPassGetTopRoleInfo.oArg.firstPassID = firstPassId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_FirstPassGetTopRoleInfo);
		}

		public void ReqRankList(int firstPassId)
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.FirstPassRank);
			rpcC2M_ClientQueryRankListNtf.oArg.firstPassID = firstPassId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void RefreshOutRedDot(bool priseReward, bool passReward)
		{
			this.IsHadOutRedDot = true;
		}

		public void OnGetFirstPassInfo(FirstPassInfoReqRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				for (int i = 0; i < oRes.stageInfos.Count; i++)
				{
					this.RefreshFirstPassData(oRes.stageInfos[i]);
				}
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.RefreshUI();
				}
			}
		}

		public void OnGetFirstPassTopRoleInfo(FirstPassGetTopRoleInfoRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				bool flag2 = this.CurData != null;
				if (flag2)
				{
					this.CurData.SetTeamInfoListData(oRes.infos);
					this.CurData.PriseTotalNum = (uint)oRes.commendNum;
					this.CurData.SetPassTime((uint)oRes.time);
					bool flag3 = this.CurData.FirstPassRow.NestType > 0U;
					if (flag3)
					{
						this.CurData.SetStar(oRes.starLevel);
					}
				}
				bool flag4 = this.View != null && this.View.IsVisible();
				if (flag4)
				{
					bool flag5 = this.View.TeamInfoHandler != null && this.View.TeamInfoHandler.IsVisible();
					if (flag5)
					{
						this.View.TeamInfoHandler.FillAvata();
					}
				}
			}
		}

		public void OnGetFirstPassReward(GetFirstPassRewardRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				bool flag2 = this.CurData != null;
				if (flag2)
				{
					this.CurData.IsGetedReward = true;
				}
				this.SetOutRedDotStatue();
				bool flag3 = this.View != null && this.View.IsVisible();
				if (flag3)
				{
					this.View.RefreshUI();
				}
			}
		}

		public void OnGetCommendFirstPass(CommendFirstPassRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				bool flag2 = this.CurData != null;
				if (flag2)
				{
					this.CurData.IsGivedPrise = true;
				}
				bool flag3 = this.CurData != null;
				if (flag3)
				{
					this.CurData.PriseTotalNum = (uint)oRes.commendNum;
				}
				this.SetOutRedDotStatue();
				bool flag4 = this.View != null && this.View.IsVisible();
				if (flag4)
				{
					bool flag5 = this.View.TeamInfoHandler != null && this.View.TeamInfoHandler.IsVisible();
					if (flag5)
					{
						this.View.TeamInfoHandler.RefreshUI();
					}
				}
			}
		}

		public void OnGetRankList(ClientQueryRankListRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				this.m_rankList = new FirstPassRankList(oRes, true);
				bool flag2 = DlgBase<FirstPassRankView, FitstpassRankBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<FirstPassRankView, FitstpassRankBehaviour>.singleton.FillContent();
				}
			}
		}

		private void SetOutRedDotStatue()
		{
			bool flag = false;
			for (int i = 0; i < this.FirstPassData.Count; i++)
			{
				flag |= this.FirstPassData[i].IsCanPrise;
				flag |= this.FirstPassData[i].IsHadReward;
			}
			this.IsHadOutRedDot = flag;
		}

		private void RefreshFirstPassData(FirstPassStageInfo2Client info)
		{
			bool flag = info == null;
			if (!flag)
			{
				for (int i = 0; i < this.FirstPassData.Count; i++)
				{
					bool flag2 = this.FirstPassData[i].Id == info.firstPassID;
					if (flag2)
					{
						this.FirstPassData[i].CurRank = info.myRank;
						this.FirstPassData[i].IsGivedPrise = info.hasCommended;
						this.FirstPassData[i].IsGetedReward = info.isGetReward;
						this.FirstPassData[i].PassTeamCount = info.totalRank;
						break;
					}
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FirstPassDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static FirstPassTable sFirstPassTable = new FirstPassTable();

		public static FirstPassReward sFirstPassReward = new FirstPassReward();

		public static readonly int MaxAvata = 6;

		private List<FirstPassAuxData> m_FirstPassData = null;

		private bool m_isHadOutRedDot = false;

		private FirstPassRankList m_rankList = null;
	}
}
