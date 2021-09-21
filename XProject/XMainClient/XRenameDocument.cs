using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000968 RID: 2408
	internal class XRenameDocument : XDocComponent
	{
		// Token: 0x17002C58 RID: 11352
		// (get) Token: 0x06009114 RID: 37140 RVA: 0x0014BABC File Offset: 0x00149CBC
		public override uint ID
		{
			get
			{
				return XRenameDocument.uuID;
			}
		}

		// Token: 0x06009115 RID: 37141 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009116 RID: 37142 RVA: 0x0014BAD3 File Offset: 0x00149CD3
		public static void Execute(OnLoadedCallback callback = null)
		{
			XRenameDocument.AsyncLoader.AddTask("Table/RenameList", XRenameDocument.RenameListTable, false);
			XRenameDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009117 RID: 37143 RVA: 0x0014BAF8 File Offset: 0x00149CF8
		public int GetRenameCost(uint renameTimes)
		{
			int num = XRenameDocument.RenameListTable.Table.Length;
			bool flag = (ulong)renameTimes < (ulong)((long)num);
			int cost;
			if (flag)
			{
				cost = XRenameDocument.RenameListTable.GetByid((int)renameTimes).cost;
			}
			else
			{
				cost = XRenameDocument.RenameListTable.Table[num - 1].cost;
			}
			return cost;
		}

		// Token: 0x17002C59 RID: 11353
		// (get) Token: 0x06009118 RID: 37144 RVA: 0x0014BB48 File Offset: 0x00149D48
		public uint renameTimes
		{
			get
			{
				return this.m_renamesTime;
			}
		}

		// Token: 0x06009119 RID: 37145 RVA: 0x0014BB60 File Offset: 0x00149D60
		public void SetPlayerRenameTimes(uint value)
		{
			this.m_renamesTime = value;
			XSingleton<XDebug>.singleton.AddGreenLog("SetPlayerRenameTimes" + value, null, null, null, null, null);
		}

		// Token: 0x0600911A RID: 37146 RVA: 0x0014BB8C File Offset: 0x00149D8C
		public void SendPlayerConstRename(string value, bool isUseItem = false)
		{
			bool flag = string.IsNullOrEmpty(value);
			if (!flag)
			{
				RpcC2M_ChangeNameNew rpcC2M_ChangeNameNew = new RpcC2M_ChangeNameNew();
				rpcC2M_ChangeNameNew.oArg.name = value;
				rpcC2M_ChangeNameNew.oArg.iscostitem = isUseItem;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeNameNew);
			}
		}

		// Token: 0x0600911B RID: 37147 RVA: 0x0014BBD4 File Offset: 0x00149DD4
		public void ReceivePlayerCostRename(ChangeNameArg arg, ChangeNameRes res)
		{
			bool flag = res.errorcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RenameSuccess"), "fece00");
				XSingleton<XAttributeMgr>.singleton.XPlayerData.Name = arg.name;
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				bool flag2 = !arg.iscostitem;
				if (flag2)
				{
					this.m_renamesTime += 1U;
				}
				bool flag3 = player != null && player.BillBoard != null;
				if (flag3)
				{
					player.BillBoard.Attached();
				}
				bool flag4 = DlgBase<RenameDlg, RenameBehaviour>.singleton.IsVisible();
				if (flag4)
				{
					DlgBase<RenameDlg, RenameBehaviour>.singleton.SetVisibleWithAnimation(false, null);
				}
				bool flag5 = DlgBase<XOptionsView, XOptionsBehaviour>.singleton.IsVisible() && DlgBase<XOptionsView, XOptionsBehaviour>.singleton.CurrentTab == OptionsTab.InfoTab;
				if (flag5)
				{
					DlgBase<XOptionsView, XOptionsBehaviour>.singleton.OnTabChanged(OptionsTab.InfoTab);
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(res.errorcode);
			}
		}

		// Token: 0x0600911C RID: 37148 RVA: 0x0014BCCC File Offset: 0x00149ECC
		public void SendDragonGuildRenameVolume(string targetValue)
		{
			bool flag = string.IsNullOrEmpty(targetValue);
			if (!flag)
			{
				RpcC2M_ModifyDragonGuildName rpcC2M_ModifyDragonGuildName = new RpcC2M_ModifyDragonGuildName();
				rpcC2M_ModifyDragonGuildName.oArg.name = targetValue;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ModifyDragonGuildName);
			}
		}

		// Token: 0x0600911D RID: 37149 RVA: 0x0014BD08 File Offset: 0x00149F08
		public void ReceiveDragonGuildRenameVolume(ModifyDragonGuildNameArg oArg, ModifyDragonGuildNameRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				XDragonGuildDocument.Doc.OnNameChange(oArg.name);
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RenameSuccess"), "fece00");
				bool flag2 = DlgBase<RenameDlg, RenameBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<RenameDlg, RenameBehaviour>.singleton.SetVisibleWithAnimation(false, null);
				}
			}
		}

		// Token: 0x0600911E RID: 37150 RVA: 0x0014BD80 File Offset: 0x00149F80
		public void SendGuildRenameVolume(string targetValue)
		{
			bool flag = string.IsNullOrEmpty(targetValue);
			if (!flag)
			{
				RpcC2M_ModifyMsGuildName rpcC2M_ModifyMsGuildName = new RpcC2M_ModifyMsGuildName();
				rpcC2M_ModifyMsGuildName.oArg.name = targetValue;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ModifyMsGuildName);
			}
		}

		// Token: 0x0600911F RID: 37151 RVA: 0x0014BDBC File Offset: 0x00149FBC
		public void ReceiveGuildRenameVolume(ModifyArg oArg, ModifyRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.error);
			}
			else
			{
				this.NotifyGuildNewName(oArg.name);
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RenameSuccess"), "fece00");
				bool flag2 = DlgBase<RenameDlg, RenameBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<RenameDlg, RenameBehaviour>.singleton.SetVisibleWithAnimation(false, null);
				}
			}
		}

		// Token: 0x06009120 RID: 37152 RVA: 0x0014BE30 File Offset: 0x0014A030
		public void NotifyGuildNewName(string targetName)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool bInGuild = specificDocument.bInGuild;
			if (bInGuild)
			{
				specificDocument.BasicData.guildName = targetName;
				XGuildInfoChange @event = XEventPool<XGuildInfoChange>.GetEvent();
				@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0400301B RID: 12315
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("RenameDocument");

		// Token: 0x0400301C RID: 12316
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400301D RID: 12317
		private static RenameList RenameListTable = new RenameList();

		// Token: 0x0400301E RID: 12318
		private uint m_renamesTime = 0U;

		// Token: 0x02001964 RID: 6500
		public enum RenameType
		{
			// Token: 0x04007E05 RID: 32261
			GUILD_NAME_VOLUME,
			// Token: 0x04007E06 RID: 32262
			PLAYER_NAME_VOLUME,
			// Token: 0x04007E07 RID: 32263
			PLAYER_NAME_COST,
			// Token: 0x04007E08 RID: 32264
			DRAGON_GUILD_NAME_VOLUME
		}
	}
}
