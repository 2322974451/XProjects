using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DragonCrusadeRankDlg : DlgBase<DragonCrusadeRankDlg, DragonCrusadeRankBehavior>
	{

		public override string fileName
		{
			get
			{
				return "DragonCrusade/DragonCrusadeRank";
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override int layer
		{
			get
			{
				return 1;
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

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public bool isHallUI
		{
			get
			{
				return XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			}
		}

		public override int sysid
		{
			get
			{
				return 50;
			}
		}

		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClosedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
		}

		protected override void Init()
		{
			base.Init();
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			this.mDoc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XDragonCrusadeDocument.uuID) as XDragonCrusadeDocument);
			GameObject gameObject = base.SetXUILable("Bg/CountDown/CountDown", "");
			IXUILabel label = gameObject.GetComponent("XUILabel") as IXUILabel;
			this.m_LeftTime = new XLeftTimeCounter(label, false);
			this.ScrollViewInit();
		}

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

		private void ScrollViewInit()
		{
			Transform transform = base.uiBehaviour.transform.Find("ScrollView/GuildList/Tpl");
			this.m_role_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
		}

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

		private void OnRankItemClicked(IXUILabel label)
		{
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(label.ID, false);
		}

		protected bool OnClose(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		private XDragonCrusadeDocument mDoc = null;

		private XLeftTimeCounter m_LeftTime;

		private XUIPool m_role_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
