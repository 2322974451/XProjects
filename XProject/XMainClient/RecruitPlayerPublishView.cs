using System;
using KKSG;
using UILib;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A36 RID: 2614
	internal class RecruitPlayerPublishView : RecruitPublishView<RecruitPlayerPublishView, RecruitPlayerPublishBehaviour>
	{
		// Token: 0x17002ED7 RID: 11991
		// (get) Token: 0x06009F37 RID: 40759 RVA: 0x001A5A7C File Offset: 0x001A3C7C
		public override string fileName
		{
			get
			{
				return "Team/RecruitPublishView";
			}
		}

		// Token: 0x06009F38 RID: 40760 RVA: 0x001A5A94 File Offset: 0x001A3C94
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

		// Token: 0x040038C8 RID: 14536
		private GroupChatFindRoleInfo _PlayerInfo;
	}
}
