using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamInviteData : XDataBase
	{

		private void _SetExpID(uint expID)
		{
			bool flag = this.briefData.dungeonID == expID;
			if (!flag)
			{
				this.briefData.dungeonID = expID;
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				this.expData = specificDocument.GetExpeditionDataByID((int)expID);
				bool flag2 = this.expData == null;
				if (!flag2)
				{
					this.briefData.dungeonName = XExpeditionDocument.GetFullName(this.expData);
					this.briefData.totalMemberCount = this.expData.PlayerNumber;
				}
			}
		}

		public void SetData(TeamInvite data)
		{
			bool flag = data.teambrief == null;
			if (!flag)
			{
				this.inviteID = data.inviteID;
				this.briefData.SetData(data.teambrief, XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID));
				this.invitorName = data.invfromrolename;
				this.invitorRelation.UpdateRelation(data.invfromroleid, data.invguildid, data.invdragonguildid);
				this.time = data.invTime;
			}
		}

		public override void Recycle()
		{
			XDataPool<XTeamInviteData>.Recycle(this);
		}

		public XTeamBriefData briefData = new XTeamBriefData();

		public uint inviteID;

		public string invitorName;

		public XTeamRelation invitorRelation = new XTeamRelation();

		public uint time;

		private ExpeditionTable.RowData expData;
	}
}
