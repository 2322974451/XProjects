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
	// Token: 0x02000CEB RID: 3307
	internal class XFlowerSendView : DlgBase<XFlowerSendView, XFlowerSendBehaviour>
	{
		// Token: 0x1700328D RID: 12941
		// (get) Token: 0x0600B924 RID: 47396 RVA: 0x002587AC File Offset: 0x002569AC
		public override string fileName
		{
			get
			{
				return "GameSystem/FlowerSendDlg";
			}
		}

		// Token: 0x1700328E RID: 12942
		// (get) Token: 0x0600B925 RID: 47397 RVA: 0x002587C4 File Offset: 0x002569C4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B926 RID: 47398 RVA: 0x002587D7 File Offset: 0x002569D7
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XFlowerSendDocument>(XFlowerSendDocument.uuID);
			this.InitFlowerBtnInfo();
		}

		// Token: 0x0600B927 RID: 47399 RVA: 0x002587F8 File Offset: 0x002569F8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B928 RID: 47400 RVA: 0x00258820 File Offset: 0x00256A20
		private void InitFlowerBtnInfo()
		{
			this.flowerTab.Clear();
			this.sendItem.Clear();
			this.ownCount.Clear();
			string[] array = new string[]
			{
				"icon-90",
				"icon-91",
				"icon-92"
			};
			for (int i = 0; i < XFlowerSendView.SEND_FLOWER_TYPE_COUNT; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_TabPool.FetchGameObject(false);
				gameObject.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (float)(-90 * i), 0f);
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = gameObject.transform.FindChild("T1").GetComponent("XUILabel") as IXUILabel;
				IXUILabel item = gameObject.transform.FindChild("T2").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = gameObject.transform.FindChild("P2").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)i);
				ixuilabel.SetText(XStringDefineProxy.GetString(string.Format("FLOWER_SEND_TYPE_{0}", i)));
				ixuisprite2.SetSprite(array[i]);
				this.flowerTab.Add(gameObject);
				this.ownCount.Add(item);
				this.SetTabSelect(gameObject, false);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSendRoseTypeClicked));
			}
			this.sendCountType = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("SendFlowerCount", XGlobalConfig.ListSeparator);
			for (int j = 0; j < this.sendCountType.Length; j++)
			{
				GameObject gameObject2 = base.uiBehaviour.m_SendItemPool.FetchGameObject(false);
				gameObject2.transform.parent = base.uiBehaviour.m_SendItemList.gameObject.transform;
				IXUISprite ixuisprite3 = gameObject2.GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel2 = gameObject2.transform.FindChild("T1").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(string.Format("{0}{1}", this.sendCountType[j], XStringDefineProxy.GetString("FLOWER_UNIT")));
				ixuisprite3.ID = (ulong)((long)j);
				this.sendItem.Add(gameObject2);
				ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSendItemClicked));
			}
			base.uiBehaviour.m_SendItemList.Refresh();
			this.SelectTab(XFlowerSendView.SendFlowerType.RED_ROSE);
		}

		// Token: 0x0600B929 RID: 47401 RVA: 0x00258AC4 File Offset: 0x00256CC4
		private void SelectTab(XFlowerSendView.SendFlowerType type)
		{
			bool flag = this.currSelectTab != null;
			if (flag)
			{
				this.SetTabSelect(this.currSelectTab, false);
			}
			this.currSelectTabType = type;
			int num = XFastEnumIntEqualityComparer<XFlowerSendView.SendFlowerType>.ToInt(type);
			this.currSelectTab = this.flowerTab[num];
			this.SetTabSelect(this.currSelectTab, true);
			int num2 = XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FLOWER_RED_ROSE) + XFastEnumIntEqualityComparer<XFlowerSendView.SendFlowerType>.ToInt(this.currSelectTabType);
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("Flower2Charm", XGlobalConfig.AllSeparators);
			int num3 = 0;
			for (int i = 0; i < andSeparateValue.Length; i += 2)
			{
				bool flag2 = num2 == int.Parse(andSeparateValue[i]);
				if (flag2)
				{
					num3 = int.Parse(andSeparateValue[i + 1]);
				}
			}
			for (int j = 0; j < this.sendCountType.Length; j++)
			{
				GameObject gameObject = this.sendItem[j];
				IXUILabel ixuilabel = gameObject.transform.FindChild("T3").GetComponent("XUILabel") as IXUILabel;
				int num4 = int.Parse(this.sendCountType[j]) * num3;
				ixuilabel.SetText("+" + num4);
			}
			string text = string.Format(XStringDefineProxy.GetString("FLOWER_SEND_TIP"), XStringDefineProxy.GetString(string.Format("FLOWER_SEND_TYPE_{0}", num)), num3);
			base.uiBehaviour.m_PointTip.SetText(text);
		}

		// Token: 0x0600B92A RID: 47402 RVA: 0x00258C41 File Offset: 0x00256E41
		private void OnSendRoseTypeClicked(IXUISprite sp)
		{
			this.SelectTab((XFlowerSendView.SendFlowerType)sp.ID);
		}

		// Token: 0x0600B92B RID: 47403 RVA: 0x00258C54 File Offset: 0x00256E54
		private void OnSendItemClicked(IXUISprite sp)
		{
			int num = (int)sp.ID;
			bool flag = num >= this.sendCountType.Length;
			if (!flag)
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HALL && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_GUILD_HALL && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_FAMILYGARDEN && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_LEISURE;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FLOWER_SEND_SCENE_TIP"), "fece00");
				}
				else
				{
					uint count = uint.Parse(this.sendCountType[num]);
					uint sendItemID = (uint)(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FLOWER_RED_ROSE) + XFastEnumIntEqualityComparer<XFlowerSendView.SendFlowerType>.ToInt(this.currSelectTabType));
					this._doc.SendFlower(this.roleIDSendTo, count, sendItemID);
				}
			}
		}

		// Token: 0x0600B92C RID: 47404 RVA: 0x00258D18 File Offset: 0x00256F18
		public void FlowerNotEnough(SendFlowerArg oArg)
		{
			this.sendFlowerCount = oArg.count;
			this.sendFlowerId = oArg.sendItemID;
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("BuyFlowerCost", XGlobalConfig.ListSeparator);
			int itemCount = XSingleton<UiUtility>.singleton.GetItemCount((int)oArg.sendItemID);
			for (int i = 0; i < andSeparateValue.Length; i++)
			{
				string[] array = andSeparateValue[i].Split(new char[]
				{
					'='
				});
				bool flag = array.Length == 3;
				if (flag)
				{
					bool flag2 = uint.Parse(array[0]) == this.sendFlowerId;
					if (flag2)
					{
						this.needCostID = uint.Parse(array[1]);
						this.needCostCount = (this.sendFlowerCount - (uint)itemCount) * uint.Parse(array[2]);
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.needCostID);
						string label = string.Format(XStringDefineProxy.GetString("FLOWER_SEND_NOT_ENOUGH"), new object[]
						{
							this.roleNameSendTo,
							this.sendFlowerCount,
							(long)((ulong)this.sendFlowerCount - (ulong)((long)itemCount)),
							this.needCostCount,
							(itemConf != null) ? XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U) : ""
						});
						string firstBtn = string.Format(XStringDefineProxy.GetString("FLOWER_SEND_NOT_ENOUGH_RIGHT"), (itemConf != null) ? XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U) : "");
						XSingleton<UiUtility>.singleton.ShowModalDialog(label, firstBtn, new ButtonClickEventHandler(this.OnUseMoney), 50);
						DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetCloseButtonVisible(true);
						break;
					}
				}
			}
		}

		// Token: 0x0600B92D RID: 47405 RVA: 0x00258EB8 File Offset: 0x002570B8
		private bool OnGotoBuy(IXUIButton button)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GameMall);
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FLOWER_MALL_NOT_OPEN"), "fece00");
				result = false;
			}
			else
			{
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
				this.SetVisibleWithAnimation(false, null);
				DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.SetVisible(false, true);
				DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_GameMall_Diamond);
				result = true;
			}
			return result;
		}

		// Token: 0x0600B92E RID: 47406 RVA: 0x00258F38 File Offset: 0x00257138
		private bool OnUseMoney(IXUIButton button)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.SendFlower(this.roleIDSendTo, this.sendFlowerCount, this.sendFlowerId, this.needCostID, this.needCostCount);
			return true;
		}

		// Token: 0x0600B92F RID: 47407 RVA: 0x00258F84 File Offset: 0x00257184
		public void ShowLackMoneyError()
		{
			ItemEnum itemEnum = (ItemEnum)this.needCostID;
			if (itemEnum != ItemEnum.GOLD)
			{
				if (itemEnum != ItemEnum.DRAGON_COIN)
				{
					if (itemEnum == ItemEnum.DIAMOND)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TEAMBUY_DIAMOND_LESS"), "fece00");
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_AUCT_DRAGONCOINLESS"), "fece00");
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_AUCTGOLDLESS"), "fece00");
			}
		}

		// Token: 0x0600B930 RID: 47408 RVA: 0x00259000 File Offset: 0x00257200
		public void ShowGoToMallError(SendFlowerArg oArg)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)oArg.sendItemID);
			string text = (itemConf != null) ? XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U) : "";
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FLOWER_SEND_GO_TO_MALL", new object[]
			{
				text
			}), "fece00");
		}

		// Token: 0x0600B931 RID: 47409 RVA: 0x0025905A File Offset: 0x0025725A
		public void RefreshSendFlowerInfo()
		{
			this.RefreshRoseOwnCount();
		}

		// Token: 0x0600B932 RID: 47410 RVA: 0x00259064 File Offset: 0x00257264
		public void OnSendFlowerError()
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FLOWER_SEND_FAIL"), "fece00");
		}

		// Token: 0x0600B933 RID: 47411 RVA: 0x00259084 File Offset: 0x00257284
		private void SetTabSelect(GameObject obj, bool select)
		{
			IXUISprite ixuisprite = obj.transform.FindChild("Select").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.SetAlpha((float)(select ? 1 : 0));
		}

		// Token: 0x0600B934 RID: 47412 RVA: 0x002590C4 File Offset: 0x002572C4
		public void ShowBoard(ulong roleID, string roleName)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
			this.roleIDSendTo = roleID;
			this.roleNameSendTo = roleName;
			this.RefreshRoseOwnCount();
		}

		// Token: 0x0600B935 RID: 47413 RVA: 0x00259100 File Offset: 0x00257300
		private void RefreshRoseOwnCount()
		{
			for (int i = 0; i < XFlowerSendView.SEND_FLOWER_TYPE_COUNT; i++)
			{
				int itemCount = XSingleton<UiUtility>.singleton.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FLOWER_RED_ROSE) + i);
				string text = string.Format(XStringDefineProxy.GetString("FLOWER_SEND_OWN_COUNT"), itemCount);
				this.ownCount[i].SetText(text);
			}
		}

		// Token: 0x0600B936 RID: 47414 RVA: 0x00259164 File Offset: 0x00257364
		private bool OnCloseClicked(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x040049B0 RID: 18864
		private XFlowerSendDocument _doc = null;

		// Token: 0x040049B1 RID: 18865
		private static readonly int SEND_FLOWER_TYPE_COUNT = 3;

		// Token: 0x040049B2 RID: 18866
		private string[] sendCountType;

		// Token: 0x040049B3 RID: 18867
		private List<IXUILabel> ownCount = new List<IXUILabel>();

		// Token: 0x040049B4 RID: 18868
		private List<GameObject> flowerTab = new List<GameObject>();

		// Token: 0x040049B5 RID: 18869
		private List<GameObject> sendItem = new List<GameObject>();

		// Token: 0x040049B6 RID: 18870
		private GameObject currSelectTab;

		// Token: 0x040049B7 RID: 18871
		private XFlowerSendView.SendFlowerType currSelectTabType;

		// Token: 0x040049B8 RID: 18872
		private ulong roleIDSendTo;

		// Token: 0x040049B9 RID: 18873
		private string roleNameSendTo;

		// Token: 0x040049BA RID: 18874
		private uint sendFlowerId;

		// Token: 0x040049BB RID: 18875
		private uint sendFlowerCount;

		// Token: 0x040049BC RID: 18876
		private uint needCostID;

		// Token: 0x040049BD RID: 18877
		private uint needCostCount;

		// Token: 0x020019B3 RID: 6579
		private enum SendFlowerType
		{
			// Token: 0x04007F97 RID: 32663
			RED_ROSE,
			// Token: 0x04007F98 RID: 32664
			WHITE_ROSE,
			// Token: 0x04007F99 RID: 32665
			BLUE_ENCHANTRESS
		}
	}
}
