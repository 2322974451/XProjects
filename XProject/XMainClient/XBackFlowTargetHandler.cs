using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBackFlowTargetHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Hall/BfTargetHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._pointLabel = (base.transform.Find("Progress/PointValue").GetComponent("XUILabel") as IXUILabel);
			this._playerDummy = (base.transform.Find("Snapshot").GetComponent("UIDummy") as IUIDummy);
			Transform transform = base.transform.Find("Progress/Items/ItemTpl");
			this._itemsRoot = base.transform.Find("Progress/Items");
			this._itemPool.SetupPool(this._itemsRoot.gameObject, transform.gameObject, 5U, false);
			this._itemDataList = XSingleton<XGlobalConfig>.singleton.GetSequence3List("BackFlowTreasure", false);
			this._progress = (base.transform.Find("Progress").GetComponent("XUIProgress") as IXUIProgress);
			this._proSpite = (base.transform.Find("Progress").GetComponent("XUISprite") as IXUISprite);
			List<uint> backflowDataByTypeAndWorldLevel = XBackFlowDocument.Doc.GetBackflowDataByTypeAndWorldLevel(1U);
			backflowDataByTypeAndWorldLevel.Sort();
			this._dragonDescLabel = (base.transform.Find("LB/Label").GetComponent("XUILabel") as IXUILabel);
			this._dragonPointLabel = (base.transform.Find("LB/Labeltex").GetComponent("XUILabel") as IXUILabel);
			this._dragonDescLabel.SetText(XStringDefineProxy.GetString("BackFlowDragonDes"));
			uint num = (backflowDataByTypeAndWorldLevel.Count > 1) ? backflowDataByTypeAndWorldLevel[1] : 20U;
			this._dragonPointLabel.SetText(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BackFlowDragonPoint")), num));
			this._nestDescLabel = (base.transform.Find("CX/Label").GetComponent("XUILabel") as IXUILabel);
			this._nestPointLabel = (base.transform.Find("CX/Labeltex").GetComponent("XUILabel") as IXUILabel);
			this._nestDescLabel.SetText(XStringDefineProxy.GetString("BackFlowNestDes"));
			uint num2 = (backflowDataByTypeAndWorldLevel.Count > 0) ? backflowDataByTypeAndWorldLevel[0] : 10U;
			this._nestPointLabel.SetText(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BackFlowNestPoint")), num2));
			this._nestLeftTimes = (base.transform.Find("CX/Limit").GetComponent("XUILabel") as IXUILabel);
			this._dragonLeftTimes = (base.transform.Find("LB/Limit").GetComponent("XUILabel") as IXUILabel);
			this._fashionList.Clear();
			for (int i = 0; i < (int)this._itemDataList.Count; i++)
			{
				this._fashionList.Add((uint)this._itemDataList[i, 1]);
			}
			this._nestBtn = (base.transform.Find("CX/BtnGo").GetComponent("XUIButton") as IXUIButton);
			this._dragonBtn = (base.transform.Find("LB/BtnGo").GetComponent("XUIButton") as IXUIButton);
			this._nestBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoNest));
			this._dragonBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoDragon));
		}

		private bool OnGotoNest(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Activity_Nest, 0UL);
			return true;
		}

		private bool OnGotoDragon(IXUIButton button)
		{
			DlgBase<XDragonNestView, XDragonNestBehaviour>.singleton.ShowDragonNestByTypeAndDiff(1U, 0U);
			return true;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("BackFlowTarget", 1);
			this.InitOutlook();
			XBackFlowDocument.Doc.SendBackFlowActivityOperation(BackFlowActOp.BackFlowAct_TreasureData, 0U);
		}

		protected override void OnHide()
		{
			this.DiscardOutlook();
			base.OnHide();
		}

		private void DiscardOutlook()
		{
			this._outLook = null;
			bool flag = this.m_dummPool != -1;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this._dummy);
			}
			base.Return3DAvatarPool();
		}

		public override void OnUnload()
		{
			this.DiscardOutlook();
			base.OnUnload();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshUI();
		}

		private void RefreshUI()
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			uint unitType = (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(xplayerData.Profession);
			this._dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonRoleDummy(this.m_dummPool, xplayerData.RoleID, unitType, this._outLook, this._playerDummy, this._dummy);
			this._itemPool.ReturnAll(false);
			float num = (float)(this._proSpite.spriteWidth / (int)this._itemDataList.Count);
			int num2 = 0;
			for (int i = 0; i < (int)this._itemDataList.Count; i++)
			{
				GameObject gameObject = this._itemPool.FetchGameObject(false);
				gameObject.transform.localPosition = this._itemPool.TplPos + Vector3.right * (float)(i + 1) * num;
				int num3 = this._itemDataList[i, 0];
				int itemid = this._itemDataList[i, 1];
				int itemCount = this._itemDataList[i, 2];
				IXUILabel ixuilabel = gameObject.transform.Find("Exp").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(num3.ToString());
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)i);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemIconClicked));
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemid, itemCount, false);
				Transform transform = gameObject.transform.Find("ylq");
				Transform transform2 = gameObject.transform.Find("klq");
				int targetPoint = (int)XBackFlowDocument.Doc.TargetPoint;
				bool flag = targetPoint >= num3;
				if (flag)
				{
					num2 = i + 1;
				}
				transform2.gameObject.SetActive(!XBackFlowDocument.Doc.RewardedTargetIDList.Contains((uint)i) && targetPoint >= num3);
				transform.gameObject.SetActive(XBackFlowDocument.Doc.RewardedTargetIDList.Contains((uint)i));
			}
			this._progress.value = (float)num2 / (float)this._itemDataList.Count;
			this._pointLabel.SetText(XBackFlowDocument.Doc.TargetPoint.ToString());
			this._dragonLeftTimes.SetText(XBackFlowDocument.Doc.DragonLeftTimes + "/" + XSingleton<XGlobalConfig>.singleton.GetInt("BackFlowDragonFinishCountLimit"));
			this._nestLeftTimes.SetText(XBackFlowDocument.Doc.NestLeftTimes + "/" + XSingleton<XGlobalConfig>.singleton.GetInt("BackFlowNestFinishCountLimit"));
		}

		private void InitOutlook()
		{
			this._outLook = new OutLook();
			this._outLook.display_fashion = new OutLookDisplayFashion();
			this._outLook.display_fashion.display_fashions.AddRange(this._fashionList);
			this._outLook.display_fashion.hair_color_id = 0U;
			this._outLook.display_fashion.special_effects_id = 0U;
		}

		private void OnItemIconClicked(IXUISprite iSp)
		{
			int num = (int)iSp.ID;
			bool flag = num < (int)this._itemDataList.Count;
			if (flag)
			{
				int num2 = this._itemDataList[num, 0];
				int targetPoint = (int)XBackFlowDocument.Doc.TargetPoint;
				bool flag2 = !XBackFlowDocument.Doc.RewardedTargetIDList.Contains((uint)num) && targetPoint >= num2;
				if (flag2)
				{
					XBackFlowDocument.Doc.SendBackFlowActivityOperation(BackFlowActOp.BackFlowAct_GetTreasure, (uint)num);
				}
				else
				{
					int itemID = this._itemDataList[num, 1];
					XItem mainItem = XBagDocument.MakeXItem(itemID, false);
					XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, iSp, false, 0U);
				}
			}
		}

		private IUIDummy _playerDummy;

		private Transform _itemsRoot;

		private SeqList<int> _itemDataList;

		private IXUIProgress _progress;

		private IXUISprite _proSpite;

		protected XUIPool _itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private OutLook _outLook = new OutLook();

		private List<uint> _fashionList = new List<uint>();

		private XDummy _dummy;

		private IXUIButton _nestBtn;

		private IXUIButton _dragonBtn;

		private IXUILabel _pointLabel;

		private IXUILabel _dragonDescLabel;

		private IXUILabel _dragonPointLabel;

		private IXUILabel _nestDescLabel;

		private IXUILabel _nestPointLabel;

		private IXUILabel _nestLeftTimes;

		private IXUILabel _dragonLeftTimes;
	}
}
