using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XMultiPkLoadingBehaviour : DlgBehaviourBase
	{

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

		public void GetComp(GameObject go, int index)
		{
			this.m_Name[index] = (go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_Score[index] = (go.transform.FindChild("Score").GetComponent("XUILabel") as IXUILabel);
			this.m_Prefession[index] = (go.transform.FindChild("Profession").GetComponent("XUISprite") as IXUISprite);
			this.m_HalfPic[index] = (go.transform.FindChild("HalfPic").GetComponent("XUITexture") as IXUITexture);
		}

		public IXUITweenTool m_PkLoadingTween;

		public IXUILabel[] m_Name = new IXUILabel[4];

		public IXUILabel[] m_Score = new IXUILabel[4];

		public IXUISprite[] m_Prefession = new IXUISprite[4];

		public IXUITexture[] m_HalfPic = new IXUITexture[4];
	}
}
