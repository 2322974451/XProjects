using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class NpcPopSpeekView : DlgBase<NpcPopSpeekView, DlgBehaviourBase>
	{

		public override string fileName
		{
			get
			{
				return "Battle/NpcPopSpeek";
			}
		}

		public override int layer
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

		protected override void Init()
		{
			this.m_avatar = (base.uiBehaviour.transform.FindChild("Duihua/Avatar").GetComponent("XUISprite") as IXUISprite);
			this.m_text = (base.uiBehaviour.transform.FindChild("Duihua/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_tween = (base.uiBehaviour.transform.FindChild("Duihua").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Warning = base.uiBehaviour.transform.FindChild("Duihua/Warning").gameObject;
		}

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

		protected void ClosePopSpeek(object o)
		{
			this.m_tween.PlayTween(false, -1f);
		}

		private IXUISprite m_avatar;

		private IXUILabel m_text;

		private IXUITweenTool m_tween;

		private GameObject m_Warning;
	}
}
