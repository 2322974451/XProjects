using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class NextLevelSealBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_NextSealLabel = (base.transform.Find("Bg/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_NextSealTexL = (base.transform.Find("Bg/TexL").GetComponent("XUITexture") as IXUITexture);
			this.m_NextSealTexR = (base.transform.Find("Bg/TexR").GetComponent("XUITexture") as IXUITexture);
			this.m_NextSealTexM = (base.transform.Find("Bg/TexM").GetComponent("XUITexture") as IXUITexture);
			this.m_NewFunction = base.transform.Find("Bg/NewFunction");
			this.m_NewFunctionBg = (base.transform.Find("Bg/NewFunction/Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_NewFunctionBgWidth = this.m_NewFunctionBg.spriteWidth;
			Transform transform = base.transform.Find("Bg/NewFunction/NewFunction/FunctionTpl");
			this.m_NewFunctionPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
		}

		public IXUIButton m_Close;

		public IXUILabel m_NextSealLabel;

		public IXUITexture m_NextSealTexL;

		public IXUITexture m_NextSealTexR;

		public IXUITexture m_NextSealTexM;

		public Transform m_NewFunction;

		public IXUISprite m_NewFunctionBg;

		public int m_NewFunctionBgWidth;

		public XUIPool m_NewFunctionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
