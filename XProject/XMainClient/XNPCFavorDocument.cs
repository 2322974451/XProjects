using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XNPCFavorDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XNPCFavorDocument.uuID;
			}
		}

		public List<uint> NPCIds
		{
			get
			{
				XNPCFavorDocument.CheckNpcIds();
				return XNPCFavorDocument.m_NpcIds;
			}
		}

		public List<uint> UnionIds
		{
			get
			{
				XNPCFavorDocument.CheckUnionIds();
				return XNPCFavorDocument.m_UnionIds;
			}
		}

		public Dictionary<uint, uint> DictSumAttr
		{
			get
			{
				return this.m_DictSumAttr;
			}
		}

		public ItemBrief Role2NPC
		{
			get
			{
				return this.m_role2npc;
			}
		}

		public ItemBrief NPC2Role
		{
			get
			{
				return this.m_npc2role;
			}
		}

		public uint ExchangeNPCID
		{
			get
			{
				return this.m_exchangeNPCId;
			}
		}

		public uint NpcFlLevTop
		{
			get
			{
				return this.npcFlLevTop;
			}
		}

		public uint GiveLeftCount
		{
			get
			{
				return this.giveLeftCount;
			}
			private set
			{
				uint num = this.giveLeftCount;
				this.giveLeftCount = value;
				bool flag = (num == 0U && this.giveLeftCount > 0U) || (num > 0U && this.giveLeftCount == 0U);
				if (flag)
				{
					XNPCFavorFxChangeArgs @event = XEventPool<XNPCFavorFxChangeArgs>.GetEvent();
					@event.Firer = XSingleton<XGame>.singleton.Doc;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
					this.SetupNpcHeadFx();
				}
			}
		}

		public uint BuyLeftCount
		{
			get
			{
				return this.buyLeftCount;
			}
			private set
			{
				this.buyLeftCount = value;
			}
		}

		public uint BuyCost
		{
			get
			{
				return this.buyCost;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.SetupNpcHeadFx();
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this.SetupNpcHeadFx();
		}

		public override void OnLeaveScene()
		{
			this.ClearFx();
			base.OnLeaveScene();
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XNPCFavorDocument.AsyncLoader.AddTask("Table/NpcFeeling", XNPCFavorDocument._npcInfoTable, false);
			XNPCFavorDocument.AsyncLoader.AddTask("Table/NpcFeelingAttr", XNPCFavorDocument._npcAttrTable, false);
			XNPCFavorDocument.AsyncLoader.AddTask("Table/NpcUniteAttr", XNPCFavorDocument._npcUnionAttrTable, false);
			XNPCFavorDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this.OnTaskStateChange));
		}

		protected void SetupNpcHeadFx()
		{
			List<uint> npcs = XSingleton<XEntityMgr>.singleton.GetNpcs(XSingleton<XScene>.singleton.SceneID);
			bool flag = npcs == null;
			if (!flag)
			{
				this.ClearFx();
				for (int i = 0; i < npcs.Count; i++)
				{
					this.SetupFixNpcHeadFx(npcs[i]);
				}
			}
		}

		private bool SetupFixNpcHeadFx(uint xnpcid)
		{
			NpcFeelingOneNpc oneNpcByXId = this.GetOneNpcByXId(xnpcid);
			bool flag = oneNpcByXId == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(xnpcid);
				bool flag2 = npc == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
					XTaskInfo xtaskInfo = null;
					NpcTaskState npcTaskState = specificDocument.GetNpcTaskState(npc.TypeID, ref xtaskInfo);
					bool flag3 = npcTaskState == NpcTaskState.Normal || npcTaskState == NpcTaskState.Invalid || npcTaskState == NpcTaskState.TaskInprocess;
					if (flag3)
					{
						string text = null;
						bool flag4 = this.IsShowExchangeFx(oneNpcByXId);
						if (flag4)
						{
							text = "Effects/FX_Particle/Scene/Lzg_scene/rwts_05";
						}
						else
						{
							bool flag5 = this.IsShowLoveFx(oneNpcByXId);
							if (flag5)
							{
								text = "Effects/FX_Particle/Scene/Lzg_scene/rwts_07";
							}
						}
						bool flag6 = text != null;
						if (flag6)
						{
							this.PlayNPCFX(npc, xnpcid, text, true, -1f);
						}
					}
					result = (npcTaskState == NpcTaskState.TaskInprocess);
				}
			}
			return result;
		}

		private void RefreshNpcHeadFxById(uint npcid)
		{
			uint npcXIdById = XNPCFavorDocument.GetNpcXIdById(npcid);
			bool flag = this.m_FxDict.ContainsKey(npcXIdById);
			if (flag)
			{
				XFx xfx = this.m_FxDict[npcXIdById];
				this.m_Fxes.Remove(xfx);
				this.m_FxDict.Remove(npcXIdById);
				XSingleton<XFxMgr>.singleton.DestroyFx(xfx, true);
			}
			bool flag2 = this.SetupFixNpcHeadFx(npcXIdById);
			if (flag2)
			{
				XNPCFavorFxChangeArgs @event = XEventPool<XNPCFavorFxChangeArgs>.GetEvent();
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		private void OnNPCActiveSuccess()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshData();
			}
			this.PlayFireWorkFx();
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCLevelUpSuccess"), "fece00");
		}

		private void OnUnionActiveSuccess()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshData();
			}
			this.PlayFireWorkFx();
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCActiveUnionSuccess"), "fece00");
		}

		private void OnTriggerExchange(uint npcId)
		{
			uint npcXIdById = XNPCFavorDocument.GetNpcXIdById(npcId);
			bool flag = npcXIdById > 0U;
			if (flag)
			{
				XNPCFavorDrama xnpcfavorDrama = XNPCFavorDocument.IsNpcDialogVisible();
				bool flag2 = xnpcfavorDrama != null;
				if (flag2)
				{
					xnpcfavorDrama.RefreshOperateStatus(false, null);
				}
				this.PlayFireWorkFx();
				bool flag3 = this.m_FxDict.ContainsKey(npcXIdById);
				if (flag3)
				{
					bool flag4 = string.Equals(this.m_FxDict[npcXIdById].FxName, "Effects/FX_Particle/Scene/Lzg_scene/rwts_05");
					if (!flag4)
					{
						bool flag5 = string.Equals(this.m_FxDict[npcXIdById].FxName, "Effects/FX_Particle/Scene/Lzg_scene/rwts_07");
						if (flag5)
						{
							XFx xfx = this.m_FxDict[npcXIdById];
							this.m_Fxes.Remove(xfx);
							XSingleton<XFxMgr>.singleton.DestroyFx(xfx, true);
							this.PlayNPCFX(null, npcXIdById, "Effects/FX_Particle/Scene/Lzg_scene/rwts_05", true, -1f);
						}
					}
				}
			}
		}

		private void PlayNPCFX(XNpc npc, uint xnpcid, string FxName, bool add = false, float delayDestroy = -1f)
		{
			bool flag = npc == null;
			if (flag)
			{
				npc = XSingleton<XEntityMgr>.singleton.GetNpc(xnpcid);
			}
			bool flag2 = npc == null;
			if (!flag2)
			{
				XFx xfx = XSingleton<XFxMgr>.singleton.CreateFx(FxName, null, true);
				bool flag3 = xfx != null;
				if (flag3)
				{
					this.m_Fxes.Add(xfx);
					xfx.Play(npc.EngineObject, new Vector3(-0.05f, npc.Height + 0.7f, 0f), Vector3.one, 1f, true, false, "", 0f);
					bool flag4 = delayDestroy > 0f;
					if (flag4)
					{
						xfx.DelayDestroy = delayDestroy;
					}
					if (add)
					{
						bool flag5 = this.m_FxDict.ContainsKey(xnpcid);
						if (flag5)
						{
							this.m_FxDict[xnpcid] = xfx;
						}
						else
						{
							this.m_FxDict.Add(xnpcid, xfx);
						}
					}
				}
			}
		}

		private void PlayOneTimeNPCFX(XNpc npc, uint xnpcid, string FxName, float delayDestroy)
		{
			bool flag = npc == null;
			if (flag)
			{
				npc = XSingleton<XEntityMgr>.singleton.GetNpc(xnpcid);
			}
			bool flag2 = npc == null;
			if (!flag2)
			{
				XFx xfx = XSingleton<XFxMgr>.singleton.CreateFx(FxName, null, true);
				bool flag3 = xfx != null;
				if (flag3)
				{
					xfx.Play(npc.EngineObject, new Vector3(-0.05f, npc.Height, 0f), Vector3.one, 1f, true, false, "", 0f);
					xfx.DelayDestroy = delayDestroy;
					XSingleton<XFxMgr>.singleton.DestroyFx(xfx, false);
				}
			}
		}

		public void PlayFx(uint xnpcid, string FxName)
		{
			this.PlayOneTimeNPCFX(null, xnpcid, FxName, 4f);
		}

		private bool OnTaskStateChange(XEventArgs e)
		{
			this.SetupNpcHeadFx();
			return true;
		}

		public void PlayFireWorkFx()
		{
			bool flag = this.fireWorkFx == null;
			if (flag)
			{
				Transform uiroot = XSingleton<UIManager>.singleton.UIRoot;
				bool flag2 = uiroot != null;
				if (flag2)
				{
					Transform transform = uiroot.Find("Camera");
					bool flag3 = transform != null;
					if (flag3)
					{
						this.fireWorkFx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_yh", transform, false);
					}
				}
			}
			else
			{
				this.fireWorkFx.Play();
			}
		}

		public void PlaySendSuccessFx(uint xnpcid)
		{
			this.PlayFx(xnpcid, "Effects/FX_Particle/Scene/Lzg_scene/NPC_aixin_Clip01");
		}

		public void PlayExchangeSuccessFx(uint xnpcid)
		{
			this.PlayFx(xnpcid, "Effects/FX_Particle/Scene/Lzg_scene/NPC_aixin_Clip01");
		}

		public bool IsShowFavorFx(uint xnpcId)
		{
			NpcFeelingOneNpc oneNpcByXId = this.GetOneNpcByXId(xnpcId);
			return this.IsShowLoveFx(oneNpcByXId) || this.IsShowExchangeFx(oneNpcByXId);
		}

		public bool IsShowExChangeFx(uint xnpcId)
		{
			NpcFeelingOneNpc oneNpcByXId = this.GetOneNpcByXId(xnpcId);
			return this.IsShowExchangeFx(oneNpcByXId);
		}

		private bool IsShowExchangeFx(NpcFeelingOneNpc oneNpc)
		{
			return this.IsCanExchange(oneNpc);
		}

		private bool IsShowLoveFx(NpcFeelingOneNpc oneNpc)
		{
			bool flag = oneNpc == null;
			return !flag && this.IsCanSend() && !this.IsCanLevelUp(oneNpc);
		}

		protected void ClearFx()
		{
			for (int i = 0; i < this.m_Fxes.Count; i++)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_Fxes[i], true);
			}
			this.m_Fxes.Clear();
			this.m_FxDict.Clear();
			bool flag = this.fireWorkFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.fireWorkFx, true);
			}
			this.fireWorkFx = null;
		}

		public void ReqSrvNpcInfo()
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_BASE_DATA;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		public void ReqSrvGiveGift(uint npcid, NpcLikeItem likeitem)
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_GIVE_GIFT;
			rpcC2M_NpcFlReqC2M.oArg.npcid = npcid;
			rpcC2M_NpcFlReqC2M.oArg.likeitem = likeitem;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		public void ReqSrvExchangeGift(uint npcid, ItemBrief role2npc, ItemBrief npc2role)
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_EXCHANGE;
			rpcC2M_NpcFlReqC2M.oArg.npcid = npcid;
			rpcC2M_NpcFlReqC2M.oArg.role2npc = role2npc;
			rpcC2M_NpcFlReqC2M.oArg.npc2role = npc2role;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		public void ReqSrvLevelUp(uint npcid)
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_NPC_LEVEL_UP;
			rpcC2M_NpcFlReqC2M.oArg.npcid = npcid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		public void ReqSrvActiveUnionLevel(uint uniteid, uint level)
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_UNITE_ACT;
			rpcC2M_NpcFlReqC2M.oArg.uniteid = uniteid;
			rpcC2M_NpcFlReqC2M.oArg.level = level;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		public void ReqSrvBuyGiftCount()
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_BUY_GIFT_COUNT;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		public void OnReqSrvNpcInfo(NpcFlArg oArg, NpcFlRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				switch (oArg.reqtype)
				{
				case NpcFlReqType.NPCFL_GIVE_GIFT:
				{
					List<NpcFeelingOneNpc> changenpclist = oRes.changenpclist;
					this.m_role2npc = oRes.role2npc;
					this.m_npc2role = oRes.npc2role;
					this.GiveLeftCount = oRes.giveleftcount;
					int i = 0;
					int count = changenpclist.Count;
					while (i < count)
					{
						NpcFeelingOneNpc oneNpc = this.GetOneNpc(changenpclist[i].npcid);
						bool flag2 = oneNpc != null;
						if (flag2)
						{
							this.activedNpc.Remove(oneNpc);
							this.activedNpc.Add(changenpclist[i]);
							bool flag3 = this.m_role2npc != null && this.m_npc2role != null;
							if (flag3)
							{
								this.OnTriggerExchange(changenpclist[i].npcid);
								this.m_exchangeNPCId = oneNpc.npcid;
							}
							this.RefreshNpcHeadFxById(changenpclist[i].npcid);
							this.OnSendSuccess();
						}
						i++;
					}
					this.SortNpc();
					this.RecalculateCanLevelUpTag();
					break;
				}
				case NpcFlReqType.NPCFL_EXCHANGE:
				{
					List<NpcFeelingOneNpc> changenpclist2 = oRes.changenpclist;
					this.m_role2npc = null;
					this.m_npc2role = null;
					int j = 0;
					int count2 = changenpclist2.Count;
					while (j < count2)
					{
						NpcFeelingOneNpc oneNpc2 = this.GetOneNpc(changenpclist2[j].npcid);
						bool flag4 = oneNpc2 != null;
						if (flag4)
						{
							this.activedNpc.Remove(oneNpc2);
							this.activedNpc.Add(changenpclist2[j]);
							this.RefreshNpcHeadFxById(changenpclist2[j].npcid);
							this.OnExchangeSuccess();
						}
						j++;
					}
					break;
				}
				case NpcFlReqType.NPCFL_BASE_DATA:
				{
					this.activedNpc = oRes.npclist;
					this.activedUnites = oRes.unitelist;
					this.npcfavorrole = oRes.npcfavorrole;
					this.giveLeftCount = oRes.giveleftcount;
					this.buyLeftCount = oRes.buyleftcount;
					this.buyCost = oRes.buycost;
					this.npcFlLevTop = oRes.npcflleveltop;
					this.CalculateSumAttr();
					this.SortNpc();
					this.RecalculateNewTag();
					this.RecalculateCanLevelUpTag();
					this.RecalculateUnionTag();
					bool flag5 = this.View != null && this.View.IsVisible();
					if (flag5)
					{
						this.View.RefreshData();
					}
					break;
				}
				case NpcFlReqType.NPCFL_NPC_LEVEL_UP:
				{
					List<NpcFeelingOneNpc> changenpclist3 = oRes.changenpclist;
					int k = 0;
					int count3 = changenpclist3.Count;
					while (k < count3)
					{
						NpcFeelingOneNpc oneNpc3 = this.GetOneNpc(changenpclist3[k].npcid);
						bool flag6 = oneNpc3 != null;
						if (flag6)
						{
							this.activedNpc.Remove(oneNpc3);
							this.activedNpc.Add(changenpclist3[k]);
							this.RefreshNpcHeadFxById(changenpclist3[k].npcid);
						}
						k++;
					}
					this.CalculateSumAttr();
					this.SortNpc();
					this.RecalculateCanLevelUpTag();
					this.RecalculateUnionTag();
					this.OnNPCActiveSuccess();
					break;
				}
				case NpcFlReqType.NPCFL_UNITE_ACT:
				{
					int l = 0;
					int count4 = oRes.unitelist.Count;
					while (l < count4)
					{
						NpcFeelingUnite activeUniteInfo = this.GetActiveUniteInfo(oRes.unitelist[l].id);
						bool flag7 = activeUniteInfo != null;
						if (flag7)
						{
							this.activedUnites.Remove(activeUniteInfo);
						}
						this.activedUnites.Add(oRes.unitelist[l]);
						l++;
					}
					this.CalculateSumAttr();
					this.RecalculateUnionTag();
					this.OnUnionActiveSuccess();
					break;
				}
				case NpcFlReqType.NPCFL_BUY_GIFT_COUNT:
				{
					uint num = this.giveLeftCount;
					this.GiveLeftCount = oRes.giveleftcount;
					this.buyLeftCount = oRes.buyleftcount;
					this.buyCost = oRes.buycost;
					bool flag8 = this.View != null && this.View.IsVisible();
					if (flag8)
					{
						this.View.RefreshGiftTimesInfo();
					}
					break;
				}
				}
			}
		}

		private void SortNpc()
		{
			XNPCFavorDocument.CheckNpcIds();
			XNPCFavorDocument.m_NpcIds.Sort(new Comparison<uint>(XNPCFavorDocument.Compare));
		}

		private void CalculateSumAttr()
		{
			this.m_DictSumAttr.Clear();
			int i = 0;
			int count = this.activedNpc.Count;
			while (i < count)
			{
				uint level = this.activedNpc[i].level;
				NpcFeelingAttr.RowData attrDataByLevel = XNPCFavorDocument.GetAttrDataByLevel(this.activedNpc[i].npcid, level);
				bool flag = attrDataByLevel != null;
				if (flag)
				{
					int j = 0;
					int count2 = attrDataByLevel.Attr.Count;
					while (j < count2)
					{
						uint num = attrDataByLevel.Attr[j, 0];
						uint num2 = attrDataByLevel.Attr[j, 1];
						bool flag2 = !this.m_DictSumAttr.ContainsKey(num);
						if (flag2)
						{
							this.m_DictSumAttr.Add(num, 0U);
						}
						Dictionary<uint, uint> dictSumAttr = this.m_DictSumAttr;
						uint key = num;
						dictSumAttr[key] += num2;
						j++;
					}
				}
				i++;
			}
			int k = 0;
			int count3 = this.activedUnites.Count;
			while (k < count3)
			{
				NpcUniteAttr.RowData unionTableInfoByUnionId = XNPCFavorDocument.GetUnionTableInfoByUnionId(this.activedUnites[k].id, this.activedUnites[k].level);
				bool flag3 = unionTableInfoByUnionId != null;
				if (flag3)
				{
					int l = 0;
					int count4 = unionTableInfoByUnionId.Attr.Count;
					while (l < count4)
					{
						uint num3 = unionTableInfoByUnionId.Attr[l, 0];
						uint num4 = unionTableInfoByUnionId.Attr[l, 1];
						bool flag4 = !this.m_DictSumAttr.ContainsKey(num3);
						if (flag4)
						{
							this.m_DictSumAttr.Add(num3, 0U);
						}
						Dictionary<uint, uint> dictSumAttr = this.m_DictSumAttr;
						uint key = num3;
						dictSumAttr[key] += num4;
						l++;
					}
				}
				k++;
			}
		}

		public void OnNpcFeelingChange(NpcFlRes res)
		{
			this.OnReqSrvNpcInfo(new NpcFlArg
			{
				reqtype = NpcFlReqType.NPCFL_BASE_DATA
			}, res);
			this.SetupNpcHeadFx();
			XNPCFavorFxChangeArgs @event = XEventPool<XNPCFavorFxChangeArgs>.GetEvent();
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		public void ReqNPCFavorUnionInfo()
		{
			this.ReqSrvNpcInfo();
		}

		private void OnSendSuccess()
		{
			XNPCFavorDrama xnpcfavorDrama = XNPCFavorDocument.IsNpcDialogVisible();
			bool flag = xnpcfavorDrama != null;
			if (flag)
			{
				xnpcfavorDrama.SendSuccess();
			}
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCSendSuccess"), "fece00");
		}

		private void OnExchangeSuccess()
		{
			XNPCFavorDrama xnpcfavorDrama = XNPCFavorDocument.IsNpcDialogVisible();
			bool flag = xnpcfavorDrama != null;
			if (flag)
			{
				xnpcfavorDrama.ExchangeSuccess();
			}
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCExchangeSuccess"), "fece00");
		}

		private static void CheckNpcIds()
		{
			bool flag = XNPCFavorDocument._npcInfoTable.Table == null;
			if (!flag)
			{
				bool flag2 = XNPCFavorDocument.m_NpcIds == null;
				if (flag2)
				{
					XNPCFavorDocument.m_NpcIds = new List<uint>();
					int i = 0;
					int num = XNPCFavorDocument._npcInfoTable.Table.Length;
					while (i < num)
					{
						XNPCFavorDocument.m_NpcIds.Add(XNPCFavorDocument._npcInfoTable.Table[i].npcId);
						i++;
					}
				}
			}
		}

		private static void CheckUnionIds()
		{
			bool flag = XNPCFavorDocument._npcUnionAttrTable.Table == null;
			if (!flag)
			{
				bool flag2 = XNPCFavorDocument.m_UnionIds == null;
				if (flag2)
				{
					XNPCFavorDocument.m_UnionIds = new List<uint>();
					for (int i = 0; i < XNPCFavorDocument._npcUnionAttrTable.Table.Length; i++)
					{
						bool flag3 = !XNPCFavorDocument.m_UnionIds.Contains(XNPCFavorDocument._npcUnionAttrTable.Table[i].id);
						if (flag3)
						{
							XNPCFavorDocument.m_UnionIds.Add(XNPCFavorDocument._npcUnionAttrTable.Table[i].id);
						}
					}
				}
			}
		}

		private static int Compare(uint x, uint y)
		{
			XNPCFavorDocument specificDocument = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			NpcFeelingOneNpc oneNpc = specificDocument.GetOneNpc(x);
			NpcFeelingOneNpc oneNpc2 = specificDocument.GetOneNpc(y);
			bool flag = oneNpc != null && oneNpc2 == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool flag2 = oneNpc == null && oneNpc2 != null;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					bool flag3 = oneNpc == null && oneNpc2 == null;
					if (flag3)
					{
						NpcFeeling.RowData npcTableInfoById = XNPCFavorDocument.GetNpcTableInfoById(x);
						NpcFeeling.RowData npcTableInfoById2 = XNPCFavorDocument.GetNpcTableInfoById(y);
						bool flag4 = npcTableInfoById != null && npcTableInfoById2 != null;
						if (flag4)
						{
							return (int)(npcTableInfoById.openLevel - npcTableInfoById2.openLevel);
						}
					}
					bool flag5 = oneNpc != null && oneNpc2 != null;
					if (flag5)
					{
						bool flag6 = oneNpc.isnew != oneNpc2.isnew;
						if (flag6)
						{
							return oneNpc2.isnew ? 1 : -1;
						}
						bool flag7 = !oneNpc.isnew;
						if (flag7)
						{
							bool flag8 = oneNpc.level != oneNpc2.level;
							if (flag8)
							{
								return (oneNpc2.level > oneNpc.level) ? 1 : -1;
							}
							bool flag9 = oneNpc.exp != oneNpc2.exp;
							if (flag9)
							{
								return (oneNpc2.exp > oneNpc.exp) ? 1 : -1;
							}
						}
					}
					result = (int)(x - y);
				}
			}
			return result;
		}

		public void RemoveAllNewTags()
		{
			bool flag = this.activedNpc == null;
			if (!flag)
			{
				int i = 0;
				int count = this.activedNpc.Count;
				while (i < count)
				{
					this.activedNpc[i].isnew = false;
					i++;
				}
				this.HasNewNpcActive = false;
				this.SortNpc();
			}
		}

		public void RecalculateNewTag()
		{
			bool hasNewNpcActive = false;
			int i = 0;
			int count = this.activedNpc.Count;
			while (i < count)
			{
				bool isnew = this.activedNpc[i].isnew;
				if (isnew)
				{
					hasNewNpcActive = true;
					break;
				}
				i++;
			}
			this.HasNewNpcActive = hasNewNpcActive;
		}

		public void RecalculateCanLevelUpTag()
		{
			bool hasCanLevelUpNpc = false;
			for (int i = 0; i < this.activedNpc.Count; i++)
			{
				bool flag = this.IsCanLevelUp(this.activedNpc[i]);
				if (flag)
				{
					hasCanLevelUpNpc = true;
					break;
				}
			}
			this.HasCanLevelUpNpc = hasCanLevelUpNpc;
		}

		public void RecalculateUnionTag()
		{
			bool hasNewUnionActive = false;
			XNPCFavorDocument.CheckUnionIds();
			int i = 0;
			int count = XNPCFavorDocument.m_UnionIds.Count;
			while (i < count)
			{
				bool flag = this.IsUnionCanActiveNextLevel(XNPCFavorDocument.m_UnionIds[i]);
				if (flag)
				{
					hasNewUnionActive = true;
					break;
				}
				i++;
			}
			this.HasNewUnionActive = hasNewUnionActive;
		}

		public bool IsNeedShowRedpoint
		{
			get
			{
				return this.m_NeedRedPointShow;
			}
			set
			{
				this.m_NeedRedPointShow = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_NPCFavor, true);
			}
		}

		public bool HasNewNpcActive
		{
			get
			{
				return this.m_HasNew;
			}
			set
			{
				this.m_HasNew = value;
				this.IsNeedShowRedpoint = (this.m_HasNew || this.m_UnionRedPoint || this.m_CanLevelUpNpc);
				bool flag = this.View != null && this.View.IsVisible();
				if (flag)
				{
					this.View.SetTabRedpoint(XNPCFavorDlg.TabIndex.Relics, this.m_HasNew || this.m_CanLevelUpNpc);
				}
			}
		}

		public bool HasCanLevelUpNpc
		{
			get
			{
				return this.m_CanLevelUpNpc;
			}
			set
			{
				this.m_CanLevelUpNpc = value;
				this.IsNeedShowRedpoint = (this.m_HasNew || this.m_UnionRedPoint || this.m_CanLevelUpNpc);
				bool flag = this.View != null && this.View.IsVisible();
				if (flag)
				{
					this.View.SetTabRedpoint(XNPCFavorDlg.TabIndex.Relics, this.m_HasNew || this.m_CanLevelUpNpc);
				}
			}
		}

		public bool HasNewUnionActive
		{
			get
			{
				return this.m_UnionRedPoint;
			}
			set
			{
				this.m_UnionRedPoint = value;
				this.IsNeedShowRedpoint = (this.m_HasNew || this.m_UnionRedPoint || this.m_CanLevelUpNpc);
				bool flag = this.View != null && this.View.IsVisible();
				if (flag)
				{
					this.View.SetTabRedpoint(XNPCFavorDlg.TabIndex.Union, this.m_UnionRedPoint);
				}
			}
		}

		public static void ShowNPCDrama(uint xnpcId)
		{
			XNPCFavorDrama xnpcfavorDrama = XNPCFavorDocument.IsNpcDialogVisible();
			bool flag = xnpcfavorDrama != null;
			if (flag)
			{
				xnpcfavorDrama.RefreshOperateStatus(true, null);
			}
		}

		public static XNPCFavorDrama IsNpcDialogVisible()
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			XNPCFavorDrama result;
			if (flag)
			{
				XDramaDocument specificDocument = XDocuments.GetSpecificDocument<XDramaDocument>(XDramaDocument.uuID);
				result = specificDocument.GetFavorDrama();
			}
			else
			{
				result = null;
			}
			return result;
		}

		public EFavorState GetState(uint xnpcId)
		{
			NpcFeelingOneNpc oneNpcByXId = this.GetOneNpcByXId(xnpcId);
			bool flag = oneNpcByXId != null;
			if (flag)
			{
				bool flag2 = this.IsCanSend() && this.IsCanExchange(oneNpcByXId);
				if (flag2)
				{
					return EFavorState.SendWithExchange;
				}
				bool flag3 = this.IsCanSend();
				if (flag3)
				{
					return EFavorState.CanSend;
				}
				bool flag4 = this.IsCanExchange(oneNpcByXId);
				if (flag4)
				{
					return EFavorState.Exchange;
				}
			}
			return EFavorState.None;
		}

		public static NpcFeeling.RowData GetNpcTableInfoByXId(uint xnpcid)
		{
			bool flag = XNPCFavorDocument._npcInfoTable.Table == null;
			NpcFeeling.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int i = 0;
				int num = XNPCFavorDocument._npcInfoTable.Table.Length;
				while (i < num)
				{
					bool flag2 = XNPCFavorDocument._npcInfoTable.Table[i].xnpclistid == xnpcid;
					if (flag2)
					{
						return XNPCFavorDocument._npcInfoTable.Table[i];
					}
					i++;
				}
				result = null;
			}
			return result;
		}

		public static NpcFeeling.RowData GetNpcTableInfoById(uint npcid)
		{
			bool flag = XNPCFavorDocument._npcInfoTable.Table == null;
			NpcFeeling.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int i = 0;
				int num = XNPCFavorDocument._npcInfoTable.Table.Length;
				while (i < num)
				{
					bool flag2 = XNPCFavorDocument._npcInfoTable.Table[i].npcId == npcid;
					if (flag2)
					{
						return XNPCFavorDocument._npcInfoTable.Table[i];
					}
					i++;
				}
				result = null;
			}
			return result;
		}

		public static NpcFeelingAttr.RowData GetAttrDataByLevel(uint npcid, uint lev)
		{
			bool flag = XNPCFavorDocument._npcAttrTable.Table == null;
			NpcFeelingAttr.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int i = 0;
				int num = XNPCFavorDocument._npcAttrTable.Table.Length;
				while (i < num)
				{
					bool flag2 = XNPCFavorDocument._npcAttrTable.Table[i].npcId == npcid && XNPCFavorDocument._npcAttrTable.Table[i].level == lev;
					if (flag2)
					{
						return XNPCFavorDocument._npcAttrTable.Table[i];
					}
					i++;
				}
				result = null;
			}
			return result;
		}

		public static NpcFeelingAttr.RowData GetNpcAttrByIdLev(uint npcId, uint lev)
		{
			bool flag = XNPCFavorDocument._npcAttrTable == null;
			NpcFeelingAttr.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int i = 0;
				int num = XNPCFavorDocument._npcAttrTable.Table.Length;
				while (i < num)
				{
					bool flag2 = XNPCFavorDocument._npcAttrTable.Table[i].npcId == npcId && XNPCFavorDocument._npcAttrTable.Table[i].level == lev;
					if (flag2)
					{
						return XNPCFavorDocument._npcAttrTable.Table[i];
					}
					i++;
				}
				result = null;
			}
			return result;
		}

		public static NpcUniteAttr.RowData GetUnionTableInfoByUnionId(uint unionId, uint lev)
		{
			bool flag = XNPCFavorDocument._npcUnionAttrTable.Table == null;
			NpcUniteAttr.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				uint num = uint.MaxValue;
				int num2 = 0;
				int i = 0;
				int num3 = XNPCFavorDocument._npcUnionAttrTable.Table.Length;
				while (i < num3)
				{
					bool flag2 = XNPCFavorDocument._npcUnionAttrTable.Table[i].id == unionId;
					if (flag2)
					{
						bool flag3 = lev == 0U;
						if (flag3)
						{
							bool flag4 = XNPCFavorDocument._npcUnionAttrTable.Table[i].level < num;
							if (flag4)
							{
								num = XNPCFavorDocument._npcUnionAttrTable.Table[i].level;
								num2 = i;
							}
						}
						else
						{
							bool flag5 = XNPCFavorDocument._npcUnionAttrTable.Table[i].level == lev;
							if (flag5)
							{
								return XNPCFavorDocument._npcUnionAttrTable.Table[i];
							}
						}
					}
					i++;
				}
				bool flag6 = lev == 0U;
				if (flag6)
				{
					result = XNPCFavorDocument._npcUnionAttrTable.Table[num2];
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		public static uint GetUnionEffectLev(uint unionId, uint lev)
		{
			bool flag = XNPCFavorDocument._npcUnionAttrTable.Table == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				uint num = 0U;
				int i = 0;
				int num2 = XNPCFavorDocument._npcUnionAttrTable.Table.Length;
				while (i < num2)
				{
					bool flag2 = XNPCFavorDocument._npcUnionAttrTable.Table[i].id == unionId;
					if (flag2)
					{
						bool flag3 = XNPCFavorDocument._npcUnionAttrTable.Table[i].level <= lev;
						if (flag3)
						{
							num += 1U;
						}
					}
					i++;
				}
				result = num;
			}
			return result;
		}

		public static NpcUniteAttr.RowData GetNextUnionDataByUnionId(uint unionId, uint lev)
		{
			bool flag = XNPCFavorDocument._npcUnionAttrTable.Table == null;
			NpcUniteAttr.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				uint num = uint.MaxValue;
				NpcUniteAttr.RowData rowData = null;
				int i = 0;
				int num2 = XNPCFavorDocument._npcUnionAttrTable.Table.Length;
				while (i < num2)
				{
					bool flag2 = XNPCFavorDocument._npcUnionAttrTable.Table[i].id != unionId;
					if (!flag2)
					{
						bool flag3 = lev < XNPCFavorDocument._npcUnionAttrTable.Table[i].level && XNPCFavorDocument._npcUnionAttrTable.Table[i].level < num;
						if (flag3)
						{
							num = XNPCFavorDocument._npcUnionAttrTable.Table[i].level;
							rowData = XNPCFavorDocument._npcUnionAttrTable.Table[i];
						}
					}
					i++;
				}
				result = rowData;
			}
			return result;
		}

		public static uint GetNpcIdByXId(uint xnpcid)
		{
			bool flag = XNPCFavorDocument._npcInfoTable.Table == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				int i = 0;
				int num = XNPCFavorDocument._npcInfoTable.Table.Length;
				while (i < num)
				{
					bool flag2 = XNPCFavorDocument._npcInfoTable.Table[i].xnpclistid == xnpcid;
					if (flag2)
					{
						return XNPCFavorDocument._npcInfoTable.Table[i].npcId;
					}
					i++;
				}
				result = 0U;
			}
			return result;
		}

		public static uint GetNpcXIdById(uint npcid)
		{
			bool flag = XNPCFavorDocument._npcInfoTable.Table == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				int i = 0;
				int num = XNPCFavorDocument._npcInfoTable.Table.Length;
				while (i < num)
				{
					bool flag2 = XNPCFavorDocument._npcInfoTable.Table[i].npcId == npcid;
					if (flag2)
					{
						return XNPCFavorDocument._npcInfoTable.Table[i].xnpclistid;
					}
					i++;
				}
				result = 0U;
			}
			return result;
		}

		public string GetFavoritePlayerName(uint xnpcid)
		{
			bool flag = this.npcfavorrole == null;
			string empty;
			if (flag)
			{
				empty = string.Empty;
			}
			else
			{
				uint npcIdByXId = XNPCFavorDocument.GetNpcIdByXId(xnpcid);
				int i = 0;
				int count = this.npcfavorrole.Count;
				while (i < count)
				{
					bool flag2 = this.npcfavorrole[i].npcid == npcIdByXId;
					if (flag2)
					{
						return this.npcfavorrole[i].rolename;
					}
					i++;
				}
				empty = string.Empty;
			}
			return empty;
		}

		public bool IsShowNPCFavoritePlayer(uint xnpcid)
		{
			return this.GetFavoritePlayerName(xnpcid) != string.Empty;
		}

		public bool IsCanSend()
		{
			return this.GiveLeftCount > 0U;
		}

		public bool IsCanExchange(NpcFeelingOneNpc oneNpc)
		{
			bool flag = oneNpc == null;
			return !flag && oneNpc.exchange != null && oneNpc.exchange.Count > 0;
		}

		public bool IsCanLevelUp(NpcFeelingOneNpc info)
		{
			bool flag = info == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				NpcFeelingAttr.RowData attrDataByLevel = XNPCFavorDocument.GetAttrDataByLevel(info.npcid, info.level);
				uint num = (attrDataByLevel == null) ? 0U : attrDataByLevel.needExp;
				NpcFeelingAttr.RowData attrDataByLevel2 = XNPCFavorDocument.GetAttrDataByLevel(info.npcid, info.level + 1U);
				bool flag2 = false;
				bool flag3 = attrDataByLevel2 != null;
				if (flag3)
				{
					uint num2 = attrDataByLevel2.needExp - num;
					flag2 = (info.exp >= num2 && info.level < this.npcFlLevTop);
				}
				result = flag2;
			}
			return result;
		}

		public uint GetFavorMaxDegree(NpcFeelingOneNpc info)
		{
			bool flag = info == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				NpcFeelingAttr.RowData attrDataByLevel = XNPCFavorDocument.GetAttrDataByLevel(info.npcid, info.level);
				uint num = (attrDataByLevel == null) ? 0U : attrDataByLevel.needExp;
				NpcFeelingAttr.RowData attrDataByLevel2 = XNPCFavorDocument.GetAttrDataByLevel(info.npcid, info.level + 1U);
				bool flag2 = attrDataByLevel2 != null;
				if (flag2)
				{
					result = attrDataByLevel2.needExp - num;
				}
				else
				{
					result = 0U;
				}
			}
			return result;
		}

		public bool IsFull(NpcFeelingOneNpc info)
		{
			bool flag = info == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				NpcFeelingAttr.RowData attrDataByLevel = XNPCFavorDocument.GetAttrDataByLevel(info.npcid, info.level + 1U);
				result = (attrDataByLevel == null);
			}
			return result;
		}

		public NpcFeelingOneNpc GetOneNpcByXId(uint xnpcid)
		{
			uint npcIdByXId = XNPCFavorDocument.GetNpcIdByXId(xnpcid);
			return this.GetOneNpc(npcIdByXId);
		}

		public NpcFeelingOneNpc GetOneNpc(uint npcid)
		{
			bool flag = this.activedNpc == null;
			NpcFeelingOneNpc result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int i = 0;
				int count = this.activedNpc.Count;
				while (i < count)
				{
					bool flag2 = this.activedNpc[i].npcid == npcid;
					if (flag2)
					{
						return this.activedNpc[i];
					}
					i++;
				}
				result = null;
			}
			return result;
		}

		public List<ItemBrief> GetExchangeInfoByXId(uint xnpcid)
		{
			uint npcIdByXId = XNPCFavorDocument.GetNpcIdByXId(xnpcid);
			return this.GetExchangeInfoById(npcIdByXId);
		}

		public List<ItemBrief> GetExchangeInfoById(uint npcid)
		{
			NpcFeelingOneNpc oneNpc = this.GetOneNpc(npcid);
			return (oneNpc != null) ? oneNpc.exchange : null;
		}

		public List<NpcLikeItem> GetLikeItemsByXId(uint xnpcid)
		{
			uint npcIdByXId = XNPCFavorDocument.GetNpcIdByXId(xnpcid);
			return this.GetLikeItemsById(npcIdByXId);
		}

		public List<NpcLikeItem> GetLikeItemsById(uint npcid)
		{
			NpcFeelingOneNpc oneNpc = this.GetOneNpc(npcid);
			return (oneNpc != null) ? oneNpc.likeitem : null;
		}

		public NpcFeelingUnite GetActiveUniteInfo(uint unionid)
		{
			bool flag = this.activedUnites == null;
			NpcFeelingUnite result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int i = 0;
				int count = this.activedUnites.Count;
				while (i < count)
				{
					bool flag2 = this.activedUnites[i].id == unionid;
					if (flag2)
					{
						return this.activedUnites[i];
					}
					i++;
				}
				result = null;
			}
			return result;
		}

		public uint GetUnionSumLevel(uint unionid)
		{
			bool flag = this.activedNpc == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				NpcUniteAttr.RowData unionTableInfoByUnionId = XNPCFavorDocument.GetUnionTableInfoByUnionId(unionid, 0U);
				bool flag2 = unionTableInfoByUnionId == null;
				if (flag2)
				{
					result = 0U;
				}
				else
				{
					uint num = 0U;
					int i = 0;
					int num2 = unionTableInfoByUnionId.npcId.Length;
					while (i < num2)
					{
						NpcFeelingOneNpc oneNpc = this.GetOneNpc(unionTableInfoByUnionId.npcId[i]);
						num += ((oneNpc == null) ? 0U : oneNpc.level);
						i++;
					}
					result = num;
				}
			}
			return result;
		}

		public bool IsUnionCanActiveNextLevel(uint unionid, uint sumLevel)
		{
			NpcFeelingUnite activeUniteInfo = this.GetActiveUniteInfo(unionid);
			NpcUniteAttr.RowData nextUnionDataByUnionId = XNPCFavorDocument.GetNextUnionDataByUnionId(unionid, (activeUniteInfo == null) ? 0U : activeUniteInfo.level);
			uint level = nextUnionDataByUnionId.level;
			return sumLevel >= level;
		}

		public bool IsUnionCanActiveNextLevel(uint unionid)
		{
			uint unionSumLevel = this.GetUnionSumLevel(unionid);
			return this.IsUnionCanActiveNextLevel(unionid, unionSumLevel);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("NPCFavorDocument");

		public static StringBuilder sb = new StringBuilder();

		private const string FX_CanSendGift = "Effects/FX_Particle/Scene/Lzg_scene/rwts_07";

		private const string FX_CanExchange = "Effects/FX_Particle/Scene/Lzg_scene/rwts_05";

		private const string FX_SendSuccess = "Effects/FX_Particle/Scene/Lzg_scene/NPC_aixin_Clip01";

		private const string FX_ChangeSuccess = "Effects/FX_Particle/Scene/Lzg_scene/NPC_aixin_Clip01";

		private const string FX_FireWorkFx = "Effects/FX_Particle/UIfx/UI_yh";

		private List<XFx> m_Fxes = new List<XFx>();

		private Dictionary<uint, XFx> m_FxDict = new Dictionary<uint, XFx>();

		private XFx fireWorkFx = null;

		public XNPCFavorDlg View;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static NpcFeeling _npcInfoTable = new NpcFeeling();

		public static NpcFeelingAttr _npcAttrTable = new NpcFeelingAttr();

		public static NpcUniteAttr _npcUnionAttrTable = new NpcUniteAttr();

		private Dictionary<uint, uint> m_DictSumAttr = new Dictionary<uint, uint>();

		private static List<uint> m_NpcIds = null;

		private static List<uint> m_UnionIds = null;

		private List<NpcFlNpc2Role> npcfavorrole;

		private List<NpcFeelingOneNpc> activedNpc;

		private List<NpcFeelingUnite> activedUnites;

		private ItemBrief m_role2npc;

		private ItemBrief m_npc2role;

		private uint m_exchangeNPCId = 0U;

		private bool m_NeedRedPointShow = false;

		private bool m_HasNew = false;

		private bool m_CanLevelUpNpc = false;

		private bool m_UnionRedPoint = false;

		private uint giveLeftCount = 0U;

		private uint buyLeftCount = 0U;

		private uint buyCost = 0U;

		private uint npcFlLevTop = uint.MaxValue;
	}
}
