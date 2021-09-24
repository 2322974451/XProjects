using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal struct XBulletCore
	{

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

		public float InitHeight
		{
			get
			{
				return this._init_h;
			}
		}

		public long Token
		{
			get
			{
				return this._token;
			}
		}

		public bool FlyWithTerrain
		{
			get
			{
				return this._with_terrain;
			}
		}

		public bool Demonstration
		{
			get
			{
				return this._demonstration;
			}
		}

		public bool Warning
		{
			get
			{
				return this._warning;
			}
		}

		public bool HasTarget
		{
			get
			{
				return this.Target != null;
			}
		}

		public Vector3 WarningPos
		{
			get
			{
				return this._warning_pos;
			}
		}

		public XResultData Result
		{
			get
			{
				return this._result;
			}
		}

		public XSkillCore SkillCore
		{
			get
			{
				return this._core;
			}
		}

		public XEntity Firer
		{
			get
			{
				return this._firer;
			}
		}

		public ulong FirerID
		{
			get
			{
				return this._firer_id;
			}
		}

		public XEntity Target
		{
			get
			{
				return XEntity.ValideEntity(this._target) ? this._target : null;
			}
		}

		public string Prefab
		{
			get
			{
				return this.Result.LongAttackData.Prefab;
			}
		}

		public int Sequnce
		{
			get
			{
				return this._sequnce;
			}
		}

		public int ResultTime
		{
			get
			{
				return this._result_time;
			}
		}

		public uint ResultID
		{
			get
			{
				return this._result_id;
			}
		}

		public bool TriggerMove
		{
			get
			{
				return this._trigger_move;
			}
		}

		public float Life
		{
			get
			{
				return this.Result.LongAttackData.Runningtime + this.Result.LongAttackData.Stickytime;
			}
		}

		public float Running
		{
			get
			{
				return this.Result.LongAttackData.Runningtime;
			}
		}

		public float Velocity
		{
			get
			{
				return this._velocity;
			}
		}

		public float Radius
		{
			get
			{
				return this.Result.LongAttackData.Radius;
			}
		}

		private XSkillCore _core;

		private XResultData _result;

		private XEntity _firer;

		private XEntity _target;

		private ulong _firer_id;

		private long _token;

		private Vector3 _warning_pos;

		private int _sequnce;

		private int _result_time;

		private uint _result_id;

		private bool _warning;

		private float _velocity;

		private float _init_h;

		private bool _demonstration;

		private bool _with_terrain;

		private bool _trigger_move;

		public Ray BulletRay;
	}
}
