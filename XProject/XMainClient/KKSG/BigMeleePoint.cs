using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000512 RID: 1298
	[ProtoContract(Name = "BigMeleePoint")]
	[Serializable]
	public class BigMeleePoint : IExtensible
	{
		// Token: 0x1700146D RID: 5229
		// (get) Token: 0x060042CB RID: 17099 RVA: 0x0007F1A4 File Offset: 0x0007D3A4
		// (set) Token: 0x060042CC RID: 17100 RVA: 0x0007F1D0 File Offset: 0x0007D3D0
		[ProtoMember(1, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x1700146E RID: 5230
		// (get) Token: 0x060042CD RID: 17101 RVA: 0x0007F1E0 File Offset: 0x0007D3E0
		// (set) Token: 0x060042CE RID: 17102 RVA: 0x0007F200 File Offset: 0x0007D400
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x060042CF RID: 17103 RVA: 0x0007F244 File Offset: 0x0007D444
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x060042D0 RID: 17104 RVA: 0x0007F25C File Offset: 0x0007D45C
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x1700146F RID: 5231
		// (get) Token: 0x060042D1 RID: 17105 RVA: 0x0007F268 File Offset: 0x0007D468
		// (set) Token: 0x060042D2 RID: 17106 RVA: 0x0007F294 File Offset: 0x0007D494
		[ProtoMember(2, IsRequired = false, Name = "posxz", DataFormat = DataFormat.TwosComplement)]
		public uint posxz
		{
			get
			{
				return this._posxz ?? 0U;
			}
			set
			{
				this._posxz = new uint?(value);
			}
		}

		// Token: 0x17001470 RID: 5232
		// (get) Token: 0x060042D3 RID: 17107 RVA: 0x0007F2A4 File Offset: 0x0007D4A4
		// (set) Token: 0x060042D4 RID: 17108 RVA: 0x0007F2C4 File Offset: 0x0007D4C4
		[XmlIgnore]
		[Browsable(false)]
		public bool posxzSpecified
		{
			get
			{
				return this._posxz != null;
			}
			set
			{
				bool flag = value == (this._posxz == null);
				if (flag)
				{
					this._posxz = (value ? new uint?(this.posxz) : null);
				}
			}
		}

		// Token: 0x060042D5 RID: 17109 RVA: 0x0007F308 File Offset: 0x0007D508
		private bool ShouldSerializeposxz()
		{
			return this.posxzSpecified;
		}

		// Token: 0x060042D6 RID: 17110 RVA: 0x0007F320 File Offset: 0x0007D520
		private void Resetposxz()
		{
			this.posxzSpecified = false;
		}

		// Token: 0x060042D7 RID: 17111 RVA: 0x0007F32C File Offset: 0x0007D52C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010A9 RID: 4265
		private uint? _point;

		// Token: 0x040010AA RID: 4266
		private uint? _posxz;

		// Token: 0x040010AB RID: 4267
		private IExtension extensionObject;
	}
}
