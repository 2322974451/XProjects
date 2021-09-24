using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DemoUIBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Bg = base.transform.FindChild("Bg").gameObject;
			Transform transform = base.transform.FindChild("Bg/DebugCommitBtn");
			bool flag = null != transform;
			if (flag)
			{
				this.m_Button = (transform.GetComponent("XUIButton") as IXUIButton);
			}
			this.m_PreviousButton = (base.transform.FindChild("Bg/PreviousBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_NextButton = (base.transform.FindChild("Bg/NextBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform2 = base.transform.FindChild("Bg/DebugDlgInput");
			bool flag2 = null != transform2;
			if (flag2)
			{
				this.m_Input = (transform2.GetComponent("XUIInput") as IXUIInput);
			}
			this.m_ScrollView = (base.transform.FindChild("Bg/MessageDisplay").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_MessagePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_MessagePool.SetupPool(base.transform.FindChild("Bg/MessageDisplay").gameObject, base.transform.FindChild("Bg/MessageDisplay/MessageTpl").gameObject, DemoUI.MAX_MESSAGE_COUNT, false);
			this.m_ActiveMessages = new List<IXUILabel>((int)DemoUI.MAX_MESSAGE_COUNT);
			Transform transform3 = base.transform.FindChild("fps");
			bool flag3 = null != transform3;
			if (flag3)
			{
				this.m_fps = (transform3.GetComponent("XUILabel") as IXUILabel);
				Transform transform4 = transform3.FindChild("Open");
				bool flag4 = transform4 != null;
				if (flag4)
				{
					this.m_Open = (transform4.GetComponent("XUIButton") as IXUIButton);
				}
			}
		}

		public IXUIButton m_Button = null;

		public IXUIButton m_PreviousButton = null;

		public IXUIButton m_NextButton = null;

		public IXUIInput m_Input = null;

		public IXUIButton m_Close = null;

		public XUIPool m_MessagePool;

		public List<IXUILabel> m_ActiveMessages;

		public IXUIScrollView m_ScrollView;

		public GameObject m_Bg;

		public IXUILabel m_fps = null;

		public IXUIButton m_Open = null;
	}
}
