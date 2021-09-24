using System;
using KKSG;

namespace XMainClient
{

	internal class Partner
	{

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

		public void UpdateLeaveInfo(bool isLeave, uint leaveTime)
		{
			this.m_detail.is_apply_leave = isLeave;
			this.m_detail.left_leave_time = leaveTime;
		}

		public ulong MemberId { get; set; }

		public PartnerMemberDetail Detail
		{
			get
			{
				return this.m_detail;
			}
		}

		private PartnerMemberDetail m_detail;
	}
}
