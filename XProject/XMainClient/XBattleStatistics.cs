using System;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000B15 RID: 2837
	internal struct XBattleStatistics
	{
		// Token: 0x17002FFC RID: 12284
		// (get) Token: 0x0600A6F3 RID: 42739 RVA: 0x001D6FB4 File Offset: 0x001D51B4
		public double Dps
		{
			get
			{
				return (this.m_TimeTotal > 0f) ? (this.m_Damage / (double)this.m_TimeTotal) : 0.0;
			}
		}

		// Token: 0x17002FFD RID: 12285
		// (get) Token: 0x0600A6F4 RID: 42740 RVA: 0x001D6FEC File Offset: 0x001D51EC
		public double PrintDamage
		{
			get
			{
				return this.m_Damage - this.m_StartPrintDamage;
			}
		}

		// Token: 0x0600A6F5 RID: 42741 RVA: 0x001D700B File Offset: 0x001D520B
		public void Reset()
		{
			this.m_Damage = 0.0;
			this.m_TimeTotal = 0f;
		}

		// Token: 0x0600A6F6 RID: 42742 RVA: 0x001D7028 File Offset: 0x001D5228
		public void AppendDamage(double damage)
		{
			this.m_Damage += damage;
		}

		// Token: 0x0600A6F7 RID: 42743 RVA: 0x001D703C File Offset: 0x001D523C
		public void AppendTime()
		{
			float time = Time.time;
			this.m_TimeTotal += time - this.m_TimeBase;
			this.m_TimeBase = time;
		}

		// Token: 0x0600A6F8 RID: 42744 RVA: 0x001D706C File Offset: 0x001D526C
		public void MarkTimeBaseLine()
		{
			this.m_TimeBase = Time.time - this.m_TimeEnd;
		}

		// Token: 0x0600A6F9 RID: 42745 RVA: 0x001D7081 File Offset: 0x001D5281
		public void MarkTimEndLine()
		{
			this.m_TimeEnd = Time.time - this.m_TimeBase;
		}

		// Token: 0x0600A6FA RID: 42746 RVA: 0x001D7098 File Offset: 0x001D5298
		public void StartPrintDamage(float time)
		{
			this.m_StartPrintDamage = this.m_Damage;
			XCombatStatisticsDocument specificDocument = XDocuments.GetSpecificDocument<XCombatStatisticsDocument>(XCombatStatisticsDocument.uuID);
			specificDocument.bShowDamage = true;
		}

		// Token: 0x0600A6FB RID: 42747 RVA: 0x001D70C4 File Offset: 0x001D52C4
		public void StopPrintDamage()
		{
			DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage((this.m_Damage - this.m_StartPrintDamage).ToString("F1"));
		}

		// Token: 0x04003D68 RID: 15720
		private double m_Damage;

		// Token: 0x04003D69 RID: 15721
		private double m_StartPrintDamage;

		// Token: 0x04003D6A RID: 15722
		private float m_TimeTotal;

		// Token: 0x04003D6B RID: 15723
		private float m_TimeBase;

		// Token: 0x04003D6C RID: 15724
		private float m_TimeEnd;
	}
}
