using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000C66 RID: 3174
	internal class Partner
	{
		// Token: 0x0600B3C2 RID: 46018 RVA: 0x00230708 File Offset: 0x0022E908
		public void SetDetailInfo(PartnerMemberDetail detail)
		{
			this.m_detail = new PartnerMemberDetail();
			this.m_detail.memberid = detail.memberid;
			this.m_detail.profession = detail.profession;
			this.m_detail.name = detail.name;
			this.m_detail.level = detail.level;
			this.m_detail.ppt = detail.ppt;
			this.m_detail.outlook = detail.outlook;
			this.m_detail.viplevel = detail.viplevel;
			this.m_detail.paymemberid = detail.paymemberid;
			this.m_detail.is_apply_leave = detail.is_apply_leave;
			this.m_detail.left_leave_time = detail.left_leave_time;
			for (int i = 0; i < detail.fashion.Count; i++)
			{
				this.m_detail.fashion.Add(detail.fashion[i]);
			}
		}

		// Token: 0x0600B3C3 RID: 46019 RVA: 0x0023080E File Offset: 0x0022EA0E
		public void UpdateLeaveInfo(bool isLeave, uint leaveTime)
		{
			this.m_detail.is_apply_leave = isLeave;
			this.m_detail.left_leave_time = leaveTime;
		}

		// Token: 0x170031CC RID: 12748
		// (get) Token: 0x0600B3C4 RID: 46020 RVA: 0x0023082B File Offset: 0x0022EA2B
		// (set) Token: 0x0600B3C5 RID: 46021 RVA: 0x00230833 File Offset: 0x0022EA33
		public ulong MemberId { get; set; }

		// Token: 0x170031CD RID: 12749
		// (get) Token: 0x0600B3C6 RID: 46022 RVA: 0x0023083C File Offset: 0x0022EA3C
		public PartnerMemberDetail Detail
		{
			get
			{
				return this.m_detail;
			}
		}

		// Token: 0x040045AB RID: 17835
		private PartnerMemberDetail m_detail;
	}
}
