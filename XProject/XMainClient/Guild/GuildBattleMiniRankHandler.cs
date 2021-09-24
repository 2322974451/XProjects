using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildBattleMiniRankHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/GuildTerritoryBattleDlg";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_boxTerritory.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTerritoryClick));
			this.m_boxPoint.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabPointClick));
			this.m_sprClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClick));
			this.m_btnOpen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOpenClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ChangeState(true);
			this.ChangeTab(true);
		}

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

		private void ChangeState(bool open)
		{
			this.m_btnOpen.SetVisible(!open);
			this.m_sprClose.SetVisible(open);
		}

		private void ChangeTab(bool isScoreTab)
		{
			this.m_wrapPoint.gameObject.SetActive(isScoreTab);
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_WAIT;
			this.m_wrapTerritory.gameObject.SetActive(!isScoreTab && !flag);
			this.m_lblTerritory.SetVisible(!isScoreTab && flag);
		}

		private bool OnTabPointClick(IXUICheckBox box)
		{
			bool bChecked = box.bChecked;
			if (bChecked)
			{
				this.ChangeTab(true);
			}
			return true;
		}

		private bool OnTerritoryClick(IXUICheckBox box)
		{
			bool bChecked = box.bChecked;
			if (bChecked)
			{
				this.ChangeTab(false);
			}
			return true;
		}

		private void OnCloseClick(IXUISprite sp)
		{
			this.ChangeState(false);
			this.m_tween.ResetTween(true);
			this.m_tween.PlayTween(true, -1f);
		}

		private bool OnOpenClick(IXUIButton btn)
		{
			this.ChangeState(true);
			this.m_tween.ResetTween(false);
			this.m_tween.PlayTween(false, -1f);
			return true;
		}

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

		private IXUISprite m_sprClose;

		private IXUIButton m_btnOpen;

		private IXUICheckBox m_boxPoint;

		private IXUICheckBox m_boxTerritory;

		private IXUITweenTool m_tween;

		private IXUILabel m_lblTerritory;

		private IXUILabel m_lblFeats;

		private IXUIWrapContent m_wrapPoint;

		private IXUIWrapContent m_wrapTerritory;

		private List<int> seal_list;
	}
}
