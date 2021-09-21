using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200181A RID: 6170
	internal class SuperRiskSelectMapHandler : DlgHandlerBase
	{
		// Token: 0x1700390C RID: 14604
		// (get) Token: 0x06010025 RID: 65573 RVA: 0x003CC390 File Offset: 0x003CA590
		protected override string FileName
		{
			get
			{
				return "GameSystem/SuperRisk/SelectMapHandler";
			}
		}

		// Token: 0x06010026 RID: 65574 RVA: 0x003CC3A8 File Offset: 0x003CA5A8
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

		// Token: 0x06010027 RID: 65575 RVA: 0x003CC48E File Offset: 0x003CA68E
		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x06010028 RID: 65576 RVA: 0x003CC4C4 File Offset: 0x003CA6C4
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_SuperRisk);
			return true;
		}

		// Token: 0x06010029 RID: 65577 RVA: 0x003CC4E4 File Offset: 0x003CA6E4
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0601002A RID: 65578 RVA: 0x003CC4F8 File Offset: 0x003CA6F8
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

		// Token: 0x0601002B RID: 65579 RVA: 0x003CC8CC File Offset: 0x003CAACC
		private bool OnCloseClick(IXUIButton go)
		{
			XSuperRiskDocument specificDocument = XDocuments.GetSpecificDocument<XSuperRiskDocument>(XSuperRiskDocument.uuID);
			specificDocument.NeedUpdate = false;
			base.SetVisible(false);
			DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601002C RID: 65580 RVA: 0x003CC908 File Offset: 0x003CAB08
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

		// Token: 0x0601002D RID: 65581 RVA: 0x003CC958 File Offset: 0x003CAB58
		private bool OnMapPress(IXUISprite uiSprite, bool isPressed)
		{
			GameObject gameObject = uiSprite.gameObject.transform.FindChild("Map").gameObject;
			gameObject.SetActive(isPressed);
			return true;
		}

		// Token: 0x0601002E RID: 65582 RVA: 0x003CC990 File Offset: 0x003CAB90
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

		// Token: 0x040071A2 RID: 29090
		private XSuperRiskDocument _doc;

		// Token: 0x040071A3 RID: 29091
		private IXUIButton m_Close;

		// Token: 0x040071A4 RID: 29092
		private IXUIButton m_Help;

		// Token: 0x040071A5 RID: 29093
		private List<Transform> m_btnTras = new List<Transform>();

		// Token: 0x040071A6 RID: 29094
		private float m_fCoolTime = 1f;

		// Token: 0x040071A7 RID: 29095
		private float m_fLastClickBtnTime = 0f;
	}
}
