using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FlowerActivityHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/FlowerActivityFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_Tip1 = (base.PanelObject.transform.Find("Main/Tip1").GetComponent("XUILabel") as IXUILabel);
			this.m_Tip2 = (base.PanelObject.transform.Find("Main/Tip2").GetComponent("XUILabel") as IXUILabel);
			this.m_AwardRankCount = (base.PanelObject.transform.Find("Main/Items/RankNum").GetComponent("XUILabel") as IXUILabel);
			this.m_GoWeekRank = (base.PanelObject.transform.Find("Main/Btns/ViewRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_AwardRoot = base.PanelObject.transform.Find("Main/Items");
			GameObject gameObject = base.PanelObject.transform.Find("Main/Items/Item").gameObject;
			this.m_ItemPool.SetupPool(this.m_AwardRoot.gameObject, gameObject, 7U, false);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_Tip1.SetText(XSingleton<XStringTable>.singleton.GetString("FLOWER_ACTIVITY_TIP1"));
			this.m_Tip2.SetText(XSingleton<XStringTable>.singleton.GetString("FLOWER_ACTIVITY_TIP3"));
			this.m_AwardRankCount.SetText(XSingleton<XStringTable>.singleton.GetString("FLOWER_ACTIVITY_AWARD_RANK"));
			this.SetAwardsInfo();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_GoWeekRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoWeekRankClicked));
		}

		private bool OnGoWeekRankClicked(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Flower_Rank_Week, 0UL);
			return true;
		}

		private void SetAwardsInfo()
		{
			XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
			SeqListRef<int> weekRankAward = specificDocument.GetWeekRankAward(1);
			this.m_ItemPool.ReturnAll(false);
			for (int i = 0; i < weekRankAward.Count; i++)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.transform.parent = this.m_AwardRoot;
				gameObject.name = i.ToString();
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3((float)(this.m_ItemPool.TplWidth * i), 0f, 0f);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)weekRankAward[i, 0]);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, weekRankAward[i, 0], weekRankAward[i, 1], false);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		private IXUILabel m_Tip1;

		private IXUILabel m_Tip2;

		private IXUILabel m_AwardRankCount;

		private IXUIButton m_GoWeekRank;

		private Transform m_AwardRoot;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
