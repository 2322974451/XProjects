using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EDE RID: 3806
	internal struct XBulletCore
	{
		// Token: 0x0600C99C RID: 51612 RVA: 0x002D58B0 File Offset: 0x002D3AB0
		public XBulletCore(long token, XEntity firer, XEntity target, XSkillCore core, XResultData data, uint resultID, int diviation, bool demonstration, int wid)
		{
			this._token = token;
			this._result = data;
			this._sequnce = data.Index;
			this._result_id = resultID;
			this._result_time = data.Token;
			this._firer = firer;
			this._firer_id = firer.ID;
			this._target = (XEntity.ValideEntity(target) ? target : null);
			this._core = core;
			this._demonstration = demonstration;
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("BulletSkillName");
			bool flag = !string.IsNullOrEmpty(value) && value.Contains(core.Soul.Name);
			if (flag)
			{
				this._trigger_move = true;
			}
			else
			{
				this._trigger_move = false;
			}
			this._warning_pos = Vector3.zero;
			bool attack_All = data.Attack_All;
			if (attack_All)
			{
				this._warning_pos = this._target.EngineObject.Position;
			}
			else
			{
				bool warning = data.Warning;
				if (warning)
				{
					this._warning_pos = this._core.WarningPosAt[data.Warning_Idx][wid].WarningAt;
				}
			}
			this._warning = (this._warning_pos.sqrMagnitude > 0f);
			Vector3 vector = this._firer.EngineObject.Position;
			vector.y += this._firer.Height * 0.5f;
			Vector3 v = this._warning ? (this._warning_pos - firer.EngineObject.Position) : ((data.LongAttackData.Reinforce && this._target != null) ? (this._target.EngineObject.Position - firer.EngineObject.Position) : firer.EngineObject.Forward);
			vector += this._firer.EngineObject.Rotation * new Vector3(this._result.LongAttackData.At_X, this._result.LongAttackData.At_Y, this._result.LongAttackData.At_Z);
			float num = 0f;
			bool flag2 = !XSingleton<XScene>.singleton.TryGetTerrainY(vector, out num) || num < 0f;
			if (flag2)
			{
				vector.x = this._firer.EngineObject.Position.x;
				vector.z = this._firer.EngineObject.Position.z;
			}
			v.y = 0f;
			Vector3 vector2 = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(v, (float)diviation, true);
			float runningtime = this._result.LongAttackData.Runningtime;
			this._velocity = (this._warning ? ((this._warning_pos - vector).magnitude / runningtime) : this._result.LongAttackData.Velocity);
			float num2 = 0f;
			bool flag3 = this._target != null && this._result.LongAttackData.AimTargetCenter;
			if (flag3)
			{
				num2 = vector.y - this._target.EngineObject.Position.y - this._target.Height * 0.5f;
				bool flag4 = Mathf.Abs(num2) > 2f;
				if (flag4)
				{
					num2 = 2f * (num2 / Mathf.Abs(num2));
				}
			}
			vector2 = ((num2 == 0f || this._velocity == 0f) ? vector2 : (num2 * Vector3.down + this._velocity * runningtime * vector2).normalized);
			this.BulletRay = new Ray(vector, vector2);
			this._init_h = vector.y - XSingleton<XScene>.singleton.TerrainY(vector);
			bool flag5 = this._init_h < 0f;
			if (flag5)
			{
				this._init_h = 0f;
			}
			this._with_terrain = this._result.LongAttackData.FlyWithTerrain;
		}

		// Token: 0x1700351F RID: 13599
		// (get) Token: 0x0600C99D RID: 51613 RVA: 0x002D5CB0 File Offset: 0x002D3EB0
		public float InitHeight
		{
			get
			{
				return this._init_h;
			}
		}

		// Token: 0x17003520 RID: 13600
		// (get) Token: 0x0600C99E RID: 51614 RVA: 0x002D5CC8 File Offset: 0x002D3EC8
		public long Token
		{
			get
			{
				return this._token;
			}
		}

		// Token: 0x17003521 RID: 13601
		// (get) Token: 0x0600C99F RID: 51615 RVA: 0x002D5CE0 File Offset: 0x002D3EE0
		public bool FlyWithTerrain
		{
			get
			{
				return this._with_terrain;
			}
		}

		// Token: 0x17003522 RID: 13602
		// (get) Token: 0x0600C9A0 RID: 51616 RVA: 0x002D5CF8 File Offset: 0x002D3EF8
		public bool Demonstration
		{
			get
			{
				return this._demonstration;
			}
		}

		// Token: 0x17003523 RID: 13603
		// (get) Token: 0x0600C9A1 RID: 51617 RVA: 0x002D5D10 File Offset: 0x002D3F10
		public bool Warning
		{
			get
			{
				return this._warning;
			}
		}

		// Token: 0x17003524 RID: 13604
		// (get) Token: 0x0600C9A2 RID: 51618 RVA: 0x002D5D28 File Offset: 0x002D3F28
		public bool HasTarget
		{
			get
			{
				return this.Target != null;
			}
		}

		// Token: 0x17003525 RID: 13605
		// (get) Token: 0x0600C9A3 RID: 51619 RVA: 0x002D5D44 File Offset: 0x002D3F44
		public Vector3 WarningPos
		{
			get
			{
				return this._warning_pos;
			}
		}

		// Token: 0x17003526 RID: 13606
		// (get) Token: 0x0600C9A4 RID: 51620 RVA: 0x002D5D5C File Offset: 0x002D3F5C
		public XResultData Result
		{
			get
			{
				return this._result;
			}
		}

		// Token: 0x17003527 RID: 13607
		// (get) Token: 0x0600C9A5 RID: 51621 RVA: 0x002D5D74 File Offset: 0x002D3F74
		public XSkillCore SkillCore
		{
			get
			{
				return this._core;
			}
		}

		// Token: 0x17003528 RID: 13608
		// (get) Token: 0x0600C9A6 RID: 51622 RVA: 0x002D5D8C File Offset: 0x002D3F8C
		public XEntity Firer
		{
			get
			{
				return this._firer;
			}
		}

		// Token: 0x17003529 RID: 13609
		// (get) Token: 0x0600C9A7 RID: 51623 RVA: 0x002D5DA4 File Offset: 0x002D3FA4
		public ulong FirerID
		{
			get
			{
				return this._firer_id;
			}
		}

		// Token: 0x1700352A RID: 13610
		// (get) Token: 0x0600C9A8 RID: 51624 RVA: 0x002D5DBC File Offset: 0x002D3FBC
		public XEntity Target
		{
			get
			{
				return XEntity.ValideEntity(this._target) ? this._target : null;
			}
		}

		// Token: 0x1700352B RID: 13611
		// (get) Token: 0x0600C9A9 RID: 51625 RVA: 0x002D5DE4 File Offset: 0x002D3FE4
		public string Prefab
		{
			get
			{
				return this.Result.LongAttackData.Prefab;
			}
		}

		// Token: 0x1700352C RID: 13612
		// (get) Token: 0x0600C9AA RID: 51626 RVA: 0x002D5E08 File Offset: 0x002D4008
		public int Sequnce
		{
			get
			{
				return this._sequnce;
			}
		}

		// Token: 0x1700352D RID: 13613
		// (get) Token: 0x0600C9AB RID: 51627 RVA: 0x002D5E20 File Offset: 0x002D4020
		public int ResultTime
		{
			get
			{
				return this._result_time;
			}
		}

		// Token: 0x1700352E RID: 13614
		// (get) Token: 0x0600C9AC RID: 51628 RVA: 0x002D5E38 File Offset: 0x002D4038
		public uint ResultID
		{
			get
			{
				return this._result_id;
			}
		}

		// Token: 0x1700352F RID: 13615
		// (get) Token: 0x0600C9AD RID: 51629 RVA: 0x002D5E50 File Offset: 0x002D4050
		public bool TriggerMove
		{
			get
			{
				return this._trigger_move;
			}
		}

		// Token: 0x17003530 RID: 13616
		// (get) Token: 0x0600C9AE RID: 51630 RVA: 0x002D5E68 File Offset: 0x002D4068
		public float Life
		{
			get
			{
				return this.Result.LongAttackData.Runningtime + this.Result.LongAttackData.Stickytime;
			}
		}

		// Token: 0x17003531 RID: 13617
		// (get) Token: 0x0600C9AF RID: 51631 RVA: 0x002D5E9C File Offset: 0x002D409C
		public float Running
		{
			get
			{
				return this.Result.LongAttackData.Runningtime;
			}
		}

		// Token: 0x17003532 RID: 13618
		// (get) Token: 0x0600C9B0 RID: 51632 RVA: 0x002D5EC0 File Offset: 0x002D40C0
		public float Velocity
		{
			get
			{
				return this._velocity;
			}
		}

		// Token: 0x17003533 RID: 13619
		// (get) Token: 0x0600C9B1 RID: 51633 RVA: 0x002D5ED8 File Offset: 0x002D40D8
		public float Radius
		{
			get
			{
				return this.Result.LongAttackData.Radius;
			}
		}

		// Token: 0x0400591F RID: 22815
		private XSkillCore _core;

		// Token: 0x04005920 RID: 22816
		private XResultData _result;

		// Token: 0x04005921 RID: 22817
		private XEntity _firer;

		// Token: 0x04005922 RID: 22818
		private XEntity _target;

		// Token: 0x04005923 RID: 22819
		private ulong _firer_id;

		// Token: 0x04005924 RID: 22820
		private long _token;

		// Token: 0x04005925 RID: 22821
		private Vector3 _warning_pos;

		// Token: 0x04005926 RID: 22822
		private int _sequnce;

		// Token: 0x04005927 RID: 22823
		private int _result_time;

		// Token: 0x04005928 RID: 22824
		private uint _result_id;

		// Token: 0x04005929 RID: 22825
		private bool _warning;

		// Token: 0x0400592A RID: 22826
		private float _velocity;

		// Token: 0x0400592B RID: 22827
		private float _init_h;

		// Token: 0x0400592C RID: 22828
		private bool _demonstration;

		// Token: 0x0400592D RID: 22829
		private bool _with_terrain;

		// Token: 0x0400592E RID: 22830
		private bool _trigger_move;

		// Token: 0x0400592F RID: 22831
		public Ray BulletRay;
	}
}
