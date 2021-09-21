using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001796 RID: 6038
	internal class BattleRecordHandler : DlgHandlerBase
	{
		// Token: 0x0600F950 RID: 63824 RVA: 0x003937B4 File Offset: 0x003919B4
		protected override void Init()
		{
			base.Init();
			this.m_RecordCloseBtn = (base.PanelObject.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.Find("Message/Tpl");
			this.m_RecordMemberPool.SetupPool(transform.parent.gameObject, transform.gameObject, 32U, false);
			transform = base.PanelObject.transform.Find("Message/MessTpl");
			this.m_RecordMessagePool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_RecordEmpty = base.PanelObject.transform.Find("Empty").gameObject;
			this.m_BattleRecordJustShowTips = base.PanelObject.transform.Find("Message/JustShow");
			this.m_ScrollView = (base.PanelObject.transform.Find("Message").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		// Token: 0x0600F951 RID: 63825 RVA: 0x003938C3 File Offset: 0x00391AC3
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_RecordCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleRecordCloseBtnClick));
		}

		// Token: 0x0600F952 RID: 63826 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600F953 RID: 63827 RVA: 0x003938E8 File Offset: 0x00391AE8
		public void SetupRecord(List<BattleRecordGameInfo> RecordList)
		{
			base.SetVisible(true);
			this.m_RecordMemberPool.ReturnAll(true);
			this.m_RecordMessagePool.ReturnAll(false);
			this.m_RecordEmpty.SetActive(RecordList.Count == 0);
			Vector3 tplPos = this.m_RecordMessagePool.TplPos;
			for (int i = 0; i < RecordList.Count; i++)
			{
				GameObject gameObject = this.m_RecordMessagePool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(i * this.m_RecordMessagePool.TplHeight));
				IXUISprite ixuisprite = gameObject.transform.Find("res").GetComponent("XUISprite") as IXUISprite;
				Transform transform = gameObject.transform.Find("MilitaryValue");
				bool flag = transform != null;
				if (flag)
				{
					IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
					bool flag2 = RecordList[i].result == HeroBattleOver.HeroBattleOver_Lose;
					if (flag2)
					{
						ixuilabel.SetText("-" + RecordList[i].militaryExploit.ToString());
					}
					else
					{
						ixuilabel.SetText("+" + RecordList[i].militaryExploit.ToString());
					}
				}
				transform = gameObject.transform.Find("Point2V2");
				bool flag3 = transform != null;
				if (flag3)
				{
					IXUILabel ixuilabel2 = transform.GetComponent("XUILabel") as IXUILabel;
					bool flag4 = RecordList[i].point2V2 >= 0;
					if (flag4)
					{
						ixuilabel2.SetText("+" + RecordList[i].point2V2.ToString());
					}
					else
					{
						ixuilabel2.SetText("-" + (-RecordList[i].point2V2).ToString());
					}
				}
				switch (RecordList[i].result)
				{
				case HeroBattleOver.HeroBattleOver_Win:
					ixuisprite.spriteName = "bhdz_win";
					break;
				case HeroBattleOver.HeroBattleOver_Lose:
					ixuisprite.spriteName = "bhdz_lose";
					break;
				case HeroBattleOver.HeroBattleOver_Draw:
					ixuisprite.spriteName = "bhdz_p";
					break;
				}
				this.SetupRecordTeam(RecordList[i].left, gameObject.transform.Find("MyTeam"));
				this.SetupRecordTeam(RecordList[i].right, gameObject.transform.Find("OtherTeam"));
			}
			this.m_BattleRecordJustShowTips.gameObject.SetActive(RecordList.Count == 10);
			bool flag5 = RecordList.Count == 10;
			if (flag5)
			{
				this.m_BattleRecordJustShowTips.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(10 * this.m_RecordMessagePool.TplHeight));
			}
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600F954 RID: 63828 RVA: 0x00393BD8 File Offset: 0x00391DD8
		private void SetupRecordTeam(List<BattleRecordPlayerInfo> list, Transform parent)
		{
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = this.m_RecordMemberPool.FetchGameObject(false);
				gameObject.transform.parent = parent;
				gameObject.transform.localPosition = new Vector3((float)(i * this.m_RecordMemberPool.TplWidth), 0f);
				IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)list[i].profression);
				bool flag = list[i].roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					ixuilabel.SetText(XStringDefineProxy.GetString("ME"));
					ixuisprite.RegisterSpriteClickEventHandler(null);
				}
				else
				{
					ixuilabel.SetText(this.CutString(list[i].name));
					ixuisprite.ID = list[i].roleID;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHeadClicked));
				}
			}
		}

		// Token: 0x0600F955 RID: 63829 RVA: 0x00393D24 File Offset: 0x00391F24
		public string CutString(string str)
		{
			int num = 4;
			int num2 = 0;
			string text = "";
			foreach (char c in str)
			{
				num2++;
				bool flag = num2 > num;
				if (flag)
				{
					text += "..";
					break;
				}
				text += c.ToString();
			}
			return text;
		}

		// Token: 0x0600F956 RID: 63830 RVA: 0x00393D90 File Offset: 0x00391F90
		private void OnHeadClicked(IXUISprite iSp)
		{
			bool flag = iSp.ID > 0UL;
			if (flag)
			{
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(iSp.ID, false);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CAPTAIN_PLAYERS_DIFFERENT_SERVER"), "fece00");
			}
		}

		// Token: 0x0600F957 RID: 63831 RVA: 0x00393DE0 File Offset: 0x00391FE0
		private bool OnBattleRecordCloseBtnClick(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04006CE2 RID: 27874
		public IXUIButton m_RecordCloseBtn;

		// Token: 0x04006CE3 RID: 27875
		public XUIPool m_RecordMemberPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006CE4 RID: 27876
		public XUIPool m_RecordMessagePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006CE5 RID: 27877
		public GameObject m_RecordEmpty;

		// Token: 0x04006CE6 RID: 27878
		public Transform m_BattleRecordJustShowTips;

		// Token: 0x04006CE7 RID: 27879
		public IXUIScrollView m_ScrollView;
	}
}
