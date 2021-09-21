using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BAC RID: 2988
	internal class LevelRewardSuperRiskHandler : DlgHandlerBase
	{
		// Token: 0x17003051 RID: 12369
		// (get) Token: 0x0600AB50 RID: 43856 RVA: 0x001F33D8 File Offset: 0x001F15D8
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardSuperRiskFrame";
			}
		}

		// Token: 0x0600AB51 RID: 43857 RVA: 0x001F33EF File Offset: 0x001F15EF
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		// Token: 0x0600AB52 RID: 43858 RVA: 0x001F3410 File Offset: 0x001F1610
		private void InitUI()
		{
			this.m_SuperRisk = base.transform.Find("Bg/ItemList/SuperRisk");
			this.m_GuildMine = base.transform.Find("Bg/ItemList/GuildMine");
			this.m_MineCount = (this.m_GuildMine.Find("Num").GetComponent("XUILabel") as IXUILabel);
			this.m_ReturnButton = (base.transform.Find("Bg/Button/Back").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/ItemList/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, true);
		}

		// Token: 0x0600AB53 RID: 43859 RVA: 0x001F34C4 File Offset: 0x001F16C4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ReturnButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
		}

		// Token: 0x0600AB54 RID: 43860 RVA: 0x001F34E8 File Offset: 0x001F16E8
		protected override void OnShow()
		{
			base.OnShow();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RESWAR_PVP || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RESWAR_PVE;
			if (flag)
			{
				this.m_SuperRisk.gameObject.SetActive(false);
				this.m_GuildMine.gameObject.SetActive(true);
				XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
				XLevelRewardDocument.GuildMineData guildMineBattleData = specificDocument.GuildMineBattleData;
				this.RefreshReward(guildMineBattleData.item);
				this.RefreshMine(guildMineBattleData.mine);
				XSingleton<XUICacheMgr>.singleton.RemoveCachedUI(XSysDefine.XSys_Team);
				XGuildMineMainDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
				specificDocument2.IsNeedShowMainUI = true;
			}
			else
			{
				this.m_SuperRisk.gameObject.SetActive(true);
				this.m_GuildMine.gameObject.SetActive(false);
				this.RefreshReward(this._doc.Items);
			}
		}

		// Token: 0x0600AB55 RID: 43861 RVA: 0x001F35CC File Offset: 0x001F17CC
		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this._doc.SendLeaveScene();
			return true;
		}

		// Token: 0x0600AB56 RID: 43862 RVA: 0x001F35EC File Offset: 0x001F17EC
		public void RefreshReward(List<ItemBrief> item)
		{
			this.m_ItemPool.ReturnAll(false);
			float num = (float)(item.Count - 1) / 2f * (float)this.m_ItemPool.TplWidth;
			for (int i = 0; i < item.Count; i++)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)item[i].itemID;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)item[i].itemID, (int)item[i].itemCount, false);
				gameObject.transform.localPosition = new Vector3(this.m_ItemPool.TplPos.x + (float)(i * this.m_ItemPool.TplWidth) - num, this.m_ItemPool.TplPos.y);
				bool isbind = item[i].isbind;
				if (isbind)
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnBindItemClick));
				}
				else
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
			}
		}

		// Token: 0x0600AB57 RID: 43863 RVA: 0x001F3736 File Offset: 0x001F1936
		public void RefreshMine(uint count)
		{
			this.m_MineCount.SetText(count.ToString());
		}

		// Token: 0x04004018 RID: 16408
		private XLevelRewardDocument _doc = null;

		// Token: 0x04004019 RID: 16409
		private IXUIButton m_ReturnButton;

		// Token: 0x0400401A RID: 16410
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400401B RID: 16411
		private Transform m_SuperRisk;

		// Token: 0x0400401C RID: 16412
		private Transform m_GuildMine;

		// Token: 0x0400401D RID: 16413
		private IXUILabel m_MineCount;
	}
}
