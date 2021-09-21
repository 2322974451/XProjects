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
	// Token: 0x02000A1E RID: 2590
	internal class XBackFlowTargetHandler : DlgHandlerBase
	{
		// Token: 0x17002EBD RID: 11965
		// (get) Token: 0x06009E62 RID: 40546 RVA: 0x0019FCA8 File Offset: 0x0019DEA8
		protected override string FileName
		{
			get
			{
				return "Hall/BfTargetHandler";
			}
		}

		// Token: 0x06009E63 RID: 40547 RVA: 0x0019FCC0 File Offset: 0x0019DEC0
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

		// Token: 0x06009E64 RID: 40548 RVA: 0x001A0024 File Offset: 0x0019E224
		private bool OnGotoNest(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Activity_Nest, 0UL);
			return true;
		}

		// Token: 0x06009E65 RID: 40549 RVA: 0x001A004C File Offset: 0x0019E24C
		private bool OnGotoDragon(IXUIButton button)
		{
			DlgBase<XDragonNestView, XDragonNestBehaviour>.singleton.ShowDragonNestByTypeAndDiff(1U, 0U);
			return true;
		}

		// Token: 0x06009E66 RID: 40550 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06009E67 RID: 40551 RVA: 0x001A006C File Offset: 0x0019E26C
		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("BackFlowTarget", 1);
			this.InitOutlook();
			XBackFlowDocument.Doc.SendBackFlowActivityOperation(BackFlowActOp.BackFlowAct_TreasureData, 0U);
		}

		// Token: 0x06009E68 RID: 40552 RVA: 0x001A0097 File Offset: 0x0019E297
		protected override void OnHide()
		{
			this.DiscardOutlook();
			base.OnHide();
		}

		// Token: 0x06009E69 RID: 40553 RVA: 0x001A00A8 File Offset: 0x0019E2A8
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

		// Token: 0x06009E6A RID: 40554 RVA: 0x001A00EB File Offset: 0x0019E2EB
		public override void OnUnload()
		{
			this.DiscardOutlook();
			base.OnUnload();
		}

		// Token: 0x06009E6B RID: 40555 RVA: 0x001A00FC File Offset: 0x0019E2FC
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshUI();
		}

		// Token: 0x06009E6C RID: 40556 RVA: 0x001A0110 File Offset: 0x0019E310
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

		// Token: 0x06009E6D RID: 40557 RVA: 0x001A03EC File Offset: 0x0019E5EC
		private void InitOutlook()
		{
			this._outLook = new OutLook();
			this._outLook.display_fashion = new OutLookDisplayFashion();
			this._outLook.display_fashion.display_fashions.AddRange(this._fashionList);
			this._outLook.display_fashion.hair_color_id = 0U;
			this._outLook.display_fashion.special_effects_id = 0U;
		}

		// Token: 0x06009E6E RID: 40558 RVA: 0x001A0458 File Offset: 0x0019E658
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

		// Token: 0x0400382C RID: 14380
		private IUIDummy _playerDummy;

		// Token: 0x0400382D RID: 14381
		private Transform _itemsRoot;

		// Token: 0x0400382E RID: 14382
		private SeqList<int> _itemDataList;

		// Token: 0x0400382F RID: 14383
		private IXUIProgress _progress;

		// Token: 0x04003830 RID: 14384
		private IXUISprite _proSpite;

		// Token: 0x04003831 RID: 14385
		protected XUIPool _itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003832 RID: 14386
		private OutLook _outLook = new OutLook();

		// Token: 0x04003833 RID: 14387
		private List<uint> _fashionList = new List<uint>();

		// Token: 0x04003834 RID: 14388
		private XDummy _dummy;

		// Token: 0x04003835 RID: 14389
		private IXUIButton _nestBtn;

		// Token: 0x04003836 RID: 14390
		private IXUIButton _dragonBtn;

		// Token: 0x04003837 RID: 14391
		private IXUILabel _pointLabel;

		// Token: 0x04003838 RID: 14392
		private IXUILabel _dragonDescLabel;

		// Token: 0x04003839 RID: 14393
		private IXUILabel _dragonPointLabel;

		// Token: 0x0400383A RID: 14394
		private IXUILabel _nestDescLabel;

		// Token: 0x0400383B RID: 14395
		private IXUILabel _nestPointLabel;

		// Token: 0x0400383C RID: 14396
		private IXUILabel _nestLeftTimes;

		// Token: 0x0400383D RID: 14397
		private IXUILabel _dragonLeftTimes;
	}
}
