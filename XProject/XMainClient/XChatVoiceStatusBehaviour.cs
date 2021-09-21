using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E1A RID: 3610
	internal class XChatVoiceStatusBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C231 RID: 49713 RVA: 0x0029B9A4 File Offset: 0x00299BA4
		private void Awake()
		{
			int num = 0;
			while ((long)num < (long)((ulong)XChatVoiceStatusBehaviour.MAX_VOL_NUM))
			{
				IXUISprite item = base.transform.FindChild("Bg/SpeakPanel/speakstatus/Info/P" + num.ToString()).GetComponent("XUISprite") as IXUISprite;
				this.m_Volume.Add(item);
				num++;
			}
		}

		// Token: 0x04005305 RID: 21253
		public static uint MAX_VOL_NUM = 7U;

		// Token: 0x04005306 RID: 21254
		public List<IXUISprite> m_Volume = new List<IXUISprite>();
	}
}
