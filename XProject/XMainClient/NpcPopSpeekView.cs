using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D15 RID: 3349
	internal class NpcPopSpeekView : DlgBase<NpcPopSpeekView, DlgBehaviourBase>
	{
		// Token: 0x170032E6 RID: 13030
		// (get) Token: 0x0600BAE5 RID: 47845 RVA: 0x00264DD4 File Offset: 0x00262FD4
		public override string fileName
		{
			get
			{
				return "Battle/NpcPopSpeek";
			}
		}

		// Token: 0x170032E7 RID: 13031
		// (get) Token: 0x0600BAE6 RID: 47846 RVA: 0x00264DEC File Offset: 0x00262FEC
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170032E8 RID: 13032
		// (get) Token: 0x0600BAE7 RID: 47847 RVA: 0x00264E00 File Offset: 0x00263000
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600BAE8 RID: 47848 RVA: 0x00264E14 File Offset: 0x00263014
		protected override void Init()
		{
			this.m_avatar = (base.uiBehaviour.transform.FindChild("Duihua/Avatar").GetComponent("XUISprite") as IXUISprite);
			this.m_text = (base.uiBehaviour.transform.FindChild("Duihua/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_tween = (base.uiBehaviour.transform.FindChild("Duihua").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Warning = base.uiBehaviour.transform.FindChild("Duihua/Warning").gameObject;
		}

		// Token: 0x0600BAE9 RID: 47849 RVA: 0x00264EC0 File Offset: 0x002630C0
		public void ShowNpcPopSpeek(int type, int npcid, string text, float time, string fmod)
		{
			this.SetVisible(true, true);
			bool flag = type == 1;
			if (flag)
			{
				this.m_Warning.SetActive(false);
			}
			else
			{
				bool flag2 = type == 2;
				if (flag2)
				{
					this.m_Warning.SetActive(true);
				}
			}
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID((uint)npcid);
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowCurrTempMsg(text, byID.Name);
			bool flag3 = byID != null;
			if (flag3)
			{
				this.m_avatar.SetSprite(byPresentID.Avatar, byPresentID.Atlas, false);
			}
			this.m_text.SetText(text);
			this.m_tween.PlayTween(true, -1f);
			bool flag4 = !string.IsNullOrEmpty(fmod);
			if (flag4)
			{
				XSingleton<XAudioMgr>.singleton.PlayUISound(fmod, true, AudioChannel.Action);
			}
		}

		// Token: 0x0600BAEA RID: 47850 RVA: 0x00264F9F File Offset: 0x0026319F
		protected void ClosePopSpeek(object o)
		{
			this.m_tween.PlayTween(false, -1f);
		}

		// Token: 0x04004B4E RID: 19278
		private IXUISprite m_avatar;

		// Token: 0x04004B4F RID: 19279
		private IXUILabel m_text;

		// Token: 0x04004B50 RID: 19280
		private IXUITweenTool m_tween;

		// Token: 0x04004B51 RID: 19281
		private GameObject m_Warning;
	}
}
