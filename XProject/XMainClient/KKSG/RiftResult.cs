using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005DF RID: 1503
	[ProtoContract(Name = "RiftResult")]
	[Serializable]
	public class RiftResult : IExtensible
	{
		// Token: 0x17001AFF RID: 6911
		// (get) Token: 0x060056ED RID: 22253 RVA: 0x000A58A8 File Offset: 0x000A3AA8
		// (set) Token: 0x060056EE RID: 22254 RVA: 0x000A58D4 File Offset: 0x000A3AD4
		[ProtoMember(1, IsRequired = false, Name = "isNewRecord", DataFormat = DataFormat.Default)]
		public bool isNewRecord
		{
			get
			{
				return this._isNewRecord ?? false;
			}
			set
			{
				this._isNewRecord = new bool?(value);
			}
		}

		// Token: 0x17001B00 RID: 6912
		// (get) Token: 0x060056EF RID: 22255 RVA: 0x000A58E4 File Offset: 0x000A3AE4
		// (set) Token: 0x060056F0 RID: 22256 RVA: 0x000A5904 File Offset: 0x000A3B04
		[XmlIgnore]
		[Browsable(false)]
		public bool isNewRecordSpecified
		{
			get
			{
				return this._isNewRecord != null;
			}
			set
			{
				bool flag = value == (this._isNewRecord == null);
				if (flag)
				{
					this._isNewRecord = (value ? new bool?(this.isNewRecord) : null);
				}
			}
		}

		// Token: 0x060056F1 RID: 22257 RVA: 0x000A5948 File Offset: 0x000A3B48
		private bool ShouldSerializeisNewRecord()
		{
			return this.isNewRecordSpecified;
		}

		// Token: 0x060056F2 RID: 22258 RVA: 0x000A5960 File Offset: 0x000A3B60
		private void ResetisNewRecord()
		{
			this.isNewRecordSpecified = false;
		}

		// Token: 0x17001B01 RID: 6913
		// (get) Token: 0x060056F3 RID: 22259 RVA: 0x000A596C File Offset: 0x000A3B6C
		// (set) Token: 0x060056F4 RID: 22260 RVA: 0x000A5998 File Offset: 0x000A3B98
		[ProtoMember(2, IsRequired = false, Name = "riftFloor", DataFormat = DataFormat.TwosComplement)]
		public uint riftFloor
		{
			get
			{
				return this._riftFloor ?? 0U;
			}
			set
			{
				this._riftFloor = new uint?(value);
			}
		}

		// Token: 0x17001B02 RID: 6914
		// (get) Token: 0x060056F5 RID: 22261 RVA: 0x000A59A8 File Offset: 0x000A3BA8
		// (set) Token: 0x060056F6 RID: 22262 RVA: 0x000A59C8 File Offset: 0x000A3BC8
		[XmlIgnore]
		[Browsable(false)]
		public bool riftFloorSpecified
		{
			get
			{
				return this._riftFloor != null;
			}
			set
			{
				bool flag = value == (this._riftFloor == null);
				if (flag)
				{
					this._riftFloor = (value ? new uint?(this.riftFloor) : null);
				}
			}
		}

		// Token: 0x060056F7 RID: 22263 RVA: 0x000A5A0C File Offset: 0x000A3C0C
		private bool ShouldSerializeriftFloor()
		{
			return this.riftFloorSpecified;
		}

		// Token: 0x060056F8 RID: 22264 RVA: 0x000A5A24 File Offset: 0x000A3C24
		private void ResetriftFloor()
		{
			this.riftFloorSpecified = false;
		}

		// Token: 0x17001B03 RID: 6915
		// (get) Token: 0x060056F9 RID: 22265 RVA: 0x000A5A30 File Offset: 0x000A3C30
		// (set) Token: 0x060056FA RID: 22266 RVA: 0x000A5A5C File Offset: 0x000A3C5C
		[ProtoMember(3, IsRequired = false, Name = "riftItemFlag", DataFormat = DataFormat.TwosComplement)]
		public uint riftItemFlag
		{
			get
			{
				return this._riftItemFlag ?? 0U;
			}
			set
			{
				this._riftItemFlag = new uint?(value);
			}
		}

		// Token: 0x17001B04 RID: 6916
		// (get) Token: 0x060056FB RID: 22267 RVA: 0x000A5A6C File Offset: 0x000A3C6C
		// (set) Token: 0x060056FC RID: 22268 RVA: 0x000A5A8C File Offset: 0x000A3C8C
		[XmlIgnore]
		[Browsable(false)]
		public bool riftItemFlagSpecified
		{
			get
			{
				return this._riftItemFlag != null;
			}
			set
			{
				bool flag = value == (this._riftItemFlag == null);
				if (flag)
				{
					this._riftItemFlag = (value ? new uint?(this.riftItemFlag) : null);
				}
			}
		}

		// Token: 0x060056FD RID: 22269 RVA: 0x000A5AD0 File Offset: 0x000A3CD0
		private bool ShouldSerializeriftItemFlag()
		{
			return this.riftItemFlagSpecified;
		}

		// Token: 0x060056FE RID: 22270 RVA: 0x000A5AE8 File Offset: 0x000A3CE8
		private void ResetriftItemFlag()
		{
			this.riftItemFlagSpecified = false;
		}

		// Token: 0x060056FF RID: 22271 RVA: 0x000A5AF4 File Offset: 0x000A3CF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400151F RID: 5407
		private bool? _isNewRecord;

		// Token: 0x04001520 RID: 5408
		private uint? _riftFloor;

		// Token: 0x04001521 RID: 5409
		private uint? _riftItemFlag;

		// Token: 0x04001522 RID: 5410
		private IExtension extensionObject;
	}
}
