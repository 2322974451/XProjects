using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000DB RID: 219
	[ProtoContract(Name = "PkPrepareNtf")]
	[Serializable]
	public class PkPrepareNtf : IExtensible
	{
		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06000E0E RID: 3598 RVA: 0x0001D324 File Offset: 0x0001B524
		// (set) Token: 0x06000E0F RID: 3599 RVA: 0x0001D350 File Offset: 0x0001B550
		[ProtoMember(1, IsRequired = false, Name = "beginorend", DataFormat = DataFormat.TwosComplement)]
		public uint beginorend
		{
			get
			{
				return this._beginorend ?? 0U;
			}
			set
			{
				this._beginorend = new uint?(value);
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06000E10 RID: 3600 RVA: 0x0001D360 File Offset: 0x0001B560
		// (set) Token: 0x06000E11 RID: 3601 RVA: 0x0001D380 File Offset: 0x0001B580
		[XmlIgnore]
		[Browsable(false)]
		public bool beginorendSpecified
		{
			get
			{
				return this._beginorend != null;
			}
			set
			{
				bool flag = value == (this._beginorend == null);
				if (flag)
				{
					this._beginorend = (value ? new uint?(this.beginorend) : null);
				}
			}
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x0001D3C4 File Offset: 0x0001B5C4
		private bool ShouldSerializebeginorend()
		{
			return this.beginorendSpecified;
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x0001D3DC File Offset: 0x0001B5DC
		private void Resetbeginorend()
		{
			this.beginorendSpecified = false;
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x0001D3E8 File Offset: 0x0001B5E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000389 RID: 905
		private uint? _beginorend;

		// Token: 0x0400038A RID: 906
		private IExtension extensionObject;
	}
}
