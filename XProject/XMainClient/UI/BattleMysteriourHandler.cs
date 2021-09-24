using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class BattleMysteriourHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this.m_lblLevel.SetText("");
			this.m_lblTime.SetText("");
			this.RefreshBuff();
		}

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

		private IXUILabel m_lblLevel;

		private IXUILabel m_lblTime;

		private GameObject[] m_icons = new GameObject[3];

		private IXUISlider m_slider;
	}
}
