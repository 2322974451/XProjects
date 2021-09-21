using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A95 RID: 2709
	internal class XTeamInviteData : XDataBase
	{
		// Token: 0x0600A4D4 RID: 42196 RVA: 0x001C983C File Offset: 0x001C7A3C
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

		// Token: 0x0600A4D5 RID: 42197 RVA: 0x001C98C0 File Offset: 0x001C7AC0
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

		// Token: 0x0600A4D6 RID: 42198 RVA: 0x001C993C File Offset: 0x001C7B3C
		public override void Recycle()
		{
			XDataPool<XTeamInviteData>.Recycle(this);
		}

		// Token: 0x04003C05 RID: 15365
		public XTeamBriefData briefData = new XTeamBriefData();

		// Token: 0x04003C06 RID: 15366
		public uint inviteID;

		// Token: 0x04003C07 RID: 15367
		public string invitorName;

		// Token: 0x04003C08 RID: 15368
		public XTeamRelation invitorRelation = new XTeamRelation();

		// Token: 0x04003C09 RID: 15369
		public uint time;

		// Token: 0x04003C0A RID: 15370
		private ExpeditionTable.RowData expData;
	}
}
