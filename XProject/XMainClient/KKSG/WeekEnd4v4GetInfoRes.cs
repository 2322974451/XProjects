using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200041D RID: 1053
	[ProtoContract(Name = "WeekEnd4v4GetInfoRes")]
	[Serializable]
	public class WeekEnd4v4GetInfoRes : IExtensible
	{
		// Token: 0x17001129 RID: 4393
		// (get) Token: 0x060037DE RID: 14302 RVA: 0x0006AF4C File Offset: 0x0006914C
		// (set) Token: 0x060037DF RID: 14303 RVA: 0x0006AF78 File Offset: 0x00069178
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700112A RID: 4394
		// (get) Token: 0x060037E0 RID: 14304 RVA: 0x0006AF88 File Offset: 0x00069188
		// (set) Token: 0x060037E1 RID: 14305 RVA: 0x0006AFA8 File Offset: 0x000691A8
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x060037E2 RID: 14306 RVA: 0x0006AFEC File Offset: 0x000691EC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060037E3 RID: 14307 RVA: 0x0006B004 File Offset: 0x00069204
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x1700112B RID: 4395
		// (get) Token: 0x060037E4 RID: 14308 RVA: 0x0006B010 File Offset: 0x00069210
		// (set) Token: 0x060037E5 RID: 14309 RVA: 0x0006B03C File Offset: 0x0006923C
		[ProtoMember(2, IsRequired = false, Name = "thisActivityID", DataFormat = DataFormat.TwosComplement)]
		public uint thisActivityID
		{
			get
			{
				return this._thisActivityID ?? 0U;
			}
			set
			{
				this._thisActivityID = new uint?(value);
			}
		}

		// Token: 0x1700112C RID: 4396
		// (get) Token: 0x060037E6 RID: 14310 RVA: 0x0006B04C File Offset: 0x0006924C
		// (set) Token: 0x060037E7 RID: 14311 RVA: 0x0006B06C File Offset: 0x0006926C
		[XmlIgnore]
		[Browsable(false)]
		public bool thisActivityIDSpecified
		{
			get
			{
				return this._thisActivityID != null;
			}
			set
			{
				bool flag = value == (this._thisActivityID == null);
				if (flag)
				{
					this._thisActivityID = (value ? new uint?(this.thisActivityID) : null);
				}
			}
		}

		// Token: 0x060037E8 RID: 14312 RVA: 0x0006B0B0 File Offset: 0x000692B0
		private bool ShouldSerializethisActivityID()
		{
			return this.thisActivityIDSpecified;
		}

		// Token: 0x060037E9 RID: 14313 RVA: 0x0006B0C8 File Offset: 0x000692C8
		private void ResetthisActivityID()
		{
			this.thisActivityIDSpecified = false;
		}

		// Token: 0x1700112D RID: 4397
		// (get) Token: 0x060037EA RID: 14314 RVA: 0x0006B0D4 File Offset: 0x000692D4
		// (set) Token: 0x060037EB RID: 14315 RVA: 0x0006B100 File Offset: 0x00069300
		[ProtoMember(3, IsRequired = false, Name = "nextActivityID", DataFormat = DataFormat.TwosComplement)]
		public uint nextActivityID
		{
			get
			{
				return this._nextActivityID ?? 0U;
			}
			set
			{
				this._nextActivityID = new uint?(value);
			}
		}

		// Token: 0x1700112E RID: 4398
		// (get) Token: 0x060037EC RID: 14316 RVA: 0x0006B110 File Offset: 0x00069310
		// (set) Token: 0x060037ED RID: 14317 RVA: 0x0006B130 File Offset: 0x00069330
		[XmlIgnore]
		[Browsable(false)]
		public bool nextActivityIDSpecified
		{
			get
			{
				return this._nextActivityID != null;
			}
			set
			{
				bool flag = value == (this._nextActivityID == null);
				if (flag)
				{
					this._nextActivityID = (value ? new uint?(this.nextActivityID) : null);
				}
			}
		}

		// Token: 0x060037EE RID: 14318 RVA: 0x0006B174 File Offset: 0x00069374
		private bool ShouldSerializenextActivityID()
		{
			return this.nextActivityIDSpecified;
		}

		// Token: 0x060037EF RID: 14319 RVA: 0x0006B18C File Offset: 0x0006938C
		private void ResetnextActivityID()
		{
			this.nextActivityIDSpecified = false;
		}

		// Token: 0x1700112F RID: 4399
		// (get) Token: 0x060037F0 RID: 14320 RVA: 0x0006B198 File Offset: 0x00069398
		// (set) Token: 0x060037F1 RID: 14321 RVA: 0x0006B1C4 File Offset: 0x000693C4
		[ProtoMember(4, IsRequired = false, Name = "joinCount", DataFormat = DataFormat.TwosComplement)]
		public uint joinCount
		{
			get
			{
				return this._joinCount ?? 0U;
			}
			set
			{
				this._joinCount = new uint?(value);
			}
		}

		// Token: 0x17001130 RID: 4400
		// (get) Token: 0x060037F2 RID: 14322 RVA: 0x0006B1D4 File Offset: 0x000693D4
		// (set) Token: 0x060037F3 RID: 14323 RVA: 0x0006B1F4 File Offset: 0x000693F4
		[XmlIgnore]
		[Browsable(false)]
		public bool joinCountSpecified
		{
			get
			{
				return this._joinCount != null;
			}
			set
			{
				bool flag = value == (this._joinCount == null);
				if (flag)
				{
					this._joinCount = (value ? new uint?(this.joinCount) : null);
				}
			}
		}

		// Token: 0x060037F4 RID: 14324 RVA: 0x0006B238 File Offset: 0x00069438
		private bool ShouldSerializejoinCount()
		{
			return this.joinCountSpecified;
		}

		// Token: 0x060037F5 RID: 14325 RVA: 0x0006B250 File Offset: 0x00069450
		private void ResetjoinCount()
		{
			this.joinCountSpecified = false;
		}

		// Token: 0x060037F6 RID: 14326 RVA: 0x0006B25C File Offset: 0x0006945C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DD9 RID: 3545
		private ErrorCode? _errorcode;

		// Token: 0x04000DDA RID: 3546
		private uint? _thisActivityID;

		// Token: 0x04000DDB RID: 3547
		private uint? _nextActivityID;

		// Token: 0x04000DDC RID: 3548
		private uint? _joinCount;

		// Token: 0x04000DDD RID: 3549
		private IExtension extensionObject;
	}
}
