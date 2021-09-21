using System;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BA3 RID: 2979
	internal class LevelRewardRaceHandler : DlgHandlerBase
	{
		// Token: 0x17003048 RID: 12360
		// (get) Token: 0x0600AAEA RID: 43754 RVA: 0x001EEBFC File Offset: 0x001ECDFC
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardRaceFrame";
			}
		}

		// Token: 0x0600AAEB RID: 43755 RVA: 0x001EEC14 File Offset: 0x001ECE14
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.m_Return = (base.PanelObject.transform.Find("Bg/Return").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.PanelObject.transform.Find("Bg/Panel/InfoTpl");
			this.m_InfoPool.SetupPool(null, transform.gameObject, LevelRewardRaceHandler.RACE_PLAYER_COUNT_MAX, false);
		}

		// Token: 0x0600AAEC RID: 43756 RVA: 0x001EEC92 File Offset: 0x001ECE92
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Return.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturnButtonClicked));
		}

		// Token: 0x0600AAED RID: 43757 RVA: 0x001EECB4 File Offset: 0x001ECEB4
		private void OnReturnButtonClicked(IXUISprite iSp)
		{
			this.doc.SendLeaveScene();
		}

		// Token: 0x0600AAEE RID: 43758 RVA: 0x001EECC3 File Offset: 0x001ECEC3
		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		// Token: 0x0600AAEF RID: 43759 RVA: 0x001EECD9 File Offset: 0x001ECED9
		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
		}

		// Token: 0x0600AAF0 RID: 43760 RVA: 0x001EECEC File Offset: 0x001ECEEC
		private void OnShowUI()
		{
			XLevelRewardDocument.RaceData raceBattleData = this.doc.RaceBattleData;
			XRaceDocument specificDocument = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
			bool flag = specificDocument.RaceHandler != null;
			if (flag)
			{
				specificDocument.RaceHandler.HideInfo();
			}
			this.m_InfoPool.FakeReturnAll();
			for (int i = 1; i <= raceBattleData.rolename.Count; i++)
			{
				int j;
				for (j = 0; j < raceBattleData.rolename.Count; j++)
				{
					bool flag2 = (ulong)raceBattleData.rank[j] == (ulong)((long)i);
					if (flag2)
					{
						break;
					}
				}
				bool flag3 = j == raceBattleData.rolename.Count;
				if (flag3)
				{
					StringBuilder stringBuilder = new StringBuilder();
					for (int k = 0; k < raceBattleData.rolename.Count; k++)
					{
						stringBuilder.Append(raceBattleData.rank[k]);
						stringBuilder.Append(" ");
					}
					XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
					{
						"No Find rank:",
						i,
						"\n",
						stringBuilder
					}), null, null, null, null, null);
				}
				else
				{
					GameObject gameObject = this.m_InfoPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_InfoPool.TplHeight * (i - 1)), 0f);
					IXUISprite ixuisprite = gameObject.transform.Find("Detail/Avatar").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(raceBattleData.profession[j]));
					IXUILabel ixuilabel = gameObject.transform.Find("Detail/Name").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(raceBattleData.rolename[j]);
					IXUISprite ixuisprite2 = gameObject.transform.Find("RankImage").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.SetSprite((i <= 3) ? string.Format("N{0}", i) : "");
					IXUILabel ixuilabel2 = gameObject.transform.Find("Rank").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText(i.ToString());
					IXUILabel ixuilabel3 = gameObject.transform.Find("PetName").GetComponent("XUILabel") as IXUILabel;
					PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(raceBattleData.petid[j]);
					bool flag4 = petInfo == null;
					if (flag4)
					{
						ixuilabel3.SetText("");
					}
					else
					{
						ixuilabel3.SetText(XPetDocument.GetPetInfo(raceBattleData.petid[j]).name);
					}
					IXUILabel ixuilabel4 = gameObject.transform.Find("Time").GetComponent("XUILabel") as IXUILabel;
					bool flag5 = raceBattleData.time[j] > 0U;
					if (flag5)
					{
						ixuilabel4.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(raceBattleData.time[j] / 1000f, 2, 3, 4, false));
					}
					else
					{
						ixuilabel4.SetText("-- : -- . --");
					}
					XUIPool xuipool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
					Transform transform = gameObject.transform.Find("Reward/ItemTpl");
					xuipool.SetupPool(null, transform.gameObject, 3U, false);
					xuipool.FakeReturnAll();
					for (int l = 0; l < raceBattleData.item[j].Count; l++)
					{
						GameObject gameObject2 = xuipool.FetchGameObject(false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)raceBattleData.item[j][l].itemID, (int)raceBattleData.item[j][l].itemCount, false);
						gameObject2.transform.localPosition = new Vector3((float)(l * xuipool.TplWidth), 0f, 0f);
						IXUISprite ixuisprite3 = gameObject2.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite3.ID = (ulong)raceBattleData.item[j][l].itemID;
						ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
					}
					xuipool.ActualReturnAll(false);
				}
			}
			this.m_InfoPool.ActualReturnAll(false);
		}

		// Token: 0x04003FBD RID: 16317
		private XLevelRewardDocument doc = null;

		// Token: 0x04003FBE RID: 16318
		public static readonly uint RACE_PLAYER_COUNT_MAX = 8U;

		// Token: 0x04003FBF RID: 16319
		private IXUISprite m_Return;

		// Token: 0x04003FC0 RID: 16320
		private XUIPool m_InfoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
