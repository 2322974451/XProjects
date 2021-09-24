using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SelectCharWindowBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/SelectFrame/EnterGame");
			this.m_enterworld = (transform.GetComponent("XUIButton") as IXUIButton);
			this.m_enterWorldLabel = (base.transform.Find("Bg/SelectFrame/EnterGame/Label").GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.FindChild("Bg/Return");
			this.m_return = (transform.GetComponent("XUIButton") as IXUIButton);
			this.m_selectFrame = base.transform.FindChild("Bg/SelectFrame");
			this.m_SelectTween = (base.transform.FindChild("Bg/SelectFrame").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_profName = (base.transform.FindChild("Bg/SelectFrame/ProfName").GetComponent("XUISprite") as IXUISprite);
			this.m_profIntro = (base.transform.FindChild("Bg/SelectFrame/ProfName/ProfIntro").GetComponent("XUISprite") as IXUISprite);
			this.m_profDetail = (base.transform.Find("Bg/SelectFrame/ProfName/ProfIntro/Detail").GetComponent("XUILabel") as IXUILabel);
			this.m_profType = (base.transform.Find("Bg/SelectFrame/ProfName/ProfIntro/Attr").GetComponent("XUILabel") as IXUILabel);
			this.m_profTween = (base.transform.FindChild("Bg/SelectFrame/ProfName").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_profTween.SetTargetGameObject(this.m_profTween.gameObject);
			transform = base.transform.FindChild("Bg/SelectFrame/ProfName/ProfIntro/Point");
			this.m_AttrPoint.SetupPool(transform.parent.gameObject, transform.gameObject, 40U, false);
			this.m_createName = (base.transform.FindChild("Bg/SelectFrame/NameFrame/PlayerName").GetComponent("XUIInput") as IXUIInput);
			this.m_preLevel = (base.transform.Find("Bg/SelectFrame/NameFrame/PlayerName/PreLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_createNameFrame = base.transform.FindChild("Bg/SelectFrame/NameFrame").gameObject;
			this.m_createNameTween = (base.transform.FindChild("Bg/SelectFrame/NameFrame").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_createRandom = (base.transform.FindChild("Bg/SelectFrame/NameFrame/Random").GetComponent("XUISprite") as IXUISprite);
			this.m_playerNameFrame = base.transform.Find("Bg/SelectFrame/PlayerName");
			this.m_playerNameLabel = (base.transform.Find("Bg/SelectFrame/PlayerName/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_playerLevelLabel = (base.transform.Find("Bg/SelectFrame/PlayerName/Level").GetComponent("XUILabel") as IXUILabel);
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("OpenProfession").Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < XGame.RoleCount; i++)
			{
				this.m_create_profp[i] = (base.transform.FindChild("Bg/SelectFrame/ProfFrame/Prof" + (i + 1)).GetComponent("XUISprite") as IXUISprite);
				this.m_create_profp[i].ID = (ulong)((long)(i + 1));
				bool active = true;
				for (int j = 0; j < array.Length; j++)
				{
					bool flag = int.Parse(array[j]) == i + 1;
					if (flag)
					{
						active = false;
						break;
					}
				}
				this.m_create_profp[i].gameObject.transform.Find("Disable").gameObject.SetActive(active);
			}
			this.m_block = base.transform.Find("Bg/Block");
			this.m_Version = (base.transform.Find("Bg/LabelVersion").GetComponent("XUILabel") as IXUILabel);
			this.m_selectFrame.gameObject.SetActive(false);
			this.m_return.SetVisible(false);
			this.m_block.gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			this.m_enterworld = null;
			this.m_enterWorldLabel = null;
			this.m_return = null;
			this.m_selectFrame = null;
			this.m_SelectTween = null;
			this.m_profIntro = null;
			this.m_profName = null;
			this.m_profTween = null;
			this.m_createName = null;
			this.m_createNameFrame = null;
			this.m_createNameTween = null;
			this.m_createRandom = null;
			this.m_create_profp = new IXUISprite[XGame.RoleCount];
			for (int i = 0; i < this.m_create_profp.Length; i++)
			{
				this.m_create_profp[i] = null;
			}
			this.m_playerNameFrame = null;
			this.m_playerNameLabel = null;
			this.m_playerLevelLabel = null;
			this.m_block = null;
			this.m_Version = null;
		}

		public IXUIButton m_enterworld;

		public IXUILabel m_enterWorldLabel;

		public IXUIButton m_return;

		public Transform m_selectFrame = null;

		public IXUITweenTool m_SelectTween;

		public IXUISprite m_profIntro;

		public IXUILabel m_profDetail;

		public IXUILabel m_profType;

		public XUIPool m_AttrPoint = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUISprite m_profName;

		public IXUITweenTool m_profTween;

		public IXUIInput m_createName;

		public GameObject m_createNameFrame;

		public IXUITweenTool m_createNameTween;

		public IXUISprite m_createRandom;

		public IXUISprite[] m_create_profp = new IXUISprite[XGame.RoleCount];

		public Transform m_playerNameFrame = null;

		public IXUILabel m_playerNameLabel;

		public IXUILabel m_playerLevelLabel;

		public Transform m_block;

		public IXUILabel m_Version;

		public IXUILabel m_preLevel;
	}
}
