using System;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal struct XBattleStatistics
	{

		public double Dps
		{
			get
			{
				return (this.m_TimeTotal > 0f) ? (this.m_Damage / (double)this.m_TimeTotal) : 0.0;
			}
		}

		public double PrintDamage
		{
			get
			{
				return this.m_Damage - this.m_StartPrintDamage;
			}
		}

		public void Reset()
		{
			this.m_Damage = 0.0;
			this.m_TimeTotal = 0f;
		}

		public void AppendDamage(double damage)
		{
			this.m_Damage += damage;
		}

		public void AppendTime()
		{
			float time = Time.time;
			this.m_TimeTotal += time - this.m_TimeBase;
			this.m_TimeBase = time;
		}

		public void MarkTimeBaseLine()
		{
			this.m_TimeBase = Time.time - this.m_TimeEnd;
		}

		public void MarkTimEndLine()
		{
			this.m_TimeEnd = Time.time - this.m_TimeBase;
		}

		public void StartPrintDamage(float time)
		{
			this.m_StartPrintDamage = this.m_Damage;
			XCombatStatisticsDocument specificDocument = XDocuments.GetSpecificDocument<XCombatStatisticsDocument>(XCombatStatisticsDocument.uuID);
			specificDocument.bShowDamage = true;
		}

		public void StopPrintDamage()
		{
			DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage((this.m_Damage - this.m_StartPrintDamage).ToString("F1"));
		}

		private double m_Damage;

		private double m_StartPrintDamage;

		private float m_TimeTotal;

		private float m_TimeBase;

		private float m_TimeEnd;
	}
}
