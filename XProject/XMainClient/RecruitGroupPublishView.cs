using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A33 RID: 2611
	internal class RecruitGroupPublishView : RecruitPublishView<RecruitGroupPublishView, RecruitGroupPublishBehaviour>
	{
		// Token: 0x17002ED4 RID: 11988
		// (get) Token: 0x06009F1C RID: 40732 RVA: 0x001A52D8 File Offset: 0x001A34D8
		public override string fileName
		{
			get
			{
				return "Team/RecruitGroupPublishFrame";
			}
		}

		// Token: 0x06009F1D RID: 40733 RVA: 0x001A52EF File Offset: 0x001A34EF
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<RecruitSelectGroupHandler>(ref this._SelectGroupHandle);
			DlgHandlerBase.EnsureUnload<RecruitStepCounter>(ref this._StepCounter);
			base.OnUnload();
		}

		// Token: 0x06009F1E RID: 40734 RVA: 0x001A5314 File Offset: 0x001A3514
		protected override void Init()
		{
			base.Init();
			this._StepCounter = DlgHandlerBase.EnsureCreate<RecruitStepCounter>(ref this._StepCounter, base.uiBehaviour.m_BattlePoint.gameObject, null, true);
			this._SelectGroupHandle = DlgHandlerBase.EnsureCreate<RecruitSelectGroupHandler>(ref this._SelectGroupHandle, base.uiBehaviour.m_SelectGroup.gameObject, null, true);
		}

		// Token: 0x06009F1F RID: 40735 RVA: 0x001A5370 File Offset: 0x001A3570
		protected override void OnShow()
		{
			base.OnShow();
			this.OnStageSelect();
			bool flag = this._SelectGroupHandle != null;
			if (flag)
			{
				this._SelectGroupHandle.RefreshData();
			}
		}

		// Token: 0x06009F20 RID: 40736 RVA: 0x001A53A8 File Offset: 0x001A35A8
		protected override void OnStageSelect()
		{
			uint selectStageID = base.GetSelectStageID();
			bool flag = selectStageID == 0U;
			if (!flag)
			{
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID((int)selectStageID);
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("TeamSettingPPTStep");
				int displayPPT = (int)expeditionDataByID.DisplayPPT;
				this._StepCounter.Setup(displayPPT, -1, displayPPT, @int, new RecruitStepCounterUpdate(this.OnPPTStepUpdate));
			}
		}

		// Token: 0x06009F21 RID: 40737 RVA: 0x001A5414 File Offset: 0x001A3614
		protected override bool OnSubmitClick(IXUIButton btn)
		{
			bool flag = this._SelectGroupHandle == null || this._SelectGroupHandle.SelectGroup == null;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GroupChat_UnSelectGroup"), "fece00");
				result = false;
			}
			else
			{
				bool flag2 = this._TeamInfo == null;
				if (flag2)
				{
					this._TeamInfo = new GroupChatFindTeamInfo();
				}
				this._TeamInfo.groupchatID = this._SelectGroupHandle.SelectGroup.id;
				this._TeamInfo.groupchatName = this._SelectGroupHandle.SelectGroup.name;
				this._TeamInfo.stageID = base.GetSelectStageID();
				this._TeamInfo.fighting = (uint)this._StepCounter.Cur;
				this._TeamInfo.type = base.GetMemberType();
				this._TeamInfo.time = (uint)base.GetTime();
				this._doc.SendGroupChatLeaderInfo(this._TeamInfo);
				result = base.OnSubmitClick(btn);
			}
			return result;
		}

		// Token: 0x06009F22 RID: 40738 RVA: 0x001A551C File Offset: 0x001A371C
		private void OnPPTStepUpdate(IXUILabel label)
		{
			label.SetText(this._StepCounter.Cur.ToString());
		}

		// Token: 0x040038C0 RID: 14528
		private RecruitStepCounter _StepCounter;

		// Token: 0x040038C1 RID: 14529
		private RecruitSelectGroupHandler _SelectGroupHandle;

		// Token: 0x040038C2 RID: 14530
		private GroupChatFindTeamInfo _TeamInfo;
	}
}
