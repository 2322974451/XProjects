using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001713 RID: 5907
	internal class TheExpBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F3F7 RID: 62455 RVA: 0x0036937C File Offset: 0x0036757C
		private void Awake()
		{
			this.m_parent = base.transform;
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			Transform tabTpl = base.transform.FindChild("Bg/Tabs/Panel/TabTpl");
			this.m_tabcontrol.SetTabTpl(tabTpl);
			this.m_MyPPT = (base.transform.Find("Bg/DetailFrame/NestName/MyPPT").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftCountGo = base.transform.Find("Bg/DetailFrame/NestName/Fatigue").gameObject;
			this.m_LeftCount = (base.transform.Find("Bg/DetailFrame/NestName/Fatigue/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftCount.SetText("");
			this.m_AddCount = (base.transform.Find("Bg/DetailFrame/NestName/Fatigue").GetComponent("XUIButton") as IXUIButton);
			this.m_NestBg = (base.transform.Find("Bg/DetailFrame/BgPanel/Bg").GetComponent("XUITexture") as IXUITexture);
			this.m_NestName = (base.transform.Find("Bg/DetailFrame/NestName").GetComponent("XUILabel") as IXUILabel);
			this.m_NestEquipText = (base.transform.Find("Bg/DetailFrame/NestName/Tj").GetComponent("XUILabel") as IXUILabel);
			this.m_NestMember = (base.transform.Find("Bg/DetailFrame/NestName/Member").GetComponent("XUILabel") as IXUILabel);
			this.m_NestPPT = (base.transform.Find("Bg/DetailFrame/NestName/PPT").GetComponent("XUILabel") as IXUILabel);
			this.m_NestLevel = (base.transform.Find("Bg/DetailFrame/NestName/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_GoBattle = (base.transform.Find("Bg/DetailFrame/Do").GetComponent("XUIButton") as IXUIButton);
			this.m_starImageGo = base.transform.Find("Bg/DetailFrame/Image").gameObject;
			this.m_starLab = (base.transform.Find("Bg/DetailFrame/Image/Rank").GetComponent("XUILabel") as IXUILabel);
			this.m_SweepButton = (base.transform.Find("Bg/DetailFrame/SweepButton").GetComponent("XUIButton") as IXUIButton);
			this.m_SweepCostItem = base.transform.Find("Bg/DetailFrame/SweepButton/Item").gameObject;
			this.m_SweepCostItemNum = (base.transform.Find("Bg/DetailFrame/SweepButton/Item/Cost").GetComponent("XUILabel") as IXUILabel);
			this.m_rewardBtn = (base.transform.Find("Bg/DetailFrame/Btn1").GetComponent("XUIButton") as IXUIButton);
			this.m_rankBtn = (base.transform.Find("Bg/DetailFrame/Btn2").GetComponent("XUIButton") as IXUIButton);
			this.m_Free = base.transform.Find("Bg/DetailFrame/Free").gameObject;
			this.m_Fatigue = (base.transform.Find("Bg/DetailFrame/Do/Cost").GetComponent("XUILabel") as IXUILabel);
			this.m_quanMinSpr = (base.transform.Find("Bg/DetailFrame/qmms").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.transform.Find("Bg/DetailFrame/ItemList/ItemTpl");
			this.m_RewardPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_DiffList.Add(null);
			this.m_DiffSelectList.Add(null);
			int num = 1;
			for (;;)
			{
				transform = base.transform.Find("Bg/DetailFrame/DiffList/Diff" + num.ToString());
				bool flag = transform == null;
				if (flag)
				{
					break;
				}
				this.m_DiffList.Add(transform.gameObject);
				this.m_DiffSelectList.Add(transform.Find("Select").gameObject);
				num++;
			}
			this.m_FirstPassDropGo = base.transform.Find("Bg/DetailFrame/ItemList/FirstPassDrop").gameObject;
			this.m_NormalDropGo = base.transform.Find("Bg/DetailFrame/ItemList/NormalDrop").gameObject;
		}

		// Token: 0x040068C7 RID: 26823
		public IXUIButton m_Close;

		// Token: 0x040068C8 RID: 26824
		public IXUIButton m_Help;

		// Token: 0x040068C9 RID: 26825
		public IXUILabel m_MyPPT;

		// Token: 0x040068CA RID: 26826
		public IXUILabel m_LeftCount;

		// Token: 0x040068CB RID: 26827
		public IXUIButton m_AddCount;

		// Token: 0x040068CC RID: 26828
		public GameObject m_Free;

		// Token: 0x040068CD RID: 26829
		public Transform m_parent;

		// Token: 0x040068CE RID: 26830
		public IXUITexture m_NestBg;

		// Token: 0x040068CF RID: 26831
		public IXUILabel m_NestName;

		// Token: 0x040068D0 RID: 26832
		public IXUILabel m_NestEquipText;

		// Token: 0x040068D1 RID: 26833
		public IXUILabel m_NestPPT;

		// Token: 0x040068D2 RID: 26834
		public IXUILabel m_NestLevel;

		// Token: 0x040068D3 RID: 26835
		public IXUILabel m_NestMember;

		// Token: 0x040068D4 RID: 26836
		public IXUIButton m_GoBattle;

		// Token: 0x040068D5 RID: 26837
		public IXUIButton m_SweepButton;

		// Token: 0x040068D6 RID: 26838
		public GameObject m_SweepCostItem;

		// Token: 0x040068D7 RID: 26839
		public IXUILabel m_SweepCostItemNum;

		// Token: 0x040068D8 RID: 26840
		public IXUILabel m_starLab;

		// Token: 0x040068D9 RID: 26841
		public IXUIButton m_rewardBtn;

		// Token: 0x040068DA RID: 26842
		public IXUIButton m_rankBtn;

		// Token: 0x040068DB RID: 26843
		public GameObject m_starImageGo;

		// Token: 0x040068DC RID: 26844
		public IXUISprite m_quanMinSpr;

		// Token: 0x040068DD RID: 26845
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040068DE RID: 26846
		public XUITabControl m_tabcontrol = new XUITabControl();

		// Token: 0x040068DF RID: 26847
		public XUIPool m_ExpPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040068E0 RID: 26848
		public List<GameObject> m_DiffList = new List<GameObject>();

		// Token: 0x040068E1 RID: 26849
		public List<GameObject> m_DiffSelectList = new List<GameObject>();

		// Token: 0x040068E2 RID: 26850
		public IXUILabel m_Fatigue;

		// Token: 0x040068E3 RID: 26851
		public GameObject m_LeftCountGo;

		// Token: 0x040068E4 RID: 26852
		public GameObject m_FirstPassDropGo;

		// Token: 0x040068E5 RID: 26853
		public GameObject m_NormalDropGo;
	}
}
