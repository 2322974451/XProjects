using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C7A RID: 3194
	internal class XMultiPkLoadingBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B490 RID: 46224 RVA: 0x00235940 File Offset: 0x00233B40
		private void Awake()
		{
			this.m_PkLoadingTween = (base.transform.FindChild("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			Transform transform = base.transform.FindChild("Bg/Left");
			Transform transform2 = base.transform.FindChild("Bg/Right");
			this.GetComp(transform.FindChild("P1").gameObject, 0);
			this.GetComp(transform.FindChild("P2").gameObject, 1);
			this.GetComp(transform2.FindChild("P3").gameObject, 2);
			this.GetComp(transform2.FindChild("P4").gameObject, 3);
		}

		// Token: 0x0600B491 RID: 46225 RVA: 0x002359F8 File Offset: 0x00233BF8
		public void GetComp(GameObject go, int index)
		{
			this.m_Name[index] = (go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_Score[index] = (go.transform.FindChild("Score").GetComponent("XUILabel") as IXUILabel);
			this.m_Prefession[index] = (go.transform.FindChild("Profession").GetComponent("XUISprite") as IXUISprite);
			this.m_HalfPic[index] = (go.transform.FindChild("HalfPic").GetComponent("XUITexture") as IXUITexture);
		}

		// Token: 0x04004621 RID: 17953
		public IXUITweenTool m_PkLoadingTween;

		// Token: 0x04004622 RID: 17954
		public IXUILabel[] m_Name = new IXUILabel[4];

		// Token: 0x04004623 RID: 17955
		public IXUILabel[] m_Score = new IXUILabel[4];

		// Token: 0x04004624 RID: 17956
		public IXUISprite[] m_Prefession = new IXUISprite[4];

		// Token: 0x04004625 RID: 17957
		public IXUITexture[] m_HalfPic = new IXUITexture[4];
	}
}
