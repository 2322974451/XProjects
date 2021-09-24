using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	public class XOutLookAttr
	{

		public XOutLookAttr(OutLook outlook)
		{
			this.guild = ((outlook != null) ? outlook.guild : null);
			this.designationID = ((outlook != null && outlook.designation != null) ? outlook.designation.id : 0U);
			this.specialDesignation = ((outlook != null && outlook.designation != null) ? outlook.designation.name : "");
			this.titleID = ((outlook != null && outlook.title != null) ? outlook.title.titleID : 0U);
			this.militaryRank = ((outlook != null && outlook.military != null) ? outlook.military.military_rank : 0U);
			bool flag = outlook == null || outlook.pre == null;
			if (flag)
			{
				this.prerogativeScore = 0U;
				this.prerogativeSetID = null;
			}
			else
			{
				this.prerogativeScore = outlook.pre.score;
				this.prerogativeSetID = outlook.pre.setid;
			}
		}

		public XOutLookAttr(uint title, MilitaryRecord military)
		{
			this.titleID = title;
			this.militaryRank = ((military != null) ? military.military_rank : 0U);
		}

		public XOutLookAttr(OutLookGuild outguild)
		{
			this.guild = outguild;
		}

		public OutLookGuild guild = null;

		public uint designationID = 0U;

		public string specialDesignation = "";

		public uint titleID = 0U;

		public uint militaryRank = 0U;

		public uint prerogativeScore = 0U;

		public List<uint> prerogativeSetID;
	}
}
