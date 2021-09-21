using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004DA RID: 1242
	[ProtoContract(Name = "BattleFieldReadyInfo")]
	[Serializable]
	public class BattleFieldReadyInfo : IExtensible
	{
		// Token: 0x170013A8 RID: 5032
		// (get) Token: 0x0600403B RID: 16443 RVA: 0x0007A524 File Offset: 0x00078724
		// (set) Token: 0x0600403C RID: 16444 RVA: 0x0007A550 File Offset: 0x00078750
		[ProtoMember(1, IsRequired = false, Name = "round", DataFormat = DataFormat.TwosComplement)]
		public uint round
		{
			get
			{
				return this._round ?? 0U;
			}
			set
			{
				this._round = new uint?(value);
			}
		}

		// Token: 0x170013A9 RID: 5033
		// (get) Token: 0x0600403D RID: 16445 RVA: 0x0007A560 File Offset: 0x00078760
		// (set) Token: 0x0600403E RID: 16446 RVA: 0x0007A580 File Offset: 0x00078780
		[XmlIgnore]
		[Browsable(false)]
		public bool roundSpecified
		{
			get
			{
				return this._round != null;
			}
			set
			{
				bool flag = value == (this._round == null);
				if (flag)
				{
					this._round = (value ? new uint?(this.round) : null);
				}
			}
		}

		// Token: 0x0600403F RID: 16447 RVA: 0x0007A5C4 File Offset: 0x000787C4
		private bool ShouldSerializeround()
		{
			return this.roundSpecified;
		}

		// Token: 0x06004040 RID: 16448 RVA: 0x0007A5DC File Offset: 0x000787DC
		private void Resetround()
		{
			this.roundSpecified = false;
		}

		// Token: 0x170013AA RID: 5034
		// (get) Token: 0x06004041 RID: 16449 RVA: 0x0007A5E8 File Offset: 0x000787E8
		// (set) Token: 0x06004042 RID: 16450 RVA: 0x0007A614 File Offset: 0x00078814
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170013AB RID: 5035
		// (get) Token: 0x06004043 RID: 16451 RVA: 0x0007A624 File Offset: 0x00078824
		// (set) Token: 0x06004044 RID: 16452 RVA: 0x0007A644 File Offset: 0x00078844
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

		// Token: 0x06004045 RID: 16453 RVA: 0x0007A688 File Offset: 0x00078888
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06004046 RID: 16454 RVA: 0x0007A6A0 File Offset: 0x000788A0
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170013AC RID: 5036
		// (get) Token: 0x06004047 RID: 16455 RVA: 0x0007A6AC File Offset: 0x000788AC
		// (set) Token: 0x06004048 RID: 16456 RVA: 0x0007A6D8 File Offset: 0x000788D8
		[ProtoMember(3, IsRequired = false, Name = "failed", DataFormat = DataFormat.Default)]
		public bool failed
		{
			get
			{
				return this._failed ?? false;
			}
			set
			{
				this._failed = new bool?(value);
			}
		}

		// Token: 0x170013AD RID: 5037
		// (get) Token: 0x06004049 RID: 16457 RVA: 0x0007A6E8 File Offset: 0x000788E8
		// (set) Token: 0x0600404A RID: 16458 RVA: 0x0007A708 File Offset: 0x00078908
		[XmlIgnore]
		[Browsable(false)]
		public bool failedSpecified
		{
			get
			{
				return this._failed != null;
			}
			set
			{
				bool flag = value == (this._failed == null);
				if (flag)
				{
					this._failed = (value ? new bool?(this.failed) : null);
				}
			}
		}

		// Token: 0x0600404B RID: 16459 RVA: 0x0007A74C File Offset: 0x0007894C
		private bool ShouldSerializefailed()
		{
			return this.failedSpecified;
		}

		// Token: 0x0600404C RID: 16460 RVA: 0x0007A764 File Offset: 0x00078964
		private void Resetfailed()
		{
			this.failedSpecified = false;
		}

		// Token: 0x170013AE RID: 5038
		// (get) Token: 0x0600404D RID: 16461 RVA: 0x0007A770 File Offset: 0x00078970
		// (set) Token: 0x0600404E RID: 16462 RVA: 0x0007A79C File Offset: 0x0007899C
		[ProtoMember(4, IsRequired = false, Name = "end", DataFormat = DataFormat.Default)]
		public bool end
		{
			get
			{
				return this._end ?? false;
			}
			set
			{
				this._end = new bool?(value);
			}
		}

		// Token: 0x170013AF RID: 5039
		// (get) Token: 0x0600404F RID: 16463 RVA: 0x0007A7AC File Offset: 0x000789AC
		// (set) Token: 0x06004050 RID: 16464 RVA: 0x0007A7CC File Offset: 0x000789CC
		[XmlIgnore]
		[Browsable(false)]
		public bool endSpecified
		{
			get
			{
				return this._end != null;
			}
			set
			{
				bool flag = value == (this._end == null);
				if (flag)
				{
					this._end = (value ? new bool?(this.end) : null);
				}
			}
		}

		// Token: 0x06004051 RID: 16465 RVA: 0x0007A810 File Offset: 0x00078A10
		private bool ShouldSerializeend()
		{
			return this.endSpecified;
		}

		// Token: 0x06004052 RID: 16466 RVA: 0x0007A828 File Offset: 0x00078A28
		private void Resetend()
		{
			this.endSpecified = false;
		}

		// Token: 0x06004053 RID: 16467 RVA: 0x0007A834 File Offset: 0x00078A34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001001 RID: 4097
		private uint? _round;

		// Token: 0x04001002 RID: 4098
		private uint? _time;

		// Token: 0x04001003 RID: 4099
		private bool? _failed;

		// Token: 0x04001004 RID: 4100
		private bool? _end;

		// Token: 0x04001005 RID: 4101
		private IExtension extensionObject;
	}
}
