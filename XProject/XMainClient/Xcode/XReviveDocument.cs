using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XReviveDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XReviveDocument.uuID;
			}
		}

		public bool CanVipRevive
		{
			get
			{
				return this._can_vip_revive;
			}
		}

		public uint VipReviveCount
		{
			get
			{
				return this._vip_revive_count;
			}
			set
			{
				this._vip_revive_count = value;
			}
		}

		public string LeaveSceneTip
		{
			get
			{
				return this._leave_scene_tip;
			}
		}

		public string BuffStringTip
		{
			get
			{
				return this._buff_string_tip;
			}
		}

		public uint NormalCostID
		{
			get
			{
				bool flag = this._normal_cost_list.Count == 0;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					bool flag2 = this._revive_cost_time < this._normal_cost_list.Count;
					if (flag2)
					{
						result = this._normal_cost_list[this._revive_cost_time, 0];
					}
					else
					{
						result = this._normal_cost_list[this._normal_cost_list.Count - 1, 0];
					}
				}
				return result;
			}
		}

		public uint NormalCostCount
		{
			get
			{
				bool flag = this._normal_cost_list.Count == 0;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					bool flag2 = this._revive_cost_time < this._normal_cost_list.Count;
					if (flag2)
					{
						result = this._normal_cost_list[this._revive_cost_time, 1];
					}
					else
					{
						result = this._normal_cost_list[this._normal_cost_list.Count - 1, 1];
					}
				}
				return result;
			}
		}

		public uint SpecialCostID
		{
			get
			{
				bool flag = this._special_cost_list.Count == 0;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					bool flag2 = this._revive_cost_time < this._special_cost_list.Count;
					if (flag2)
					{
						result = this._special_cost_list[this._revive_cost_time, 0];
					}
					else
					{
						result = this._special_cost_list[this._special_cost_list.Count - 1, 0];
					}
				}
				return result;
			}
		}

		public uint SpecialCostCount
		{
			get
			{
				bool flag = this._special_cost_list.Count == 0;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					bool flag2 = this._revive_cost_time < this._special_cost_list.Count;
					if (flag2)
					{
						result = this._special_cost_list[this._revive_cost_time, 1];
					}
					else
					{
						result = this._special_cost_list[this._special_cost_list.Count - 1, 1];
					}
				}
				return result;
			}
		}

		public int ReviveUsedTime
		{
			get
			{
				return this._revive_used_time;
			}
		}

		public int ReviveMaxTime
		{
			get
			{
				return this._revive_max_time;
			}
		}

		public int ReviveCostTime
		{
			get
			{
				return this._revive_cost_time;
			}
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			this._leave_scene_tip = XSingleton<UiUtility>.singleton.ReplaceReturn(sceneData.LeaveSceneTip);
			this._buff_string_tip = XSingleton<UiUtility>.singleton.ReplaceReturn(sceneData.ReviveBuffTip);
			this._revive_max_time = (int)sceneData.ReviveNumb;
			this._revive_used_time = 0;
			this._revive_cost_time = 0;
			this._normal_cost_list = sceneData.ReviveCost;
			this._special_cost_list = sceneData.ReviveMoneyCost;
			this._can_vip_revive = (sceneData.CanVIPRevive == 0);
			this._vip_revive_count = (uint)sceneData.VipReviveLimit;
			this.ResetAutoReviveData();
		}

		public void SetReviveData(int usedtime, int costtime, ReviveType type)
		{
			this._revive_used_time = usedtime;
			this._revive_cost_time = costtime;
			this._sync_revive_type = type;
		}

		public void SendReviveRpc(ReviveType type)
		{
			RpcC2G_Revive rpcC2G_Revive = new RpcC2G_Revive();
			rpcC2G_Revive.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Revive);
		}

		public void SendLeaveScene()
		{
			XSingleton<XLevelFinishMgr>.singleton.SendLevelFailData();
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		public void ResetAutoReviveData()
		{
			this._auto_revive = false;
			this._auto_revive_limit = false;
			this._auto_revive_time = 0f;
		}

		public void SetAutoReviveData(bool haslimit, float time = 2f)
		{
			this._auto_revive = true;
			this._auto_revive_limit = haslimit;
			this._auto_revive_time = time;
		}

		public void StartRevive()
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				ReviveType sync_revive_type = this._sync_revive_type;
				if (sync_revive_type - ReviveType.ReviveItem <= 1 || sync_revive_type == ReviveType.ReviveVIP)
				{
					DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.SetVisible(true, true);
				}
			}
			else
			{
				bool auto_revive = this._auto_revive;
				if (auto_revive)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._auto_revive_token);
					this._auto_revive_token = XSingleton<XTimerMgr>.singleton.SetTimer(this._auto_revive_time, new XTimerMgr.ElapsedEventHandler(this.SendAutoReviveRpc), null);
				}
				else
				{
					DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.SetVisible(true, true);
				}
			}
		}

		private void SendAutoReviveRpc(object o)
		{
			RpcC2G_Revive rpcC2G_Revive = new RpcC2G_Revive();
			rpcC2G_Revive.oArg.type = ReviveType.ReviveSprite;
			rpcC2G_Revive.oArg.clientinfo = new ClientReviveInfo();
			rpcC2G_Revive.oArg.clientinfo.islimit = this._auto_revive_limit;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Revive);
		}

		public void ShowSpecialRevive()
		{
			bool flag = !DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.ShowSpecialReviveFrame();
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool auto_revive = this._auto_revive;
			if (auto_revive)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._auto_revive_token);
				this.ShowSpecialRevive();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ReviveDocument");

		private string _leave_scene_tip = "";

		private string _buff_string_tip = "";

		private SeqListRef<uint> _normal_cost_list;

		private SeqListRef<uint> _special_cost_list;

		private int _revive_used_time = 0;

		private int _revive_max_time = 0;

		private int _revive_cost_time = 0;

		private ReviveType _sync_revive_type = ReviveType.ReviveNone;

		private bool _can_vip_revive = false;

		private uint _vip_revive_count = 0U;

		private bool _auto_revive = false;

		private bool _auto_revive_limit = false;

		private float _auto_revive_time = 0f;

		private uint _auto_revive_token = 0U;
	}
}
