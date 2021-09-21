using System;

namespace XMainClient
{
	// Token: 0x02000FF0 RID: 4080
	internal class HurtInfo : XDataBase
	{
		// Token: 0x0600D438 RID: 54328 RVA: 0x0031FC56 File Offset: 0x0031DE56
		public HurtInfo()
		{
			this.Reset();
		}

		// Token: 0x0600D439 RID: 54329 RVA: 0x0031FC67 File Offset: 0x0031DE67
		public void Reset()
		{
			this._caster = null;
			this._target = null;
			this._skill_id = 0U;
			this._hitPoint = 0;
			this._skill_token = 0L;
			this.Callback = null;
		}

		// Token: 0x17003709 RID: 14089
		// (get) Token: 0x0600D43A RID: 54330 RVA: 0x0031FC98 File Offset: 0x0031DE98
		// (set) Token: 0x0600D43B RID: 54331 RVA: 0x0031FCB0 File Offset: 0x0031DEB0
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

		// Token: 0x1700370A RID: 14090
		// (get) Token: 0x0600D43C RID: 54332 RVA: 0x0031FCBC File Offset: 0x0031DEBC
		// (set) Token: 0x0600D43D RID: 54333 RVA: 0x0031FCD4 File Offset: 0x0031DED4
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

		// Token: 0x1700370B RID: 14091
		// (get) Token: 0x0600D43E RID: 54334 RVA: 0x0031FCE0 File Offset: 0x0031DEE0
		// (set) Token: 0x0600D43F RID: 54335 RVA: 0x0031FCF8 File Offset: 0x0031DEF8
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

		// Token: 0x1700370C RID: 14092
		// (get) Token: 0x0600D440 RID: 54336 RVA: 0x0031FD04 File Offset: 0x0031DF04
		// (set) Token: 0x0600D441 RID: 54337 RVA: 0x0031FD1C File Offset: 0x0031DF1C
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

		// Token: 0x1700370D RID: 14093
		// (get) Token: 0x0600D442 RID: 54338 RVA: 0x0031FD28 File Offset: 0x0031DF28
		// (set) Token: 0x0600D443 RID: 54339 RVA: 0x0031FD40 File Offset: 0x0031DF40
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

		// Token: 0x0600D444 RID: 54340 RVA: 0x0031FD4A File Offset: 0x0031DF4A
		public override void Init()
		{
			base.Init();
			this.Reset();
		}

		// Token: 0x0600D445 RID: 54341 RVA: 0x0031FD5B File Offset: 0x0031DF5B
		public override void Recycle()
		{
			XDataPool<HurtInfo>.Recycle(this);
		}

		// Token: 0x040060CD RID: 24781
		private XEntity _caster;

		// Token: 0x040060CE RID: 24782
		private XEntity _target;

		// Token: 0x040060CF RID: 24783
		private int _hitPoint;

		// Token: 0x040060D0 RID: 24784
		private uint _skill_id;

		// Token: 0x040060D1 RID: 24785
		private long _skill_token;

		// Token: 0x040060D2 RID: 24786
		public SkillExternalCallback Callback;
	}
}
