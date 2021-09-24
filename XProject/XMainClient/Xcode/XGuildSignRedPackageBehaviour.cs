using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XGuildSignRedPackageBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_History = (base.transform.FindChild("Bg/History").GetComponent("XUIButton") as IXUIButton);
			this.m_sign = (base.transform.FindChild("Bg/Bg/Dontbelazy").GetComponent("XUIButton") as IXUIButton);
			this.m_Ask = (base.transform.FindChild("Bg/RedPacketFrame/p/Status/Ask").GetComponent("XUIButton") as IXUIButton);
			this.m_Send = (base.transform.FindChild("Bg/RedPacketFrame/p/Status/Send").GetComponent("XUIButton") as IXUIButton);
			this.m_Fiexd = (base.transform.FindChild("Bg/Fiexd").GetComponent("XUIButton") as IXUIButton);
			this.m_fixedRedPoint = base.transform.FindChild("Bg/Fiexd/RedPoint");
			this.m_AakLabel = (base.transform.FindChild("Bg/RedPacketFrame/p/Status/Ask/Require").GetComponent("XUILabel") as IXUILabel);
			this.m_signLabel = (base.transform.FindChild("Bg/Bg/Dontbelazy/Gogogo").GetComponent("XUILabel") as IXUILabel);
			this.m_OnlineValue = (base.transform.FindChild("Bg/RedPacketFrame/p/Status/OnlineValue").GetComponent("XUILabel") as IXUILabel);
			this.m_BufferValue = (base.transform.FindChild("Bg/RedPacketFrame/p/Status/Buff/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_SignValue = (base.transform.FindChild("Bg/Sign/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_CurSignValue = (base.transform.FindChild("Bg/ProgressBar/Thumb/CurrentNum/T").GetComponent("XUILabel") as IXUILabel);
			this.m_redNumber = (base.transform.FindChild("Bg/RedPacketFrame/p/Status/Number/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_instructionTitle = (base.transform.FindChild("Bg/RedPacketFrame/p/Instruction/Title").GetComponent("XUILabel") as IXUILabel);
			this.m_scrollView = (base.transform.FindChild("Bg/RedPacketFrame/p/Instruction/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_scrollContent = (base.transform.FindChild("Bg/RedPacketFrame/p/Instruction/ScrollView/Content").GetComponent("XUILabel") as IXUILabel);
			this.m_redPoint = base.transform.FindChild("Bg/History/RedPoint");
			for (int i = 0; i < 4; i++)
			{
				int num = i + 1;
				string text = string.Format("Bg/ProgressBar/BarBack/bar/progress{0}", num);
				string text2 = string.Format("Bg/ProgressBar/BarBack/circle/circle{0}", num);
				string text3 = string.Format("Bg/RedPacketFrame/p/Status/Panel/red{0}", num);
				this.m_SignNodes[i] = new XGuildSignNode(i, base.transform.FindChild(text), base.transform.FindChild(text2));
				this.m_redPakages[i] = (base.transform.FindChild(text3).GetComponent("XUISprite") as IXUISprite);
			}
		}

		public IXUILabel m_OnlineValue;

		public IXUILabel m_BufferValue;

		public IXUILabel m_SignValue;

		public IXUILabel m_CurSignValue;

		public IXUILabel m_AakLabel;

		public IXUILabel m_signLabel;

		public IXUILabel m_redNumber;

		public IXUILabel m_instructionTitle;

		public IXUIScrollView m_scrollView;

		public IXUILabel m_scrollContent;

		public IXUIButton m_Close;

		public IXUIButton m_History;

		public IXUIButton m_sign;

		public IXUIButton m_Ask;

		public IXUIButton m_Send;

		public IXUIButton m_Fiexd;

		public Transform m_redPoint;

		public Transform m_fixedRedPoint;

		public XGuildSignNode[] m_SignNodes = new XGuildSignNode[4];

		public IXUISprite[] m_redPakages = new IXUISprite[4];
	}
}
