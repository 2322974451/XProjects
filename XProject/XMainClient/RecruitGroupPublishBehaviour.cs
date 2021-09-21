using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000A32 RID: 2610
	internal class RecruitGroupPublishBehaviour : RecruitPublishBehaviour
	{
		// Token: 0x06009F1A RID: 40730 RVA: 0x001A529D File Offset: 0x001A349D
		public override void OtherAwake()
		{
			this.m_SelectGroup = base.transform.Find("Bg/SelectGroup");
			this.m_BattlePoint = base.transform.Find("Bg/BattlePoint");
		}

		// Token: 0x040038BE RID: 14526
		public Transform m_BattlePoint;

		// Token: 0x040038BF RID: 14527
		public Transform m_SelectGroup;
	}
}
