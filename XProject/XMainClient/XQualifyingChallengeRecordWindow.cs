using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQualifyingChallengeRecordWindow
	{

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

		public void SetVisible(bool v)
		{
			this.m_Go.SetActive(v);
		}

		public bool IsVisible
		{
			get
			{
				return this.m_Go.activeSelf;
			}
		}

		public GameObject m_Go;

		public XUIPool m_RecordPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_Close;

		public IXUIScrollView m_ScrollView;

		public IXUILabel MatchTotalWin;

		public IXUILabel MatchTotalLose;

		public IXUILabel RateOfTotalWin;

		public IXUILabel MaxConsecutiveWin;

		public IXUILabel MaxConsecutiveLose;

		public List<IXUILabel> RateOfWinProf = new List<IXUILabel>();
	}
}
