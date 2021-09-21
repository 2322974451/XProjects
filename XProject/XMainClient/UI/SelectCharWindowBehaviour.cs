using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018BA RID: 6330
	internal class SelectCharWindowBehaviour : DlgBehaviourBase
	{
		// Token: 0x060107EC RID: 67564 RVA: 0x0040A81C File Offset: 0x00408A1C
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

		// Token: 0x060107ED RID: 67565 RVA: 0x0040AC30 File Offset: 0x00408E30
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

		// Token: 0x0400775C RID: 30556
		public IXUIButton m_enterworld;

		// Token: 0x0400775D RID: 30557
		public IXUILabel m_enterWorldLabel;

		// Token: 0x0400775E RID: 30558
		public IXUIButton m_return;

		// Token: 0x0400775F RID: 30559
		public Transform m_selectFrame = null;

		// Token: 0x04007760 RID: 30560
		public IXUITweenTool m_SelectTween;

		// Token: 0x04007761 RID: 30561
		public IXUISprite m_profIntro;

		// Token: 0x04007762 RID: 30562
		public IXUILabel m_profDetail;

		// Token: 0x04007763 RID: 30563
		public IXUILabel m_profType;

		// Token: 0x04007764 RID: 30564
		public XUIPool m_AttrPoint = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007765 RID: 30565
		public IXUISprite m_profName;

		// Token: 0x04007766 RID: 30566
		public IXUITweenTool m_profTween;

		// Token: 0x04007767 RID: 30567
		public IXUIInput m_createName;

		// Token: 0x04007768 RID: 30568
		public GameObject m_createNameFrame;

		// Token: 0x04007769 RID: 30569
		public IXUITweenTool m_createNameTween;

		// Token: 0x0400776A RID: 30570
		public IXUISprite m_createRandom;

		// Token: 0x0400776B RID: 30571
		public IXUISprite[] m_create_profp = new IXUISprite[XGame.RoleCount];

		// Token: 0x0400776C RID: 30572
		public Transform m_playerNameFrame = null;

		// Token: 0x0400776D RID: 30573
		public IXUILabel m_playerNameLabel;

		// Token: 0x0400776E RID: 30574
		public IXUILabel m_playerLevelLabel;

		// Token: 0x0400776F RID: 30575
		public Transform m_block;

		// Token: 0x04007770 RID: 30576
		public IXUILabel m_Version;

		// Token: 0x04007771 RID: 30577
		public IXUILabel m_preLevel;
	}
}
