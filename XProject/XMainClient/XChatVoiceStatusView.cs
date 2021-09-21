using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E25 RID: 3621
	internal class XChatVoiceStatusView : DlgBase<XChatVoiceStatusView, XChatVoiceStatusBehaviour>
	{
		// Token: 0x17003419 RID: 13337
		// (get) Token: 0x0600C28C RID: 49804 RVA: 0x0029DAB0 File Offset: 0x0029BCB0
		public override string fileName
		{
			get
			{
				return "GameSystem/ChatVoiceStatus";
			}
		}

		// Token: 0x1700341A RID: 13338
		// (get) Token: 0x0600C28D RID: 49805 RVA: 0x0029DAC8 File Offset: 0x0029BCC8
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700341B RID: 13339
		// (get) Token: 0x0600C28E RID: 49806 RVA: 0x0029DADC File Offset: 0x0029BCDC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700341C RID: 13340
		// (get) Token: 0x0600C28F RID: 49807 RVA: 0x0029DAF0 File Offset: 0x0029BCF0
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700341D RID: 13341
		// (get) Token: 0x0600C290 RID: 49808 RVA: 0x0029DB03 File Offset: 0x0029BD03
		// (set) Token: 0x0600C291 RID: 49809 RVA: 0x0029DB0B File Offset: 0x0029BD0B
		public bool IsNormalHide { get; set; }

		// Token: 0x0600C292 RID: 49810 RVA: 0x0029DB14 File Offset: 0x0029BD14
		protected override void OnShow()
		{
			base.OnShow();
			int num = 0;
			while ((long)num < (long)((ulong)XChatVoiceStatusBehaviour.MAX_VOL_NUM))
			{
				base.uiBehaviour.m_Volume[num].SetVisible(false);
				num++;
			}
			this.IsNormalHide = false;
		}

		// Token: 0x0600C293 RID: 49811 RVA: 0x0029DB64 File Offset: 0x0029BD64
		protected override void OnUnload()
		{
			bool flag = !this.IsNormalHide;
			if (flag)
			{
				XSingleton<XChatApolloMgr>.singleton.StopRecord(true);
			}
			this.IsNormalHide = false;
		}

		// Token: 0x0600C294 RID: 49812 RVA: 0x0029DB93 File Offset: 0x0029BD93
		public void SetNormalHide(bool normal)
		{
			this.IsNormalHide = normal;
		}

		// Token: 0x0600C295 RID: 49813 RVA: 0x0029DBA0 File Offset: 0x0029BDA0
		public void OnSetVolume(uint volume)
		{
			bool flag = !base.IsLoaded() || !base.IsVisible();
			if (!flag)
			{
				bool flag2 = volume > XChatVoiceStatusBehaviour.MAX_VOL_NUM;
				if (flag2)
				{
					volume = XChatVoiceStatusBehaviour.MAX_VOL_NUM;
				}
				else
				{
					bool flag3 = volume <= 0U;
					if (flag3)
					{
						volume = 1U;
					}
				}
				int num = 0;
				while ((long)num < (long)((ulong)XChatVoiceStatusBehaviour.MAX_VOL_NUM))
				{
					bool flag4 = base.uiBehaviour.m_Volume[num] != null;
					if (flag4)
					{
						bool flag5 = (long)num < (long)((ulong)volume);
						if (flag5)
						{
							base.uiBehaviour.m_Volume[num].SetVisible(true);
						}
						else
						{
							base.uiBehaviour.m_Volume[num].SetVisible(false);
						}
					}
					num++;
				}
			}
		}
	}
}
