using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005C0 RID: 1472
	[ProtoContract(Name = "CliAntiCheatInfo")]
	[Serializable]
	public class CliAntiCheatInfo : IExtensible
	{
		// Token: 0x17001988 RID: 6536
		// (get) Token: 0x06005285 RID: 21125 RVA: 0x0009CF7C File Offset: 0x0009B17C
		// (set) Token: 0x06005286 RID: 21126 RVA: 0x0009CFA8 File Offset: 0x0009B1A8
		[ProtoMember(1, IsRequired = false, Name = "currentHp", DataFormat = DataFormat.TwosComplement)]
		public uint currentHp
		{
			get
			{
				return this._currentHp ?? 0U;
			}
			set
			{
				this._currentHp = new uint?(value);
			}
		}

		// Token: 0x17001989 RID: 6537
		// (get) Token: 0x06005287 RID: 21127 RVA: 0x0009CFB8 File Offset: 0x0009B1B8
		// (set) Token: 0x06005288 RID: 21128 RVA: 0x0009CFD8 File Offset: 0x0009B1D8
		[XmlIgnore]
		[Browsable(false)]
		public bool currentHpSpecified
		{
			get
			{
				return this._currentHp != null;
			}
			set
			{
				bool flag = value == (this._currentHp == null);
				if (flag)
				{
					this._currentHp = (value ? new uint?(this.currentHp) : null);
				}
			}
		}

		// Token: 0x06005289 RID: 21129 RVA: 0x0009D01C File Offset: 0x0009B21C
		private bool ShouldSerializecurrentHp()
		{
			return this.currentHpSpecified;
		}

		// Token: 0x0600528A RID: 21130 RVA: 0x0009D034 File Offset: 0x0009B234
		private void ResetcurrentHp()
		{
			this.currentHpSpecified = false;
		}

		// Token: 0x1700198A RID: 6538
		// (get) Token: 0x0600528B RID: 21131 RVA: 0x0009D040 File Offset: 0x0009B240
		// (set) Token: 0x0600528C RID: 21132 RVA: 0x0009D06C File Offset: 0x0009B26C
		[ProtoMember(2, IsRequired = false, Name = "totalDamage", DataFormat = DataFormat.TwosComplement)]
		public uint totalDamage
		{
			get
			{
				return this._totalDamage ?? 0U;
			}
			set
			{
				this._totalDamage = new uint?(value);
			}
		}

		// Token: 0x1700198B RID: 6539
		// (get) Token: 0x0600528D RID: 21133 RVA: 0x0009D07C File Offset: 0x0009B27C
		// (set) Token: 0x0600528E RID: 21134 RVA: 0x0009D09C File Offset: 0x0009B29C
		[XmlIgnore]
		[Browsable(false)]
		public bool totalDamageSpecified
		{
			get
			{
				return this._totalDamage != null;
			}
			set
			{
				bool flag = value == (this._totalDamage == null);
				if (flag)
				{
					this._totalDamage = (value ? new uint?(this.totalDamage) : null);
				}
			}
		}

		// Token: 0x0600528F RID: 21135 RVA: 0x0009D0E0 File Offset: 0x0009B2E0
		private bool ShouldSerializetotalDamage()
		{
			return this.totalDamageSpecified;
		}

		// Token: 0x06005290 RID: 21136 RVA: 0x0009D0F8 File Offset: 0x0009B2F8
		private void ResettotalDamage()
		{
			this.totalDamageSpecified = false;
		}

		// Token: 0x1700198C RID: 6540
		// (get) Token: 0x06005291 RID: 21137 RVA: 0x0009D104 File Offset: 0x0009B304
		// (set) Token: 0x06005292 RID: 21138 RVA: 0x0009D130 File Offset: 0x0009B330
		[ProtoMember(3, IsRequired = false, Name = "totalHurt", DataFormat = DataFormat.TwosComplement)]
		public uint totalHurt
		{
			get
			{
				return this._totalHurt ?? 0U;
			}
			set
			{
				this._totalHurt = new uint?(value);
			}
		}

		// Token: 0x1700198D RID: 6541
		// (get) Token: 0x06005293 RID: 21139 RVA: 0x0009D140 File Offset: 0x0009B340
		// (set) Token: 0x06005294 RID: 21140 RVA: 0x0009D160 File Offset: 0x0009B360
		[XmlIgnore]
		[Browsable(false)]
		public bool totalHurtSpecified
		{
			get
			{
				return this._totalHurt != null;
			}
			set
			{
				bool flag = value == (this._totalHurt == null);
				if (flag)
				{
					this._totalHurt = (value ? new uint?(this.totalHurt) : null);
				}
			}
		}

		// Token: 0x06005295 RID: 21141 RVA: 0x0009D1A4 File Offset: 0x0009B3A4
		private bool ShouldSerializetotalHurt()
		{
			return this.totalHurtSpecified;
		}

		// Token: 0x06005296 RID: 21142 RVA: 0x0009D1BC File Offset: 0x0009B3BC
		private void ResettotalHurt()
		{
			this.totalHurtSpecified = false;
		}

		// Token: 0x1700198E RID: 6542
		// (get) Token: 0x06005297 RID: 21143 RVA: 0x0009D1C8 File Offset: 0x0009B3C8
		// (set) Token: 0x06005298 RID: 21144 RVA: 0x0009D1F4 File Offset: 0x0009B3F4
		[ProtoMember(4, IsRequired = false, Name = "totalRecovery", DataFormat = DataFormat.TwosComplement)]
		public uint totalRecovery
		{
			get
			{
				return this._totalRecovery ?? 0U;
			}
			set
			{
				this._totalRecovery = new uint?(value);
			}
		}

		// Token: 0x1700198F RID: 6543
		// (get) Token: 0x06005299 RID: 21145 RVA: 0x0009D204 File Offset: 0x0009B404
		// (set) Token: 0x0600529A RID: 21146 RVA: 0x0009D224 File Offset: 0x0009B424
		[XmlIgnore]
		[Browsable(false)]
		public bool totalRecoverySpecified
		{
			get
			{
				return this._totalRecovery != null;
			}
			set
			{
				bool flag = value == (this._totalRecovery == null);
				if (flag)
				{
					this._totalRecovery = (value ? new uint?(this.totalRecovery) : null);
				}
			}
		}

		// Token: 0x0600529B RID: 21147 RVA: 0x0009D268 File Offset: 0x0009B468
		private bool ShouldSerializetotalRecovery()
		{
			return this.totalRecoverySpecified;
		}

		// Token: 0x0600529C RID: 21148 RVA: 0x0009D280 File Offset: 0x0009B480
		private void ResettotalRecovery()
		{
			this.totalRecoverySpecified = false;
		}

		// Token: 0x17001990 RID: 6544
		// (get) Token: 0x0600529D RID: 21149 RVA: 0x0009D28C File Offset: 0x0009B48C
		[ProtoMember(5, Name = "monsterRfsTimes", DataFormat = DataFormat.TwosComplement)]
		public List<uint> monsterRfsTimes
		{
			get
			{
				return this._monsterRfsTimes;
			}
		}

		// Token: 0x17001991 RID: 6545
		// (get) Token: 0x0600529E RID: 21150 RVA: 0x0009D2A4 File Offset: 0x0009B4A4
		// (set) Token: 0x0600529F RID: 21151 RVA: 0x0009D2C5 File Offset: 0x0009B4C5
		[ProtoMember(6, IsRequired = false, Name = "battleStamp", DataFormat = DataFormat.Default)]
		public string battleStamp
		{
			get
			{
				return this._battleStamp ?? "";
			}
			set
			{
				this._battleStamp = value;
			}
		}

		// Token: 0x17001992 RID: 6546
		// (get) Token: 0x060052A0 RID: 21152 RVA: 0x0009D2D0 File Offset: 0x0009B4D0
		// (set) Token: 0x060052A1 RID: 21153 RVA: 0x0009D2EC File Offset: 0x0009B4EC
		[XmlIgnore]
		[Browsable(false)]
		public bool battleStampSpecified
		{
			get
			{
				return this._battleStamp != null;
			}
			set
			{
				bool flag = value == (this._battleStamp == null);
				if (flag)
				{
					this._battleStamp = (value ? this.battleStamp : null);
				}
			}
		}

		// Token: 0x060052A2 RID: 21154 RVA: 0x0009D31C File Offset: 0x0009B51C
		private bool ShouldSerializebattleStamp()
		{
			return this.battleStampSpecified;
		}

		// Token: 0x060052A3 RID: 21155 RVA: 0x0009D334 File Offset: 0x0009B534
		private void ResetbattleStamp()
		{
			this.battleStampSpecified = false;
		}

		// Token: 0x060052A4 RID: 21156 RVA: 0x0009D340 File Offset: 0x0009B540
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001430 RID: 5168
		private uint? _currentHp;

		// Token: 0x04001431 RID: 5169
		private uint? _totalDamage;

		// Token: 0x04001432 RID: 5170
		private uint? _totalHurt;

		// Token: 0x04001433 RID: 5171
		private uint? _totalRecovery;

		// Token: 0x04001434 RID: 5172
		private readonly List<uint> _monsterRfsTimes = new List<uint>();

		// Token: 0x04001435 RID: 5173
		private string _battleStamp;

		// Token: 0x04001436 RID: 5174
		private IExtension extensionObject;
	}
}
