using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000055 RID: 85
	[ProtoContract(Name = "SweepArg")]
	[Serializable]
	public class SweepArg : IExtensible
	{
		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0000D780 File Offset: 0x0000B980
		// (set) Token: 0x060005A5 RID: 1445 RVA: 0x0000D7AC File Offset: 0x0000B9AC
		[ProtoMember(1, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public uint sceneID
		{
			get
			{
				return this._sceneID ?? 0U;
			}
			set
			{
				this._sceneID = new uint?(value);
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x0000D7BC File Offset: 0x0000B9BC
		// (set) Token: 0x060005A7 RID: 1447 RVA: 0x0000D7DC File Offset: 0x0000B9DC
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new uint?(this.sceneID) : null);
				}
			}
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0000D820 File Offset: 0x0000BA20
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0000D838 File Offset: 0x0000BA38
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x0000D844 File Offset: 0x0000BA44
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x0000D870 File Offset: 0x0000BA70
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x0000D880 File Offset: 0x0000BA80
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x0000D8A0 File Offset: 0x0000BAA0
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0000D8E4 File Offset: 0x0000BAE4
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0000D8FC File Offset: 0x0000BAFC
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0000D908 File Offset: 0x0000BB08
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0000D934 File Offset: 0x0000BB34
		[ProtoMember(3, IsRequired = false, Name = "expid", DataFormat = DataFormat.TwosComplement)]
		public uint expid
		{
			get
			{
				return this._expid ?? 0U;
			}
			set
			{
				this._expid = new uint?(value);
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x0000D944 File Offset: 0x0000BB44
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x0000D964 File Offset: 0x0000BB64
		[XmlIgnore]
		[Browsable(false)]
		public bool expidSpecified
		{
			get
			{
				return this._expid != null;
			}
			set
			{
				bool flag = value == (this._expid == null);
				if (flag)
				{
					this._expid = (value ? new uint?(this.expid) : null);
				}
			}
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0000D9A8 File Offset: 0x0000BBA8
		private bool ShouldSerializeexpid()
		{
			return this.expidSpecified;
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0000D9C0 File Offset: 0x0000BBC0
		private void Resetexpid()
		{
			this.expidSpecified = false;
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0000D9CC File Offset: 0x0000BBCC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000171 RID: 369
		private uint? _sceneID;

		// Token: 0x04000172 RID: 370
		private uint? _count;

		// Token: 0x04000173 RID: 371
		private uint? _expid;

		// Token: 0x04000174 RID: 372
		private IExtension extensionObject;
	}
}
