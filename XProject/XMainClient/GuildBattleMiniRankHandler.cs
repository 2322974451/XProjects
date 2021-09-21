using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C12 RID: 3090
	internal class GuildBattleMiniRankHandler : DlgHandlerBase
	{
		// Token: 0x170030F5 RID: 12533
		// (get) Token: 0x0600AF85 RID: 44933 RVA: 0x00214710 File Offset: 0x00212910
		protected override string FileName
		{
			get
			{
				return "Battle/GuildTerritoryBattleDlg";
			}
		}

		// Token: 0x0600AF86 RID: 44934 RVA: 0x00214728 File Offset: 0x00212928
		protected override void Init()
		{
			base.Init();
			this.m_sprClose = (base.transform.Find("Bg/offset/LeftView/close").GetComponent("XUISprite") as IXUISprite);
			this.m_btnOpen = (base.transform.Find("Bg/Open").GetComponent("XUIButton") as IXUIButton);
			this.m_boxPoint = (base.transform.Find("Bg/offset/Tabs/Tab_Point").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_boxTerritory = (base.transform.Find("Bg/offset/Tabs/Tab_Territory").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_tween = (base.transform.Find("Bg/offset").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_lblTerritory = (base.transform.Find("Bg/offset/LeftView/TerritoryName").GetComponent("XUILabel") as IXUILabel);
			this.m_lblFeats = (base.transform.Find("Bg/offset/LeftView/TerritoryFeats").GetComponent("XUILabel") as IXUILabel);
			this.m_wrapPoint = (base.transform.Find("Bg/offset/LeftView/PointScrollView/wrap").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_wrapTerritory = (base.transform.Find("Bg/offset/LeftView/TerritoryScrollView/wrap").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_wrapPoint.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapPointUpdate));
			this.m_wrapTerritory.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapTorritoryUpdate));
		}

		// Token: 0x0600AF87 RID: 44935 RVA: 0x002148BC File Offset: 0x00212ABC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_boxTerritory.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTerritoryClick));
			this.m_boxPoint.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabPointClick));
			this.m_sprClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClick));
			this.m_btnOpen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOpenClick));
		}

		// Token: 0x0600AF88 RID: 44936 RVA: 0x00214931 File Offset: 0x00212B31
		protected override void OnShow()
		{
			base.OnShow();
			this.ChangeState(true);
			this.ChangeTab(true);
		}

		// Token: 0x0600AF89 RID: 44937 RVA: 0x0021494C File Offset: 0x00212B4C
		public void RefreshAll()
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			bool activeSelf = this.m_wrapPoint.gameObject.activeSelf;
			if (activeSelf)
			{
				this.m_wrapPoint.SetContentCount(specificDocument.guilds.Count, false);
			}
			bool activeSelf2 = this.m_wrapTerritory.gameObject.activeSelf;
			if (activeSelf2)
			{
				this.m_wrapTerritory.SetContentCount(specificDocument.jvdians.Count, false);
			}
			this.RefreshFeats(specificDocument);
		}

		// Token: 0x0600AF8A RID: 44938 RVA: 0x002149C5 File Offset: 0x00212BC5
		private void ChangeState(bool open)
		{
			this.m_btnOpen.SetVisible(!open);
			this.m_sprClose.SetVisible(open);
		}

		// Token: 0x0600AF8B RID: 44939 RVA: 0x002149E8 File Offset: 0x00212BE8
		private void ChangeTab(bool isScoreTab)
		{
			this.m_wrapPoint.gameObject.SetActive(isScoreTab);
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_WAIT;
			this.m_wrapTerritory.gameObject.SetActive(!isScoreTab && !flag);
			this.m_lblTerritory.SetVisible(!isScoreTab && flag);
		}

		// Token: 0x0600AF8C RID: 44940 RVA: 0x00214A44 File Offset: 0x00212C44
		private bool OnTabPointClick(IXUICheckBox box)
		{
			bool bChecked = box.bChecked;
			if (bChecked)
			{
				this.ChangeTab(true);
			}
			return true;
		}

		// Token: 0x0600AF8D RID: 44941 RVA: 0x00214A6C File Offset: 0x00212C6C
		private bool OnTerritoryClick(IXUICheckBox box)
		{
			bool bChecked = box.bChecked;
			if (bChecked)
			{
				this.ChangeTab(false);
			}
			return true;
		}

		// Token: 0x0600AF8E RID: 44942 RVA: 0x00214A91 File Offset: 0x00212C91
		private void OnCloseClick(IXUISprite sp)
		{
			this.ChangeState(false);
			this.m_tween.ResetTween(true);
			this.m_tween.PlayTween(true, -1f);
		}

		// Token: 0x0600AF8F RID: 44943 RVA: 0x00214ABC File Offset: 0x00212CBC
		private bool OnOpenClick(IXUIButton btn)
		{
			this.ChangeState(true);
			this.m_tween.ResetTween(false);
			this.m_tween.PlayTween(false, -1f);
			return true;
		}

		// Token: 0x0600AF90 RID: 44944 RVA: 0x00214AF8 File Offset: 0x00212CF8
		private void WrapPointUpdate(Transform t, int index)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			bool flag = specificDocument.guilds.Count > index;
			if (flag)
			{
				GCFGuild gcfguild = specificDocument.guilds[index];
				IXUISprite ixuisprite = t.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.Find("Num").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("Score").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = t.Find("BG_SELF").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite3 = t.Find("BG_ENERMY").GetComponent("XUISprite") as IXUISprite;
				ixuilabel.SetText((index + 1).ToString());
				ixuisprite.SetSprite(XGuildDocument.GetPortraitName((int)gcfguild.brief.guildicon));
				ixuilabel2.SetText(gcfguild.brief.guildname);
				ixuilabel3.SetText(gcfguild.brief.point.ToString());
				ixuisprite2.SetVisible(gcfguild.isPartern);
				ixuisprite3.SetVisible(!gcfguild.isPartern);
			}
		}

		// Token: 0x0600AF91 RID: 44945 RVA: 0x00214C58 File Offset: 0x00212E58
		private void WrapTorritoryUpdate(Transform t, int index)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			bool flag = specificDocument.jvdians.Count > index;
			if (flag)
			{
				GCFJvDianInfo gcfjvDianInfo = specificDocument.jvdians[index];
				IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("CheckPoint").GetComponent("XUILabel") as IXUILabel;
				int num = XFastEnumIntEqualityComparer<GCFJvDianType>.ToInt(gcfjvDianInfo.type);
				ixuilabel2.SetText(XStringDefineProxy.GetString("Territory_judian" + num));
				ixuilabel.SetText(string.IsNullOrEmpty(gcfjvDianInfo.guildname) ? "-" : gcfjvDianInfo.guildname);
			}
		}

		// Token: 0x0600AF92 RID: 44946 RVA: 0x00214D18 File Offset: 0x00212F18
		private void RefreshFeats(XGuildTerritoryDocument doc)
		{
			uint feats = doc.feats;
			bool flag = this.seal_list == null;
			if (flag)
			{
				this.CulResult();
			}
			int num = 0;
			for (int i = 0; i < this.seal_list.Count; i++)
			{
				bool flag2 = (long)this.seal_list[i] > (long)((ulong)feats);
				if (flag2)
				{
					num = this.seal_list[i];
					break;
				}
			}
			IXUILabel ixuilabel = this.m_lblFeats.gameObject.transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
			bool flag3 = num != 0;
			if (flag3)
			{
				this.m_lblFeats.SetText(string.Format("{0}/{1}", feats, num));
				ixuilabel.Alpha = 1f;
			}
			else
			{
				this.m_lblFeats.SetText(XStringDefineProxy.GetString("BIG_MELEE_MAX_POINT_STAGE"));
				ixuilabel.Alpha = 0f;
			}
		}

		// Token: 0x0600AF93 RID: 44947 RVA: 0x00214E18 File Offset: 0x00213018
		private void CulResult()
		{
			this.seal_list = new List<int>();
			int num = 0;
			foreach (TerritoryRewd.RowData rowData in XGuildTerritoryDocument.mTerritoryRewd.Table)
			{
				bool flag = rowData.Point != num;
				if (flag)
				{
					this.seal_list.Add(rowData.Point);
					num = rowData.Point;
				}
			}
		}

		// Token: 0x040042E7 RID: 17127
		private IXUISprite m_sprClose;

		// Token: 0x040042E8 RID: 17128
		private IXUIButton m_btnOpen;

		// Token: 0x040042E9 RID: 17129
		private IXUICheckBox m_boxPoint;

		// Token: 0x040042EA RID: 17130
		private IXUICheckBox m_boxTerritory;

		// Token: 0x040042EB RID: 17131
		private IXUITweenTool m_tween;

		// Token: 0x040042EC RID: 17132
		private IXUILabel m_lblTerritory;

		// Token: 0x040042ED RID: 17133
		private IXUILabel m_lblFeats;

		// Token: 0x040042EE RID: 17134
		private IXUIWrapContent m_wrapPoint;

		// Token: 0x040042EF RID: 17135
		private IXUIWrapContent m_wrapTerritory;

		// Token: 0x040042F0 RID: 17136
		private List<int> seal_list;
	}
}
