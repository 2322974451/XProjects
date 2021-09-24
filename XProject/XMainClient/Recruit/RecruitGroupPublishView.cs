using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RecruitGroupPublishView : RecruitPublishView<RecruitGroupPublishView, RecruitGroupPublishBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/RecruitGroupPublishFrame";
			}
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<RecruitSelectGroupHandler>(ref this._SelectGroupHandle);
			DlgHandlerBase.EnsureUnload<RecruitStepCounter>(ref this._StepCounter);
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this._StepCounter = DlgHandlerBase.EnsureCreate<RecruitStepCounter>(ref this._StepCounter, base.uiBehaviour.m_BattlePoint.gameObject, null, true);
			this._SelectGroupHandle = DlgHandlerBase.EnsureCreate<RecruitSelectGroupHandler>(ref this._SelectGroupHandle, base.uiBehaviour.m_SelectGroup.gameObject, null, true);
		}

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

		private void OnPPTStepUpdate(IXUILabel label)
		{
			label.SetText(this._StepCounter.Cur.ToString());
		}

		private RecruitStepCounter _StepCounter;

		private RecruitSelectGroupHandler _SelectGroupHandle;

		private GroupChatFindTeamInfo _TeamInfo;
	}
}
