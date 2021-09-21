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
	// Token: 0x02000C5F RID: 3167
	internal class XOptionsBattleDetailHandler : DlgHandlerBase
	{
		// Token: 0x170031B2 RID: 12722
		// (get) Token: 0x0600B359 RID: 45913 RVA: 0x0022D724 File Offset: 0x0022B924
		public OptionsBattleTab CurrentTab
		{
			get
			{
				return this.m_CurrentTab;
			}
		}

		// Token: 0x170031B3 RID: 12723
		// (get) Token: 0x0600B35A RID: 45914 RVA: 0x0022D73C File Offset: 0x0022B93C
		protected override string FileName
		{
			get
			{
				return "Battle/BattleSetDlg";
			}
		}

		// Token: 0x0600B35B RID: 45915 RVA: 0x0022D754 File Offset: 0x0022B954
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			this.m_Label = (base.transform.Find("Label").GetComponent("XUILabel") as IXUILabel);
			this.m_CameraPanel = base.transform.Find("Classify/CameraPanel");
			bool flag = this.m_CameraPanel != null;
			if (flag)
			{
				this.m_25D = (this.m_CameraPanel.Find("25D/Normal").GetComponent("XUISprite") as IXUISprite);
				this.m_3D = (this.m_CameraPanel.Find("3D/Normal").GetComponent("XUISprite") as IXUISprite);
				this.m_3DFree = (this.m_CameraPanel.Find("3DFree/Normal").GetComponent("XUISprite") as IXUISprite);
				this.m_25DSelected = this.m_CameraPanel.Find("25D/Selected");
				this.m_3DSelected = this.m_CameraPanel.Find("3D/Selected");
				this.m_3DFreeSelected = this.m_CameraPanel.Find("3DFree/Selected");
			}
			this.m_OperatePanel = base.transform.Find("Classify/OperatePanel");
			bool flag2 = this.m_OperatePanel != null;
			if (flag2)
			{
				this.m_AutoLock = (this.m_OperatePanel.Find("AutoLock/Normal").GetComponent("XUISprite") as IXUISprite);
				this.m_FreeLock = (this.m_OperatePanel.Find("FreeLock/Normal").GetComponent("XUISprite") as IXUISprite);
				this.m_AutoLockSelected = this.m_OperatePanel.Find("AutoLock/Selected");
				this.m_FreeLockSelected = this.m_OperatePanel.Find("FreeLock/Selected");
			}
			this.m_panel = base.transform.Find("Panel");
			this.m_fullPanel = base.transform.Find("FullPanel");
			Transform transform = this.m_panel.transform.Find("SingleTpl");
			this.m_SinglePool.SetupPool(null, transform.gameObject, 5U, false);
			Transform transform2 = this.m_panel.transform.Find("SlideTpl");
			this.m_SlidePool.SetupPool(null, transform2.gameObject, 5U, false);
			Transform transform3 = this.m_panel.transform.Find("CheckBoxTpl");
			this.m_CheckBoxPool.SetupPool(null, transform3.gameObject, 5U, false);
			Transform transform4 = transform3.Find("Select/SelectTpl");
			this.m_SelectPool.SetupPool(this.m_panel.gameObject, transform4.gameObject, 3U, false);
			base.SetVisible(false);
		}

		// Token: 0x0600B35C RID: 45916 RVA: 0x0022D9FC File Offset: 0x0022BBFC
		public override void RegisterEvent()
		{
			bool flag = this.m_25D != null;
			if (flag)
			{
				this.m_25D.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X25D));
				this.m_25D.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChangeTab));
			}
			bool flag2 = this.m_3D != null;
			if (flag2)
			{
				this.m_3D.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X3D));
				this.m_3D.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChangeTab));
			}
			bool flag3 = this.m_3DFree != null;
			if (flag3)
			{
				this.m_3DFree.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X3D_Free));
				this.m_3DFree.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChangeTab));
			}
			bool flag4 = this.m_AutoLock != null;
			if (flag4)
			{
				this.m_AutoLock.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperateMode>.ToInt(XOperateMode.AutoLock));
				this.m_AutoLock.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChangeTab));
			}
			bool flag5 = this.m_FreeLock != null;
			if (flag5)
			{
				this.m_FreeLock.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperateMode>.ToInt(XOperateMode.FreeLock));
				this.m_FreeLock.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChangeTab));
			}
		}

		// Token: 0x0600B35D RID: 45917 RVA: 0x0022DB30 File Offset: 0x0022BD30
		private void OnChangeTab(IXUISprite sp)
		{
			this.SaveOption();
			bool flag = this.m_CurrentTab == OptionsBattleTab.CameraTab;
			if (flag)
			{
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
				bool flag2 = sceneData != null && sceneData.ShieldSight != null;
				if (flag2)
				{
					for (int i = 0; i < sceneData.ShieldSight.Length; i++)
					{
						bool flag3 = (int)sp.ID == (int)sceneData.ShieldSight[i];
						if (flag3)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("OPTION_SHIELD_SIGHT"), "fece00");
							return;
						}
					}
				}
				this.doc.SetValue(XOptionsDefine.OD_VIEW, (int)sp.ID, false);
				this.m_25DSelected.gameObject.SetActive((int)sp.ID == 1);
				this.m_3DSelected.gameObject.SetActive((int)sp.ID == 2);
				this.m_3DFreeSelected.gameObject.SetActive((int)sp.ID == 3);
				bool flag4 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag4)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetView((XOperationMode)sp.ID);
				}
				bool flag5 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag5)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetView((XOperationMode)sp.ID);
				}
			}
			bool flag6 = this.m_CurrentTab == OptionsBattleTab.OperateTab;
			if (flag6)
			{
				this.doc.SetValue(XOptionsDefine.OD_OPERATE, (int)sp.ID, false);
				this.m_AutoLockSelected.gameObject.SetActive((int)sp.ID == 1);
				this.m_FreeLockSelected.gameObject.SetActive((int)sp.ID == 2);
			}
			this.RefreshDynamicOption(XFastEnumIntEqualityComparer<OptionsBattleTab>.ToInt(this.m_CurrentTab), (int)sp.ID);
		}

		// Token: 0x0600B35E RID: 45918 RVA: 0x0022DD08 File Offset: 0x0022BF08
		public void OnMainTabChanged(OptionsBattleTab handler)
		{
			this.m_CurrentTab = handler;
			int cassifyID = 0;
			switch (this.m_CurrentTab)
			{
			case OptionsBattleTab.CameraTab:
				cassifyID = this.ShowCameraPanel();
				break;
			case OptionsBattleTab.OperateTab:
				cassifyID = this.ShowOperatePanel();
				break;
			case OptionsBattleTab.OtherTab:
				cassifyID = this.ShowOtherPanel();
				break;
			}
			this.SaveOption();
			this.RefreshDynamicOption(XFastEnumIntEqualityComparer<OptionsBattleTab>.ToInt(this.m_CurrentTab), cassifyID);
		}

		// Token: 0x0600B35F RID: 45919 RVA: 0x0022DD74 File Offset: 0x0022BF74
		public void ShowUI(OptionsBattleTab tab)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				base.SetVisible(true);
			}
			this.OnMainTabChanged(tab);
		}

		// Token: 0x0600B360 RID: 45920 RVA: 0x0022DDA0 File Offset: 0x0022BFA0
		public void CloseUI()
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				base.SetVisible(false);
			}
		}

		// Token: 0x0600B361 RID: 45921 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B362 RID: 45922 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B363 RID: 45923 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B364 RID: 45924 RVA: 0x0022DDC0 File Offset: 0x0022BFC0
		public void SaveOption()
		{
			bool flag = this.m_uiSingle.Count == 0 && this.m_uiSlider.Count == 0 && this.m_uiCheckBox.Count == 0;
			if (!flag)
			{
				bool flag2 = false;
				for (int i = 0; i < this.m_uiSingle.Count; i++)
				{
					bool flag3 = this.doc.SetValue(this.m_uiSingle[i].option, Convert.ToInt32(this.m_uiSingle[i].uiCheckBox.bChecked), false);
					if (flag3)
					{
						flag2 = true;
					}
				}
				for (int j = 0; j < this.m_uiSlider.Count; j++)
				{
					bool flag4 = this.doc.SetSliderValue(this.m_uiSlider[j].option, Mathf.Lerp(this.m_uiSlider[j].min, this.m_uiSlider[j].max, this.m_uiSlider[j].uiSlider.Value));
					if (flag4)
					{
						flag2 = true;
					}
				}
				for (int k = 0; k < this.m_uiCheckBox.Count; k++)
				{
					for (int l = 0; l < this.m_uiCheckBox[k].select.Count; l++)
					{
						bool bChecked = this.m_uiCheckBox[k].select[l].bChecked;
						if (bChecked)
						{
							bool flag5 = this.doc.SetValue(this.m_uiCheckBox[k].option, l, false);
							if (flag5)
							{
								flag2 = true;
							}
							break;
						}
					}
				}
				this.m_uiSingle.Clear();
				this.m_uiSlider.Clear();
				this.m_uiCheckBox.Clear();
				bool flag6 = flag2;
				if (flag6)
				{
					this.bDirty = true;
					this.doc.SaveSetting();
				}
			}
		}

		// Token: 0x0600B365 RID: 45925 RVA: 0x0022DFD0 File Offset: 0x0022C1D0
		private void CloseAllPanel()
		{
			bool flag = this.m_CameraPanel != null;
			if (flag)
			{
				this.m_CameraPanel.gameObject.SetActive(false);
			}
			bool flag2 = this.m_OperatePanel != null;
			if (flag2)
			{
				this.m_OperatePanel.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600B366 RID: 45926 RVA: 0x0022E024 File Offset: 0x0022C224
		public int ShowCameraPanel()
		{
			this.CloseAllPanel();
			this.m_CameraPanel.gameObject.SetActive(true);
			int value = this.doc.GetValue(XOptionsDefine.OD_VIEW);
			this.m_25DSelected.gameObject.SetActive(value == 1);
			this.m_3DSelected.gameObject.SetActive(value == 2);
			this.m_3DFreeSelected.gameObject.SetActive(value == 3);
			return value;
		}

		// Token: 0x0600B367 RID: 45927 RVA: 0x0022E0A0 File Offset: 0x0022C2A0
		public int ShowOperatePanel()
		{
			this.CloseAllPanel();
			this.m_OperatePanel.gameObject.SetActive(true);
			int value = this.doc.GetValue(XOptionsDefine.OD_OPERATE);
			XOperateMode xoperateMode = (XOperateMode)value;
			this.m_AutoLockSelected.gameObject.SetActive(xoperateMode == XOperateMode.AutoLock);
			this.m_FreeLockSelected.gameObject.SetActive(xoperateMode == XOperateMode.FreeLock);
			return value;
		}

		// Token: 0x0600B368 RID: 45928 RVA: 0x0022E10C File Offset: 0x0022C30C
		public int ShowOtherPanel()
		{
			this.CloseAllPanel();
			return 1;
		}

		// Token: 0x0600B369 RID: 45929 RVA: 0x0022E128 File Offset: 0x0022C328
		public void RefreshDynamicOption(int tabID, int cassifyID)
		{
			this.m_Label.SetText(this.GetDescription(tabID, cassifyID));
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			this.m_uiSingle.Clear();
			this.m_uiSlider.Clear();
			this.m_uiCheckBox.Clear();
			this.m_SelectPool.FakeReturnAll();
			this.m_SinglePool.FakeReturnAll();
			this.m_SlidePool.FakeReturnAll();
			this.m_CheckBoxPool.FakeReturnAll();
			bool flag = tabID > 0 && cassifyID > 0;
			if (flag)
			{
				for (int i = 0; i < XOptionsDocument.optionsData[tabID - 1][cassifyID - 1].Count; i++)
				{
					XOptions.RowData rowData = XOptionsDocument.optionsData[tabID - 1][cassifyID - 1][i];
					XOptionsBattleDetailHandler.OptionsType type = (XOptionsBattleDetailHandler.OptionsType)rowData.Type;
					XOptionsDefine id = (XOptionsDefine)rowData.ID;
					bool flag2 = !this.IsShowOption(id);
					if (!flag2)
					{
						bool flag3 = type == XOptionsBattleDetailHandler.OptionsType.Single;
						if (flag3)
						{
							GameObject gameObject = this.m_SinglePool.FetchGameObject(false);
							bool flag4 = this.IsNeedFullPanel(tabID);
							if (flag4)
							{
								XSingleton<UiUtility>.singleton.AddChild(this.m_fullPanel, gameObject.transform);
							}
							else
							{
								XSingleton<UiUtility>.singleton.AddChild(this.m_panel, gameObject.transform);
							}
							gameObject.name = string.Format("Single{0}", num2);
							gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num), 0f) + this.m_SinglePool.TplPos;
							num += this.m_SinglePool.TplHeight;
							num2++;
							IXUILabel ixuilabel = gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
							ixuilabel.SetText(rowData.Text);
							IXUICheckBox ixuicheckBox = gameObject.transform.Find("Category/Normal").GetComponent("XUICheckBox") as IXUICheckBox;
							ixuicheckBox.bChecked = Convert.ToBoolean(this.doc.GetValue(id));
							this.m_single.option = id;
							this.m_single.uiCheckBox = ixuicheckBox;
							this.m_uiSingle.Add(this.m_single);
						}
						else
						{
							bool flag5 = type == XOptionsBattleDetailHandler.OptionsType.Slide;
							if (flag5)
							{
								GameObject gameObject = this.m_SlidePool.FetchGameObject(false);
								bool flag6 = this.IsNeedFullPanel(tabID);
								if (flag6)
								{
									XSingleton<UiUtility>.singleton.AddChild(this.m_fullPanel, gameObject.transform);
								}
								else
								{
									XSingleton<UiUtility>.singleton.AddChild(this.m_panel, gameObject.transform);
								}
								gameObject.name = string.Format("Slide{0}", num3);
								gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num), 0f) + this.m_SlidePool.TplPos;
								num += this.m_SlidePool.TplHeight;
								num3++;
								IXUILabel ixuilabel = gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
								ixuilabel.SetText(rowData.Text);
								IXUISlider ixuislider = gameObject.transform.Find("Slider/Bar").GetComponent("XUISlider") as IXUISlider;
								int num5 = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession) % 10;
								string[] array = rowData.Range.Split(new char[]
								{
									'|'
								});
								string[] array2 = array[num5 - 1].Split(new char[]
								{
									'='
								});
								ixuislider.Value = Mathf.Clamp01(Mathf.InverseLerp(float.Parse(array2[0]), float.Parse(array2[1]), this.doc.GetFloatValue(id)));
								ixuilabel = (gameObject.transform.Find("Slider/TLeft").GetComponent("XUILabel") as IXUILabel);
								string text = (rowData.OptionText != null && rowData.OptionText.Length != 0) ? rowData.OptionText[0] : "";
								ixuilabel.SetText(text);
								ixuilabel = (gameObject.transform.Find("Slider/TRight").GetComponent("XUILabel") as IXUILabel);
								text = ((rowData.OptionText != null && rowData.OptionText.Length > 1) ? rowData.OptionText[1] : "");
								ixuilabel.SetText(text);
								this.m_slider.option = id;
								this.m_slider.uiSlider = ixuislider;
								this.m_slider.min = float.Parse(array2[0]);
								this.m_slider.max = float.Parse(array2[1]);
								this.m_uiSlider.Add(this.m_slider);
							}
							else
							{
								bool flag7 = type == XOptionsBattleDetailHandler.OptionsType.CheckBox;
								if (flag7)
								{
									GameObject gameObject = this.m_CheckBoxPool.FetchGameObject(false);
									bool flag8 = this.IsNeedFullPanel(tabID);
									if (flag8)
									{
										XSingleton<UiUtility>.singleton.AddChild(this.m_fullPanel, gameObject.transform);
									}
									else
									{
										XSingleton<UiUtility>.singleton.AddChild(this.m_panel, gameObject.transform);
									}
									gameObject.name = string.Format("CheckBox{0}", num4);
									gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num), 0f) + this.m_CheckBoxPool.TplPos;
									num += this.m_CheckBoxPool.TplHeight;
									num4++;
									IXUILabel ixuilabel = gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
									ixuilabel.SetText(rowData.Text);
									Transform transform = gameObject.transform.Find("Select/SelectTpl");
									int num6 = (rowData.OptionText != null) ? rowData.OptionText.Length : 0;
									int value = this.doc.GetValue(id);
									this.m_checkBox.option = id;
									this.m_checkBox.Init();
									for (int j = 0; j < num6; j++)
									{
										GameObject gameObject2 = this.m_SelectPool.FetchGameObject(false);
										XSingleton<UiUtility>.singleton.AddChild(gameObject, gameObject2);
										gameObject2.transform.localPosition = new Vector3((float)(this.m_SelectPool.TplWidth * j), 0f, 0f) + this.m_SelectPool.TplPos;
										IXUICheckBox ixuicheckBox2 = gameObject2.transform.Find("Btn").GetComponent("XUICheckBox") as IXUICheckBox;
										ixuicheckBox2.ForceSetFlag(false);
										ixuicheckBox2.SetGroup(rowData.ID);
										bool flag9 = j == value;
										if (flag9)
										{
											ixuicheckBox2.bChecked = true;
										}
										ixuilabel = (ixuicheckBox2.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
										ixuilabel.SetText(rowData.OptionText[j]);
										ixuilabel = (ixuicheckBox2.gameObject.transform.Find("select/T").GetComponent("XUILabel") as IXUILabel);
										ixuilabel.SetText(rowData.OptionText[j]);
										this.m_checkBox.select.Add(ixuicheckBox2);
									}
									this.m_uiCheckBox.Add(this.m_checkBox);
								}
							}
						}
					}
				}
			}
			this.m_SelectPool.ActualReturnAll(false);
			this.m_SinglePool.ActualReturnAll(false);
			this.m_SlidePool.ActualReturnAll(false);
			this.m_CheckBoxPool.ActualReturnAll(false);
		}

		// Token: 0x0600B36A RID: 45930 RVA: 0x0022E8E8 File Offset: 0x0022CAE8
		public string GetDescription(int tabID, int cassifyID)
		{
			bool flag = cassifyID == 0;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				XOptionsDefine option = XOptionsDefine.OD_START;
				bool flag2 = tabID == 1;
				if (flag2)
				{
					option = XOptionsDefine.OD_VIEW;
				}
				else
				{
					bool flag3 = tabID == 2;
					if (flag3)
					{
						option = XOptionsDefine.OD_OPERATE;
					}
					else
					{
						bool flag4 = tabID == 3;
						if (flag4)
						{
							option = XOptionsDefine.OD_OTHER;
						}
					}
				}
				XOptions.RowData optionData = XOptionsDocument.GetOptionData(option);
				bool flag5 = optionData.OptionText != null && optionData.OptionText.Length > cassifyID - 1;
				if (flag5)
				{
					result = optionData.OptionText[cassifyID - 1];
				}
				else
				{
					result = "";
				}
			}
			return result;
		}

		// Token: 0x0600B36B RID: 45931 RVA: 0x0022E980 File Offset: 0x0022CB80
		public bool IsNeedFullPanel(int tabID)
		{
			return 3 == tabID;
		}

		// Token: 0x0600B36C RID: 45932 RVA: 0x0022E9A0 File Offset: 0x0022CBA0
		public bool IsShowOption(XOptionsDefine option)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			bool flag = option == XOptionsDefine.OD_3D_TOUCH_BATTLE;
			return !flag || specificDocument.IsShow3DTouch();
		}

		// Token: 0x04004560 RID: 17760
		private XOptionsDocument doc = null;

		// Token: 0x04004561 RID: 17761
		private OptionsBattleTab m_CurrentTab;

		// Token: 0x04004562 RID: 17762
		public bool bDirty = false;

		// Token: 0x04004563 RID: 17763
		private Transform m_panel;

		// Token: 0x04004564 RID: 17764
		private Transform m_fullPanel;

		// Token: 0x04004565 RID: 17765
		private IXUILabel m_Label;

		// Token: 0x04004566 RID: 17766
		private Transform m_CameraPanel;

		// Token: 0x04004567 RID: 17767
		private Transform m_OperatePanel;

		// Token: 0x04004568 RID: 17768
		private IXUISprite m_25D;

		// Token: 0x04004569 RID: 17769
		private IXUISprite m_3D;

		// Token: 0x0400456A RID: 17770
		private IXUISprite m_3DFree;

		// Token: 0x0400456B RID: 17771
		private IXUISprite m_AutoLock;

		// Token: 0x0400456C RID: 17772
		private IXUISprite m_FreeLock;

		// Token: 0x0400456D RID: 17773
		private Transform m_25DSelected;

		// Token: 0x0400456E RID: 17774
		private Transform m_3DSelected;

		// Token: 0x0400456F RID: 17775
		private Transform m_3DFreeSelected;

		// Token: 0x04004570 RID: 17776
		private Transform m_AutoLockSelected;

		// Token: 0x04004571 RID: 17777
		private Transform m_FreeLockSelected;

		// Token: 0x04004572 RID: 17778
		private XUIPool m_SelectPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004573 RID: 17779
		private XUIPool m_SinglePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004574 RID: 17780
		private XUIPool m_SlidePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004575 RID: 17781
		private XUIPool m_CheckBoxPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004576 RID: 17782
		private List<XOptionsBattleDetailHandler.UiSingle> m_uiSingle = new List<XOptionsBattleDetailHandler.UiSingle>();

		// Token: 0x04004577 RID: 17783
		private List<XOptionsBattleDetailHandler.UiSlider> m_uiSlider = new List<XOptionsBattleDetailHandler.UiSlider>();

		// Token: 0x04004578 RID: 17784
		private List<XOptionsBattleDetailHandler.UiCheckBox> m_uiCheckBox = new List<XOptionsBattleDetailHandler.UiCheckBox>();

		// Token: 0x04004579 RID: 17785
		private XOptionsBattleDetailHandler.UiSingle m_single = default(XOptionsBattleDetailHandler.UiSingle);

		// Token: 0x0400457A RID: 17786
		private XOptionsBattleDetailHandler.UiSlider m_slider = default(XOptionsBattleDetailHandler.UiSlider);

		// Token: 0x0400457B RID: 17787
		private XOptionsBattleDetailHandler.UiCheckBox m_checkBox = default(XOptionsBattleDetailHandler.UiCheckBox);

		// Token: 0x020019A6 RID: 6566
		public struct UiSingle
		{
			// Token: 0x04007F5D RID: 32605
			public XOptionsDefine option;

			// Token: 0x04007F5E RID: 32606
			public IXUICheckBox uiCheckBox;
		}

		// Token: 0x020019A7 RID: 6567
		public struct UiSlider
		{
			// Token: 0x04007F5F RID: 32607
			public XOptionsDefine option;

			// Token: 0x04007F60 RID: 32608
			public IXUISlider uiSlider;

			// Token: 0x04007F61 RID: 32609
			public float min;

			// Token: 0x04007F62 RID: 32610
			public float max;
		}

		// Token: 0x020019A8 RID: 6568
		public struct UiCheckBox
		{
			// Token: 0x06011049 RID: 69705 RVA: 0x004543D0 File Offset: 0x004525D0
			public void Init()
			{
				this.select = new List<IXUICheckBox>();
			}

			// Token: 0x04007F63 RID: 32611
			public XOptionsDefine option;

			// Token: 0x04007F64 RID: 32612
			public List<IXUICheckBox> select;
		}

		// Token: 0x020019A9 RID: 6569
		public enum OptionsType
		{
			// Token: 0x04007F66 RID: 32614
			Single = 1,
			// Token: 0x04007F67 RID: 32615
			Slide,
			// Token: 0x04007F68 RID: 32616
			CheckBox
		}
	}
}
