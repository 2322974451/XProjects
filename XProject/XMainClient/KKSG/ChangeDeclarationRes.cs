using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003A8 RID: 936
	[ProtoContract(Name = "ChangeDeclarationRes")]
	[Serializable]
	public class ChangeDeclarationRes : IExtensible
	{
		// Token: 0x17000F89 RID: 3977
		// (get) Token: 0x06003251 RID: 12881 RVA: 0x00060CFC File Offset: 0x0005EEFC
		// (set) Token: 0x06003252 RID: 12882 RVA: 0x00060D28 File Offset: 0x0005EF28
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000F8A RID: 3978
		// (get) Token: 0x06003253 RID: 12883 RVA: 0x00060D38 File Offset: 0x0005EF38
		// (set) Token: 0x06003254 RID: 12884 RVA: 0x00060D58 File Offset: 0x0005EF58
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06003255 RID: 12885 RVA: 0x00060D9C File Offset: 0x0005EF9C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003256 RID: 12886 RVA: 0x00060DB4 File Offset: 0x0005EFB4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000F8B RID: 3979
		// (get) Token: 0x06003257 RID: 12887 RVA: 0x00060DC0 File Offset: 0x0005EFC0
		// (set) Token: 0x06003258 RID: 12888 RVA: 0x00060DE1 File Offset: 0x0005EFE1
		[ProtoMember(2, IsRequired = false, Name = "declaration", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000F8C RID: 3980
		// (get) Token: 0x06003259 RID: 12889 RVA: 0x00060DEC File Offset: 0x0005EFEC
		// (set) Token: 0x0600325A RID: 12890 RVA: 0x00060E08 File Offset: 0x0005F008
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

		// Token: 0x0600325B RID: 12891 RVA: 0x00060E38 File Offset: 0x0005F038
		private bool ShouldSerializedeclaration()
		{
			return this.declarationSpecified;
		}

		// Token: 0x0600325C RID: 12892 RVA: 0x00060E50 File Offset: 0x0005F050
		private void Resetdeclaration()
		{
			this.declarationSpecified = false;
		}

		// Token: 0x0600325D RID: 12893 RVA: 0x00060E5C File Offset: 0x0005F05C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C82 RID: 3202
		private ErrorCode? _result;

		// Token: 0x04000C83 RID: 3203
		private string _declaration;

		// Token: 0x04000C84 RID: 3204
		private IExtension extensionObject;
	}
}
