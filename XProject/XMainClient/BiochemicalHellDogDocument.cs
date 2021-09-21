using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CA5 RID: 3237
	internal class BiochemicalHellDogDocument : XDocComponent
	{
		// Token: 0x17003231 RID: 12849
		// (get) Token: 0x0600B64A RID: 46666 RVA: 0x00241F34 File Offset: 0x00240134
		public override uint ID
		{
			get
			{
				return BiochemicalHellDogDocument.uuID;
			}
		}

		// Token: 0x17003232 RID: 12850
		// (get) Token: 0x0600B64B RID: 46667 RVA: 0x00241F4C File Offset: 0x0024014C
		public XThemeActivityDocument ActDoc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XThemeActivityDocument.uuID) as XThemeActivityDocument;
			}
		}

		// Token: 0x17003233 RID: 12851
		// (get) Token: 0x0600B64C RID: 46668 RVA: 0x00241F78 File Offset: 0x00240178
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

		// Token: 0x17003234 RID: 12852
		// (get) Token: 0x0600B64D RID: 46669 RVA: 0x00241FC4 File Offset: 0x002401C4
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

		// Token: 0x0600B64E RID: 46670 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600B64F RID: 46671 RVA: 0x00242046 File Offset: 0x00240246
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnTaskChange));
		}

		// Token: 0x0600B650 RID: 46672 RVA: 0x00242068 File Offset: 0x00240268
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

		// Token: 0x0600B651 RID: 46673 RVA: 0x00242111 File Offset: 0x00240311
		public void RecordActivityPastTime(uint time, SeqListRef<uint> timestage)
		{
			this.curTime = (int)(time / 3600U);
			XSingleton<XDebug>.singleton.AddGreenLog("time:" + time, null, null, null, null, null);
		}

		// Token: 0x0600B652 RID: 46674 RVA: 0x00242144 File Offset: 0x00240344
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

		// Token: 0x0600B653 RID: 46675 RVA: 0x002421B0 File Offset: 0x002403B0
		public BiochemicalHellDogDocument.Stage GetStage(int type)
		{
			BiochemicalHellDogDocument.Stage result;
			int num;
			int num2;
			this.GetTime(type, out result, out num, out num2);
			return result;
		}

		// Token: 0x0600B654 RID: 46676 RVA: 0x002421D4 File Offset: 0x002403D4
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

		// Token: 0x0600B655 RID: 46677 RVA: 0x00242274 File Offset: 0x00240474
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

		// Token: 0x17003235 RID: 12853
		// (get) Token: 0x0600B656 RID: 46678 RVA: 0x00242380 File Offset: 0x00240580
		public FirstPassRankList RankList
		{
			get
			{
				return this._rankList;
			}
		}

		// Token: 0x0600B657 RID: 46679 RVA: 0x00242398 File Offset: 0x00240598
		public void SendRankList()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.BioHelllRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x0600B658 RID: 46680 RVA: 0x002423CC File Offset: 0x002405CC
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

		// Token: 0x0600B659 RID: 46681 RVA: 0x00242428 File Offset: 0x00240628
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

		// Token: 0x04004759 RID: 18265
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("BiochemicalHellDogDocument");

		// Token: 0x0400475A RID: 18266
		public int curTime;

		// Token: 0x0400475B RID: 18267
		public int systemID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_ThemeActivity_HellDog);

		// Token: 0x0400475C RID: 18268
		public string[] sceneID = XSingleton<XGlobalConfig>.singleton.GetValue("BioHellSceneStage").Split(new char[]
		{
			'|'
		});

		// Token: 0x0400475D RID: 18269
		public string[] tex = XSingleton<XGlobalConfig>.singleton.GetValue("BioHellTex").Split(new char[]
		{
			'|'
		});

		// Token: 0x0400475E RID: 18270
		public static readonly uint REWARD_MAX = 3U;

		// Token: 0x0400475F RID: 18271
		private List<SuperActivityTask.RowData> _RewardTableData;

		// Token: 0x04004760 RID: 18272
		private SuperActivityTime.RowData _actInfo = null;

		// Token: 0x04004761 RID: 18273
		private FirstPassRankList _rankList = new FirstPassRankList();

		// Token: 0x04004762 RID: 18274
		private List<DesignationTable.RowData> m_titleRowList;

		// Token: 0x020019AF RID: 6575
		public enum Stage
		{
			// Token: 0x04007F8B RID: 32651
			Ready,
			// Token: 0x04007F8C RID: 32652
			Processing,
			// Token: 0x04007F8D RID: 32653
			End
		}
	}
}
