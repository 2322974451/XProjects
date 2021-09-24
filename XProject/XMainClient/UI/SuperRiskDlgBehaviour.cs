using System;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class SuperRiskDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_SelectMapPanel = base.transform.Find("Bg/SelectMap").gameObject;
			this.m_RiskMapPanel = base.transform.Find("Bg/RiskMap").gameObject;
		}

		public GameObject m_SelectMapPanel;

		public GameObject m_RiskMapPanel;
	}
}
