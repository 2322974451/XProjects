using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	public class MentorRelationInfo
	{

		public RoleBriefInfo roleInfo;

		public MentorRelationStatus status;

		public List<MentorRelationTime> statusTimeList = new List<MentorRelationTime>();

		public List<MentorshipTaskInfo> taskList = new List<MentorshipTaskInfo>();

		public EMentorTaskStatus inheritStatus;

		public ulong breakApplyRoleID;

		public ulong inheritApplyRoleID = 0UL;
	}
}
