using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XChatVoiceStatusView : DlgBase<XChatVoiceStatusView, XChatVoiceStatusBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ChatVoiceStatus";
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public bool IsNormalHide { get; set; }

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

		protected override void OnUnload()
		{
			bool flag = !this.IsNormalHide;
			if (flag)
			{
				XSingleton<XChatApolloMgr>.singleton.StopRecord(true);
			}
			this.IsNormalHide = false;
		}

		public void SetNormalHide(bool normal)
		{
			this.IsNormalHide = normal;
		}

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
