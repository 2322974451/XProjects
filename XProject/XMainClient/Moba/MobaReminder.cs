using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	public class MobaReminder
	{

		public void Recycle()
		{
			this.killer = null;
			this.deader = null;
			bool flag = this.assists != null;
			if (flag)
			{
				this.assists.Clear();
			}
			this.assists = null;
			this.AudioName = "";
			this.ReminderText = "";
			MobaInfoPool.Recycle(this);
		}

		public MobaReminderEnum reminder;

		public HeroKillUnit killer;

		public HeroKillUnit deader;

		public List<HeroKillUnit> assists;

		public int type;

		public string AudioName;

		public string ReminderText;
	}
}
