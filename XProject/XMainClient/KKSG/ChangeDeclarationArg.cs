using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003A7 RID: 935
	[ProtoContract(Name = "ChangeDeclarationArg")]
	[Serializable]
	public class ChangeDeclarationArg : IExtensible
	{
		// Token: 0x17000F87 RID: 3975
		// (get) Token: 0x06003249 RID: 12873 RVA: 0x00060C40 File Offset: 0x0005EE40
		// (set) Token: 0x0600324A RID: 12874 RVA: 0x00060C61 File Offset: 0x0005EE61
		[ProtoMember(1, IsRequired = false, Name = "declaration", DataFormat = DataFormat.Default)]
		public string declaration
		{
			get
			{
				return this._declaration ?? "";
			}
			set
			{
				this._declaration = value;
			}
		}

		// Token: 0x17000F88 RID: 3976
		// (get) Token: 0x0600324B RID: 12875 RVA: 0x00060C6C File Offset: 0x0005EE6C
		// (set) Token: 0x0600324C RID: 12876 RVA: 0x00060C88 File Offset: 0x0005EE88
		[XmlIgnore]
		[Browsable(false)]
		public bool declarationSpecified
		{
			get
			{
				return this._declaration != null;
			}
			set
			{
				bool flag = value == (this._declaration == null);
				if (flag)
				{
					this._declaration = (value ? this.declaration : null);
				}
			}
		}

		// Token: 0x0600324D RID: 12877 RVA: 0x00060CB8 File Offset: 0x0005EEB8
		private bool ShouldSerializedeclaration()
		{
			return this.declarationSpecified;
		}

		// Token: 0x0600324E RID: 12878 RVA: 0x00060CD0 File Offset: 0x0005EED0
		private void Resetdeclaration()
		{
			this.declarationSpecified = false;
		}

		// Token: 0x0600324F RID: 12879 RVA: 0x00060CDC File Offset: 0x0005EEDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C80 RID: 3200
		private string _declaration;

		// Token: 0x04000C81 RID: 3201
		private IExtension extensionObject;
	}
}
