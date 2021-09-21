using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000358 RID: 856
	[ProtoContract(Name = "ClearGuildTerrAllianceRes")]
	[Serializable]
	public class ClearGuildTerrAllianceRes : IExtensible
	{
		// Token: 0x17000E91 RID: 3729
		// (get) Token: 0x06002EFA RID: 12026 RVA: 0x0005ABB8 File Offset: 0x00058DB8
		// (set) Token: 0x06002EFB RID: 12027 RVA: 0x0005ABE4 File Offset: 0x00058DE4
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

		// Token: 0x17000E92 RID: 3730
		// (get) Token: 0x06002EFC RID: 12028 RVA: 0x0005ABF4 File Offset: 0x00058DF4
		// (set) Token: 0x06002EFD RID: 12029 RVA: 0x0005AC14 File Offset: 0x00058E14
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

		// Token: 0x06002EFE RID: 12030 RVA: 0x0005AC58 File Offset: 0x00058E58
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002EFF RID: 12031 RVA: 0x0005AC70 File Offset: 0x00058E70
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06002F00 RID: 12032 RVA: 0x0005AC7C File Offset: 0x00058E7C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BA6 RID: 2982
		private ErrorCode? _errorcode;

		// Token: 0x04000BA7 RID: 2983
		private IExtension extensionObject;
	}
}
