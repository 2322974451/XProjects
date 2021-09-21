using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020016D1 RID: 5841
	internal class BattleMysteriourHandler : DlgHandlerBase
	{
		// Token: 0x1700373D RID: 14141
		// (get) Token: 0x0600F0EE RID: 61678 RVA: 0x003518FC File Offset: 0x0034FAFC
		protected override string FileName
		{
			get
			{
				return "";
			}
		}

		// Token: 0x0600F0EF RID: 61679 RVA: 0x00351914 File Offset: 0x0034FB14
		protected override void Init()
		{
			base.Init();
			int i = 0;
			int num = this.m_icons.Length;
			while (i < num)
			{
				this.m_icons[i] = base.transform.Find(string.Concat(i)).gameObject;
				i++;
			}
			this.m_lblLevel = (base.transform.FindChild("").GetComponent("") as IXUILabel);
			this.m_lblTime = (base.transform.FindChild("").GetComponent("") as IXUILabel);
			this.m_slider = (base.transform.FindChild("").GetComponent("") as IXUISlider);
		}

		// Token: 0x0600F0F0 RID: 61680 RVA: 0x003519D6 File Offset: 0x0034FBD6
		protected override void OnShow()
		{
			base.OnShow();
			this.m_lblLevel.SetText("");
			this.m_lblTime.SetText("");
			this.RefreshBuff();
		}

		// Token: 0x0600F0F1 RID: 61681 RVA: 0x00351A0C File Offset: 0x0034FC0C
		private void RefreshBuff()
		{
			int i = 0;
			int num = this.m_icons.Length;
			while (i < num)
			{
				this.m_icons[i].SetActive(false);
				i++;
			}
		}

		// Token: 0x040066CE RID: 26318
		private IXUILabel m_lblLevel;

		// Token: 0x040066CF RID: 26319
		private IXUILabel m_lblTime;

		// Token: 0x040066D0 RID: 26320
		private GameObject[] m_icons = new GameObject[3];

		// Token: 0x040066D1 RID: 26321
		private IXUISlider m_slider;
	}
}
