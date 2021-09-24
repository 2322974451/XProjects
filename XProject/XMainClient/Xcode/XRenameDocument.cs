using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRenameDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XRenameDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XRenameDocument.AsyncLoader.AddTask("Table/RenameList", XRenameDocument.RenameListTable, false);
			XRenameDocument.AsyncLoader.Execute(callback);
		}

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

		public uint renameTimes
		{
			get
			{
				return this.m_renamesTime;
			}
		}

		public void SetPlayerRenameTimes(uint value)
		{
			this.m_renamesTime = value;
			XSingleton<XDebug>.singleton.AddGreenLog("SetPlayerRenameTimes" + value, null, null, null, null, null);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("RenameDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static RenameList RenameListTable = new RenameList();

		private uint m_renamesTime = 0U;

		public enum RenameType
		{

			GUILD_NAME_VOLUME,

			PLAYER_NAME_VOLUME,

			PLAYER_NAME_COST,

			DRAGON_GUILD_NAME_VOLUME
		}
	}
}
