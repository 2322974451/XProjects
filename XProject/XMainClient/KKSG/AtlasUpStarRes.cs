using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000382 RID: 898
	[ProtoContract(Name = "AtlasUpStarRes")]
	[Serializable]
	public class AtlasUpStarRes : IExtensible
	{
		// Token: 0x17000F15 RID: 3861
		// (get) Token: 0x060030C0 RID: 12480 RVA: 0x0005DFE8 File Offset: 0x0005C1E8
		// (set) Token: 0x060030C1 RID: 12481 RVA: 0x0005E014 File Offset: 0x0005C214
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

		// Token: 0x17000F16 RID: 3862
		// (get) Token: 0x060030C2 RID: 12482 RVA: 0x0005E024 File Offset: 0x0005C224
		// (set) Token: 0x060030C3 RID: 12483 RVA: 0x0005E044 File Offset: 0x0005C244
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

		// Token: 0x060030C4 RID: 12484 RVA: 0x0005E088 File Offset: 0x0005C288
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060030C5 RID: 12485 RVA: 0x0005E0A0 File Offset: 0x0005C2A0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000F17 RID: 3863
		// (get) Token: 0x060030C6 RID: 12486 RVA: 0x0005E0AC File Offset: 0x0005C2AC
		// (set) Token: 0x060030C7 RID: 12487 RVA: 0x0005E0D8 File Offset: 0x0005C2D8
		[ProtoMember(2, IsRequired = false, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public uint groupid
		{
			get
			{
				return this._groupid ?? 0U;
			}
			set
			{
				this._groupid = new uint?(value);
			}
		}

		// Token: 0x17000F18 RID: 3864
		// (get) Token: 0x060030C8 RID: 12488 RVA: 0x0005E0E8 File Offset: 0x0005C2E8
		// (set) Token: 0x060030C9 RID: 12489 RVA: 0x0005E108 File Offset: 0x0005C308
		[XmlIgnore]
		[Browsable(false)]
		public bool groupidSpecified
		{
			get
			{
				return this._groupid != null;
			}
			set
			{
				bool flag = value == (this._groupid == null);
				if (flag)
				{
					this._groupid = (value ? new uint?(this.groupid) : null);
				}
			}
		}

		// Token: 0x060030CA RID: 12490 RVA: 0x0005E14C File Offset: 0x0005C34C
		private bool ShouldSerializegroupid()
		{
			return this.groupidSpecified;
		}

		// Token: 0x060030CB RID: 12491 RVA: 0x0005E164 File Offset: 0x0005C364
		private void Resetgroupid()
		{
			this.groupidSpecified = false;
		}

		// Token: 0x17000F19 RID: 3865
		// (get) Token: 0x060030CC RID: 12492 RVA: 0x0005E170 File Offset: 0x0005C370
		// (set) Token: 0x060030CD RID: 12493 RVA: 0x0005E19C File Offset: 0x0005C39C
		[ProtoMember(3, IsRequired = false, Name = "star", DataFormat = DataFormat.TwosComplement)]
		public uint star
		{
			get
			{
				return this._star ?? 0U;
			}
			set
			{
				this._star = new uint?(value);
			}
		}

		// Token: 0x17000F1A RID: 3866
		// (get) Token: 0x060030CE RID: 12494 RVA: 0x0005E1AC File Offset: 0x0005C3AC
		// (set) Token: 0x060030CF RID: 12495 RVA: 0x0005E1CC File Offset: 0x0005C3CC
		[XmlIgnore]
		[Browsable(false)]
		public bool starSpecified
		{
			get
			{
				return this._star != null;
			}
			set
			{
				bool flag = value == (this._star == null);
				if (flag)
				{
					this._star = (value ? new uint?(this.star) : null);
				}
			}
		}

		// Token: 0x060030D0 RID: 12496 RVA: 0x0005E210 File Offset: 0x0005C410
		private bool ShouldSerializestar()
		{
			return this.starSpecified;
		}

		// Token: 0x060030D1 RID: 12497 RVA: 0x0005E228 File Offset: 0x0005C428
		private void Resetstar()
		{
			this.starSpecified = false;
		}

		// Token: 0x060030D2 RID: 12498 RVA: 0x0005E234 File Offset: 0x0005C434
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C19 RID: 3097
		private ErrorCode? _errorcode;

		// Token: 0x04000C1A RID: 3098
		private uint? _groupid;

		// Token: 0x04000C1B RID: 3099
		private uint? _star;

		// Token: 0x04000C1C RID: 3100
		private IExtension extensionObject;
	}
}
