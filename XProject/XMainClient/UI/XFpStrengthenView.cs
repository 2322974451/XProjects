using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XFpStrengthenView : DlgBase<XFpStrengthenView, XFPStrengthenBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/FpStrengthenDlg";
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
			this._doc.StrengthenView = this;
			this.m_FpStrengthenPool.SetupPool(base.uiBehaviour.m_tabParentGo, base.uiBehaviour.m_tabParentGo.transform.FindChild("template").gameObject, XFPStrengthenBehaviour.FUNCTION_NUM, false);
			Transform transform = base.uiBehaviour.transform.FindChild("Bg/Content/Panel");
			this.m_FpButtonPool.SetupPool(transform.gameObject, transform.FindChild("template").gameObject, 20U, false);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Scroll.SetPosition(0f);
			this.InitLeftViews();
			this.FillTopContent();
			bool flag = !this.m_checkBoxDic.ContainsKey(this._curFunctionEnum);
			if (flag)
			{
				this._curFunctionEnum = this._defFunctionEnum;
			}
			this._isFromShow = true;
			this._doc.RequsetFightNum();
			this.m_checkBoxDic[this._curFunctionEnum].bChecked = true;
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.m_FpStrengthenPool.ReturnAll(false);
			bool flag = this.m_checkBoxDic != null;
			if (flag)
			{
				foreach (KeyValuePair<FunctionDef, IXUICheckBox> keyValuePair in this.m_checkBoxDic)
				{
					bool flag2 = keyValuePair.Value != null;
					if (flag2)
					{
						keyValuePair.Value.ForceSetFlag(false);
					}
				}
			}
			this.m_tabReddot.Clear();
			base.uiBehaviour.m_RateTex.SetTexturePath("");
		}

		protected override void OnUnload()
		{
			this.m_checkBoxDic.Clear();
			this._doc = null;
			base.OnUnload();
		}

		public override void StackRefresh()
		{
			base.uiBehaviour.m_Scroll.SetPosition(0f);
			this.FillTopContent();
			this._doc.RequsetFightNum();
		}

		public void ShowContent(FunctionDef fun = FunctionDef.ZHANLI)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Strong);
			if (!flag)
			{
				this._curFunctionEnum = fun;
				bool flag2 = !base.IsVisible();
				if (flag2)
				{
					this.SetVisible(true, true);
				}
			}
		}

		public void RefreshUi(bool isFromMes)
		{
			bool flag = this._curFunctionEnum == FunctionDef.ZHANLI;
			if (flag)
			{
				this.m_FpButtonPool.ReturnAll(false);
				this.FillStrengthenContent();
				this.RefreshTabRedDot();
				bool flag2 = !this._isFromShow;
				if (flag2)
				{
					this._doc.CancleNew(XFastEnumIntEqualityComparer<FunctionDef>.ToInt(this._curFunctionEnum));
				}
				else
				{
					this._isFromShow = false;
					if (isFromMes)
					{
						this._doc.CancleNew(XFastEnumIntEqualityComparer<FunctionDef>.ToInt(this._curFunctionEnum));
					}
				}
			}
		}

		public void RefreshTabRedDot()
		{
			bool flag = this.m_tabReddot == null || this.m_tabReddot.Count == 0;
			if (!flag)
			{
				foreach (KeyValuePair<FunctionDef, XTuple<GameObject, GameObject>> keyValuePair in this.m_tabReddot)
				{
					bool flag2 = keyValuePair.Value != null;
					if (flag2)
					{
						bool flag3 = keyValuePair.Key == FunctionDef.ZHANLI;
						if (flag3)
						{
							bool tabNew = this._doc.GetTabNew(XFastEnumIntEqualityComparer<FunctionDef>.ToInt(keyValuePair.Key));
							bool flag4 = tabNew;
							if (flag4)
							{
								keyValuePair.Value.Item1.SetActive(true);
								keyValuePair.Value.Item2.SetActive(false);
							}
							else
							{
								keyValuePair.Value.Item1.SetActive(false);
								keyValuePair.Value.Item2.SetActive(this._doc.NeedUp);
							}
						}
						else
						{
							keyValuePair.Value.Item1.SetActive(this._doc.GetTabNew(XFastEnumIntEqualityComparer<FunctionDef>.ToInt(keyValuePair.Key)));
							keyValuePair.Value.Item2.SetActive(false);
						}
					}
				}
			}
		}

		private void InitLeftViews()
		{
			string @string = XStringDefineProxy.GetString("BQ_TITLE_STRING");
			string[] array = @string.Split(new char[]
			{
				'|'
			});
			int num = 0;
			this._defFunctionEnum = FunctionDef.END;
			this.m_checkBoxDic.Clear();
			this.m_tabReddot.Clear();
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = this.GetFuncNum(FunctionDef.ZHANLI + i) == 0;
				if (!flag)
				{
					GameObject gameObject = this.m_FpStrengthenPool.FetchGameObject(false);
					gameObject.transform.parent = base.uiBehaviour.m_tabParentGo.transform;
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3(this.m_FpStrengthenPool.TplPos.x, this.m_FpStrengthenPool.TplPos.y - (float)(num * this.m_FpStrengthenPool.TplHeight), this.m_FpStrengthenPool.TplPos.z);
					this.InitTabInfo(gameObject.transform.FindChild("Bg"), array[i], i);
					num++;
				}
			}
			IXUIScrollView ixuiscrollView = base.uiBehaviour.m_tabParentGo.GetComponent("XUIScrollView") as IXUIScrollView;
			ixuiscrollView.ResetPosition();
		}

		private void InitTabInfo(Transform tra, string name, int index)
		{
			bool flag = tra == null;
			if (!flag)
			{
				IXUILabel ixuilabel = tra.FindChild("TextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(name);
				ixuilabel = (tra.FindChild("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(name);
				IXUICheckBox ixuicheckBox = tra.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.SelectStrengthItem));
				ixuicheckBox.ID = (ulong)((long)(0 + index));
				this.m_checkBoxDic.Add((FunctionDef)ixuicheckBox.ID, ixuicheckBox);
				GameObject gameObject = tra.FindChild("New").gameObject;
				GameObject gameObject2 = tra.FindChild("Up").gameObject;
				this.m_tabReddot.Add((FunctionDef)ixuicheckBox.ID, new XTuple<GameObject, GameObject>(gameObject, gameObject2));
				bool flag2 = this._defFunctionEnum == FunctionDef.END;
				if (flag2)
				{
					this._defFunctionEnum = (FunctionDef)ixuicheckBox.ID;
				}
			}
		}

		private int GetFuncNum(FunctionDef def)
		{
			return this._doc.GetFuncNumByType(XFastEnumIntEqualityComparer<FunctionDef>.ToInt(def));
		}

		private void FillContentArea(FunctionDef def)
		{
			bool flag = def == FunctionDef.ZHANLI;
			if (flag)
			{
				this.RefreshUi(false);
			}
			else
			{
				this.RefreshTabRedDot();
				this.m_FpButtonPool.ReturnAll(false);
				this.FillOtherContent(def);
				this._doc.CancleNew(XFastEnumIntEqualityComparer<FunctionDef>.ToInt(def));
			}
			base.uiBehaviour.m_Scroll.ResetPosition();
		}

		private void FillTopContent()
		{
			uint num = (uint)XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
			RecommendFightNum.RowData recommendFightData = this._doc.GetRecommendFightData(XSysDefine.XSys_None, -1);
			uint num2 = 1U;
			bool flag = recommendFightData == null && XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("the data is not find,level = " + XSingleton<XAttributeMgr>.singleton.XPlayerData.Level, null, null, null, null, null);
			}
			else
			{
				num2 = recommendFightData.Total;
			}
			base.uiBehaviour.m_MyFightLab.SetText(num.ToString());
			base.uiBehaviour.m_RecommendFightLab.SetText(num2.ToString());
			base.uiBehaviour.m_MyLevelLab.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level.ToString());
			int fightPercent = (int)(num / num2 * 100.0);
			string totalFightRateDes = this._doc.GetTotalFightRateDes(fightPercent);
			base.uiBehaviour.m_RateTex.SetTexturePath("atlas/UI/GameSystem/Activity/" + totalFightRateDes);
		}

		private void FillStrengthenContent()
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < this._doc.StrengthAuxDataList.Count; i++)
			{
				StrengthAuxData strengthAuxData = this._doc.StrengthAuxDataList[i];
				bool flag = strengthAuxData == null || !strengthAuxData.IsShow;
				if (!flag)
				{
					GameObject gameObject = this.m_FpButtonPool.FetchGameObject(true);
					gameObject.transform.FindChild("Other").gameObject.SetActive(false);
					gameObject.transform.localPosition = new Vector3(this.m_FpButtonPool.TplPos.x, this.m_FpButtonPool.TplPos.y - (float)(num * this.m_FpButtonPool.TplHeight), this.m_FpButtonPool.TplPos.z);
					num++;
					IXUIButton ixuibutton = gameObject.transform.FindChild("go").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.GoToStrengthSys));
					ixuibutton.ID = (ulong)((long)strengthAuxData.StrengthenData.BQSystem);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Sprite").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetSprite(strengthAuxData.StrengthenData.BQImageID);
					bool tabNew = this._doc.GetTabNew(XFastEnumIntEqualityComparer<FunctionDef>.ToInt(this._curFunctionEnum));
					bool flag2 = tabNew;
					if (flag2)
					{
						bool flag3 = strengthAuxData.StrengthenData != null;
						if (flag3)
						{
							gameObject.transform.FindChild("New").gameObject.SetActive(this._doc.GetNewStatus(strengthAuxData.StrengthenData.BQID));
						}
						else
						{
							gameObject.transform.FindChild("New").gameObject.SetActive(false);
						}
						gameObject.transform.FindChild("Up").gameObject.SetActive(false);
					}
					else
					{
						gameObject.transform.FindChild("New").gameObject.SetActive(false);
						bool flag4 = strengthAuxData.FightPercent < (double)this._doc.ShowUpSprNum && num2 < 2;
						if (flag4)
						{
							num2++;
							gameObject.transform.FindChild("Up").gameObject.SetActive(true);
						}
						else
						{
							gameObject.transform.FindChild("Up").gameObject.SetActive(false);
						}
					}
					gameObject = gameObject.transform.FindChild("Strengthen").gameObject;
					gameObject.SetActive(true);
					IXUILabel ixuilabel = gameObject.transform.FindChild("TittleLab").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(strengthAuxData.StrengthenData.BQTips);
					double num3 = strengthAuxData.FightPercent;
					ixuilabel = (gameObject.transform.FindChild("RateLab").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(this._doc.GetPartFightRateDes(num3));
					IXUISlider ixuislider = gameObject.transform.FindChild("Slider").GetComponent("XUISlider") as IXUISlider;
					num3 = ((num3 > 100.0) ? 100.0 : num3);
					num3 = ((num3 < 0.0) ? 0.0 : num3);
					ixuislider.Value = (float)num3 / 100f;
				}
			}
		}

		private void FillOtherContent(FunctionDef def)
		{
			List<FpStrengthNew.RowData> strengthByType = this._doc.GetStrengthByType(XFastEnumIntEqualityComparer<FunctionDef>.ToInt(def));
			for (int i = 0; i < strengthByType.Count; i++)
			{
				FpStrengthNew.RowData rowData = strengthByType[i];
				bool flag = rowData == null;
				if (!flag)
				{
					GameObject gameObject = this.m_FpButtonPool.FetchGameObject(true);
					gameObject.transform.FindChild("Strengthen").gameObject.SetActive(false);
					gameObject.transform.localPosition = new Vector3(this.m_FpButtonPool.TplPos.x, this.m_FpButtonPool.TplPos.y - (float)(i * this.m_FpButtonPool.TplHeight), this.m_FpButtonPool.TplPos.z);
					IXUIButton ixuibutton = gameObject.transform.FindChild("go").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.GoToStrengthSys));
					ixuibutton.ID = (ulong)((long)rowData.BQSystem);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Sprite").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetSprite(rowData.BQImageID);
					gameObject.transform.FindChild("New").gameObject.SetActive(this._doc.GetNewStatus(rowData.BQID));
					gameObject.transform.FindChild("Up").gameObject.SetActive(false);
					gameObject = gameObject.transform.FindChild("Other").gameObject;
					gameObject.SetActive(true);
					IXUILabel ixuilabel = gameObject.transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(rowData.BQTips);
					for (int j = 0; j < 5; j++)
					{
						gameObject.transform.FindChild(j.ToString()).gameObject.SetActive(j < rowData.StarNum);
					}
				}
			}
		}

		private bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisible(false, true);
			return true;
		}

		private bool SelectStrengthItem(IXUICheckBox iXUICheckBox)
		{
			FunctionDef functionDef = (FunctionDef)iXUICheckBox.ID;
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				bool flag = this._isFirst && functionDef == FunctionDef.ZHANLI;
				if (flag)
				{
					this._isFirst = false;
					return true;
				}
				this._curFunctionEnum = functionDef;
				this.FillContentArea(functionDef);
			}
			return true;
		}

		public bool GoToStrengthSys(IXUIButton sp)
		{
			XSysDefine xsysDefine = (XSysDefine)sp.ID;
			XSysDefine xsysDefine2 = xsysDefine;
			if (xsysDefine2 - XSysDefine.XSys_Level_Normal > 1)
			{
				if (xsysDefine2 - XSysDefine.XSys_Item_Enchant > 1)
				{
					if (xsysDefine2 != XSysDefine.XSys_GuildDailyTask)
					{
						XSingleton<XGameSysMgr>.singleton.OpenSystem(xsysDefine, 0UL);
					}
					else
					{
						XSingleton<UIManager>.singleton.CloseAllUI();
						XSingleton<XGameSysMgr>.singleton.OpenSystem(xsysDefine, 0UL);
					}
				}
				else
				{
					XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Item_Equip, 0UL);
				}
			}
			else
			{
				XLevelDocument specificDocument = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
				bool flag = xsysDefine == XSysDefine.XSys_Level_Normal;
				if (flag)
				{
					specificDocument.AutoGoBattle(0, 0, 0U);
				}
				else
				{
					specificDocument.AutoGoBattle(0, 0, 1U);
				}
			}
			return true;
		}

		private XFPStrengthenDocument _doc = null;

		public XUIPool m_FpStrengthenPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_FpButtonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Dictionary<FunctionDef, IXUICheckBox> m_checkBoxDic = new Dictionary<FunctionDef, IXUICheckBox>();

		private Dictionary<FunctionDef, XTuple<GameObject, GameObject>> m_tabReddot = new Dictionary<FunctionDef, XTuple<GameObject, GameObject>>();

		private FunctionDef _curFunctionEnum = FunctionDef.ZHANLI;

		private FunctionDef _defFunctionEnum = FunctionDef.END;

		private bool _isFirst = true;

		private bool _isFromShow = false;
	}
}
