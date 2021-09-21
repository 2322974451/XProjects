using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000463 RID: 1123
	[ProtoContract(Name = "SelectHeroAncientPowerRes")]
	[Serializable]
	public class SelectHeroAncientPowerRes : IExtensible
	{
		// Token: 0x1700120B RID: 4619
		// (get) Token: 0x06003ADB RID: 15067 RVA: 0x00070844 File Offset: 0x0006EA44
		// (set) Token: 0x06003ADC RID: 15068 RVA: 0x00070870 File Offset: 0x0006EA70
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

		// Token: 0x1700120C RID: 4620
		// (get) Token: 0x06003ADD RID: 15069 RVA: 0x00070880 File Offset: 0x0006EA80
		// (set) Token: 0x06003ADE RID: 15070 RVA: 0x000708A0 File Offset: 0x0006EAA0
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

		// Token: 0x06003ADF RID: 15071 RVA: 0x000708E4 File Offset: 0x0006EAE4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003AE0 RID: 15072 RVA: 0x000708FC File Offset: 0x0006EAFC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003AE1 RID: 15073 RVA: 0x00070908 File Offset: 0x0006EB08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E9F RID: 3743
		private ErrorCode? _errorcode;

		// Token: 0x04000EA0 RID: 3744
		private IExtension extensionObject;
	}
}
