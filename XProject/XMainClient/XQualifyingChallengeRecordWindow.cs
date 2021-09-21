using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D07 RID: 3335
	internal class XQualifyingChallengeRecordWindow
	{
		// Token: 0x0600BA73 RID: 47731 RVA: 0x002609E4 File Offset: 0x0025EBE4
		public XQualifyingChallengeRecordWindow(GameObject go)
		{
			this.m_Go = go;
			this.m_Close = (go.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RecordPool.SetupPool(go.transform.Find("Bg/Bg/ScrollView").gameObject, go.transform.Find("Bg/Bg/ScrollView/RecordTpl").gameObject, 20U, false);
			this.m_ScrollView = (go.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.MatchTotalWin = (go.transform.FindChild("Bg/Bg/Message/Win/Label").GetComponent("XUILabel") as IXUILabel);
			this.MatchTotalLose = (go.transform.FindChild("Bg/Bg/Message/Lose/Label").GetComponent("XUILabel") as IXUILabel);
			this.RateOfTotalWin = (go.transform.FindChild("Bg/Bg/Message/Rate/Label").GetComponent("XUILabel") as IXUILabel);
			this.MaxConsecutiveWin = (go.transform.FindChild("Bg/Bg/Message/ConsWin/Label").GetComponent("XUILabel") as IXUILabel);
			this.MaxConsecutiveLose = (go.transform.FindChild("Bg/Bg/Message/ConsLose/Label").GetComponent("XUILabel") as IXUILabel);
			Transform transform = go.transform.FindChild("Bg/Bg/Message/WinRate");
			for (int i = 0; i < transform.childCount; i++)
			{
				IXUILabel item = transform.FindChild(string.Format("Rate{0}/Label", i)).GetComponent("XUILabel") as IXUILabel;
				this.RateOfWinProf.Add(item);
			}
		}

		// Token: 0x0600BA74 RID: 47732 RVA: 0x00260BB7 File Offset: 0x0025EDB7
		public void SetVisible(bool v)
		{
			this.m_Go.SetActive(v);
		}

		// Token: 0x170032D9 RID: 13017
		// (get) Token: 0x0600BA75 RID: 47733 RVA: 0x00260BC8 File Offset: 0x0025EDC8
		public bool IsVisible
		{
			get
			{
				return this.m_Go.activeSelf;
			}
		}

		// Token: 0x04004AA8 RID: 19112
		public GameObject m_Go;

		// Token: 0x04004AA9 RID: 19113
		public XUIPool m_RecordPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004AAA RID: 19114
		public IXUIButton m_Close;

		// Token: 0x04004AAB RID: 19115
		public IXUIScrollView m_ScrollView;

		// Token: 0x04004AAC RID: 19116
		public IXUILabel MatchTotalWin;

		// Token: 0x04004AAD RID: 19117
		public IXUILabel MatchTotalLose;

		// Token: 0x04004AAE RID: 19118
		public IXUILabel RateOfTotalWin;

		// Token: 0x04004AAF RID: 19119
		public IXUILabel MaxConsecutiveWin;

		// Token: 0x04004AB0 RID: 19120
		public IXUILabel MaxConsecutiveLose;

		// Token: 0x04004AB1 RID: 19121
		public List<IXUILabel> RateOfWinProf = new List<IXUILabel>();
	}
}
