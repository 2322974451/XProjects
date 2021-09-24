using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class AnnounceBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg");
			this.m_closedSpr = (transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_iconSpr = (transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_playerTween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = transform.FindChild("SkillFrame").transform;
			this.m_nameLab = (transform.FindChild("AttrName").GetComponent("XUILabel") as IXUILabel);
			this.m_levelLab = (transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_describeLab = (transform.FindChild("Describe").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUISprite m_closedSpr;

		public IXUISprite m_iconSpr;

		public IXUILabel m_nameLab;

		public IXUILabel m_levelLab;

		public IXUILabel m_describeLab;

		public IXUITweenTool m_playerTween = null;
	}
}
