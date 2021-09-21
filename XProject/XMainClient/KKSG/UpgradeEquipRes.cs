using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004A7 RID: 1191
	[ProtoContract(Name = "UpgradeEquipRes")]
	[Serializable]
	public class UpgradeEquipRes : IExtensible
	{
		// Token: 0x170012FA RID: 4858
		// (get) Token: 0x06003DF2 RID: 15858 RVA: 0x000762F4 File Offset: 0x000744F4
		// (set) Token: 0x06003DF3 RID: 15859 RVA: 0x00076320 File Offset: 0x00074520
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170012FB RID: 4859
		// (get) Token: 0x06003DF4 RID: 15860 RVA: 0x00076330 File Offset: 0x00074530
		// (set) Token: 0x06003DF5 RID: 15861 RVA: 0x00076350 File Offset: 0x00074550
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06003DF6 RID: 15862 RVA: 0x00076394 File Offset: 0x00074594
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003DF7 RID: 15863 RVA: 0x000763AC File Offset: 0x000745AC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003DF8 RID: 15864 RVA: 0x000763B8 File Offset: 0x000745B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F6D RID: 3949
		private ErrorCode? _errorcode;

		// Token: 0x04000F6E RID: 3950
		private IExtension extensionObject;
	}
}
