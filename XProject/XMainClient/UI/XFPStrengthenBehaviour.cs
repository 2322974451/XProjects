using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XFPStrengthenBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Scroll = (base.transform.FindChild("Bg/Content/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = base.transform.FindChild("Bg/Top");
			this.m_MyFightLab = (transform.FindChild("MyFightLab").GetComponent("XUILabel") as IXUILabel);
			this.m_RecommendFightLab = (transform.FindChild("RecommendFightLab").GetComponent("XUILabel") as IXUILabel);
			this.m_MyLevelLab = (transform.FindChild("RecommendFightLab/LevelLab").GetComponent("XUILabel") as IXUILabel);
			this.m_RateTex = (transform.FindChild("RateTex").GetComponent("XUITexture") as IXUITexture);
			this.m_tabParentGo = base.transform.FindChild("Bg/functions/scroll").gameObject;
		}

		public GameObject m_tabParentGo;

		public IXUIButton m_Close;

		public IXUIScrollView m_Scroll;

		public IXUILabel m_MyFightLab;

		public IXUILabel m_MyLevelLab;

		public IXUILabel m_RecommendFightLab;

		public IXUITexture m_RateTex;

		public static readonly uint FUNCTION_NUM = 4U;
	}
}
