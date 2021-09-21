using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003C5 RID: 965
	[ProtoContract(Name = "ModifyRes")]
	[Serializable]
	public class ModifyRes : IExtensible
	{
		// Token: 0x17000FDC RID: 4060
		// (get) Token: 0x0600337A RID: 13178 RVA: 0x00062D50 File Offset: 0x00060F50
		// (set) Token: 0x0600337B RID: 13179 RVA: 0x00062D7C File Offset: 0x00060F7C
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000FDD RID: 4061
		// (get) Token: 0x0600337C RID: 13180 RVA: 0x00062D8C File Offset: 0x00060F8C
		// (set) Token: 0x0600337D RID: 13181 RVA: 0x00062DAC File Offset: 0x00060FAC
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x0600337E RID: 13182 RVA: 0x00062DF0 File Offset: 0x00060FF0
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x0600337F RID: 13183 RVA: 0x00062E08 File Offset: 0x00061008
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06003380 RID: 13184 RVA: 0x00062E14 File Offset: 0x00061014
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CCC RID: 3276
		private ErrorCode? _error;

		// Token: 0x04000CCD RID: 3277
		private IExtension extensionObject;
	}
}
