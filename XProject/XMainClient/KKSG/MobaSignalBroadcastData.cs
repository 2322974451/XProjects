using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000428 RID: 1064
	[ProtoContract(Name = "MobaSignalBroadcastData")]
	[Serializable]
	public class MobaSignalBroadcastData : IExtensible
	{
		// Token: 0x17001152 RID: 4434
		// (get) Token: 0x0600385F RID: 14431 RVA: 0x0006BE68 File Offset: 0x0006A068
		// (set) Token: 0x06003860 RID: 14432 RVA: 0x0006BE94 File Offset: 0x0006A094
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001153 RID: 4435
		// (get) Token: 0x06003861 RID: 14433 RVA: 0x0006BEA4 File Offset: 0x0006A0A4
		// (set) Token: 0x06003862 RID: 14434 RVA: 0x0006BEC4 File Offset: 0x0006A0C4
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

		// Token: 0x06003863 RID: 14435 RVA: 0x0006BF08 File Offset: 0x0006A108
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003864 RID: 14436 RVA: 0x0006BF20 File Offset: 0x0006A120
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001154 RID: 4436
		// (get) Token: 0x06003865 RID: 14437 RVA: 0x0006BF2C File Offset: 0x0006A12C
		// (set) Token: 0x06003866 RID: 14438 RVA: 0x0006BF59 File Offset: 0x0006A159
		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17001155 RID: 4437
		// (get) Token: 0x06003867 RID: 14439 RVA: 0x0006BF68 File Offset: 0x0006A168
		// (set) Token: 0x06003868 RID: 14440 RVA: 0x0006BF88 File Offset: 0x0006A188
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06003869 RID: 14441 RVA: 0x0006BFCC File Offset: 0x0006A1CC
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x0600386A RID: 14442 RVA: 0x0006BFE4 File Offset: 0x0006A1E4
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17001156 RID: 4438
		// (get) Token: 0x0600386B RID: 14443 RVA: 0x0006BFF0 File Offset: 0x0006A1F0
		// (set) Token: 0x0600386C RID: 14444 RVA: 0x0006C01C File Offset: 0x0006A21C
		[ProtoMember(3, IsRequired = false, Name = "posxz", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001157 RID: 4439
		// (get) Token: 0x0600386D RID: 14445 RVA: 0x0006C02C File Offset: 0x0006A22C
		// (set) Token: 0x0600386E RID: 14446 RVA: 0x0006C04C File Offset: 0x0006A24C
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

		// Token: 0x0600386F RID: 14447 RVA: 0x0006C090 File Offset: 0x0006A290
		private bool ShouldSerializeposxz()
		{
			return this.posxzSpecified;
		}

		// Token: 0x06003870 RID: 14448 RVA: 0x0006C0A8 File Offset: 0x0006A2A8
		private void Resetposxz()
		{
			this.posxzSpecified = false;
		}

		// Token: 0x06003871 RID: 14449 RVA: 0x0006C0B4 File Offset: 0x0006A2B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DFD RID: 3581
		private uint? _type;

		// Token: 0x04000DFE RID: 3582
		private ulong? _uid;

		// Token: 0x04000DFF RID: 3583
		private uint? _posxz;

		// Token: 0x04000E00 RID: 3584
		private IExtension extensionObject;
	}
}
