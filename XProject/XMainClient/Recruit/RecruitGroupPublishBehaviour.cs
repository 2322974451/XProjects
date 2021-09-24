using System;
using UnityEngine;

namespace XMainClient
{

	internal class RecruitGroupPublishBehaviour : RecruitPublishBehaviour
	{

		public override void OtherAwake()
		{
			this.m_SelectGroup = base.transform.Find("Bg/SelectGroup");
			this.m_BattlePoint = base.transform.Find("Bg/BattlePoint");
		}

		public Transform m_BattlePoint;

		public Transform m_SelectGroup;
	}
}
