using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003C9 RID: 969
	[ProtoContract(Name = "ArgentaActivityArg")]
	[Serializable]
	public class ArgentaActivityArg : IExtensible
	{
		// Token: 0x17000FE4 RID: 4068
		// (get) Token: 0x0600339A RID: 13210 RVA: 0x000630E0 File Offset: 0x000612E0
		// (set) Token: 0x0600339B RID: 13211 RVA: 0x0006310C File Offset: 0x0006130C
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

		// Token: 0x17000FE5 RID: 4069
		// (get) Token: 0x0600339C RID: 13212 RVA: 0x0006311C File Offset: 0x0006131C
		// (set) Token: 0x0600339D RID: 13213 RVA: 0x0006313C File Offset: 0x0006133C
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

		// Token: 0x0600339E RID: 13214 RVA: 0x00063180 File Offset: 0x00061380
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600339F RID: 13215 RVA: 0x00063198 File Offset: 0x00061398
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000FE6 RID: 4070
		// (get) Token: 0x060033A0 RID: 13216 RVA: 0x000631A4 File Offset: 0x000613A4
		// (set) Token: 0x060033A1 RID: 13217 RVA: 0x000631D0 File Offset: 0x000613D0
		[ProtoMember(2, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17000FE7 RID: 4071
		// (get) Token: 0x060033A2 RID: 13218 RVA: 0x000631E0 File Offset: 0x000613E0
		// (set) Token: 0x060033A3 RID: 13219 RVA: 0x00063200 File Offset: 0x00061400
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x060033A4 RID: 13220 RVA: 0x00063244 File Offset: 0x00061444
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060033A5 RID: 13221 RVA: 0x0006325C File Offset: 0x0006145C
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x060033A6 RID: 13222 RVA: 0x00063268 File Offset: 0x00061468
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CD4 RID: 3284
		private uint? _type;

		// Token: 0x04000CD5 RID: 3285
		private uint? _id;

		// Token: 0x04000CD6 RID: 3286
		private IExtension extensionObject;
	}
}
