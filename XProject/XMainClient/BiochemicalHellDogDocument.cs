using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BiochemicalHellDogDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return BiochemicalHellDogDocument.uuID;
			}
		}

		public XThemeActivityDocument ActDoc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XThemeActivityDocument.uuID) as XThemeActivityDocument;
			}
		}

		public List<SuperActivityTask.RowData> RewardTableData
		{
			get
			{
				bool flag = this._RewardTableData != null;
				List<SuperActivityTask.RowData> rewardTableData;
				if (flag)
				{
					rewardTableData = this._RewardTableData;
				}
				else
				{
					this._RewardTableData = XTempActivityDocument.Doc.GetDataByActivityType(this.ActInfo.actid);
					rewardTableData = this._RewardTableData;
				}
				return rewardTableData;
			}
		}

		public SuperActivityTime.RowData ActInfo
		{
			get
			{
				bool flag = this._actInfo != null;
				SuperActivityTime.RowData actInfo;
				if (flag)
				{
					actInfo = this._actInfo;
				}
				else
				{
					XTempActivityDocument specificDocument = XDocuments.GetSpecificDocument<XTempActivityDocument>(XTempActivityDocument.uuID);
					this._actInfo = specificDocument.GetDataBySystemID((uint)this.systemID);
					bool flag2 = this._actInfo == null;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("SuperActivityTime SystemID:" + this.systemID + "No Find", null, null, null, null, null);
					}
					actInfo = this._actInfo;
				}
				return actInfo;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnTaskChange));
		}

		private bool OnTaskChange(XEventArgs e)
		{
			XActivityTaskUpdatedArgs xactivityTaskUpdatedArgs = e as XActivityTaskUpdatedArgs;
			bool flag = xactivityTaskUpdatedArgs.xActID == this.ActInfo.actid;
			if (flag)
			{
				bool flag2 = DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.m_HellDogHandler != null && DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.m_HellDogHandler.m_HelpRewardHandler != null && DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.m_HellDogHandler.m_HelpRewardHandler.IsVisible();
				if (flag2)
				{
					DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.m_HellDogHandler.m_HelpRewardHandler.SetData(this.GetRewardData());
				}
				bool flag3 = DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.m_HellDogHandler != null;
				if (flag3)
				{
					DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.m_HellDogHandler.RefreshRedPoint();
				}
			}
			return true;
		}

		public void RecordActivityPastTime(uint time, SeqListRef<uint> timestage)
		{
			this.curTime = (int)(time / 3600U);
			XSingleton<XDebug>.singleton.AddGreenLog("time:" + time, null, null, null, null, null);
		}

		public bool GetRedPoint()
		{
			int i = 0;
			int count = this.RewardTableData.Count;
			while (i < count)
			{
				bool flag = XTempActivityDocument.Doc.GetActivityState(this.RewardTableData[i].actid, this.RewardTableData[i].taskid) == 1U;
				if (flag)
				{
					return true;
				}
				i++;
			}
			return false;
		}

		public BiochemicalHellDogDocument.Stage GetStage(int type)
		{
			BiochemicalHellDogDocument.Stage result;
			int num;
			int num2;
			this.GetTime(type, out result, out num, out num2);
			return result;
		}

		public void GetTime(int type, out BiochemicalHellDogDocument.Stage timeStage, out int actStartTime, out int actEndTime)
		{
			actStartTime = 0;
			actEndTime = 0;
			for (int i = 0; i < this.sceneID.Length; i++)
			{
				bool flag = i != 0;
				if (flag)
				{
					actStartTime += (int)this.ActInfo.timestage[i - 1, 0];
				}
				actEndTime += (int)this.ActInfo.timestage[i, 0];
				bool flag2 = i == type;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = this.curTime < actStartTime;
			if (flag3)
			{
				timeStage = BiochemicalHellDogDocument.Stage.Ready;
			}
			else
			{
				bool flag4 = this.curTime < actEndTime;
				if (flag4)
				{
					timeStage = BiochemicalHellDogDocument.Stage.Processing;
				}
				else
				{
					timeStage = BiochemicalHellDogDocument.Stage.End;
				}
			}
		}

		public List<ActivityHelpReward> GetRewardData()
		{
			List<ActivityHelpReward> list = new List<ActivityHelpReward>();
			bool flag = this.RewardTableData != null;
			if (flag)
			{
				int i = 0;
				int count = this.RewardTableData.Count;
				while (i < count)
				{
					ActivityHelpReward activityHelpReward = new ActivityHelpReward();
					activityHelpReward.index = i;
					activityHelpReward.tableData = this.RewardTableData[i];
					activityHelpReward.state = XTempActivityDocument.Doc.GetActivityState(this.RewardTableData[i].actid, this.RewardTableData[i].taskid);
					activityHelpReward.sort = (int)activityHelpReward.state;
					bool flag2 = (long)activityHelpReward.sort == 2L;
					if (flag2)
					{
						activityHelpReward.sort = -1;
					}
					activityHelpReward.progress = XTempActivityDocument.Doc.GetActivityProgress(this.RewardTableData[i].actid, this.RewardTableData[i].taskid);
					list.Add(activityHelpReward);
					i++;
				}
			}
			return list;
		}

		public FirstPassRankList RankList
		{
			get
			{
				return this._rankList;
			}
		}

		public void SendRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.BioHelllRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void ReceiveRankList(ClientQueryRankListRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				this._rankList.Init(oRes, false);
				bool flag2 = DlgBase<BiochemicalHellDogRankView, BiochemicalHellDogRankBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<BiochemicalHellDogRankView, BiochemicalHellDogRankBehaviour>.singleton.FillContent();
				}
			}
		}

		public DesignationTable.RowData GetTittleNameByRank(int rank)
		{
			bool flag = this.m_titleRowList == null;
			if (flag)
			{
				XDesignationDocument xdesignationDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XDesignationDocument.uuID) as XDesignationDocument;
				this.m_titleRowList = new List<DesignationTable.RowData>();
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("BiochemicalHellTitleType");
				for (int i = 0; i < xdesignationDocument._DesignationTable.Table.Length; i++)
				{
					DesignationTable.RowData rowData = xdesignationDocument._DesignationTable.Table[i];
					bool flag2 = rowData != null && rowData.CompleteType == @int;
					if (flag2)
					{
						bool flag3 = !this.m_titleRowList.Contains(rowData);
						if (flag3)
						{
							this.m_titleRowList.Add(rowData);
						}
					}
				}
			}
			for (int j = 0; j < this.m_titleRowList.Count; j++)
			{
				bool flag4 = this.m_titleRowList[j].CompleteValue != null && this.m_titleRowList[j].CompleteValue.Length == 2;
				if (flag4)
				{
					bool flag5 = rank >= this.m_titleRowList[j].CompleteValue[0] && rank <= this.m_titleRowList[j].CompleteValue[1];
					if (flag5)
					{
						return this.m_titleRowList[j];
					}
				}
			}
			return null;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("BiochemicalHellDogDocument");

		public int curTime;

		public int systemID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_ThemeActivity_HellDog);

		public string[] sceneID = XSingleton<XGlobalConfig>.singleton.GetValue("BioHellSceneStage").Split(new char[]
		{
			'|'
		});

		public string[] tex = XSingleton<XGlobalConfig>.singleton.GetValue("BioHellTex").Split(new char[]
		{
			'|'
		});

		public static readonly uint REWARD_MAX = 3U;

		private List<SuperActivityTask.RowData> _RewardTableData;

		private SuperActivityTime.RowData _actInfo = null;

		private FirstPassRankList _rankList = new FirstPassRankList();

		private List<DesignationTable.RowData> m_titleRowList;

		public enum Stage
		{

			Ready,

			Processing,

			End
		}
	}
}
