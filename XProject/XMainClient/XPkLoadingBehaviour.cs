using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E4F RID: 3663
	internal class XPkLoadingBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C477 RID: 50295 RVA: 0x002AE664 File Offset: 0x002AC864
		private void Awake()
		{
			this.m_PkLoadingTween = (base.transform.FindChild("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			Transform transform = base.transform.FindChild("Bg/Left");
			Transform transform2 = base.transform.FindChild("Bg/Right");
			this.m_Name[0] = (transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_Name[1] = (transform2.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_Level[0] = (transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_Level[1] = (transform2.FindChild("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_Prefession[0] = (transform.FindChild("Profession").GetComponent("XUISprite") as IXUISprite);
			this.m_Prefession[1] = (transform2.FindChild("Profession").GetComponent("XUISprite") as IXUISprite);
			this.m_LeftSnapshot = transform.FindChild("Snapshot");
			this.m_RightSnapshot = transform2.FindChild("Snapshot");
			this.m_HalfPic[0] = (transform.Find("HalfPic").GetComponent("XUITexture") as IXUITexture);
			this.m_HalfPic[1] = (transform2.Find("HalfPic").GetComponent("XUITexture") as IXUITexture);
			Transform transform3 = transform.Find("Detail");
			Transform transform4 = transform2.Find("Detail");
			bool flag = transform3 != null;
			if (flag)
			{
				this.m_Detail[0] = transform.Find("Detail").gameObject;
				this.m_WinCount[0] = (transform.FindChild("Detail/WinCount").GetComponent("XUILabel") as IXUILabel);
				this.m_Point[0] = (transform.FindChild("Detail/Point").GetComponent("XUILabel") as IXUILabel);
				this.m_Percent[0] = (transform.FindChild("Detail/Percent").GetComponent("XUILabel") as IXUILabel);
				this.m_NearWin[0] = (transform.FindChild("Detail/NearWin").GetComponent("XUILabel") as IXUILabel);
			}
			bool flag2 = transform4 != null;
			if (flag2)
			{
				this.m_Detail[1] = transform2.Find("Detail").gameObject;
				this.m_WinCount[1] = (transform2.FindChild("Detail/WinCount").GetComponent("XUILabel") as IXUILabel);
				this.m_Point[1] = (transform2.FindChild("Detail/Point").GetComponent("XUILabel") as IXUILabel);
				this.m_Percent[1] = (transform2.FindChild("Detail/Percent").GetComponent("XUILabel") as IXUILabel);
				this.m_NearWin[1] = (transform2.FindChild("Detail/NearWin").GetComponent("XUILabel") as IXUILabel);
			}
		}

		// Token: 0x0400557F RID: 21887
		public IXUITweenTool m_PkLoadingTween;

		// Token: 0x04005580 RID: 21888
		public IXUILabel[] m_Name = new IXUILabel[2];

		// Token: 0x04005581 RID: 21889
		public IXUILabel[] m_Level = new IXUILabel[2];

		// Token: 0x04005582 RID: 21890
		public IXUILabel[] m_WinCount = new IXUILabel[2];

		// Token: 0x04005583 RID: 21891
		public IXUILabel[] m_Point = new IXUILabel[2];

		// Token: 0x04005584 RID: 21892
		public IXUILabel[] m_Percent = new IXUILabel[2];

		// Token: 0x04005585 RID: 21893
		public IXUILabel[] m_NearWin = new IXUILabel[2];

		// Token: 0x04005586 RID: 21894
		public IXUISprite[] m_Prefession = new IXUISprite[2];

		// Token: 0x04005587 RID: 21895
		public Transform m_LeftSnapshot;

		// Token: 0x04005588 RID: 21896
		public Transform m_RightSnapshot;

		// Token: 0x04005589 RID: 21897
		public IXUITexture[] m_HalfPic = new IXUITexture[2];

		// Token: 0x0400558A RID: 21898
		public GameObject[] m_Detail = new GameObject[2];
	}
}
