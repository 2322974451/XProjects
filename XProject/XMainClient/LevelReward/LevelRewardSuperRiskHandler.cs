using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardSuperRiskHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardSuperRiskFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		private void InitUI()
		{
			this.m_SuperRisk = base.transform.Find("Bg/ItemList/SuperRisk");
			this.m_GuildMine = base.transform.Find("Bg/ItemList/GuildMine");
			this.m_MineCount = (this.m_GuildMine.Find("Num").GetComponent("XUILabel") as IXUILabel);
			this.m_ReturnButton = (base.transform.Find("Bg/Button/Back").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/ItemList/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, true);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ReturnButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
		}

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

		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this._doc.SendLeaveScene();
			return true;
		}

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

		public void RefreshMine(uint count)
		{
			this.m_MineCount.SetText(count.ToString());
		}

		private XLevelRewardDocument _doc = null;

		private IXUIButton m_ReturnButton;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_SuperRisk;

		private Transform m_GuildMine;

		private IXUILabel m_MineCount;
	}
}
