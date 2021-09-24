using System;
using KKSG;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRollDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XRollDocument.uuID;
			}
		}

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

		public float LastRollTime
		{
			get
			{
				return this._last_roll_time;
			}
		}

		public void SendRollReq(int type)
		{
			RpcC2G_ChooseRollReq rpcC2G_ChooseRollReq = new RpcC2G_ChooseRollReq();
			rpcC2G_ChooseRollReq.oArg.info = this._current_roll_info;
			rpcC2G_ChooseRollReq.oArg.chooseType = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChooseRollReq);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("RollDocument");

		private EnemyDoodadInfo _current_roll_info;

		public int ClientRollTime = 0;

		private float _last_roll_time = 0f;
	}
}
