using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSweepDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSweepDocument.uuID;
			}
		}

		public float CurExp { get; set; }

		public float GainExp { get; set; }

		public float ExpDelta { get; set; }

		public uint ProcessLevel { get; set; }

		public bool NotHaveFatigue { get; set; }

		public bool ShowTip { get; set; }

		public bool IsSeal { get; set; }

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

		public int SlectDiffect
		{
			get
			{
				return XSingleton<XSceneMgr>.singleton.GetSceneDifficult((int)this.SelectLevel);
			}
		}

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

		private void ReqSweep()
		{
			RpcC2G_Sweep rpcC2G_Sweep = new RpcC2G_Sweep();
			rpcC2G_Sweep.oArg.sceneID = this.SelectLevel;
			rpcC2G_Sweep.oArg.expid = 0U;
			rpcC2G_Sweep.oArg.count = (uint)this.Count;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Sweep);
		}

		public void TrySweepQuery(uint sceneID, uint count)
		{
			RpcC2G_Sweep rpcC2G_Sweep = new RpcC2G_Sweep();
			rpcC2G_Sweep.oArg.sceneID = sceneID;
			rpcC2G_Sweep.oArg.expid = 0U;
			rpcC2G_Sweep.oArg.count = (uint)this.Count;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Sweep);
		}

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

		public bool SendSweepQueryWithModal(IXUIButton button = null)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.SendSweepQuery(null);
			return true;
		}

		public bool SendSweepQuery(IXUIButton button = null)
		{
			RpcC2G_Sweep rpcC2G_Sweep = new RpcC2G_Sweep();
			rpcC2G_Sweep.oArg.sceneID = this.sweepSceneID;
			rpcC2G_Sweep.oArg.expid = this.sweepExpID;
			rpcC2G_Sweep.oArg.count = this.sweepCount;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Sweep);
			return true;
		}

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

		private static void ReqSceneDayCount()
		{
			RpcC2G_QuerySceneDayCount rpcC2G_QuerySceneDayCount = new RpcC2G_QuerySceneDayCount();
			rpcC2G_QuerySceneDayCount.oArg.type = 2U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_QuerySceneDayCount);
		}

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

		public int GetCount()
		{
			return this.Result.Count - this.Count;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SweepDocument");

		private int _Count = 0;

		private uint _SelectLevel = 0U;

		private List<SweepResult> Result = new List<SweepResult>();

		private uint sweepSceneID = 0U;

		private uint sweepExpID = 0U;

		private uint sweepCount = 0U;
	}
}
