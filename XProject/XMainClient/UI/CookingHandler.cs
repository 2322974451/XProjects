using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200179A RID: 6042
	internal class CookingHandler : DlgHandlerBase
	{
		// Token: 0x17003851 RID: 14417
		// (get) Token: 0x0600F97F RID: 63871 RVA: 0x00395E98 File Offset: 0x00394098
		protected override string FileName
		{
			get
			{
				return "Home/CookingHandler";
			}
		}

		// Token: 0x0600F980 RID: 63872 RVA: 0x00395EAF File Offset: 0x003940AF
		protected override void Init()
		{
			base.Init();
			this.InitUIPool();
			this.InitProperties();
			this.InitClickCallback();
		}

		// Token: 0x0600F981 RID: 63873 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F982 RID: 63874 RVA: 0x00395ECE File Offset: 0x003940CE
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshUI();
		}

		// Token: 0x0600F983 RID: 63875 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F984 RID: 63876 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F985 RID: 63877 RVA: 0x00395EDF File Offset: 0x003940DF
		public void RefreshUI()
		{
			this._selectedFoodItem = null;
			this._curCookLevel = HomeMainDocument.Doc.GetCookingLevel();
			this.InitLeftPanel();
			this.InitSelectedFood();
			this.RefreshRightDetail(this._curCookID);
		}

		// Token: 0x0600F986 RID: 63878 RVA: 0x00395F14 File Offset: 0x00394114
		protected void InitSelectedFood()
		{
			bool flag = this._levelItems.Count <= 0;
			if (!flag)
			{
				bool flag2 = null != this._selectedFoodItem;
				IXUICheckBox ixuicheckBox;
				if (flag2)
				{
					ixuicheckBox = (this._selectedFoodItem.GetComponent("XUICheckBox") as IXUICheckBox);
				}
				else
				{
					bool flag3 = this._childCuisineItems.Count > 0;
					if (flag3)
					{
						ixuicheckBox = (this._childCuisineItems[0].GetComponent("XUICheckBox") as IXUICheckBox);
					}
					else
					{
						IXUITweenTool ixuitweenTool = this._levelItems[0].GetComponent("XUIPlayTween") as IXUITweenTool;
						ixuitweenTool.PlayTween(true, -1f);
						ixuicheckBox = (this._levelItems[0].Find("Children").GetChild(0).GetComponent("XUICheckBox") as IXUICheckBox);
					}
				}
				bool flag4 = ixuicheckBox == null;
				if (!flag4)
				{
					this._curCookID = (uint)ixuicheckBox.ID;
					ixuicheckBox.ForceSetFlag(true);
					Transform parent = ixuicheckBox.gameObject.transform.parent.parent;
					Transform transform = parent.Find("ToggleSprite");
					transform.gameObject.SetActive(true);
					this.SwitchToggleSprite(transform);
				}
			}
		}

		// Token: 0x0600F987 RID: 63879 RVA: 0x00396050 File Offset: 0x00394250
		private void SwitchToggleSprite(Transform spriteToggle)
		{
			bool flag = this._toggleSprite != null && this._toggleSprite != spriteToggle;
			if (flag)
			{
				this._toggleSprite.gameObject.SetActive(false);
			}
			this._toggleSprite = spriteToggle;
		}

		// Token: 0x0600F988 RID: 63880 RVA: 0x00396098 File Offset: 0x00394298
		protected void InitProperties()
		{
			this._cookingProgressFrame = base.transform.Find("Content/CookingProgressFrame");
			this._cookingProgressFrame.gameObject.SetActive(true);
			Transform transform = this._cookingProgressFrame.Find("Making/Bar");
			this._cookingSlider = (transform.GetComponent("XUISlider") as IXUISlider);
			this._doBtn = (this._cookingProgressFrame.Find("Do").GetComponent("XUIButton") as IXUIButton);
			this._cancelMakingBtn = (this._cookingProgressFrame.Find("Cancel").GetComponent("XUIButton") as IXUIButton);
			this._doBtn.gameObject.SetActive(false);
			this._cookingItem = this._cookingProgressFrame.Find("Item");
			this._successEffect = this._cookingProgressFrame.Find("Suc");
			this._cookingEffect = this._cookingProgressFrame.Find("effex");
			this._makingTrans = this._cookingProgressFrame.Find("Making");
			this._successEffect.gameObject.SetActive(false);
			this._cookingProgressFrame.gameObject.SetActive(false);
			this._makeBtn = (base.transform.Find("MakeBtn").GetComponent("XUIButton") as IXUIButton);
			this._oneKeyCookingBtn = (base.transform.Find("AllMake").GetComponent("XUIButton") as IXUIButton);
			this._oneKeyCookingBtn.gameObject.SetActive(true);
			this._upCuisineLevel = (base.transform.Find("Content/CookLevel/NameLab").GetComponent("XUILabel") as IXUILabel);
			this._upExpPercent = (base.transform.Find("Content/CookLevel/planLab").GetComponent("XUILabel") as IXUILabel);
			this._upProgress = (base.transform.Find("Content/CookLevel/Bar").GetComponent("XUISlider") as IXUISlider);
			this._middCuisineItem = base.transform.Find("Content/CookItem/Item");
			this._middCuisineName = (base.transform.Find("Content/CookItem/Name").GetComponent("XUILabel") as IXUILabel);
			this._middCuisineAddExp = (base.transform.Find("Content/CookItem/Exp").GetComponent("XUILabel") as IXUILabel);
			this._middMakeTimes = (base.transform.Find("Content/CookItem/Tips").GetComponent("XUILabel") as IXUILabel);
			this._downCuisineDec = (base.transform.Find("Content/ContentLab").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600F989 RID: 63881 RVA: 0x00396344 File Offset: 0x00394544
		protected void InitUIPool()
		{
			this._tabs = base.transform.Find("Tabs");
			this._tabTable = (this._tabs.Find("UITable").GetComponent("XUITable") as IXUITable);
			this._needMats = base.transform.Find("Content/Items");
			Transform transform = this._tabs.Find("UITable/TittleTpl");
			Transform transform2 = this._tabs.Find("UITable/ChildTpl");
			this._levelCuisinePool.SetupPool(this._tabs.gameObject, transform.gameObject, 2U, false);
			this._cuisineChildPool.SetupPool(this._tabs.gameObject, transform2.gameObject, 2U, false);
			this._foodItemPool.SetupPool(this._needMats.gameObject, this._needMats.Find("Item").gameObject, 2U, false);
		}

		// Token: 0x0600F98A RID: 63882 RVA: 0x00396434 File Offset: 0x00394634
		protected void InitLeftPanel()
		{
			uint num = Math.Min(this._curCookLevel + 1U, XHomeCookAndPartyDocument.Doc.GetMaxLevel());
			this._levelCuisinePool.ReturnAll(false);
			this._cuisineChildPool.ReturnAll(true);
			this._childCuisineItems.Clear();
			this._levelItems.Clear();
			XHomeCookAndPartyDocument.Doc.SortFoodTableData();
			CookingFoodInfo.RowData[] table = XHomeCookAndPartyDocument.CookingFoolInfoTable.Table;
			int num2 = 0;
			int num3 = (int)this._levelCuisinePool.TplPos.y;
			Transform transform = null;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = (ulong)table[i].Level != (ulong)((long)num2);
				if (flag)
				{
					num2++;
					bool flag2 = (long)num2 > (long)((ulong)num);
					if (flag2)
					{
						break;
					}
					transform = this.SetLevelItem(ref num3, num2);
					this._levelItems.Add(transform);
				}
				CookingFoodInfo.RowData rowData = table[i];
				uint basicTypeID = XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID;
				foreach (uint num4 in rowData.Profession)
				{
					bool flag3 = num4 == basicTypeID;
					if (flag3)
					{
						this.SetChildItem(ref num3, table[i], transform.Find("Children"));
						break;
					}
				}
			}
			this._tabTable.Reposition();
		}

		// Token: 0x0600F98B RID: 63883 RVA: 0x00396594 File Offset: 0x00394794
		protected Transform SetLevelItem(ref int height, int level)
		{
			GameObject gameObject = this._levelCuisinePool.FetchGameObject(false);
			gameObject.transform.parent = this._tabs.Find("UITable");
			gameObject.transform.localPosition = new Vector3(this._levelCuisinePool.TplPos.x, (float)height, 0f);
			IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)level);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClicklevel));
			height -= this._levelCuisinePool.TplHeight;
			IXUILabel ixuilabel = gameObject.transform.Find("NameLab").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("FoodLevel"), level));
			IXUILabel ixuilabel2 = gameObject.transform.Find("ToggleSprite/NameLab").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("FoodLevel"), level));
			Transform transform = gameObject.transform.Find("ToggleSprite");
			transform.gameObject.SetActive(false);
			return gameObject.transform;
		}

		// Token: 0x0600F98C RID: 63884 RVA: 0x003966E0 File Offset: 0x003948E0
		protected Transform SetChildItem(ref int height, CookingFoodInfo.RowData info, Transform parent)
		{
			GameObject gameObject = this._cuisineChildPool.FetchGameObject(false);
			gameObject.transform.parent = parent;
			gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this._levelCuisinePool.TplHeight - (parent.childCount - 1) * this._cuisineChildPool.TplHeight), 0f);
			height -= this._cuisineChildPool.TplHeight;
			Transform transform = gameObject.transform.Find("NewSpr");
			transform.gameObject.SetActive(XHomeCookAndPartyDocument.Doc.IsNewAddedCookItem(info.FoodID));
			IXUILabel ixuilabel = gameObject.transform.Find("SelectLab").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = gameObject.transform.Find("UnSelectLab").GetComponent("XUILabel") as IXUILabel;
			IXUICheckBox ixuicheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
			ixuilabel.SetText(info.FoodName);
			IXUISprite ixuisprite = gameObject.transform.Find("Sprite").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(null);
			ixuisprite.gameObject.GetComponent<BoxCollider>().enabled = false;
			ixuicheckBox.SetEnable(true);
			bool flag = HomeMainDocument.Doc.IsFoodIDActive(info.FoodID);
			if (flag)
			{
				ixuicheckBox.ID = (ulong)info.FoodID;
				ixuilabel2.SetText(info.FoodName);
			}
			else
			{
				ixuilabel2.SetText("? ? ? ?");
				ixuicheckBox.ID = 0UL;
				ixuicheckBox.SetEnable(false);
				ixuisprite.gameObject.GetComponent<BoxCollider>().enabled = true;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnUnactiveFood));
			}
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCuisineToggleChanged));
			gameObject.transform.localScale = Vector3.one;
			bool flag2 = this._preCookID != 0UL && (ulong)info.FoodID == this._preCookID;
			if (flag2)
			{
				this._selectedFoodItem = gameObject.transform;
			}
			bool flag3 = gameObject.transform.parent.localScale.y > 0.02f;
			if (flag3)
			{
				this._childCuisineItems.Add(gameObject.transform);
			}
			return gameObject.transform;
		}

		// Token: 0x0600F98D RID: 63885 RVA: 0x00396938 File Offset: 0x00394B38
		protected void OnClicklevel(IXUISprite uiSprite)
		{
			foreach (object obj in uiSprite.gameObject.transform)
			{
				Transform transform = (Transform)obj;
			}
		}

		// Token: 0x0600F98E RID: 63886 RVA: 0x00396994 File Offset: 0x00394B94
		protected void OnUnactiveFood(IXUISprite sprite)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CookMenuNotActive"), "fece00");
		}

		// Token: 0x0600F98F RID: 63887 RVA: 0x003969B4 File Offset: 0x00394BB4
		protected void InitClickCallback()
		{
			this._makeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.StartToCooking));
			this._oneKeyCookingBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OneShotCooking));
			this._doBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCookingButtonOK));
			this._cancelMakingBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.CancelCooking));
		}

		// Token: 0x0600F990 RID: 63888 RVA: 0x00396A24 File Offset: 0x00394C24
		protected bool OnCuisineToggleChanged(IXUICheckBox checkbox)
		{
			bool bChecked = checkbox.bChecked;
			if (bChecked)
			{
				bool flag = checkbox.ID > 0UL;
				if (flag)
				{
					this._curCookID = (uint)checkbox.ID;
					Transform transform = checkbox.gameObject.transform.parent.parent.Find("ToggleSprite");
					transform.gameObject.SetActive(true);
					this.SwitchToggleSprite(transform);
					bool flag2 = XHomeCookAndPartyDocument.Doc.RemoveNewCookItem(this._curCookID);
					if (flag2)
					{
						Transform transform2 = checkbox.gameObject.transform.Find("NewSpr");
						transform2.gameObject.SetActive(false);
					}
					this.RefreshRightDetail(this._curCookID);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600F991 RID: 63889 RVA: 0x00396AEC File Offset: 0x00394CEC
		protected void RefreshRightDetail(uint cuisineId)
		{
			CookingFoodInfo.RowData cookInfoByCuisineID = XHomeCookAndPartyDocument.Doc.GetCookInfoByCuisineID(cuisineId);
			bool flag = cookInfoByCuisineID != null;
			if (flag)
			{
				this._preCookID = (ulong)this._curCookID;
				this._upCuisineLevel.SetText(this._curCookLevel.ToString());
				uint cookingExp = HomeMainDocument.Doc.GetCookingExp();
				uint expByCookLevel = XHomeCookAndPartyDocument.Doc.GetExpByCookLevel(this._curCookLevel);
				this._upExpPercent.SetText(cookingExp + "/" + expByCookLevel);
				bool flag2 = expByCookLevel == 0U;
				if (flag2)
				{
					this._upProgress.Value = 0f;
				}
				else
				{
					this._upProgress.Value = cookingExp / expByCookLevel;
				}
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this._middCuisineItem.gameObject, (int)cuisineId, 1, false);
				IXUISprite ixuisprite = this._middCuisineItem.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)cuisineId;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				this._middCuisineAddExp.SetText(cookInfoByCuisineID.AddExp.ToString());
				this._middCuisineName.SetText(cookInfoByCuisineID.FoodName);
				string text = "";
				bool flag3 = cookInfoByCuisineID.Frequency > 0U;
				if (flag3)
				{
					text = string.Format(XSingleton<XStringTable>.singleton.GetString("CookItemMaxTimes"), cookInfoByCuisineID.Frequency);
				}
				this._middMakeTimes.SetText(text);
				this._downCuisineDec.SetText(cookInfoByCuisineID.Desc);
				this._foodItemPool.ReturnAll(false);
				for (int i = 0; i < cookInfoByCuisineID.Ingredients.Count; i++)
				{
					GameObject gameObject = this._foodItemPool.FetchGameObject(false);
					IXUILabel ixuilabel = gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					uint num = cookInfoByCuisineID.Ingredients[i, 0];
					ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)num);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)num, (int)cookInfoByCuisineID.Ingredients[i, 1], true);
					IXUISprite ixuisprite2 = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)num;
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					string text2 = itemCount + "/" + cookInfoByCuisineID.Ingredients[i, 1];
					bool flag4 = itemCount < (ulong)cookInfoByCuisineID.Ingredients[i, 1];
					if (flag4)
					{
						text2 = string.Concat(new object[]
						{
							"[ff0000]",
							itemCount,
							"/",
							cookInfoByCuisineID.Ingredients[i, 1],
							"[-]"
						});
					}
					ixuilabel.SetText(text2);
					gameObject.transform.localPosition = new Vector3(this._foodItemPool.TplPos.x + (float)(i * this._foodItemPool.TplWidth), this._foodItemPool.TplPos.y, 0f);
				}
				bool flag5 = cookInfoByCuisineID.Level > this._curCookLevel;
				if (flag5)
				{
					this._oneKeyCookingBtn.SetEnable(false, false);
					this._makeBtn.SetEnable(false, false);
				}
				else
				{
					this._oneKeyCookingBtn.SetEnable(true, false);
					this._makeBtn.SetEnable(true, false);
				}
			}
		}

		// Token: 0x0600F992 RID: 63890 RVA: 0x00396E9D File Offset: 0x0039509D
		protected void SendMakeCuisineReq()
		{
			XHomeCookAndPartyDocument.Doc.ReqGardenCookingFood(this._curCookID);
		}

		// Token: 0x0600F993 RID: 63891 RVA: 0x00396EB4 File Offset: 0x003950B4
		protected bool StartToCooking(IXUIButton cook)
		{
			bool flag = XHomeCookAndPartyDocument.Doc.IsTimeLimited(this._curCookID);
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FoodMakingMaxTimes"), "fece00");
				result = false;
			}
			else
			{
				bool flag2 = this.IsValidCooking();
				if (flag2)
				{
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/Cook_ing", true, AudioChannel.Action);
					XHomeCookAndPartyDocument.Doc.StartCreateFood(this._curCookID);
					this.RefreshProgressFrame();
					result = true;
				}
				else
				{
					bool isOneKeyCooking = this._isOneKeyCooking;
					if (isOneKeyCooking)
					{
						this.CancelCooking(null);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FoodMatsLack"), "fece00");
					}
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600F994 RID: 63892 RVA: 0x00396F70 File Offset: 0x00395170
		protected bool OneShotCooking(IXUIButton cook)
		{
			bool flag = XHomeCookAndPartyDocument.Doc.IsTimeLimited(this._curCookID);
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FoodMakingMaxTimes"), "fece00");
				result = false;
			}
			else
			{
				bool flag2 = this.IsValidCooking();
				if (flag2)
				{
					this.OneKeyContinue(true);
					this.StartToCooking(null);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FoodMatsLack"), "fece00");
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600F995 RID: 63893 RVA: 0x00396FFA File Offset: 0x003951FA
		private void OneKeyContinue(bool continueCooking)
		{
			this._isOneKeyCooking = continueCooking;
			this._cancelMakingBtn.gameObject.SetActive(continueCooking);
			this._doBtn.gameObject.SetActive(!continueCooking);
		}

		// Token: 0x0600F996 RID: 63894 RVA: 0x0039702C File Offset: 0x0039522C
		private bool CancelCooking(IXUIButton button)
		{
			this.OneKeyContinue(false);
			XHomeCookAndPartyDocument.Doc.StopCreateFoodTimer();
			XSingleton<XAudioMgr>.singleton.StopUISound();
			this._cookingEffect.gameObject.SetActive(false);
			this._cookingProgressFrame.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0600F997 RID: 63895 RVA: 0x00397084 File Offset: 0x00395284
		protected void RefreshProgressFrame()
		{
			this._cookingProgressFrame.gameObject.SetActive(true);
			this._successEffect.gameObject.SetActive(false);
			this._cookingSlider.Value = 0f;
			this._cookingEffect.gameObject.SetActive(true);
			this._makingTrans.gameObject.SetActive(true);
			this._doBtn.gameObject.SetActive(false);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this._cookingItem.gameObject, (int)this._curCookID, 1, false);
			this._cookingItem.gameObject.SetActive(false);
		}

		// Token: 0x0600F998 RID: 63896 RVA: 0x00397134 File Offset: 0x00395334
		protected bool IsValidCooking()
		{
			CookingFoodInfo.RowData cookInfoByCuisineID = XHomeCookAndPartyDocument.Doc.GetCookInfoByCuisineID(this._curCookID);
			bool flag = cookInfoByCuisineID != null;
			bool result;
			if (flag)
			{
				for (int i = 0; i < cookInfoByCuisineID.Ingredients.Count; i++)
				{
					uint itemid = cookInfoByCuisineID.Ingredients[i, 0];
					uint num = cookInfoByCuisineID.Ingredients[i, 1];
					uint num2 = (uint)XBagDocument.BagDoc.GetItemCount((int)itemid);
					bool flag2 = num2 < num;
					if (flag2)
					{
						return false;
					}
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600F999 RID: 63897 RVA: 0x003971C4 File Offset: 0x003953C4
		private bool OnClickCookingButtonOK(IXUIButton btn)
		{
			this._successEffect.gameObject.SetActive(false);
			this._cookingProgressFrame.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0600F99A RID: 63898 RVA: 0x003971FB File Offset: 0x003953FB
		public void CookingTimeEnd()
		{
			this._doBtn.gameObject.SetActive(!this._isOneKeyCooking);
			this._cookingEffect.gameObject.SetActive(false);
			this.SendMakeCuisineReq();
		}

		// Token: 0x0600F99B RID: 63899 RVA: 0x00397234 File Offset: 0x00395434
		public void CookingSuccess()
		{
			this._successEffect.gameObject.SetActive(true);
			this._cookingItem.gameObject.SetActive(true);
			this._makingTrans.gameObject.SetActive(false);
			this._doBtn.gameObject.SetActive(!this._isOneKeyCooking);
			this._curCookLevel = HomeMainDocument.Doc.GetCookingLevel();
			this.RefreshRightDetail(this._curCookID);
			bool flag = !this._isOneKeyCooking || !this.StartToCooking(null);
			if (flag)
			{
				XSingleton<XAudioMgr>.singleton.StopUISound();
				XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/Cook_Over", true, AudioChannel.Action);
			}
		}

		// Token: 0x0600F99C RID: 63900 RVA: 0x003972E8 File Offset: 0x003954E8
		public void SetProgress(float percent)
		{
			this._cookingSlider.Value = percent;
			bool flag = percent >= 1f;
			if (flag)
			{
				this.CookingTimeEnd();
			}
		}

		// Token: 0x0600F99D RID: 63901 RVA: 0x00397319 File Offset: 0x00395519
		public void RefreshRightInfo()
		{
			this.RefreshRightDetail(this._curCookID);
		}

		// Token: 0x04006D11 RID: 27921
		protected IXUILabel _upCuisineLevel;

		// Token: 0x04006D12 RID: 27922
		protected IXUILabel _upExpPercent;

		// Token: 0x04006D13 RID: 27923
		protected IXUISlider _upProgress;

		// Token: 0x04006D14 RID: 27924
		protected Transform _middCuisineItem;

		// Token: 0x04006D15 RID: 27925
		protected IXUILabel _middCuisineName;

		// Token: 0x04006D16 RID: 27926
		protected IXUILabel _middCuisineAddExp;

		// Token: 0x04006D17 RID: 27927
		protected IXUILabel _middMakeTimes;

		// Token: 0x04006D18 RID: 27928
		protected IXUILabel _downCuisineDec;

		// Token: 0x04006D19 RID: 27929
		protected Transform _needMats;

		// Token: 0x04006D1A RID: 27930
		protected IXUIButton _makeBtn;

		// Token: 0x04006D1B RID: 27931
		protected IXUIButton _cancelMakingBtn = null;

		// Token: 0x04006D1C RID: 27932
		protected IXUIButton _oneKeyCookingBtn = null;

		// Token: 0x04006D1D RID: 27933
		protected uint _curCookID = 0U;

		// Token: 0x04006D1E RID: 27934
		protected uint _curCookLevel = 0U;

		// Token: 0x04006D1F RID: 27935
		protected Transform _selectedFoodItem;

		// Token: 0x04006D20 RID: 27936
		protected Transform _tabs;

		// Token: 0x04006D21 RID: 27937
		protected IXUITable _tabTable;

		// Token: 0x04006D22 RID: 27938
		protected XUIPool _levelCuisinePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006D23 RID: 27939
		protected XUIPool _cuisineChildPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006D24 RID: 27940
		protected XUIPool _foodItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006D25 RID: 27941
		protected List<Transform> _childCuisineItems = new List<Transform>();

		// Token: 0x04006D26 RID: 27942
		protected List<Transform> _levelItems = new List<Transform>();

		// Token: 0x04006D27 RID: 27943
		protected ulong _preCookID = 0UL;

		// Token: 0x04006D28 RID: 27944
		protected bool _isOneKeyCooking = false;

		// Token: 0x04006D29 RID: 27945
		protected Transform _cookingProgressFrame;

		// Token: 0x04006D2A RID: 27946
		protected IXUISlider _cookingSlider;

		// Token: 0x04006D2B RID: 27947
		protected Transform _cookingItem;

		// Token: 0x04006D2C RID: 27948
		protected Transform _makingTrans;

		// Token: 0x04006D2D RID: 27949
		protected Transform _successEffect;

		// Token: 0x04006D2E RID: 27950
		protected Transform _cookingEffect;

		// Token: 0x04006D2F RID: 27951
		protected IXUIButton _doBtn;

		// Token: 0x04006D30 RID: 27952
		protected Transform _toggleSprite;
	}
}
