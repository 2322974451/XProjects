using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000429 RID: 1065
	[ProtoContract(Name = "MobaSignalingRes")]
	[Serializable]
	public class MobaSignalingRes : IExtensible
	{
		// Token: 0x17001158 RID: 4440
		// (get) Token: 0x06003873 RID: 14451 RVA: 0x0006C0D4 File Offset: 0x0006A2D4
		// (set) Token: 0x06003874 RID: 14452 RVA: 0x0006C100 File Offset: 0x0006A300
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

		// Token: 0x17001159 RID: 4441
		// (get) Token: 0x06003875 RID: 14453 RVA: 0x0006C110 File Offset: 0x0006A310
		// (set) Token: 0x06003876 RID: 14454 RVA: 0x0006C130 File Offset: 0x0006A330
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

		// Token: 0x06003877 RID: 14455 RVA: 0x0006C174 File Offset: 0x0006A374
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003878 RID: 14456 RVA: 0x0006C18C File Offset: 0x0006A38C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003879 RID: 14457 RVA: 0x0006C198 File Offset: 0x0006A398
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E01 RID: 3585
		private ErrorCode? _errorcode;

		// Token: 0x04000E02 RID: 3586
		private IExtension extensionObject;
	}
}
