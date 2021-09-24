using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SuperRiskSelectMapHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/SuperRisk/SelectMapHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XSuperRiskDocument.uuID) as XSuperRiskDocument);
			this.m_btnTras.Clear();
			Transform transform = base.PanelObject.transform.Find("Bg/RiskMap/SelectMap");
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform item = transform.FindChild(XSingleton<XCommon>.singleton.StringCombine("Map", i.ToString()));
				this.m_btnTras.Add(item);
			}
			this.m_Close = (base.PanelObject.transform.Find("Bg/panel/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/panel/Help").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_SuperRisk);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		private void FillContent()
		{
			bool flag = false;
			for (int i = 0; i < this.m_btnTras.Count; i++)
			{
				RiskMapFile.RowData mapIdByIndex = this._doc.GetMapIdByIndex(i);
				bool flag2 = mapIdByIndex == null;
				if (flag2)
				{
					this.m_btnTras[i].FindChild("Map").gameObject.SetActive(false);
					this.m_btnTras[i].FindChild("Cloud/T").gameObject.SetActive(false);
					this.m_btnTras[i].FindChild("Cloud").gameObject.SetActive(true);
				}
				else
				{
					uint num = 0U;
					bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
					if (flag3)
					{
						num = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
					}
					this.m_btnTras[i].FindChild("Map").gameObject.SetActive(false);
					bool flag4 = (ulong)num > (ulong)((long)mapIdByIndex.NeedLevel);
					if (flag4)
					{
						this.m_btnTras[i].FindChild("Cloud").gameObject.SetActive(false);
						IXUISprite ixuisprite = this.m_btnTras[i].GetComponent("XUISprite") as IXUISprite;
						bool flag5 = mapIdByIndex == null;
						if (flag5)
						{
							ixuisprite.ID = 0UL;
						}
						else
						{
							ixuisprite.ID = (ulong)((long)mapIdByIndex.MapID);
						}
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMapClick));
						ixuisprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnMapPress));
					}
					else
					{
						bool flag6 = (ulong)num < (ulong)((long)mapIdByIndex.NeedLevel);
						if (flag6)
						{
							bool flag7 = flag;
							if (flag7)
							{
								this.m_btnTras[i].FindChild("Cloud").gameObject.SetActive(true);
								this.m_btnTras[i].FindChild("Cloud/T").gameObject.SetActive(false);
							}
							else
							{
								this.m_btnTras[i].FindChild("Cloud").gameObject.SetActive(true);
								IXUILabel ixuilabel = this.m_btnTras[i].FindChild("Cloud/T").GetComponent("XUILabel") as IXUILabel;
								ixuilabel.gameObject.SetActive(true);
								ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("OPEN_AT_LEVEL"), mapIdByIndex.NeedLevel));
								flag = true;
							}
						}
						else
						{
							bool flag8 = num > this._doc.HisMaxLevel.PreLevel;
							if (flag8)
							{
								this._doc.HisMaxLevel.PreLevel = num;
								this.m_btnTras[i].FindChild("Cloud/T").gameObject.SetActive(false);
								IXUITweenTool ixuitweenTool = this.m_btnTras[i].FindChild("Cloud").GetComponent("XUIPlayTween") as IXUITweenTool;
								ixuitweenTool.gameObject.SetActive(true);
								ixuitweenTool.SetTweenGroup(0);
								ixuitweenTool.ResetTweenByGroup(true, 0);
								ixuitweenTool.PlayTween(true, -1f);
							}
							else
							{
								this.m_btnTras[i].FindChild("Cloud").gameObject.SetActive(false);
							}
							IXUISprite ixuisprite = this.m_btnTras[i].GetComponent("XUISprite") as IXUISprite;
							bool flag9 = mapIdByIndex == null;
							if (flag9)
							{
								ixuisprite.ID = 0UL;
							}
							else
							{
								ixuisprite.ID = (ulong)((long)mapIdByIndex.MapID);
							}
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMapClick));
							ixuisprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnMapPress));
						}
					}
				}
			}
		}

		private bool OnCloseClick(IXUIButton go)
		{
			XSuperRiskDocument specificDocument = XDocuments.GetSpecificDocument<XSuperRiskDocument>(XSuperRiskDocument.uuID);
			specificDocument.NeedUpdate = false;
			base.SetVisible(false);
			DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private void OnMapClick(IXUISprite button)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			if (!flag)
			{
				bool flag2 = button.ID == 0UL;
				if (!flag2)
				{
					this._doc.CurrentMapID = (int)button.ID;
					DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.ShowGameMap();
				}
			}
		}

		private bool OnMapPress(IXUISprite uiSprite, bool isPressed)
		{
			GameObject gameObject = uiSprite.gameObject.transform.FindChild("Map").gameObject;
			gameObject.SetActive(isPressed);
			return true;
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

		private XSuperRiskDocument _doc;

		private IXUIButton m_Close;

		private IXUIButton m_Help;

		private List<Transform> m_btnTras = new List<Transform>();

		private float m_fCoolTime = 1f;

		private float m_fLastClickBtnTime = 0f;
	}
}
