using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200186A RID: 6250
	public class TitleDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010461 RID: 66657 RVA: 0x003F0200 File Offset: 0x003EE400
		private void Awake()
		{
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Promote = (base.transform.FindChild("Bg/Promote").GetComponent("XUIButton") as IXUIButton);
			this.m_redPoint = (base.transform.FindChild("Bg/Promote/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_ScrollView = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_ItemTpl = base.transform.FindChild("Bg/ScrollView/ItemTpl").gameObject;
			this.m_point = base.transform.FindChild("Bg/Point").gameObject;
			this.m_ItemTpl.gameObject.SetActive(false);
			this.m_MaxTitle = base.transform.FindChild("Bg/MaxTitle").gameObject;
			this.m_CurrentTitle.Init(base.transform.FindChild("Bg/Current"));
			this.m_NextTitle.Init(base.transform.FindChild("Bg/Next"));
		}

		// Token: 0x040074FD RID: 29949
		public IXUIButton m_Close;

		// Token: 0x040074FE RID: 29950
		public IXUIButton m_Help;

		// Token: 0x040074FF RID: 29951
		public IXUIButton m_Promote;

		// Token: 0x04007500 RID: 29952
		public IXUIScrollView m_ScrollView;

		// Token: 0x04007501 RID: 29953
		public GameObject m_ItemTpl;

		// Token: 0x04007502 RID: 29954
		public GameObject m_point;

		// Token: 0x04007503 RID: 29955
		public GameObject m_MaxTitle;

		// Token: 0x04007504 RID: 29956
		public IXUISprite m_redPoint;

		// Token: 0x04007505 RID: 29957
		public TitleDisplay m_CurrentTitle = new TitleDisplay();

		// Token: 0x04007506 RID: 29958
		public TitleDisplay m_NextTitle = new TitleDisplay();
	}
}
