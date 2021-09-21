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
	// Token: 0x0200095B RID: 2395
	internal class XNPCFavorDocument : XDocComponent
	{
		// Token: 0x17002C37 RID: 11319
		// (get) Token: 0x06009016 RID: 36886 RVA: 0x001467C8 File Offset: 0x001449C8
		public override uint ID
		{
			get
			{
				return XNPCFavorDocument.uuID;
			}
		}

		// Token: 0x17002C38 RID: 11320
		// (get) Token: 0x06009017 RID: 36887 RVA: 0x001467E0 File Offset: 0x001449E0
		public List<uint> NPCIds
		{
			get
			{
				XNPCFavorDocument.CheckNpcIds();
				return XNPCFavorDocument.m_NpcIds;
			}
		}

		// Token: 0x17002C39 RID: 11321
		// (get) Token: 0x06009018 RID: 36888 RVA: 0x00146800 File Offset: 0x00144A00
		public List<uint> UnionIds
		{
			get
			{
				XNPCFavorDocument.CheckUnionIds();
				return XNPCFavorDocument.m_UnionIds;
			}
		}

		// Token: 0x17002C3A RID: 11322
		// (get) Token: 0x06009019 RID: 36889 RVA: 0x00146820 File Offset: 0x00144A20
		public Dictionary<uint, uint> DictSumAttr
		{
			get
			{
				return this.m_DictSumAttr;
			}
		}

		// Token: 0x17002C3B RID: 11323
		// (get) Token: 0x0600901A RID: 36890 RVA: 0x00146838 File Offset: 0x00144A38
		public ItemBrief Role2NPC
		{
			get
			{
				return this.m_role2npc;
			}
		}

		// Token: 0x17002C3C RID: 11324
		// (get) Token: 0x0600901B RID: 36891 RVA: 0x00146850 File Offset: 0x00144A50
		public ItemBrief NPC2Role
		{
			get
			{
				return this.m_npc2role;
			}
		}

		// Token: 0x17002C3D RID: 11325
		// (get) Token: 0x0600901C RID: 36892 RVA: 0x00146868 File Offset: 0x00144A68
		public uint ExchangeNPCID
		{
			get
			{
				return this.m_exchangeNPCId;
			}
		}

		// Token: 0x17002C3E RID: 11326
		// (get) Token: 0x0600901D RID: 36893 RVA: 0x00146880 File Offset: 0x00144A80
		public uint NpcFlLevTop
		{
			get
			{
				return this.npcFlLevTop;
			}
		}

		// Token: 0x17002C3F RID: 11327
		// (get) Token: 0x0600901E RID: 36894 RVA: 0x00146898 File Offset: 0x00144A98
		// (set) Token: 0x0600901F RID: 36895 RVA: 0x001468B0 File Offset: 0x00144AB0
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

		// Token: 0x17002C40 RID: 11328
		// (get) Token: 0x06009020 RID: 36896 RVA: 0x0014691C File Offset: 0x00144B1C
		// (set) Token: 0x06009021 RID: 36897 RVA: 0x00146934 File Offset: 0x00144B34
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

		// Token: 0x17002C41 RID: 11329
		// (get) Token: 0x06009022 RID: 36898 RVA: 0x00146940 File Offset: 0x00144B40
		public uint BuyCost
		{
			get
			{
				return this.buyCost;
			}
		}

		// Token: 0x06009023 RID: 36899 RVA: 0x00146958 File Offset: 0x00144B58
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.SetupNpcHeadFx();
		}

		// Token: 0x06009024 RID: 36900 RVA: 0x00146962 File Offset: 0x00144B62
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this.SetupNpcHeadFx();
		}

		// Token: 0x06009025 RID: 36901 RVA: 0x00146973 File Offset: 0x00144B73
		public override void OnLeaveScene()
		{
			this.ClearFx();
			base.OnLeaveScene();
		}

		// Token: 0x06009026 RID: 36902 RVA: 0x00146984 File Offset: 0x00144B84
		public static void Execute(OnLoadedCallback callback = null)
		{
			XNPCFavorDocument.AsyncLoader.AddTask("Table/NpcFeeling", XNPCFavorDocument._npcInfoTable, false);
			XNPCFavorDocument.AsyncLoader.AddTask("Table/NpcFeelingAttr", XNPCFavorDocument._npcAttrTable, false);
			XNPCFavorDocument.AsyncLoader.AddTask("Table/NpcUniteAttr", XNPCFavorDocument._npcUnionAttrTable, false);
			XNPCFavorDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009027 RID: 36903 RVA: 0x001469E0 File Offset: 0x00144BE0
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this.OnTaskStateChange));
		}

		// Token: 0x06009028 RID: 36904 RVA: 0x001469FC File Offset: 0x00144BFC
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

		// Token: 0x06009029 RID: 36905 RVA: 0x00146A58 File Offset: 0x00144C58
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

		// Token: 0x0600902A RID: 36906 RVA: 0x00146B34 File Offset: 0x00144D34
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

		// Token: 0x0600902B RID: 36907 RVA: 0x00146BC4 File Offset: 0x00144DC4
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

		// Token: 0x0600902C RID: 36908 RVA: 0x00146C1C File Offset: 0x00144E1C
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

		// Token: 0x0600902D RID: 36909 RVA: 0x00146C74 File Offset: 0x00144E74
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

		// Token: 0x0600902E RID: 36910 RVA: 0x00146D54 File Offset: 0x00144F54
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

		// Token: 0x0600902F RID: 36911 RVA: 0x00146E40 File Offset: 0x00145040
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

		// Token: 0x06009030 RID: 36912 RVA: 0x00146ED4 File Offset: 0x001450D4
		public void PlayFx(uint xnpcid, string FxName)
		{
			this.PlayOneTimeNPCFX(null, xnpcid, FxName, 4f);
		}

		// Token: 0x06009031 RID: 36913 RVA: 0x00146EE8 File Offset: 0x001450E8
		private bool OnTaskStateChange(XEventArgs e)
		{
			this.SetupNpcHeadFx();
			return true;
		}

		// Token: 0x06009032 RID: 36914 RVA: 0x00146F04 File Offset: 0x00145104
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

		// Token: 0x06009033 RID: 36915 RVA: 0x00146F79 File Offset: 0x00145179
		public void PlaySendSuccessFx(uint xnpcid)
		{
			this.PlayFx(xnpcid, "Effects/FX_Particle/Scene/Lzg_scene/NPC_aixin_Clip01");
		}

		// Token: 0x06009034 RID: 36916 RVA: 0x00146F79 File Offset: 0x00145179
		public void PlayExchangeSuccessFx(uint xnpcid)
		{
			this.PlayFx(xnpcid, "Effects/FX_Particle/Scene/Lzg_scene/NPC_aixin_Clip01");
		}

		// Token: 0x06009035 RID: 36917 RVA: 0x00146F8C File Offset: 0x0014518C
		public bool IsShowFavorFx(uint xnpcId)
		{
			NpcFeelingOneNpc oneNpcByXId = this.GetOneNpcByXId(xnpcId);
			return this.IsShowLoveFx(oneNpcByXId) || this.IsShowExchangeFx(oneNpcByXId);
		}

		// Token: 0x06009036 RID: 36918 RVA: 0x00146FBC File Offset: 0x001451BC
		public bool IsShowExChangeFx(uint xnpcId)
		{
			NpcFeelingOneNpc oneNpcByXId = this.GetOneNpcByXId(xnpcId);
			return this.IsShowExchangeFx(oneNpcByXId);
		}

		// Token: 0x06009037 RID: 36919 RVA: 0x00146FE0 File Offset: 0x001451E0
		private bool IsShowExchangeFx(NpcFeelingOneNpc oneNpc)
		{
			return this.IsCanExchange(oneNpc);
		}

		// Token: 0x06009038 RID: 36920 RVA: 0x00146FFC File Offset: 0x001451FC
		private bool IsShowLoveFx(NpcFeelingOneNpc oneNpc)
		{
			bool flag = oneNpc == null;
			return !flag && this.IsCanSend() && !this.IsCanLevelUp(oneNpc);
		}

		// Token: 0x06009039 RID: 36921 RVA: 0x00147030 File Offset: 0x00145230
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

		// Token: 0x0600903A RID: 36922 RVA: 0x001470B0 File Offset: 0x001452B0
		public void ReqSrvNpcInfo()
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_BASE_DATA;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		// Token: 0x0600903B RID: 36923 RVA: 0x001470E0 File Offset: 0x001452E0
		public void ReqSrvGiveGift(uint npcid, NpcLikeItem likeitem)
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_GIVE_GIFT;
			rpcC2M_NpcFlReqC2M.oArg.npcid = npcid;
			rpcC2M_NpcFlReqC2M.oArg.likeitem = likeitem;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		// Token: 0x0600903C RID: 36924 RVA: 0x00147128 File Offset: 0x00145328
		public void ReqSrvExchangeGift(uint npcid, ItemBrief role2npc, ItemBrief npc2role)
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_EXCHANGE;
			rpcC2M_NpcFlReqC2M.oArg.npcid = npcid;
			rpcC2M_NpcFlReqC2M.oArg.role2npc = role2npc;
			rpcC2M_NpcFlReqC2M.oArg.npc2role = npc2role;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		// Token: 0x0600903D RID: 36925 RVA: 0x0014717C File Offset: 0x0014537C
		public void ReqSrvLevelUp(uint npcid)
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_NPC_LEVEL_UP;
			rpcC2M_NpcFlReqC2M.oArg.npcid = npcid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		// Token: 0x0600903E RID: 36926 RVA: 0x001471B8 File Offset: 0x001453B8
		public void ReqSrvActiveUnionLevel(uint uniteid, uint level)
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_UNITE_ACT;
			rpcC2M_NpcFlReqC2M.oArg.uniteid = uniteid;
			rpcC2M_NpcFlReqC2M.oArg.level = level;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		// Token: 0x0600903F RID: 36927 RVA: 0x00147200 File Offset: 0x00145400
		public void ReqSrvBuyGiftCount()
		{
			RpcC2M_NpcFlReqC2M rpcC2M_NpcFlReqC2M = new RpcC2M_NpcFlReqC2M();
			rpcC2M_NpcFlReqC2M.oArg.reqtype = NpcFlReqType.NPCFL_BUY_GIFT_COUNT;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_NpcFlReqC2M);
		}

		// Token: 0x06009040 RID: 36928 RVA: 0x00147230 File Offset: 0x00145430
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

		// Token: 0x06009041 RID: 36929 RVA: 0x00147671 File Offset: 0x00145871
		private void SortNpc()
		{
			XNPCFavorDocument.CheckNpcIds();
			XNPCFavorDocument.m_NpcIds.Sort(new Comparison<uint>(XNPCFavorDocument.Compare));
		}

		// Token: 0x06009042 RID: 36930 RVA: 0x00147694 File Offset: 0x00145894
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

		// Token: 0x06009043 RID: 36931 RVA: 0x00147894 File Offset: 0x00145A94
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

		// Token: 0x06009044 RID: 36932 RVA: 0x001478E3 File Offset: 0x00145AE3
		public void ReqNPCFavorUnionInfo()
		{
			this.ReqSrvNpcInfo();
		}

		// Token: 0x06009045 RID: 36933 RVA: 0x001478F0 File Offset: 0x00145AF0
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

		// Token: 0x06009046 RID: 36934 RVA: 0x00147930 File Offset: 0x00145B30
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

		// Token: 0x06009047 RID: 36935 RVA: 0x00147970 File Offset: 0x00145B70
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

		// Token: 0x06009048 RID: 36936 RVA: 0x001479E8 File Offset: 0x00145BE8
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

		// Token: 0x06009049 RID: 36937 RVA: 0x00147A80 File Offset: 0x00145C80
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

		// Token: 0x0600904A RID: 36938 RVA: 0x00147BD4 File Offset: 0x00145DD4
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

		// Token: 0x0600904B RID: 36939 RVA: 0x00147C34 File Offset: 0x00145E34
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

		// Token: 0x0600904C RID: 36940 RVA: 0x00147C88 File Offset: 0x00145E88
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

		// Token: 0x0600904D RID: 36941 RVA: 0x00147CD8 File Offset: 0x00145ED8
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

		// Token: 0x17002C42 RID: 11330
		// (get) Token: 0x0600904E RID: 36942 RVA: 0x00147D30 File Offset: 0x00145F30
		// (set) Token: 0x0600904F RID: 36943 RVA: 0x00147D48 File Offset: 0x00145F48
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

		// Token: 0x17002C43 RID: 11331
		// (get) Token: 0x06009050 RID: 36944 RVA: 0x00147D64 File Offset: 0x00145F64
		// (set) Token: 0x06009051 RID: 36945 RVA: 0x00147D7C File Offset: 0x00145F7C
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

		// Token: 0x17002C44 RID: 11332
		// (get) Token: 0x06009052 RID: 36946 RVA: 0x00147DEC File Offset: 0x00145FEC
		// (set) Token: 0x06009053 RID: 36947 RVA: 0x00147E04 File Offset: 0x00146004
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

		// Token: 0x17002C45 RID: 11333
		// (get) Token: 0x06009054 RID: 36948 RVA: 0x00147E74 File Offset: 0x00146074
		// (set) Token: 0x06009055 RID: 36949 RVA: 0x00147E8C File Offset: 0x0014608C
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

		// Token: 0x06009056 RID: 36950 RVA: 0x00147EF0 File Offset: 0x001460F0
		public static void ShowNPCDrama(uint xnpcId)
		{
			XNPCFavorDrama xnpcfavorDrama = XNPCFavorDocument.IsNpcDialogVisible();
			bool flag = xnpcfavorDrama != null;
			if (flag)
			{
				xnpcfavorDrama.RefreshOperateStatus(true, null);
			}
		}

		// Token: 0x06009057 RID: 36951 RVA: 0x00147F18 File Offset: 0x00146118
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

		// Token: 0x06009058 RID: 36952 RVA: 0x00147F50 File Offset: 0x00146150
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

		// Token: 0x06009059 RID: 36953 RVA: 0x00147FB0 File Offset: 0x001461B0
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

		// Token: 0x0600905A RID: 36954 RVA: 0x00148024 File Offset: 0x00146224
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

		// Token: 0x0600905B RID: 36955 RVA: 0x00148098 File Offset: 0x00146298
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

		// Token: 0x0600905C RID: 36956 RVA: 0x00148124 File Offset: 0x00146324
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

		// Token: 0x0600905D RID: 36957 RVA: 0x001481AC File Offset: 0x001463AC
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

		// Token: 0x0600905E RID: 36958 RVA: 0x001482AC File Offset: 0x001464AC
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

		// Token: 0x0600905F RID: 36959 RVA: 0x00148338 File Offset: 0x00146538
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

		// Token: 0x06009060 RID: 36960 RVA: 0x00148408 File Offset: 0x00146608
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

		// Token: 0x06009061 RID: 36961 RVA: 0x00148480 File Offset: 0x00146680
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

		// Token: 0x06009062 RID: 36962 RVA: 0x001484F8 File Offset: 0x001466F8
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

		// Token: 0x06009063 RID: 36963 RVA: 0x0014857C File Offset: 0x0014677C
		public bool IsShowNPCFavoritePlayer(uint xnpcid)
		{
			return this.GetFavoritePlayerName(xnpcid) != string.Empty;
		}

		// Token: 0x06009064 RID: 36964 RVA: 0x001485A0 File Offset: 0x001467A0
		public bool IsCanSend()
		{
			return this.GiveLeftCount > 0U;
		}

		// Token: 0x06009065 RID: 36965 RVA: 0x001485BC File Offset: 0x001467BC
		public bool IsCanExchange(NpcFeelingOneNpc oneNpc)
		{
			bool flag = oneNpc == null;
			return !flag && oneNpc.exchange != null && oneNpc.exchange.Count > 0;
		}

		// Token: 0x06009066 RID: 36966 RVA: 0x001485F4 File Offset: 0x001467F4
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

		// Token: 0x06009067 RID: 36967 RVA: 0x00148680 File Offset: 0x00146880
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

		// Token: 0x06009068 RID: 36968 RVA: 0x001486EC File Offset: 0x001468EC
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

		// Token: 0x06009069 RID: 36969 RVA: 0x00148724 File Offset: 0x00146924
		public NpcFeelingOneNpc GetOneNpcByXId(uint xnpcid)
		{
			uint npcIdByXId = XNPCFavorDocument.GetNpcIdByXId(xnpcid);
			return this.GetOneNpc(npcIdByXId);
		}

		// Token: 0x0600906A RID: 36970 RVA: 0x00148744 File Offset: 0x00146944
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

		// Token: 0x0600906B RID: 36971 RVA: 0x001487B4 File Offset: 0x001469B4
		public List<ItemBrief> GetExchangeInfoByXId(uint xnpcid)
		{
			uint npcIdByXId = XNPCFavorDocument.GetNpcIdByXId(xnpcid);
			return this.GetExchangeInfoById(npcIdByXId);
		}

		// Token: 0x0600906C RID: 36972 RVA: 0x001487D4 File Offset: 0x001469D4
		public List<ItemBrief> GetExchangeInfoById(uint npcid)
		{
			NpcFeelingOneNpc oneNpc = this.GetOneNpc(npcid);
			return (oneNpc != null) ? oneNpc.exchange : null;
		}

		// Token: 0x0600906D RID: 36973 RVA: 0x001487FC File Offset: 0x001469FC
		public List<NpcLikeItem> GetLikeItemsByXId(uint xnpcid)
		{
			uint npcIdByXId = XNPCFavorDocument.GetNpcIdByXId(xnpcid);
			return this.GetLikeItemsById(npcIdByXId);
		}

		// Token: 0x0600906E RID: 36974 RVA: 0x0014881C File Offset: 0x00146A1C
		public List<NpcLikeItem> GetLikeItemsById(uint npcid)
		{
			NpcFeelingOneNpc oneNpc = this.GetOneNpc(npcid);
			return (oneNpc != null) ? oneNpc.likeitem : null;
		}

		// Token: 0x0600906F RID: 36975 RVA: 0x00148844 File Offset: 0x00146A44
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

		// Token: 0x06009070 RID: 36976 RVA: 0x001488B4 File Offset: 0x00146AB4
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

		// Token: 0x06009071 RID: 36977 RVA: 0x00148938 File Offset: 0x00146B38
		public bool IsUnionCanActiveNextLevel(uint unionid, uint sumLevel)
		{
			NpcFeelingUnite activeUniteInfo = this.GetActiveUniteInfo(unionid);
			NpcUniteAttr.RowData nextUnionDataByUnionId = XNPCFavorDocument.GetNextUnionDataByUnionId(unionid, (activeUniteInfo == null) ? 0U : activeUniteInfo.level);
			uint level = nextUnionDataByUnionId.level;
			return sumLevel >= level;
		}

		// Token: 0x06009072 RID: 36978 RVA: 0x00148978 File Offset: 0x00146B78
		public bool IsUnionCanActiveNextLevel(uint unionid)
		{
			uint unionSumLevel = this.GetUnionSumLevel(unionid);
			return this.IsUnionCanActiveNextLevel(unionid, unionSumLevel);
		}

		// Token: 0x04002FB4 RID: 12212
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("NPCFavorDocument");

		// Token: 0x04002FB5 RID: 12213
		public static StringBuilder sb = new StringBuilder();

		// Token: 0x04002FB6 RID: 12214
		private const string FX_CanSendGift = "Effects/FX_Particle/Scene/Lzg_scene/rwts_07";

		// Token: 0x04002FB7 RID: 12215
		private const string FX_CanExchange = "Effects/FX_Particle/Scene/Lzg_scene/rwts_05";

		// Token: 0x04002FB8 RID: 12216
		private const string FX_SendSuccess = "Effects/FX_Particle/Scene/Lzg_scene/NPC_aixin_Clip01";

		// Token: 0x04002FB9 RID: 12217
		private const string FX_ChangeSuccess = "Effects/FX_Particle/Scene/Lzg_scene/NPC_aixin_Clip01";

		// Token: 0x04002FBA RID: 12218
		private const string FX_FireWorkFx = "Effects/FX_Particle/UIfx/UI_yh";

		// Token: 0x04002FBB RID: 12219
		private List<XFx> m_Fxes = new List<XFx>();

		// Token: 0x04002FBC RID: 12220
		private Dictionary<uint, XFx> m_FxDict = new Dictionary<uint, XFx>();

		// Token: 0x04002FBD RID: 12221
		private XFx fireWorkFx = null;

		// Token: 0x04002FBE RID: 12222
		public XNPCFavorDlg View;

		// Token: 0x04002FBF RID: 12223
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002FC0 RID: 12224
		public static NpcFeeling _npcInfoTable = new NpcFeeling();

		// Token: 0x04002FC1 RID: 12225
		public static NpcFeelingAttr _npcAttrTable = new NpcFeelingAttr();

		// Token: 0x04002FC2 RID: 12226
		public static NpcUniteAttr _npcUnionAttrTable = new NpcUniteAttr();

		// Token: 0x04002FC3 RID: 12227
		private Dictionary<uint, uint> m_DictSumAttr = new Dictionary<uint, uint>();

		// Token: 0x04002FC4 RID: 12228
		private static List<uint> m_NpcIds = null;

		// Token: 0x04002FC5 RID: 12229
		private static List<uint> m_UnionIds = null;

		// Token: 0x04002FC6 RID: 12230
		private List<NpcFlNpc2Role> npcfavorrole;

		// Token: 0x04002FC7 RID: 12231
		private List<NpcFeelingOneNpc> activedNpc;

		// Token: 0x04002FC8 RID: 12232
		private List<NpcFeelingUnite> activedUnites;

		// Token: 0x04002FC9 RID: 12233
		private ItemBrief m_role2npc;

		// Token: 0x04002FCA RID: 12234
		private ItemBrief m_npc2role;

		// Token: 0x04002FCB RID: 12235
		private uint m_exchangeNPCId = 0U;

		// Token: 0x04002FCC RID: 12236
		private bool m_NeedRedPointShow = false;

		// Token: 0x04002FCD RID: 12237
		private bool m_HasNew = false;

		// Token: 0x04002FCE RID: 12238
		private bool m_CanLevelUpNpc = false;

		// Token: 0x04002FCF RID: 12239
		private bool m_UnionRedPoint = false;

		// Token: 0x04002FD0 RID: 12240
		private uint giveLeftCount = 0U;

		// Token: 0x04002FD1 RID: 12241
		private uint buyLeftCount = 0U;

		// Token: 0x04002FD2 RID: 12242
		private uint buyCost = 0U;

		// Token: 0x04002FD3 RID: 12243
		private uint npcFlLevTop = uint.MaxValue;
	}
}
