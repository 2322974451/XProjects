using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200172B RID: 5931
	internal class XBattleTeamTowerHandler : DlgHandlerBase
	{
		// Token: 0x0600F4E7 RID: 62695 RVA: 0x00371E00 File Offset: 0x00370000
		protected override void Init()
		{
			base.Init();
			this._total_coin = (base.PanelObject.transform.FindChild("TotalCoin").GetComponent("XUILabel") as IXUILabel);
			this._req_level = (base.PanelObject.transform.FindChild("InfoBack/Level").GetComponent("XUILabel") as IXUILabel);
			this._req_fight_point = (base.PanelObject.transform.FindChild("InfoBack/FightPoint").GetComponent("XUILabel") as IXUILabel);
			this._difficulty = (base.PanelObject.transform.FindChild("InfoBack/Difficulty").GetComponent("XUILabel") as IXUILabel);
			this._coin_tween = XNumberTween.Create(this._total_coin);
			this._total_manao = (base.PanelObject.transform.FindChild("TotalManao").GetComponent("XUILabel") as IXUILabel);
			this._manao_tween = XNumberTween.Create(this._total_manao);
		}

		// Token: 0x0600F4E8 RID: 62696 RVA: 0x00371F0C File Offset: 0x0037010C
		public void SetLeftTime(uint leftTime)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(leftTime, -1);
			}
			bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag2)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetLeftTime(leftTime);
			}
		}

		// Token: 0x0600F4E9 RID: 62697 RVA: 0x00371F50 File Offset: 0x00370150
		public void OnRefreshTowerInfo(PtcG2C_TowerSceneInfoNtf infoNtf)
		{
			bool flag = infoNtf.Data.leftTime > 0;
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime((uint)infoNtf.Data.leftTime, -1);
				}
				bool flag3 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag3)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetLeftTime((uint)infoNtf.Data.leftTime);
				}
			}
			bool flag4 = false;
			bool flag5 = false;
			for (int i = 0; i < infoNtf.Data.items.Count; i++)
			{
				ItemBrief itemBrief = infoNtf.Data.items[i];
				bool flag6 = itemBrief.itemID == 1U;
				if (flag6)
				{
					this._coin_tween.SetNumberWithTween((ulong)infoNtf.Data.items[0].itemCount, "", false, true);
					flag4 = true;
				}
				else
				{
					bool flag7 = itemBrief.itemID == 93U;
					if (flag7)
					{
						this._manao_tween.SetNumberWithTween((ulong)infoNtf.Data.items[1].itemCount, "", false, true);
						flag5 = true;
					}
				}
			}
			bool flag8 = !flag4;
			if (flag8)
			{
				this._coin_tween.SetNumberWithTween(0UL, "", false, true);
			}
			bool flag9 = !flag5;
			if (flag9)
			{
				this._manao_tween.SetNumberWithTween(0UL, "", false, true);
			}
			this._req_level.SetText(infoNtf.Data.curTowerFloor.ToString());
			double attr = XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Total);
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			double num = (double)sceneData.RecommendPower * 1.0;
			bool flag10 = sceneData != null;
			if (flag10)
			{
				num = (double)sceneData.RecommendPower * 1.0;
			}
			double num2 = (attr - num * 1.0) / num * 1.0;
			bool flag11 = num2 > 0.01;
			if (flag11)
			{
				this._req_fight_point.SetText(num.ToString());
				this._req_fight_point.SetColor(Color.green);
			}
			else
			{
				bool flag12 = num2 > -0.01;
				if (flag12)
				{
					this._req_fight_point.SetText(string.Format("[e2ca9e]{0}[-]", num));
				}
				else
				{
					this._req_fight_point.SetText(num.ToString());
					this._req_fight_point.SetColor(Color.red);
				}
			}
			this._difficulty.SetText("");
		}

		// Token: 0x040069BE RID: 27070
		public IXUILabel _total_coin;

		// Token: 0x040069BF RID: 27071
		public IXUILabel _total_manao;

		// Token: 0x040069C0 RID: 27072
		public IXUILabel _req_level;

		// Token: 0x040069C1 RID: 27073
		public IXUILabel _req_fight_point;

		// Token: 0x040069C2 RID: 27074
		public IXUILabel _difficulty;

		// Token: 0x040069C3 RID: 27075
		public XNumberTween _coin_tween;

		// Token: 0x040069C4 RID: 27076
		public XNumberTween _manao_tween;
	}
}
