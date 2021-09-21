using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000556 RID: 1366
	[ProtoContract(Name = "ClientUpdatePackageData")]
	[Serializable]
	public class ClientUpdatePackageData : IExtensible
	{
		// Token: 0x17001552 RID: 5458
		// (get) Token: 0x060045CF RID: 17871 RVA: 0x00084A8C File Offset: 0x00082C8C
		// (set) Token: 0x060045D0 RID: 17872 RVA: 0x00084AAD File Offset: 0x00082CAD
		[ProtoMember(1, IsRequired = false, Name = "version", DataFormat = DataFormat.Default)]
		public string version
		{
			get
			{
				return this._version ?? "";
			}
			set
			{
				this._version = value;
			}
		}

		// Token: 0x17001553 RID: 5459
		// (get) Token: 0x060045D1 RID: 17873 RVA: 0x00084AB8 File Offset: 0x00082CB8
		// (set) Token: 0x060045D2 RID: 17874 RVA: 0x00084AD4 File Offset: 0x00082CD4
		[XmlIgnore]
		[Browsable(false)]
		public bool versionSpecified
		{
			get
			{
				return this._version != null;
			}
			set
			{
				bool flag = value == (this._version == null);
				if (flag)
				{
					this._version = (value ? this.version : null);
				}
			}
		}

		// Token: 0x060045D3 RID: 17875 RVA: 0x00084B04 File Offset: 0x00082D04
		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		// Token: 0x060045D4 RID: 17876 RVA: 0x00084B1C File Offset: 0x00082D1C
		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		// Token: 0x060045D5 RID: 17877 RVA: 0x00084B28 File Offset: 0x00082D28
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400116E RID: 4462
		private string _version;

		// Token: 0x0400116F RID: 4463
		private IExtension extensionObject;
	}
}
