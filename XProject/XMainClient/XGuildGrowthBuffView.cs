using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A63 RID: 2659
	internal class XGuildGrowthBuffView : DlgBase<XGuildGrowthBuffView, XGuildGrowthBuffBehavior>
	{
		// Token: 0x17002F19 RID: 12057
		// (get) Token: 0x0600A141 RID: 41281 RVA: 0x001B3D28 File Offset: 0x001B1F28
		public override string fileName
		{
			get
			{
				return "Guild/GuildGrowth/GuildGrowthBuffDlg";
			}
		}

		// Token: 0x17002F1A RID: 12058
		// (get) Token: 0x0600A142 RID: 41282 RVA: 0x001B3D40 File Offset: 0x001B1F40
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002F1B RID: 12059
		// (get) Token: 0x0600A143 RID: 41283 RVA: 0x001B3D54 File Offset: 0x001B1F54
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002F1C RID: 12060
		// (get) Token: 0x0600A144 RID: 41284 RVA: 0x001B3D68 File Offset: 0x001B1F68
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F1D RID: 12061
		// (get) Token: 0x0600A145 RID: 41285 RVA: 0x001B3D7C File Offset: 0x001B1F7C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F1E RID: 12062
		// (get) Token: 0x0600A146 RID: 41286 RVA: 0x001B3D90 File Offset: 0x001B1F90
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F1F RID: 12063
		// (get) Token: 0x0600A147 RID: 41287 RVA: 0x001B3DA4 File Offset: 0x001B1FA4
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildGrowthBuff);
			}
		}

		// Token: 0x0600A148 RID: 41288 RVA: 0x001B3DC0 File Offset: 0x001B1FC0
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
			this._guildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
		}

		// Token: 0x0600A149 RID: 41289 RVA: 0x001B3DE4 File Offset: 0x001B1FE4
		private bool OnClose(IXUIButton button)
		{
			this.SetVisible(false, true);
			return false;
		}

		// Token: 0x0600A14A RID: 41290 RVA: 0x001B3E00 File Offset: 0x001B2000
		private void OnPointClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess(34, null);
		}

		// Token: 0x0600A14B RID: 41291 RVA: 0x001B3E14 File Offset: 0x001B2014
		private bool OnHelpBtnClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildGrowthBuff);
			return true;
		}

		// Token: 0x0600A14C RID: 41292 RVA: 0x001B3E37 File Offset: 0x001B2037
		protected override void OnHide()
		{
			base.uiBehaviour.m_levelUpFx.gameObject.SetActive(false);
			base.OnHide();
		}

		// Token: 0x0600A14D RID: 41293 RVA: 0x001B3E58 File Offset: 0x001B2058
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600A14E RID: 41294 RVA: 0x001B3E64 File Offset: 0x001B2064
		public override void RegisterEvent()
		{
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.HelpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClick));
			base.uiBehaviour.LevelUpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLevelUpBtnClick));
			base.uiBehaviour.m_PointClick.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPointClick));
		}

		// Token: 0x0600A14F RID: 41295 RVA: 0x001B3EE6 File Offset: 0x001B20E6
		protected override void OnShow()
		{
			this._currSelectID = 1;
			this.RefreshList(false);
		}

		// Token: 0x0600A150 RID: 41296 RVA: 0x001B3EF8 File Offset: 0x001B20F8
		private bool OnCheckBoxClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._currSelectID = (int)icb.ID;
				this.RefreshDetail();
				result = true;
			}
			return result;
		}

		// Token: 0x0600A151 RID: 41297 RVA: 0x001B3F30 File Offset: 0x001B2130
		private bool OnLevelUpBtnClick(IXUIButton btn)
		{
			GuildHall.RowData data = this._doc.GetData(this._doc.BuffList[this._currSelectID].BuffID, this._doc.BuffList[this._currSelectID].BuffLevel + 1U);
			bool flag = data == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this._guildDoc.Level < data.glevel;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("GuildGrowthHallGuildLevelNeedShow"), data.glevel), "fece00");
					result = false;
				}
				else
				{
					bool flag3 = !this._doc.LevelUpEnable;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GuildGrowthAuthorityFail"), "fece00");
						result = false;
					}
					else
					{
						this._doc.QueryGuildHallBuffLevelUp(this._doc.BuffList[this._currSelectID].BuffID);
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x0600A152 RID: 41298 RVA: 0x001B4038 File Offset: 0x001B2238
		public void RefreshList(bool forceRefreshDetail = false)
		{
			base.uiBehaviour.BuffItemPool.ReturnAll(false);
			Vector3 tplPos = base.uiBehaviour.BuffItemPool.TplPos;
			int num = 0;
			IXUICheckBox ixuicheckBox = null;
			for (int i = 1; i < this._doc.BuffList.Count; i++)
			{
				GuildHall.RowData data = this._doc.GetData(this._doc.BuffList[i].BuffID, this._doc.BuffList[i].BuffLevel);
				bool flag = data == null;
				if (!flag)
				{
					GameObject gameObject = base.uiBehaviour.BuffItemPool.FetchGameObject(false);
					gameObject.transform.localPosition = tplPos + new Vector3((float)(num % 2 * base.uiBehaviour.BuffItemPool.TplWidth), (float)(-(float)(num / 2) * base.uiBehaviour.BuffItemPool.TplHeight));
					IXUILabel ixuilabel = gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel3 = gameObject.transform.Find("Attr").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					bool flag2 = (long)this.ShowLevelUpFx == (long)((ulong)this._doc.BuffList[i].BuffID);
					if (flag2)
					{
						base.uiBehaviour.m_levelUpFx.position = ixuisprite.transform.position;
						base.uiBehaviour.m_levelUpFx.gameObject.SetActive(false);
						base.uiBehaviour.m_levelUpFx.gameObject.SetActive(true);
						this.ShowLevelUpFx = -1;
					}
					IXUICheckBox ixuicheckBox2 = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckBoxClick));
					ixuicheckBox2.ID = (ulong)i;
					bool flag3 = i == this._currSelectID;
					if (flag3)
					{
						ixuicheckBox = ixuicheckBox2;
					}
					ixuilabel.SetText(string.Format("{0}/{1}", this._doc.BuffList[i].BuffLevel, this._doc.BuffList[i].BuffMaxLevel));
					ixuilabel2.SetText(data.name);
					ixuilabel3.SetText(data.currentLevelDescription);
					ixuisprite.SetSprite(data.icon, data.atlas, false);
					num++;
				}
			}
			bool flag4 = ixuicheckBox != null;
			if (flag4)
			{
				ixuicheckBox.bChecked = true;
			}
			base.uiBehaviour.m_PointLeft.SetText(this._doc.ResourcesPoint.ToString());
			if (forceRefreshDetail)
			{
				this.RefreshDetail();
			}
		}

		// Token: 0x0600A153 RID: 41299 RVA: 0x001B433C File Offset: 0x001B253C
		public void RefreshDetail()
		{
			XSingleton<XDebug>.singleton.AddLog(this._currSelectID.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = this._doc.BuffList[this._currSelectID].BuffLevel == this._doc.BuffList[this._currSelectID].BuffMaxLevel;
			GuildHall.RowData data = this._doc.GetData(this._doc.BuffList[this._currSelectID].BuffID, this._doc.BuffList[this._currSelectID].BuffLevel);
			GuildHall.RowData rowData = flag ? null : this._doc.GetData(this._doc.BuffList[this._currSelectID].BuffID, this._doc.BuffList[this._currSelectID].BuffLevel + 1U);
			base.uiBehaviour.m_DetailBuffIcon.SetSprite(data.icon, data.atlas, false);
			base.uiBehaviour.m_DetailBuffName.SetText(data.name);
			base.uiBehaviour.m_DetailMaxLevel.SetText(this._doc.BuffList[this._currSelectID].BuffMaxLevel.ToString());
			bool flag2 = flag;
			if (flag2)
			{
				base.uiBehaviour.m_DetailCurrLevel.SetVisible(false);
				base.uiBehaviour.m_DetailCostArrow.SetVisible(false);
				base.uiBehaviour.m_DetailCurrKeepCost.SetText(XStringDefineProxy.GetString("GuildGrowthHallCost"));
				base.uiBehaviour.m_DetailNextKeepCost.SetText(data.dailyneed.ToString());
				base.uiBehaviour.m_NextAttrText.SetText(XStringDefineProxy.GetString("GuildGrowthTextMax"));
				base.uiBehaviour.m_DetailCost.InputText = "0";
				base.uiBehaviour.LevelUpBtn.SetEnable(false, false);
				base.uiBehaviour.LevelUpText.SetText(XStringDefineProxy.GetString("GuildGrowthHallMaxLevel"));
			}
			else
			{
				base.uiBehaviour.m_DetailCurrLevel.SetVisible(true);
				base.uiBehaviour.m_DetailCostArrow.SetVisible(true);
				base.uiBehaviour.m_DetailCurrLevel.SetText(string.Format("{0} {1}", XStringDefineProxy.GetString("GuildGrowthHallLevel"), this._doc.BuffList[this._currSelectID].BuffLevel));
				base.uiBehaviour.m_DetailNextLevel.SetText((this._doc.BuffList[this._currSelectID].BuffLevel + 1U).ToString());
				base.uiBehaviour.m_DetailCurrKeepCost.SetText(string.Format("{0} {1}", XStringDefineProxy.GetString("GuildGrowthHallCost"), data.dailyneed));
				base.uiBehaviour.m_DetailNextKeepCost.SetText(rowData.dailyneed.ToString());
				base.uiBehaviour.m_NextAttrText.SetText(string.Format(XStringDefineProxy.GetString("GuildGrowthNextText"), rowData.currentLevelDescription));
				base.uiBehaviour.m_DetailCost.InputText = string.Format("{0}{1}{2}", (this._doc.ResourcesPoint >= rowData.updateneed) ? "" : "[e60012]", XLabelSymbolHelper.FormatSmallIcon(34), rowData.updateneed);
				base.uiBehaviour.LevelUpBtn.SetEnable(true, false);
				base.uiBehaviour.LevelUpBtn.SetGrey(this._guildDoc.Level >= rowData.glevel);
				base.uiBehaviour.LevelUpText.SetText(XStringDefineProxy.GetString((this._guildDoc.Level >= rowData.glevel) ? "GuildGrowthHallLevelUp" : "GuildGrowthHallGuildLevelNeed"));
			}
		}

		// Token: 0x04003A12 RID: 14866
		private XGuildGrowthDocument _doc;

		// Token: 0x04003A13 RID: 14867
		private XGuildDocument _guildDoc;

		// Token: 0x04003A14 RID: 14868
		private int _currSelectID = 0;

		// Token: 0x04003A15 RID: 14869
		public int ShowLevelUpFx = -1;
	}
}
