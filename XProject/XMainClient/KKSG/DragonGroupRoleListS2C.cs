using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200048E RID: 1166
	[ProtoContract(Name = "DragonGroupRoleListS2C")]
	[Serializable]
	public class DragonGroupRoleListS2C : IExtensible
	{
		// Token: 0x170012A6 RID: 4774
		// (get) Token: 0x06003CD5 RID: 15573 RVA: 0x00074254 File Offset: 0x00072454
		[ProtoMember(1, Name = "rolelist", DataFormat = DataFormat.Default)]
		public List<DragonGroupRoleInfo> rolelist
		{
			get
			{
				return this._rolelist;
			}
		}

		// Token: 0x170012A7 RID: 4775
		// (get) Token: 0x06003CD6 RID: 15574 RVA: 0x0007426C File Offset: 0x0007246C
		// (set) Token: 0x06003CD7 RID: 15575 RVA: 0x00074298 File Offset: 0x00072498
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170012A8 RID: 4776
		// (get) Token: 0x06003CD8 RID: 15576 RVA: 0x000742A8 File Offset: 0x000724A8
		// (set) Token: 0x06003CD9 RID: 15577 RVA: 0x000742C8 File Offset: 0x000724C8
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

		// Token: 0x06003CDA RID: 15578 RVA: 0x0007430C File Offset: 0x0007250C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003CDB RID: 15579 RVA: 0x00074324 File Offset: 0x00072524
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003CDC RID: 15580 RVA: 0x00074330 File Offset: 0x00072530
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F25 RID: 3877
		private readonly List<DragonGroupRoleInfo> _rolelist = new List<DragonGroupRoleInfo>();

		// Token: 0x04000F26 RID: 3878
		private ErrorCode? _errorcode;

		// Token: 0x04000F27 RID: 3879
		private IExtension extensionObject;
	}
}
