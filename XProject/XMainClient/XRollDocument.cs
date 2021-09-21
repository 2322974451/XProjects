using System;
using KKSG;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200097A RID: 2426
	internal class XRollDocument : XDocComponent
	{
		// Token: 0x17002C8A RID: 11402
		// (get) Token: 0x06009214 RID: 37396 RVA: 0x00150838 File Offset: 0x0014EA38
		public override uint ID
		{
			get
			{
				return XRollDocument.uuID;
			}
		}

		// Token: 0x17002C8B RID: 11403
		// (get) Token: 0x06009215 RID: 37397 RVA: 0x00150850 File Offset: 0x0014EA50
		public uint RollItemID
		{
			get
			{
				bool flag = this._current_roll_info == null;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					result = this._current_roll_info.id;
				}
				return result;
			}
		}

		// Token: 0x17002C8C RID: 11404
		// (get) Token: 0x06009216 RID: 37398 RVA: 0x00150880 File Offset: 0x0014EA80
		public uint RollItemCount
		{
			get
			{
				bool flag = this._current_roll_info == null;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					result = this._current_roll_info.count;
				}
				return result;
			}
		}

		// Token: 0x17002C8D RID: 11405
		// (get) Token: 0x06009217 RID: 37399 RVA: 0x001508B0 File Offset: 0x0014EAB0
		public float LastRollTime
		{
			get
			{
				return this._last_roll_time;
			}
		}

		// Token: 0x06009218 RID: 37400 RVA: 0x001508C8 File Offset: 0x0014EAC8
		public void SendRollReq(int type)
		{
			RpcC2G_ChooseRollReq rpcC2G_ChooseRollReq = new RpcC2G_ChooseRollReq();
			rpcC2G_ChooseRollReq.oArg.info = this._current_roll_info;
			rpcC2G_ChooseRollReq.oArg.chooseType = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChooseRollReq);
		}

		// Token: 0x06009219 RID: 37401 RVA: 0x00150908 File Offset: 0x0014EB08
		public void SetRollItem(EnemyDoodadInfo info)
		{
			bool flag = this.ClientRollTime == 0;
			if (flag)
			{
				this.ClientRollTime = XSingleton<XGlobalConfig>.singleton.GetInt("ClientRollTime");
			}
			this._last_roll_time = Time.time;
			this._current_roll_info = info;
			DlgBase<RollDlg, RollDlgBehaviour>.singleton.ShowRollInfo();
		}

		// Token: 0x0600921A RID: 37402 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x040030BA RID: 12474
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("RollDocument");

		// Token: 0x040030BB RID: 12475
		private EnemyDoodadInfo _current_roll_info;

		// Token: 0x040030BC RID: 12476
		public int ClientRollTime = 0;

		// Token: 0x040030BD RID: 12477
		private float _last_roll_time = 0f;
	}
}
