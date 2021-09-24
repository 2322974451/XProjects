using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XChatVoiceStatusBehaviour : DlgBehaviourBase
	{

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

		public static uint MAX_VOL_NUM = 7U;

		public List<IXUISprite> m_Volume = new List<IXUISprite>();
	}
}
