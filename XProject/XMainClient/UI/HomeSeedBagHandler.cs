using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HomeSeedBagHandler : DlgHandlerBase
	{

		private HomePlantDocument m_doc
		{
			get
			{
				return HomePlantDocument.Doc;
			}
		}

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

		protected override string FileName
		{
			get
			{
				return "Home/SeedBag";
			}
		}

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

		public override void RegisterEvent()
		{
			this.m_gotoShopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGoToShopBtn));
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_bIsPlayingAction = false;
			this.FillContent();
		}

		protected override void OnHide()
		{
			this.m_bagWindow.OnHide();
			this._ItemSelector.Hide();
			this.m_bIsPlayingAction = false;
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.FillContent();
		}

		public override void OnUnload()
		{
			this._ItemSelector.Unload();
			base.OnUnload();
		}

		public void RefreshUI()
		{
			this.FillContent();
		}

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

		private IXUIWrapContent m_wrapContent;

		private GameObject m_hadSeedGo;

		private GameObject m_noSeddGo;

		private GameObject m_ItemGo;

		private GameObject m_tplGo;

		private GameObject m_noSeedTipsGo;

		private IXUILabel m_describeLab;

		private IXUILabel m_timeLab;

		private IXUILabel m_harvestLab;

		private IXUIButton m_plantBtn;

		private IXUIButton m_gotoShopBtn;

		private IXUILabel m_sprNameLab;

		private XBagWindow m_bagWindow;

		private XItemSelector _ItemSelector = new XItemSelector(0U);

		private uint m_token;

		private float m_plantActionTime = 2.5f;

		private float m_fCoolTime = 3f;

		private float m_fLastClickBtnTime = 0f;
	}
}
