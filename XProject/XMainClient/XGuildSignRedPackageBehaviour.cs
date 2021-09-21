using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CF1 RID: 3313
	internal class XGuildSignRedPackageBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B96C RID: 47468 RVA: 0x0025A324 File Offset: 0x00258524
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

		// Token: 0x040049F1 RID: 18929
		public IXUILabel m_OnlineValue;

		// Token: 0x040049F2 RID: 18930
		public IXUILabel m_BufferValue;

		// Token: 0x040049F3 RID: 18931
		public IXUILabel m_SignValue;

		// Token: 0x040049F4 RID: 18932
		public IXUILabel m_CurSignValue;

		// Token: 0x040049F5 RID: 18933
		public IXUILabel m_AakLabel;

		// Token: 0x040049F6 RID: 18934
		public IXUILabel m_signLabel;

		// Token: 0x040049F7 RID: 18935
		public IXUILabel m_redNumber;

		// Token: 0x040049F8 RID: 18936
		public IXUILabel m_instructionTitle;

		// Token: 0x040049F9 RID: 18937
		public IXUIScrollView m_scrollView;

		// Token: 0x040049FA RID: 18938
		public IXUILabel m_scrollContent;

		// Token: 0x040049FB RID: 18939
		public IXUIButton m_Close;

		// Token: 0x040049FC RID: 18940
		public IXUIButton m_History;

		// Token: 0x040049FD RID: 18941
		public IXUIButton m_sign;

		// Token: 0x040049FE RID: 18942
		public IXUIButton m_Ask;

		// Token: 0x040049FF RID: 18943
		public IXUIButton m_Send;

		// Token: 0x04004A00 RID: 18944
		public IXUIButton m_Fiexd;

		// Token: 0x04004A01 RID: 18945
		public Transform m_redPoint;

		// Token: 0x04004A02 RID: 18946
		public Transform m_fixedRedPoint;

		// Token: 0x04004A03 RID: 18947
		public XGuildSignNode[] m_SignNodes = new XGuildSignNode[4];

		// Token: 0x04004A04 RID: 18948
		public IXUISprite[] m_redPakages = new IXUISprite[4];
	}
}
