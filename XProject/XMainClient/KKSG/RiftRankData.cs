using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000590 RID: 1424
	[ProtoContract(Name = "RiftRankData")]
	[Serializable]
	public class RiftRankData : IExtensible
	{
		// Token: 0x1700173D RID: 5949
		// (get) Token: 0x06004B8B RID: 19339 RVA: 0x0008FA6C File Offset: 0x0008DC6C
		// (set) Token: 0x06004B8C RID: 19340 RVA: 0x0008FA98 File Offset: 0x0008DC98
		[ProtoMember(1, IsRequired = false, Name = "riftFloor", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700173E RID: 5950
		// (get) Token: 0x06004B8D RID: 19341 RVA: 0x0008FAA8 File Offset: 0x0008DCA8
		// (set) Token: 0x06004B8E RID: 19342 RVA: 0x0008FAC8 File Offset: 0x0008DCC8
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

		// Token: 0x06004B8F RID: 19343 RVA: 0x0008FB0C File Offset: 0x0008DD0C
		private bool ShouldSerializeriftFloor()
		{
			return this.riftFloorSpecified;
		}

		// Token: 0x06004B90 RID: 19344 RVA: 0x0008FB24 File Offset: 0x0008DD24
		private void ResetriftFloor()
		{
			this.riftFloorSpecified = false;
		}

		// Token: 0x1700173F RID: 5951
		// (get) Token: 0x06004B91 RID: 19345 RVA: 0x0008FB30 File Offset: 0x0008DD30
		// (set) Token: 0x06004B92 RID: 19346 RVA: 0x0008FB5C File Offset: 0x0008DD5C
		[ProtoMember(2, IsRequired = false, Name = "passTime", DataFormat = DataFormat.TwosComplement)]
		public uint passTime
		{
			get
			{
				return this._passTime ?? 0U;
			}
			set
			{
				this._passTime = new uint?(value);
			}
		}

		// Token: 0x17001740 RID: 5952
		// (get) Token: 0x06004B93 RID: 19347 RVA: 0x0008FB6C File Offset: 0x0008DD6C
		// (set) Token: 0x06004B94 RID: 19348 RVA: 0x0008FB8C File Offset: 0x0008DD8C
		[XmlIgnore]
		[Browsable(false)]
		public bool passTimeSpecified
		{
			get
			{
				return this._passTime != null;
			}
			set
			{
				bool flag = value == (this._passTime == null);
				if (flag)
				{
					this._passTime = (value ? new uint?(this.passTime) : null);
				}
			}
		}

		// Token: 0x06004B95 RID: 19349 RVA: 0x0008FBD0 File Offset: 0x0008DDD0
		private bool ShouldSerializepassTime()
		{
			return this.passTimeSpecified;
		}

		// Token: 0x06004B96 RID: 19350 RVA: 0x0008FBE8 File Offset: 0x0008DDE8
		private void ResetpassTime()
		{
			this.passTimeSpecified = false;
		}

		// Token: 0x17001741 RID: 5953
		// (get) Token: 0x06004B97 RID: 19351 RVA: 0x0008FBF4 File Offset: 0x0008DDF4
		// (set) Token: 0x06004B98 RID: 19352 RVA: 0x0008FC20 File Offset: 0x0008DE20
		[ProtoMember(3, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		// Token: 0x17001742 RID: 5954
		// (get) Token: 0x06004B99 RID: 19353 RVA: 0x0008FC30 File Offset: 0x0008DE30
		// (set) Token: 0x06004B9A RID: 19354 RVA: 0x0008FC50 File Offset: 0x0008DE50
		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		// Token: 0x06004B9B RID: 19355 RVA: 0x0008FC94 File Offset: 0x0008DE94
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x06004B9C RID: 19356 RVA: 0x0008FCAC File Offset: 0x0008DEAC
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x17001743 RID: 5955
		// (get) Token: 0x06004B9D RID: 19357 RVA: 0x0008FCB8 File Offset: 0x0008DEB8
		// (set) Token: 0x06004B9E RID: 19358 RVA: 0x0008FCE4 File Offset: 0x0008DEE4
		[ProtoMember(4, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public uint updateTime
		{
			get
			{
				return this._updateTime ?? 0U;
			}
			set
			{
				this._updateTime = new uint?(value);
			}
		}

		// Token: 0x17001744 RID: 5956
		// (get) Token: 0x06004B9F RID: 19359 RVA: 0x0008FCF4 File Offset: 0x0008DEF4
		// (set) Token: 0x06004BA0 RID: 19360 RVA: 0x0008FD14 File Offset: 0x0008DF14
		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new uint?(this.updateTime) : null);
				}
			}
		}

		// Token: 0x06004BA1 RID: 19361 RVA: 0x0008FD58 File Offset: 0x0008DF58
		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		// Token: 0x06004BA2 RID: 19362 RVA: 0x0008FD70 File Offset: 0x0008DF70
		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		// Token: 0x06004BA3 RID: 19363 RVA: 0x0008FD7C File Offset: 0x0008DF7C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012C3 RID: 4803
		private uint? _riftFloor;

		// Token: 0x040012C4 RID: 4804
		private uint? _passTime;

		// Token: 0x040012C5 RID: 4805
		private uint? _ppt;

		// Token: 0x040012C6 RID: 4806
		private uint? _updateTime;

		// Token: 0x040012C7 RID: 4807
		private IExtension extensionObject;
	}
}
