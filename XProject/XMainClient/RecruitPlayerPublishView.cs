using System;
using KKSG;
using UILib;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RecruitPlayerPublishView : RecruitPublishView<RecruitPlayerPublishView, RecruitPlayerPublishBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/RecruitPublishView";
			}
		}

		protected override bool OnSubmitClick(IXUIButton btn)
		{
			bool flag = this._PlayerInfo == null;
			if (flag)
			{
				this._PlayerInfo = new GroupChatFindRoleInfo();
			}
			this._PlayerInfo.stageID = base.GetSelectStageID();
			this._PlayerInfo.type = base.GetMemberType();
			this._PlayerInfo.time = (uint)base.GetTime();
			this._PlayerInfo.roleid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			this._PlayerInfo.rolename = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
			this._PlayerInfo.fighting = XCharacterDocument.GetCharacterPPT();
			this._doc.SendGroupChatPlayerInfo(this._PlayerInfo);
			return base.OnSubmitClick(btn);
		}

		private GroupChatFindRoleInfo _PlayerInfo;
	}
}
