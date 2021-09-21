using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009E6 RID: 2534
	internal class XSweepDocument : XDocComponent
	{
		// Token: 0x17002E10 RID: 11792
		// (get) Token: 0x06009AD2 RID: 39634 RVA: 0x00189448 File Offset: 0x00187648
		public override uint ID
		{
			get
			{
				return XSweepDocument.uuID;
			}
		}

		// Token: 0x17002E11 RID: 11793
		// (get) Token: 0x06009AD3 RID: 39635 RVA: 0x0018945F File Offset: 0x0018765F
		// (set) Token: 0x06009AD4 RID: 39636 RVA: 0x00189467 File Offset: 0x00187667
		public float CurExp { get; set; }

		// Token: 0x17002E12 RID: 11794
		// (get) Token: 0x06009AD5 RID: 39637 RVA: 0x00189470 File Offset: 0x00187670
		// (set) Token: 0x06009AD6 RID: 39638 RVA: 0x00189478 File Offset: 0x00187678
		public float GainExp { get; set; }

		// Token: 0x17002E13 RID: 11795
		// (get) Token: 0x06009AD7 RID: 39639 RVA: 0x00189481 File Offset: 0x00187681
		// (set) Token: 0x06009AD8 RID: 39640 RVA: 0x00189489 File Offset: 0x00187689
		public float ExpDelta { get; set; }

		// Token: 0x17002E14 RID: 11796
		// (get) Token: 0x06009AD9 RID: 39641 RVA: 0x00189492 File Offset: 0x00187692
		// (set) Token: 0x06009ADA RID: 39642 RVA: 0x0018949A File Offset: 0x0018769A
		public uint ProcessLevel { get; set; }

		// Token: 0x17002E15 RID: 11797
		// (get) Token: 0x06009ADB RID: 39643 RVA: 0x001894A3 File Offset: 0x001876A3
		// (set) Token: 0x06009ADC RID: 39644 RVA: 0x001894AB File Offset: 0x001876AB
		public bool NotHaveFatigue { get; set; }

		// Token: 0x17002E16 RID: 11798
		// (get) Token: 0x06009ADD RID: 39645 RVA: 0x001894B4 File Offset: 0x001876B4
		// (set) Token: 0x06009ADE RID: 39646 RVA: 0x001894BC File Offset: 0x001876BC
		public bool ShowTip { get; set; }

		// Token: 0x17002E17 RID: 11799
		// (get) Token: 0x06009ADF RID: 39647 RVA: 0x001894C5 File Offset: 0x001876C5
		// (set) Token: 0x06009AE0 RID: 39648 RVA: 0x001894CD File Offset: 0x001876CD
		public bool IsSeal { get; set; }

		// Token: 0x17002E18 RID: 11800
		// (get) Token: 0x06009AE1 RID: 39649 RVA: 0x001894D8 File Offset: 0x001876D8
		// (set) Token: 0x06009AE2 RID: 39650 RVA: 0x001894F0 File Offset: 0x001876F0
		public uint SelectLevel
		{
			get
			{
				return this._SelectLevel;
			}
			set
			{
				this._SelectLevel = value;
			}
		}

		// Token: 0x17002E19 RID: 11801
		// (get) Token: 0x06009AE3 RID: 39651 RVA: 0x001894FC File Offset: 0x001876FC
		// (set) Token: 0x06009AE4 RID: 39652 RVA: 0x00189514 File Offset: 0x00187714
		public int Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		// Token: 0x17002E1A RID: 11802
		// (get) Token: 0x06009AE5 RID: 39653 RVA: 0x00189520 File Offset: 0x00187720
		public int SlectDiffect
		{
			get
			{
				return XSingleton<XSceneMgr>.singleton.GetSceneDifficult((int)this.SelectLevel);
			}
		}

		// Token: 0x06009AE6 RID: 39654 RVA: 0x00189544 File Offset: 0x00187744
		public void StartSweep(uint level, uint count)
		{
			bool flag = DlgBase<XSweepView, XSweepBehaviour>.singleton.IsVisible() && DlgBase<XSweepView, XSweepBehaviour>.singleton.GetAlpha() == 1f;
			if (!flag)
			{
				this.SelectLevel = level;
				this.Count = (int)count;
				this.TryToSweep();
			}
		}

		// Token: 0x06009AE7 RID: 39655 RVA: 0x00189590 File Offset: 0x00187790
		public bool TryToSweep()
		{
			bool flag = this.SelectLevel > 0U;
			if (flag)
			{
				bool flag2 = !XSingleton<UiUtility>.singleton.CanEnterBattleScene(this.SelectLevel);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_SCENE_NOFATIGUE"), "fece00");
					this.Count = 0;
					return false;
				}
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				this.CurExp = player.Attributes.Exp;
				this.ProcessLevel = player.Attributes.Level;
				this.ReqSweep();
			}
			return true;
		}

		// Token: 0x06009AE8 RID: 39656 RVA: 0x00189628 File Offset: 0x00187828
		private void ReqSweep()
		{
			RpcC2G_Sweep rpcC2G_Sweep = new RpcC2G_Sweep();
			rpcC2G_Sweep.oArg.sceneID = this.SelectLevel;
			rpcC2G_Sweep.oArg.expid = 0U;
			rpcC2G_Sweep.oArg.count = (uint)this.Count;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Sweep);
		}

		// Token: 0x06009AE9 RID: 39657 RVA: 0x0018967C File Offset: 0x0018787C
		public void TrySweepQuery(uint sceneID, uint count)
		{
			RpcC2G_Sweep rpcC2G_Sweep = new RpcC2G_Sweep();
			rpcC2G_Sweep.oArg.sceneID = sceneID;
			rpcC2G_Sweep.oArg.expid = 0U;
			rpcC2G_Sweep.oArg.count = (uint)this.Count;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Sweep);
		}

		// Token: 0x06009AEA RID: 39658 RVA: 0x001896C8 File Offset: 0x001878C8
		public void TrySweepQuery(uint sceneID, uint expID, uint count)
		{
			XBagDocument specificDocument = XDocuments.GetSpecificDocument<XBagDocument>(XBagDocument.uuID);
			XExpeditionDocument specificDocument2 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			uint sceneIDByExpID = specificDocument2.GetSceneIDByExpID((int)expID);
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneIDByExpID);
			this.sweepSceneID = sceneID;
			this.sweepExpID = expID;
			this.sweepCount = count;
			bool flag = sceneData.SweepTicket != null;
			if (flag)
			{
				List<XItem> list = new List<XItem>();
				int i = 0;
				while (i < sceneData.SweepTicket.Length)
				{
					bool itemByItemId = specificDocument.GetItemByItemId((int)sceneData.SweepTicket[i], out list);
					if (itemByItemId)
					{
						bool flag2 = i != 0;
						if (flag2)
						{
							string @string = XSingleton<XStringTable>.singleton.GetString("REVIVE_COST_NOT_ENOUGH");
							object[] itemName = XBagDocument.GetItemConf((int)sceneData.SweepTicket[i]).ItemName;
							string label = string.Format(@string, itemName);
							XSingleton<UiUtility>.singleton.ShowModalDialog(label, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.SendSweepQueryWithModal));
							return;
						}
						break;
					}
					else
					{
						i++;
					}
				}
			}
			this.SendSweepQuery(null);
		}

		// Token: 0x06009AEB RID: 39659 RVA: 0x001897E0 File Offset: 0x001879E0
		public bool SendSweepQueryWithModal(IXUIButton button = null)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.SendSweepQuery(null);
			return true;
		}

		// Token: 0x06009AEC RID: 39660 RVA: 0x00189808 File Offset: 0x00187A08
		public bool SendSweepQuery(IXUIButton button = null)
		{
			RpcC2G_Sweep rpcC2G_Sweep = new RpcC2G_Sweep();
			rpcC2G_Sweep.oArg.sceneID = this.sweepSceneID;
			rpcC2G_Sweep.oArg.expid = this.sweepExpID;
			rpcC2G_Sweep.oArg.count = this.sweepCount;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Sweep);
			return true;
		}

		// Token: 0x06009AED RID: 39661 RVA: 0x00189864 File Offset: 0x00187A64
		public bool GetReward(SweepRes Rewards)
		{
			bool flag = Rewards.result > ErrorCode.ERR_SUCCESS;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(Rewards.result, "fece00");
				this.Count = 0;
				result = false;
			}
			else
			{
				XSweepDocument xsweepDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XSweepDocument.uuID) as XSweepDocument;
				bool flag2 = xsweepDocument.SlectDiffect == 1;
				if (flag2)
				{
					XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
					specificDocument.OnRefreshTeamLevelAbyss(Rewards.abyssleftcount);
				}
				this.IsSeal = Rewards.isexpseal;
				this.ShowTip = (this.Count != Rewards.rewards.Count);
				this.NotHaveFatigue = !XSingleton<UiUtility>.singleton.CanEnterBattleScene(this.SelectLevel);
				bool flag3 = DlgBase<XSweepView, XSweepBehaviour>.singleton.IsVisible();
				if (flag3)
				{
					DlgBase<XSweepView, XSweepBehaviour>.singleton.SetAlpha(1f);
				}
				DlgBase<XSweepView, XSweepBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				this.GainExp = 0f;
				uint num = (uint)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.EXP);
				this.Result.Clear();
				for (int i = 0; i < Rewards.rewards.Count; i++)
				{
					SweepResult sweepResult = new SweepResult();
					for (int j = 0; j < Rewards.rewards[i].items.Count; j++)
					{
						bool flag4 = false;
						for (int k = 0; k < sweepResult.items.Count; k++)
						{
							bool flag5 = sweepResult.items[k].itemID == Rewards.rewards[i].items[j].itemID && sweepResult.items[k].isbind == Rewards.rewards[i].items[j].isbind;
							if (flag5)
							{
								flag4 = true;
								sweepResult.items[k].itemCount += Rewards.rewards[i].items[j].itemCount;
								break;
							}
						}
						bool flag6 = !flag4;
						if (flag6)
						{
							sweepResult.items.Add(Rewards.rewards[i].items[j]);
						}
					}
					this.Result.Add(sweepResult);
					for (int l = 0; l < Rewards.rewards[i].items.Count; l++)
					{
						bool flag7 = Rewards.rewards[i].items[l].itemID == num;
						if (flag7)
						{
							this.GainExp += Rewards.rewards[i].items[l].itemCount;
						}
					}
				}
				this.Count = this.Result.Count;
				XSweepDocument.ReqSceneDayCount();
				this.ExpDelta = this.GainExp / 100f;
				DlgBase<XSweepView, XSweepBehaviour>.singleton.SetReward();
				XLevelSealDocument specificDocument2 = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
				result = true;
			}
			return result;
		}

		// Token: 0x06009AEE RID: 39662 RVA: 0x00189BC8 File Offset: 0x00187DC8
		private static void ReqSceneDayCount()
		{
			RpcC2G_QuerySceneDayCount rpcC2G_QuerySceneDayCount = new RpcC2G_QuerySceneDayCount();
			rpcC2G_QuerySceneDayCount.oArg.type = 2U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_QuerySceneDayCount);
		}

		// Token: 0x06009AEF RID: 39663 RVA: 0x00189BF8 File Offset: 0x00187DF8
		public ItemBrief GetItem(int SweepNum, int ItemNum)
		{
			bool flag = SweepNum < 0 || ItemNum < 0;
			ItemBrief result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = SweepNum >= this.Result.Count;
				if (flag2)
				{
					result = null;
				}
				else
				{
					bool flag3 = ItemNum >= this.Result[SweepNum].items.Count;
					if (flag3)
					{
						result = null;
					}
					else
					{
						bool flag4 = this.Result[SweepNum].items[ItemNum] != null;
						if (flag4)
						{
							ItemBrief itemBrief = this.Result[SweepNum].items[ItemNum];
							result = itemBrief;
						}
						else
						{
							result = null;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06009AF0 RID: 39664 RVA: 0x00189CA0 File Offset: 0x00187EA0
		public int GetCount()
		{
			return this.Result.Count - this.Count;
		}

		// Token: 0x06009AF1 RID: 39665 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0400356A RID: 13674
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SweepDocument");

		// Token: 0x0400356B RID: 13675
		private int _Count = 0;

		// Token: 0x0400356C RID: 13676
		private uint _SelectLevel = 0U;

		// Token: 0x0400356D RID: 13677
		private List<SweepResult> Result = new List<SweepResult>();

		// Token: 0x04003575 RID: 13685
		private uint sweepSceneID = 0U;

		// Token: 0x04003576 RID: 13686
		private uint sweepExpID = 0U;

		// Token: 0x04003577 RID: 13687
		private uint sweepCount = 0U;
	}
}
