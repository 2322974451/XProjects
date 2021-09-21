using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000710 RID: 1808
	[ProtoContract(Name = "SkyCraftBattleRecord")]
	[Serializable]
	public class SkyCraftBattleRecord : IExtensible
	{
		// Token: 0x170026E6 RID: 9958
		// (get) Token: 0x06007ABD RID: 31421 RVA: 0x000EA9DC File Offset: 0x000E8BDC
		// (set) Token: 0x06007ABE RID: 31422 RVA: 0x000EAA09 File Offset: 0x000E8C09
		[ProtoMember(1, IsRequired = false, Name = "other_teamid", DataFormat = DataFormat.TwosComplement)]
		public ulong other_teamid
		{
			get
			{
				return this._other_teamid ?? 0UL;
			}
			set
			{
				this._other_teamid = new ulong?(value);
			}
		}

		// Token: 0x170026E7 RID: 9959
		// (get) Token: 0x06007ABF RID: 31423 RVA: 0x000EAA18 File Offset: 0x000E8C18
		// (set) Token: 0x06007AC0 RID: 31424 RVA: 0x000EAA38 File Offset: 0x000E8C38
		[XmlIgnore]
		[Browsable(false)]
		public bool other_teamidSpecified
		{
			get
			{
				return this._other_teamid != null;
			}
			set
			{
				bool flag = value == (this._other_teamid == null);
				if (flag)
				{
					this._other_teamid = (value ? new ulong?(this.other_teamid) : null);
				}
			}
		}

		// Token: 0x06007AC1 RID: 31425 RVA: 0x000EAA7C File Offset: 0x000E8C7C
		private bool ShouldSerializeother_teamid()
		{
			return this.other_teamidSpecified;
		}

		// Token: 0x06007AC2 RID: 31426 RVA: 0x000EAA94 File Offset: 0x000E8C94
		private void Resetother_teamid()
		{
			this.other_teamidSpecified = false;
		}

		// Token: 0x170026E8 RID: 9960
		// (get) Token: 0x06007AC3 RID: 31427 RVA: 0x000EAAA0 File Offset: 0x000E8CA0
		// (set) Token: 0x06007AC4 RID: 31428 RVA: 0x000EAAC1 File Offset: 0x000E8CC1
		[ProtoMember(2, IsRequired = false, Name = "other_name", DataFormat = DataFormat.Default)]
		public string other_name
		{
			get
			{
				return this._other_name ?? "";
			}
			set
			{
				this._other_name = value;
			}
		}

		// Token: 0x170026E9 RID: 9961
		// (get) Token: 0x06007AC5 RID: 31429 RVA: 0x000EAACC File Offset: 0x000E8CCC
		// (set) Token: 0x06007AC6 RID: 31430 RVA: 0x000EAAE8 File Offset: 0x000E8CE8
		[XmlIgnore]
		[Browsable(false)]
		public bool other_nameSpecified
		{
			get
			{
				return this._other_name != null;
			}
			set
			{
				bool flag = value == (this._other_name == null);
				if (flag)
				{
					this._other_name = (value ? this.other_name : null);
				}
			}
		}

		// Token: 0x06007AC7 RID: 31431 RVA: 0x000EAB18 File Offset: 0x000E8D18
		private bool ShouldSerializeother_name()
		{
			return this.other_nameSpecified;
		}

		// Token: 0x06007AC8 RID: 31432 RVA: 0x000EAB30 File Offset: 0x000E8D30
		private void Resetother_name()
		{
			this.other_nameSpecified = false;
		}

		// Token: 0x170026EA RID: 9962
		// (get) Token: 0x06007AC9 RID: 31433 RVA: 0x000EAB3C File Offset: 0x000E8D3C
		// (set) Token: 0x06007ACA RID: 31434 RVA: 0x000EAB68 File Offset: 0x000E8D68
		[ProtoMember(3, IsRequired = false, Name = "score_change", DataFormat = DataFormat.TwosComplement)]
		public int score_change
		{
			get
			{
				return this._score_change ?? 0;
			}
			set
			{
				this._score_change = new int?(value);
			}
		}

		// Token: 0x170026EB RID: 9963
		// (get) Token: 0x06007ACB RID: 31435 RVA: 0x000EAB78 File Offset: 0x000E8D78
		// (set) Token: 0x06007ACC RID: 31436 RVA: 0x000EAB98 File Offset: 0x000E8D98
		[XmlIgnore]
		[Browsable(false)]
		public bool score_changeSpecified
		{
			get
			{
				return this._score_change != null;
			}
			set
			{
				bool flag = value == (this._score_change == null);
				if (flag)
				{
					this._score_change = (value ? new int?(this.score_change) : null);
				}
			}
		}

		// Token: 0x06007ACD RID: 31437 RVA: 0x000EABDC File Offset: 0x000E8DDC
		private bool ShouldSerializescore_change()
		{
			return this.score_changeSpecified;
		}

		// Token: 0x06007ACE RID: 31438 RVA: 0x000EABF4 File Offset: 0x000E8DF4
		private void Resetscore_change()
		{
			this.score_changeSpecified = false;
		}

		// Token: 0x170026EC RID: 9964
		// (get) Token: 0x06007ACF RID: 31439 RVA: 0x000EAC00 File Offset: 0x000E8E00
		// (set) Token: 0x06007AD0 RID: 31440 RVA: 0x000EAC2C File Offset: 0x000E8E2C
		[ProtoMember(4, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public PkResultType result
		{
			get
			{
				return this._result ?? PkResultType.PkResult_Win;
			}
			set
			{
				this._result = new PkResultType?(value);
			}
		}

		// Token: 0x170026ED RID: 9965
		// (get) Token: 0x06007AD1 RID: 31441 RVA: 0x000EAC3C File Offset: 0x000E8E3C
		// (set) Token: 0x06007AD2 RID: 31442 RVA: 0x000EAC5C File Offset: 0x000E8E5C
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new PkResultType?(this.result) : null);
				}
			}
		}

		// Token: 0x06007AD3 RID: 31443 RVA: 0x000EACA0 File Offset: 0x000E8EA0
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06007AD4 RID: 31444 RVA: 0x000EACB8 File Offset: 0x000E8EB8
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170026EE RID: 9966
		// (get) Token: 0x06007AD5 RID: 31445 RVA: 0x000EACC4 File Offset: 0x000E8EC4
		// (set) Token: 0x06007AD6 RID: 31446 RVA: 0x000EACF0 File Offset: 0x000E8EF0
		[ProtoMember(5, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x170026EF RID: 9967
		// (get) Token: 0x06007AD7 RID: 31447 RVA: 0x000EAD00 File Offset: 0x000E8F00
		// (set) Token: 0x06007AD8 RID: 31448 RVA: 0x000EAD20 File Offset: 0x000E8F20
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06007AD9 RID: 31449 RVA: 0x000EAD64 File Offset: 0x000E8F64
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007ADA RID: 31450 RVA: 0x000EAD7C File Offset: 0x000E8F7C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170026F0 RID: 9968
		// (get) Token: 0x06007ADB RID: 31451 RVA: 0x000EAD88 File Offset: 0x000E8F88
		// (set) Token: 0x06007ADC RID: 31452 RVA: 0x000EADB4 File Offset: 0x000E8FB4
		[ProtoMember(6, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public SkyCraftType type
		{
			get
			{
				return this._type ?? SkyCraftType.SCT_RacePoint;
			}
			set
			{
				this._type = new SkyCraftType?(value);
			}
		}

		// Token: 0x170026F1 RID: 9969
		// (get) Token: 0x06007ADD RID: 31453 RVA: 0x000EADC4 File Offset: 0x000E8FC4
		// (set) Token: 0x06007ADE RID: 31454 RVA: 0x000EADE4 File Offset: 0x000E8FE4
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new SkyCraftType?(this.type) : null);
				}
			}
		}

		// Token: 0x06007ADF RID: 31455 RVA: 0x000EAE28 File Offset: 0x000E9028
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06007AE0 RID: 31456 RVA: 0x000EAE40 File Offset: 0x000E9040
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06007AE1 RID: 31457 RVA: 0x000EAE4C File Offset: 0x000E904C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CFC RID: 7420
		private ulong? _other_teamid;

		// Token: 0x04001CFD RID: 7421
		private string _other_name;

		// Token: 0x04001CFE RID: 7422
		private int? _score_change;

		// Token: 0x04001CFF RID: 7423
		private PkResultType? _result;

		// Token: 0x04001D00 RID: 7424
		private uint? _time;

		// Token: 0x04001D01 RID: 7425
		private SkyCraftType? _type;

		// Token: 0x04001D02 RID: 7426
		private IExtension extensionObject;
	}
}
