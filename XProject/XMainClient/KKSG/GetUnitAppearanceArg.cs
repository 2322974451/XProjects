using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200004E RID: 78
	[ProtoContract(Name = "GetUnitAppearanceArg")]
	[Serializable]
	public class GetUnitAppearanceArg : IExtensible
	{
		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x0000C984 File Offset: 0x0000AB84
		// (set) Token: 0x06000530 RID: 1328 RVA: 0x0000C9B1 File Offset: 0x0000ABB1
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x0000C9C0 File Offset: 0x0000ABC0
		// (set) Token: 0x06000532 RID: 1330 RVA: 0x0000C9E0 File Offset: 0x0000ABE0
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0000CA24 File Offset: 0x0000AC24
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0000CA3C File Offset: 0x0000AC3C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x0000CA48 File Offset: 0x0000AC48
		// (set) Token: 0x06000536 RID: 1334 RVA: 0x0000CA74 File Offset: 0x0000AC74
		[ProtoMember(2, IsRequired = false, Name = "mask", DataFormat = DataFormat.TwosComplement)]
		public int mask
		{
			get
			{
				return this._mask ?? 0;
			}
			set
			{
				this._mask = new int?(value);
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x0000CA84 File Offset: 0x0000AC84
		// (set) Token: 0x06000538 RID: 1336 RVA: 0x0000CAA4 File Offset: 0x0000ACA4
		[XmlIgnore]
		[Browsable(false)]
		public bool maskSpecified
		{
			get
			{
				return this._mask != null;
			}
			set
			{
				bool flag = value == (this._mask == null);
				if (flag)
				{
					this._mask = (value ? new int?(this.mask) : null);
				}
			}
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0000CAE8 File Offset: 0x0000ACE8
		private bool ShouldSerializemask()
		{
			return this.maskSpecified;
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0000CB00 File Offset: 0x0000AD00
		private void Resetmask()
		{
			this.maskSpecified = false;
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x0000CB0C File Offset: 0x0000AD0C
		// (set) Token: 0x0600053C RID: 1340 RVA: 0x0000CB38 File Offset: 0x0000AD38
		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600053D RID: 1341 RVA: 0x0000CB48 File Offset: 0x0000AD48
		// (set) Token: 0x0600053E RID: 1342 RVA: 0x0000CB68 File Offset: 0x0000AD68
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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0000CBAC File Offset: 0x0000ADAC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0000CBC4 File Offset: 0x0000ADC4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000541 RID: 1345 RVA: 0x0000CBD0 File Offset: 0x0000ADD0
		// (set) Token: 0x06000542 RID: 1346 RVA: 0x0000CBFD File Offset: 0x0000ADFD
		[ProtoMember(4, IsRequired = false, Name = "petId", DataFormat = DataFormat.TwosComplement)]
		public ulong petId
		{
			get
			{
				return this._petId ?? 0UL;
			}
			set
			{
				this._petId = new ulong?(value);
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x0000CC0C File Offset: 0x0000AE0C
		// (set) Token: 0x06000544 RID: 1348 RVA: 0x0000CC2C File Offset: 0x0000AE2C
		[XmlIgnore]
		[Browsable(false)]
		public bool petIdSpecified
		{
			get
			{
				return this._petId != null;
			}
			set
			{
				bool flag = value == (this._petId == null);
				if (flag)
				{
					this._petId = (value ? new ulong?(this.petId) : null);
				}
			}
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0000CC70 File Offset: 0x0000AE70
		private bool ShouldSerializepetId()
		{
			return this.petIdSpecified;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0000CC88 File Offset: 0x0000AE88
		private void ResetpetId()
		{
			this.petIdSpecified = false;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0000CC94 File Offset: 0x0000AE94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000155 RID: 341
		private ulong? _roleid;

		// Token: 0x04000156 RID: 342
		private int? _mask;

		// Token: 0x04000157 RID: 343
		private uint? _type;

		// Token: 0x04000158 RID: 344
		private ulong? _petId;

		// Token: 0x04000159 RID: 345
		private IExtension extensionObject;
	}
}
