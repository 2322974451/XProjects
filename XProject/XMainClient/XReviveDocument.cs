using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008D1 RID: 2257
	internal class XReviveDocument : XDocComponent
	{
		// Token: 0x17002AA8 RID: 10920
		// (get) Token: 0x06008884 RID: 34948 RVA: 0x0011B158 File Offset: 0x00119358
		public override uint ID
		{
			get
			{
				return XReviveDocument.uuID;
			}
		}

		// Token: 0x17002AA9 RID: 10921
		// (get) Token: 0x06008885 RID: 34949 RVA: 0x0011B170 File Offset: 0x00119370
		public bool CanVipRevive
		{
			get
			{
				return this._can_vip_revive;
			}
		}

		// Token: 0x17002AAA RID: 10922
		// (get) Token: 0x06008886 RID: 34950 RVA: 0x0011B188 File Offset: 0x00119388
		// (set) Token: 0x06008887 RID: 34951 RVA: 0x0011B1A0 File Offset: 0x001193A0
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

		// Token: 0x17002AAB RID: 10923
		// (get) Token: 0x06008888 RID: 34952 RVA: 0x0011B1AC File Offset: 0x001193AC
		public string LeaveSceneTip
		{
			get
			{
				return this._leave_scene_tip;
			}
		}

		// Token: 0x17002AAC RID: 10924
		// (get) Token: 0x06008889 RID: 34953 RVA: 0x0011B1C4 File Offset: 0x001193C4
		public string BuffStringTip
		{
			get
			{
				return this._buff_string_tip;
			}
		}

		// Token: 0x17002AAD RID: 10925
		// (get) Token: 0x0600888A RID: 34954 RVA: 0x0011B1DC File Offset: 0x001193DC
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

		// Token: 0x17002AAE RID: 10926
		// (get) Token: 0x0600888B RID: 34955 RVA: 0x0011B24C File Offset: 0x0011944C
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

		// Token: 0x17002AAF RID: 10927
		// (get) Token: 0x0600888C RID: 34956 RVA: 0x0011B2BC File Offset: 0x001194BC
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

		// Token: 0x17002AB0 RID: 10928
		// (get) Token: 0x0600888D RID: 34957 RVA: 0x0011B32C File Offset: 0x0011952C
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

		// Token: 0x17002AB1 RID: 10929
		// (get) Token: 0x0600888E RID: 34958 RVA: 0x0011B39C File Offset: 0x0011959C
		public int ReviveUsedTime
		{
			get
			{
				return this._revive_used_time;
			}
		}

		// Token: 0x17002AB2 RID: 10930
		// (get) Token: 0x0600888F RID: 34959 RVA: 0x0011B3B4 File Offset: 0x001195B4
		public int ReviveMaxTime
		{
			get
			{
				return this._revive_max_time;
			}
		}

		// Token: 0x17002AB3 RID: 10931
		// (get) Token: 0x06008890 RID: 34960 RVA: 0x0011B3CC File Offset: 0x001195CC
		public int ReviveCostTime
		{
			get
			{
				return this._revive_cost_time;
			}
		}

		// Token: 0x06008891 RID: 34961 RVA: 0x0011B3E4 File Offset: 0x001195E4
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

		// Token: 0x06008892 RID: 34962 RVA: 0x0011B48E File Offset: 0x0011968E
		public void SetReviveData(int usedtime, int costtime, ReviveType type)
		{
			this._revive_used_time = usedtime;
			this._revive_cost_time = costtime;
			this._sync_revive_type = type;
		}

		// Token: 0x06008893 RID: 34963 RVA: 0x0011B4A8 File Offset: 0x001196A8
		public void SendReviveRpc(ReviveType type)
		{
			RpcC2G_Revive rpcC2G_Revive = new RpcC2G_Revive();
			rpcC2G_Revive.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Revive);
		}

		// Token: 0x06008894 RID: 34964 RVA: 0x0011B4D5 File Offset: 0x001196D5
		public void SendLeaveScene()
		{
			XSingleton<XLevelFinishMgr>.singleton.SendLevelFailData();
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		// Token: 0x06008895 RID: 34965 RVA: 0x0011B4EE File Offset: 0x001196EE
		public void ResetAutoReviveData()
		{
			this._auto_revive = false;
			this._auto_revive_limit = false;
			this._auto_revive_time = 0f;
		}

		// Token: 0x06008896 RID: 34966 RVA: 0x0011B50A File Offset: 0x0011970A
		public void SetAutoReviveData(bool haslimit, float time = 2f)
		{
			this._auto_revive = true;
			this._auto_revive_limit = haslimit;
			this._auto_revive_time = time;
		}

		// Token: 0x06008897 RID: 34967 RVA: 0x0011B524 File Offset: 0x00119724
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

		// Token: 0x06008898 RID: 34968 RVA: 0x0011B5BC File Offset: 0x001197BC
		private void SendAutoReviveRpc(object o)
		{
			RpcC2G_Revive rpcC2G_Revive = new RpcC2G_Revive();
			rpcC2G_Revive.oArg.type = ReviveType.ReviveSprite;
			rpcC2G_Revive.oArg.clientinfo = new ClientReviveInfo();
			rpcC2G_Revive.oArg.clientinfo.islimit = this._auto_revive_limit;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Revive);
		}

		// Token: 0x06008899 RID: 34969 RVA: 0x0011B614 File Offset: 0x00119814
		public void ShowSpecialRevive()
		{
			bool flag = !DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.ShowSpecialReviveFrame();
			}
		}

		// Token: 0x0600889A RID: 34970 RVA: 0x0011B640 File Offset: 0x00119840
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool auto_revive = this._auto_revive;
			if (auto_revive)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._auto_revive_token);
				this.ShowSpecialRevive();
			}
		}

		// Token: 0x04002B2B RID: 11051
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ReviveDocument");

		// Token: 0x04002B2C RID: 11052
		private string _leave_scene_tip = "";

		// Token: 0x04002B2D RID: 11053
		private string _buff_string_tip = "";

		// Token: 0x04002B2E RID: 11054
		private SeqListRef<uint> _normal_cost_list;

		// Token: 0x04002B2F RID: 11055
		private SeqListRef<uint> _special_cost_list;

		// Token: 0x04002B30 RID: 11056
		private int _revive_used_time = 0;

		// Token: 0x04002B31 RID: 11057
		private int _revive_max_time = 0;

		// Token: 0x04002B32 RID: 11058
		private int _revive_cost_time = 0;

		// Token: 0x04002B33 RID: 11059
		private ReviveType _sync_revive_type = ReviveType.ReviveNone;

		// Token: 0x04002B34 RID: 11060
		private bool _can_vip_revive = false;

		// Token: 0x04002B35 RID: 11061
		private uint _vip_revive_count = 0U;

		// Token: 0x04002B36 RID: 11062
		private bool _auto_revive = false;

		// Token: 0x04002B37 RID: 11063
		private bool _auto_revive_limit = false;

		// Token: 0x04002B38 RID: 11064
		private float _auto_revive_time = 0f;

		// Token: 0x04002B39 RID: 11065
		private uint _auto_revive_token = 0U;
	}
}
