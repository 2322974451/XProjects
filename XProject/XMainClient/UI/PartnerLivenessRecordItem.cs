using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	public class PartnerLivenessRecordItem : MonoBehaviour
	{

		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_bgSpr = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_nameLab = (base.transform.Find("Bg/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_timeLab = (base.transform.Find("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_contentLab = (base.transform.Find("Bg/Description").GetComponent("XUILabel") as IXUILabel);
		}

		public void Refresh(PartnerLivenessRecord record)
		{
			bool flag = record == null;
			if (!flag)
			{
				this.m_nameLab.SetText(record.Name);
				this.m_timeLab.SetText(record.ShowTimeStr);
				this.m_contentLab.SetText(record.ShowString);
				this.m_sprRoot.spriteHeight = 46 + this.m_contentLab.spriteHeight;
				this.m_bgSpr.spriteHeight = this.m_sprRoot.spriteHeight;
			}
		}

		public IXUILabel m_nameLab;

		public IXUILabel m_timeLab;

		public IXUILabel m_contentLab;

		private IXUISprite m_sprRoot;

		private IXUISprite m_bgSpr;
	}
}
