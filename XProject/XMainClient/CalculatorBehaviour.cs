using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class CalculatorBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_sprMax = (base.transform.Find("Bg/p/max").GetComponent("XUISprite") as IXUISprite);
			this.m_sprOK = (base.transform.Find("Bg/p/ok").GetComponent("XUISprite") as IXUISprite);
			this.m_sprDel = (base.transform.Find("Bg/p/del").GetComponent("XUISprite") as IXUISprite);
			this.m_sprBg = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			for (int i = 0; i < this.m_sprCounter.Length; i++)
			{
				this.m_sprCounter[i] = (base.transform.Find("Bg/p/" + i).GetComponent("XUISprite") as IXUISprite);
			}
		}

		public IXUISprite m_sprMax;

		public IXUISprite m_sprOK;

		public IXUISprite m_sprDel;

		public IXUISprite m_sprBg;

		public IXUISprite[] m_sprCounter = new IXUISprite[10];
	}
}
