using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class TheExpBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUILabel m_MyPPT;

		public IXUILabel m_LeftCount;

		public IXUIButton m_AddCount;

		public GameObject m_Free;

		public Transform m_parent;

		public IXUITexture m_NestBg;

		public IXUILabel m_NestName;

		public IXUILabel m_NestEquipText;

		public IXUILabel m_NestPPT;

		public IXUILabel m_NestLevel;

		public IXUILabel m_NestMember;

		public IXUIButton m_GoBattle;

		public IXUIButton m_SweepButton;

		public GameObject m_SweepCostItem;

		public IXUILabel m_SweepCostItemNum;

		public IXUILabel m_starLab;

		public IXUIButton m_rewardBtn;

		public IXUIButton m_rankBtn;

		public GameObject m_starImageGo;

		public IXUISprite m_quanMinSpr;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUITabControl m_tabcontrol = new XUITabControl();

		public XUIPool m_ExpPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public List<GameObject> m_DiffList = new List<GameObject>();

		public List<GameObject> m_DiffSelectList = new List<GameObject>();

		public IXUILabel m_Fatigue;

		public GameObject m_LeftCountGo;

		public GameObject m_FirstPassDropGo;

		public GameObject m_NormalDropGo;
	}
}
