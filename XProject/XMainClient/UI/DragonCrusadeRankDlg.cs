using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001738 RID: 5944
	internal class DragonCrusadeRankDlg : DlgBase<DragonCrusadeRankDlg, DragonCrusadeRankBehavior>
	{
		// Token: 0x170037C1 RID: 14273
		// (get) Token: 0x0600F573 RID: 62835 RVA: 0x003769F4 File Offset: 0x00374BF4
		public override string fileName
		{
			get
			{
				return "DragonCrusade/DragonCrusadeRank";
			}
		}

		// Token: 0x170037C2 RID: 14274
		// (get) Token: 0x0600F574 RID: 62836 RVA: 0x00376A0C File Offset: 0x00374C0C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037C3 RID: 14275
		// (get) Token: 0x0600F575 RID: 62837 RVA: 0x00376A20 File Offset: 0x00374C20
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037C4 RID: 14276
		// (get) Token: 0x0600F576 RID: 62838 RVA: 0x00376A34 File Offset: 0x00374C34
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037C5 RID: 14277
		// (get) Token: 0x0600F577 RID: 62839 RVA: 0x00376A48 File Offset: 0x00374C48
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037C6 RID: 14278
		// (get) Token: 0x0600F578 RID: 62840 RVA: 0x00376A5C File Offset: 0x00374C5C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037C7 RID: 14279
		// (get) Token: 0x0600F579 RID: 62841 RVA: 0x00376A70 File Offset: 0x00374C70
		public bool isHallUI
		{
			get
			{
				return XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			}
		}

		// Token: 0x170037C8 RID: 14280
		// (get) Token: 0x0600F57A RID: 62842 RVA: 0x00376A94 File Offset: 0x00374C94
		public override int sysid
		{
			get
			{
				return 50;
			}
		}

		// Token: 0x0600F57B RID: 62843 RVA: 0x00376AA8 File Offset: 0x00374CA8
		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		// Token: 0x0600F57C RID: 62844 RVA: 0x00376AB4 File Offset: 0x00374CB4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClosedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
		}

		// Token: 0x0600F57D RID: 62845 RVA: 0x00376ADB File Offset: 0x00374CDB
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600F57E RID: 62846 RVA: 0x00376AE8 File Offset: 0x00374CE8
		protected override void OnLoad()
		{
			base.OnLoad();
			this.mDoc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XDragonCrusadeDocument.uuID) as XDragonCrusadeDocument);
			GameObject gameObject = base.SetXUILable("Bg/CountDown/CountDown", "");
			IXUILabel label = gameObject.GetComponent("XUILabel") as IXUILabel;
			this.m_LeftTime = new XLeftTimeCounter(label, false);
			this.ScrollViewInit();
		}

		// Token: 0x0600F57F RID: 62847 RVA: 0x00376B54 File Offset: 0x00374D54
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_LeftTime != null;
			if (flag)
			{
				this.m_LeftTime.Update();
				bool flag2 = this.m_LeftTime.GetLeftTime() <= 0;
				if (flag2)
				{
				}
			}
		}

		// Token: 0x0600F580 RID: 62848 RVA: 0x00376B9C File Offset: 0x00374D9C
		private void ScrollViewInit()
		{
			Transform transform = base.uiBehaviour.transform.Find("ScrollView/GuildList/Tpl");
			this.m_role_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
		}

		// Token: 0x0600F581 RID: 62849 RVA: 0x00376BE0 File Offset: 0x00374DE0
		public void RefreshRankWindow(DERankRes oRes)
		{
			bool flag = oRes != null;
			if (flag)
			{
				this.m_LeftTime.SetLeftTime(oRes.rewardlefttime, -1);
			}
			bool flag2 = oRes == null || oRes.ranks == null || oRes.ranks.Count == 0;
			if (flag2)
			{
				base.uiBehaviour.m_EmptyHint.SetActive(true);
			}
			else
			{
				Vector3 tplPos = this.m_role_pool.TplPos;
				this.m_role_pool.FakeReturnAll();
				for (int i = 0; i < oRes.ranks.Count; i++)
				{
					DERank derank = oRes.ranks[i];
					GameObject gameObject = this.m_role_pool.FetchGameObject(false);
					IXUILabel ixuilabel = gameObject.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel3 = gameObject.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel4 = gameObject.transform.FindChild("LeaderName").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite = gameObject.transform.FindChild("P").GetComponent("XUISprite") as IXUISprite;
					ixuilabel.SetText(derank.rank.ToString());
					IXUISprite ixuisprite2 = gameObject.transform.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
					bool flag3 = i < 3;
					if (flag3)
					{
						ixuisprite2.SetSprite("N" + (i + 1));
						ixuisprite2.SetVisible(true);
						ixuilabel.SetVisible(false);
					}
					else
					{
						ixuisprite2.SetVisible(false);
						ixuilabel.SetVisible(true);
					}
					ixuilabel2.SetText(derank.rolename);
					string text = string.Empty;
					for (int j = 0; j < derank.reward.Count; j++)
					{
						ItemBrief itemBrief = derank.reward[j];
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemBrief.itemID);
						text += itemBrief.itemCount.ToString();
					}
					ixuilabel3.SetText(text);
					bool flag4 = derank.progress != null;
					if (flag4)
					{
						ixuilabel4.SetText(this.mDoc.GetChapter(derank.progress.sceneID) + " " + (100 - derank.progress.bossavghppercent).ToString() + "%");
					}
					else
					{
						ixuilabel4.SetText(this.mDoc.GetChapter(derank.progress.sceneID) + "info.progress == null%");
					}
					ixuilabel2.ID = derank.roleID;
					bool flag5 = derank.roleID == 0UL;
					if (flag5)
					{
						ixuilabel2.RegisterLabelClickEventHandler(null);
					}
					else
					{
						ixuilabel2.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnRankItemClicked));
					}
					bool flag6 = i % 2 == 0;
					if (flag6)
					{
						ixuisprite.SetVisible(true);
						ixuisprite.SetSprite("Panel_popup2_back");
					}
					else
					{
						ixuisprite.SetVisible(false);
						ixuisprite.SetSprite("Panel_popup2_back");
					}
					gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(this.m_role_pool.TplHeight * i), tplPos.z);
				}
				this.m_role_pool.ActualReturnAll(false);
				base.uiBehaviour.m_scroll_view.ResetPosition();
				base.uiBehaviour.m_EmptyHint.SetActive(false);
			}
		}

		// Token: 0x0600F582 RID: 62850 RVA: 0x00236154 File Offset: 0x00234354
		private void OnRankItemClicked(IXUILabel label)
		{
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(label.ID, false);
		}

		// Token: 0x0600F583 RID: 62851 RVA: 0x00376FB4 File Offset: 0x003751B4
		protected bool OnClose(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x04006A60 RID: 27232
		private XDragonCrusadeDocument mDoc = null;

		// Token: 0x04006A61 RID: 27233
		private XLeftTimeCounter m_LeftTime;

		// Token: 0x04006A62 RID: 27234
		private XUIPool m_role_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
