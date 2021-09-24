using System;

namespace XMainClient
{

	internal class HurtInfo : XDataBase
	{

		public HurtInfo()
		{
			this.Reset();
		}

		public void Reset()
		{
			this._caster = null;
			this._target = null;
			this._skill_id = 0U;
			this._hitPoint = 0;
			this._skill_token = 0L;
			this.Callback = null;
		}

		public long SkillToken
		{
			get
			{
				return this._skill_token;
			}
			set
			{
				this._skill_token = value;
			}
		}

		public XEntity Caster
		{
			get
			{
				return this._caster;
			}
			set
			{
				this._caster = value;
			}
		}

		public XEntity Target
		{
			get
			{
				return this._target;
			}
			set
			{
				this._target = value;
			}
		}

		public uint SkillID
		{
			get
			{
				return this._skill_id;
			}
			set
			{
				this._skill_id = value;
			}
		}

		public int HitPoint
		{
			get
			{
				return this._hitPoint;
			}
			set
			{
				this._hitPoint = value;
			}
		}

		public override void Init()
		{
			base.Init();
			this.Reset();
		}

		public override void Recycle()
		{
			XDataPool<HurtInfo>.Recycle(this);
		}

		private XEntity _caster;

		private XEntity _target;

		private int _hitPoint;

		private uint _skill_id;

		private long _skill_token;

		public SkillExternalCallback Callback;
	}
}
