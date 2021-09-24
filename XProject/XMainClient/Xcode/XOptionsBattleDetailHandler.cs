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

	internal class XOptionsBattleDetailHandler : DlgHandlerBase
	{

		public OptionsBattleTab CurrentTab
		{
			get
			{
				return this.m_CurrentTab;
			}
		}

		protected override string FileName
		{
			get
			{
				return "Battle/BattleSetDlg";
			}
		}

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

		public void ShowUI(OptionsBattleTab tab)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				base.SetVisible(true);
			}
			this.OnMainTabChanged(tab);
		}

		public void CloseUI()
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				base.SetVisible(false);
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

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

		public int ShowOtherPanel()
		{
			this.CloseAllPanel();
			return 1;
		}

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

		public bool IsNeedFullPanel(int tabID)
		{
			return 3 == tabID;
		}

		public bool IsShowOption(XOptionsDefine option)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			bool flag = option == XOptionsDefine.OD_3D_TOUCH_BATTLE;
			return !flag || specificDocument.IsShow3DTouch();
		}

		private XOptionsDocument doc = null;

		private OptionsBattleTab m_CurrentTab;

		public bool bDirty = false;

		private Transform m_panel;

		private Transform m_fullPanel;

		private IXUILabel m_Label;

		private Transform m_CameraPanel;

		private Transform m_OperatePanel;

		private IXUISprite m_25D;

		private IXUISprite m_3D;

		private IXUISprite m_3DFree;

		private IXUISprite m_AutoLock;

		private IXUISprite m_FreeLock;

		private Transform m_25DSelected;

		private Transform m_3DSelected;

		private Transform m_3DFreeSelected;

		private Transform m_AutoLockSelected;

		private Transform m_FreeLockSelected;

		private XUIPool m_SelectPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_SinglePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_SlidePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_CheckBoxPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<XOptionsBattleDetailHandler.UiSingle> m_uiSingle = new List<XOptionsBattleDetailHandler.UiSingle>();

		private List<XOptionsBattleDetailHandler.UiSlider> m_uiSlider = new List<XOptionsBattleDetailHandler.UiSlider>();

		private List<XOptionsBattleDetailHandler.UiCheckBox> m_uiCheckBox = new List<XOptionsBattleDetailHandler.UiCheckBox>();

		private XOptionsBattleDetailHandler.UiSingle m_single = default(XOptionsBattleDetailHandler.UiSingle);

		private XOptionsBattleDetailHandler.UiSlider m_slider = default(XOptionsBattleDetailHandler.UiSlider);

		private XOptionsBattleDetailHandler.UiCheckBox m_checkBox = default(XOptionsBattleDetailHandler.UiCheckBox);

		public struct UiSingle
		{

			public XOptionsDefine option;

			public IXUICheckBox uiCheckBox;
		}

		public struct UiSlider
		{

			public XOptionsDefine option;

			public IXUISlider uiSlider;

			public float min;

			public float max;
		}

		public struct UiCheckBox
		{

			public void Init()
			{
				this.select = new List<IXUICheckBox>();
			}

			public XOptionsDefine option;

			public List<IXUICheckBox> select;
		}

		public enum OptionsType
		{

			Single = 1,

			Slide,

			CheckBox
		}
	}
}
