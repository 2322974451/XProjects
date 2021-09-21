using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CDE RID: 3294
	internal class CalculatorBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B88E RID: 47246 RVA: 0x002530B0 File Offset: 0x002512B0
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

		// Token: 0x0400492C RID: 18732
		public IXUISprite m_sprMax;

		// Token: 0x0400492D RID: 18733
		public IXUISprite m_sprOK;

		// Token: 0x0400492E RID: 18734
		public IXUISprite m_sprDel;

		// Token: 0x0400492F RID: 18735
		public IXUISprite m_sprBg;

		// Token: 0x04004930 RID: 18736
		public IXUISprite[] m_sprCounter = new IXUISprite[10];
	}
}
