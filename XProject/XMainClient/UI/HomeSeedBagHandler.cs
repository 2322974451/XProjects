using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017A5 RID: 6053
	internal class HomeSeedBagHandler : DlgHandlerBase
	{
		// Token: 0x17003867 RID: 14439
		// (get) Token: 0x0600FA38 RID: 64056 RVA: 0x0039C6A8 File Offset: 0x0039A8A8
		private HomePlantDocument m_doc
		{
			get
			{
				return HomePlantDocument.Doc;
			}
		}

		// Token: 0x17003868 RID: 14440
		// (get) Token: 0x0600FA39 RID: 64057 RVA: 0x0039C6C0 File Offset: 0x0039A8C0
		// (set) Token: 0x0600FA3A RID: 64058 RVA: 0x0039A1B4 File Offset: 0x003983B4
		private bool m_bIsPlayingAction
		{
			get
			{
				return DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.IsPlayingAction;
			}
			set
			{
				DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.IsPlayingAction = value;
			}
		}

		// Token: 0x17003869 RID: 14441
		// (get) Token: 0x0600FA3B RID: 64059 RVA: 0x0039C6DC File Offset: 0x0039A8DC
		protected override string FileName
		{
			get
			{
				return "Home/SeedBag";
			}
		}

		// Token: 0x0600FA3C RID: 64060 RVA: 0x0039C6F4 File Offset: 0x0039A8F4
		protected override void Init()
		{
			this.m_hadSeedGo = base.PanelObject.transform.FindChild("HadSeed").gameObject;
			this.m_noSeddGo = base.PanelObject.transform.FindChild("NoSeed").gameObject;
			this.m_noSeedTipsGo = this.m_noSeddGo.transform.Find("tip").gameObject;
			Transform transform = this.m_hadSeedGo.transform.FindChild("ItemView");
			this.m_ItemGo = transform.FindChild("Item").gameObject;
			this.m_describeLab = (transform.FindChild("Panel/Describe").GetComponent("XUILabel") as IXUILabel);
			this.m_timeLab = (transform.FindChild("time").GetComponent("XUILabel") as IXUILabel);
			this.m_harvestLab = (transform.FindChild("harvest").GetComponent("XUILabel") as IXUILabel);
			this.m_sprNameLab = (transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			transform = this.m_hadSeedGo.transform.FindChild("Items/Panel/WrapContent");
			this.m_wrapContent = (transform.GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			this.m_tplGo = this.m_hadSeedGo.transform.FindChild("Items").gameObject;
			this.m_plantBtn = (this.m_hadSeedGo.transform.FindChild("BtnPlant").GetComponent("XUIButton") as IXUIButton);
			this.m_gotoShopBtn = (this.m_noSeddGo.transform.FindChild("BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_bagWindow = new XBagWindow(this.m_tplGo, null, null);
			this.m_bagWindow.Init();
			base.Init();
		}

		// Token: 0x0600FA3D RID: 64061 RVA: 0x0039C8EC File Offset: 0x0039AAEC
		public override void RegisterEvent()
		{
			this.m_gotoShopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGoToShopBtn));
			base.RegisterEvent();
		}

		// Token: 0x0600FA3E RID: 64062 RVA: 0x0039C90E File Offset: 0x0039AB0E
		protected override void OnShow()
		{
			base.OnShow();
			this.m_bIsPlayingAction = false;
			this.FillContent();
		}

		// Token: 0x0600FA3F RID: 64063 RVA: 0x0039C927 File Offset: 0x0039AB27
		protected override void OnHide()
		{
			this.m_bagWindow.OnHide();
			this._ItemSelector.Hide();
			this.m_bIsPlayingAction = false;
			base.OnHide();
		}

		// Token: 0x0600FA40 RID: 64064 RVA: 0x0039C951 File Offset: 0x0039AB51
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.FillContent();
		}

		// Token: 0x0600FA41 RID: 64065 RVA: 0x0039C962 File Offset: 0x0039AB62
		public override void OnUnload()
		{
			this._ItemSelector.Unload();
			base.OnUnload();
		}

		// Token: 0x0600FA42 RID: 64066 RVA: 0x0039C978 File Offset: 0x0039AB78
		public void RefreshUI()
		{
			this.FillContent();
		}

		// Token: 0x0600FA43 RID: 64067 RVA: 0x0039C984 File Offset: 0x0039AB84
		private void FillContent()
		{
			this.m_doc.GetHadSeedList();
			bool flag = this.m_doc.HadSeedList == null || this.m_doc.HadSeedList.Count == 0;
			if (flag)
			{
				this.m_noSeddGo.SetActive(true);
				this.m_hadSeedGo.SetActive(false);
				this.m_gotoShopBtn.gameObject.SetActive(this.m_doc.HomeType != HomeTypeEnum.GuildHome);
				this.m_noSeedTipsGo.SetActive(this.m_doc.HomeType != HomeTypeEnum.GuildHome);
			}
			else
			{
				this.m_noSeddGo.SetActive(false);
				this.m_hadSeedGo.SetActive(true);
				this.m_bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this.m_doc.GetHadSeedsList));
				this.m_bagWindow.OnShow();
			}
		}

		// Token: 0x0600FA44 RID: 64068 RVA: 0x0039CA74 File Offset: 0x0039AC74
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this.m_doc.HadSeedList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("no data", null, null, null, null, null);
			}
			else
			{
				bool flag2 = index >= this.m_doc.HadSeedList.Count;
				if (flag2)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				}
				else
				{
					IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					XItem xitem = this.m_doc.HadSeedList[index];
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, xitem);
					ixuisprite.ID = xitem.uid;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
					bool flag3 = index == 0;
					if (flag3)
					{
						this.OnItemClicked(ixuisprite);
					}
				}
			}
		}

		// Token: 0x0600FA45 RID: 64069 RVA: 0x0039CB50 File Offset: 0x0039AD50
		private void FillSeedInfo(XItem item)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
			bool flag = itemConf != null;
			if (flag)
			{
				this.m_describeLab.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(itemConf.ItemDescription));
			}
			else
			{
				this.m_describeLab.SetText(string.Empty);
			}
			PlantSeed.RowData bySeedID = HomePlantDocument.PlantSeedTable.GetBySeedID((uint)item.itemID);
			bool flag2 = bySeedID != null;
			if (flag2)
			{
				this.m_sprNameLab.SetText(bySeedID.SeedName);
				this.m_timeLab.SetText(this.GetTimeString((ulong)bySeedID.PredictGrowUpTime));
				this.m_harvestLab.SetText(bySeedID.PlantID[1].ToString());
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_ItemGo, bySeedID.PlantID[0], 0, false);
				IXUISprite ixuisprite = this.m_ItemGo.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)bySeedID.PlantID[0]);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			else
			{
				this.m_sprNameLab.SetText("");
				this.m_timeLab.SetText("");
				this.m_harvestLab.SetText("");
			}
			this.m_plantBtn.ID = (ulong)((long)item.itemID);
			this.m_plantBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickPlantBtn));
		}

		// Token: 0x0600FA46 RID: 64070 RVA: 0x0039CCE4 File Offset: 0x0039AEE4
		private string GetTimeString(ulong ti)
		{
			bool flag = ti < 60UL;
			string result;
			if (flag)
			{
				string text = string.Format("{0}{1}", ti, XStringDefineProxy.GetString("MINUTE_DUARATION"));
				result = text;
			}
			else
			{
				ulong num = ti / 60UL;
				ulong num2 = ti % 60UL;
				bool flag2 = num2 > 0UL;
				string text;
				if (flag2)
				{
					text = string.Format("{0}{1}{2}{3}", new object[]
					{
						num,
						XStringDefineProxy.GetString("HOUR_DUARATION"),
						num2,
						XStringDefineProxy.GetString("MINUTE_DUARATION")
					});
				}
				else
				{
					text = string.Format("{0}{1}", num, XStringDefineProxy.GetString("HOUR_DUARATION"));
				}
				result = text;
			}
			return result;
		}

		// Token: 0x0600FA47 RID: 64071 RVA: 0x0039CD9C File Offset: 0x0039AF9C
		private bool OnClickPlantBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				Farmland farmland = this.m_doc.GetFarmland(this.m_doc.CurFarmlandId);
				bool flag2 = farmland == null || !farmland.IsFree;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool bIsPlayingAction = this.m_bIsPlayingAction;
					if (bIsPlayingAction)
					{
						result = true;
					}
					else
					{
						List<XItem> hadSeedsList = this.m_doc.GetHadSeedsList();
						bool flag3 = hadSeedsList == null || hadSeedsList.Count == 0;
						if (flag3)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_GARDEN_NOSEED"), "fece00");
							result = true;
						}
						else
						{
							bool flag4 = XSingleton<XEntityMgr>.singleton.Player == null;
							if (flag4)
							{
								result = true;
							}
							else
							{
								bool flag5 = !XOutlookHelper.CanPlaySpecifiedAnimation(XSingleton<XEntityMgr>.singleton.Player);
								if (flag5)
								{
									result = true;
								}
								else
								{
									this.m_bIsPlayingAction = true;
									XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this.m_doc.GetHomePlantAction(ActionType.Plant));
									XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
									this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_plantActionTime, new XTimerMgr.ElapsedEventHandler(this.QequestPlant), (uint)btn.ID);
									XSingleton<XFxMgr>.singleton.CreateAndPlay(HomePlantDocument.PlantEffectPath, XSingleton<XEntityMgr>.singleton.Player.EngineObject, Vector3.zero, Vector3.one, 1f, false, this.m_plantActionTime, true);
									XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/Farm_Planting", true, AudioChannel.Action);
									result = true;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600FA48 RID: 64072 RVA: 0x0039CF34 File Offset: 0x0039B134
		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		// Token: 0x0600FA49 RID: 64073 RVA: 0x0039CF6C File Offset: 0x0039B16C
		public void QequestPlant(object o = null)
		{
			XSingleton<XEntityMgr>.singleton.Player.PlayStateBack();
			bool flag = o != null;
			if (flag)
			{
				this.m_doc.StartPlant(this.m_doc.CurFarmlandId, (uint)o, false);
			}
			this.m_bIsPlayingAction = false;
		}

		// Token: 0x0600FA4A RID: 64074 RVA: 0x0039CFB8 File Offset: 0x0039B1B8
		private bool OnClickGoToShopBtn(IXUIButton btn)
		{
			HomeTypeEnum homeType = this.m_doc.HomeType;
			bool flag = homeType == HomeTypeEnum.GuildHome;
			if (flag)
			{
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				bool flag2 = !specificDocument.CheckInGuild();
				if (flag2)
				{
					return true;
				}
				bool flag3 = !specificDocument.CheckUnlockLevel(XSysDefine.XSys_GuildBoon_Shop);
				if (flag3)
				{
					return true;
				}
				DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.SetVisible(false, true);
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Guild, 0UL);
			}
			else
			{
				DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.SetVisible(false, true);
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Home, 0UL);
			}
			return true;
		}

		// Token: 0x0600FA4B RID: 64075 RVA: 0x0039D05C File Offset: 0x0039B25C
		private void OnItemClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID == null;
			if (!flag)
			{
				this.FillSeedInfo(itemByUID);
				this._ItemSelector.Select(iSp);
			}
		}

		// Token: 0x04006D99 RID: 28057
		private IXUIWrapContent m_wrapContent;

		// Token: 0x04006D9A RID: 28058
		private GameObject m_hadSeedGo;

		// Token: 0x04006D9B RID: 28059
		private GameObject m_noSeddGo;

		// Token: 0x04006D9C RID: 28060
		private GameObject m_ItemGo;

		// Token: 0x04006D9D RID: 28061
		private GameObject m_tplGo;

		// Token: 0x04006D9E RID: 28062
		private GameObject m_noSeedTipsGo;

		// Token: 0x04006D9F RID: 28063
		private IXUILabel m_describeLab;

		// Token: 0x04006DA0 RID: 28064
		private IXUILabel m_timeLab;

		// Token: 0x04006DA1 RID: 28065
		private IXUILabel m_harvestLab;

		// Token: 0x04006DA2 RID: 28066
		private IXUIButton m_plantBtn;

		// Token: 0x04006DA3 RID: 28067
		private IXUIButton m_gotoShopBtn;

		// Token: 0x04006DA4 RID: 28068
		private IXUILabel m_sprNameLab;

		// Token: 0x04006DA5 RID: 28069
		private XBagWindow m_bagWindow;

		// Token: 0x04006DA6 RID: 28070
		private XItemSelector _ItemSelector = new XItemSelector(0U);

		// Token: 0x04006DA7 RID: 28071
		private uint m_token;

		// Token: 0x04006DA8 RID: 28072
		private float m_plantActionTime = 2.5f;

		// Token: 0x04006DA9 RID: 28073
		private float m_fCoolTime = 3f;

		// Token: 0x04006DAA RID: 28074
		private float m_fLastClickBtnTime = 0f;
	}
}
