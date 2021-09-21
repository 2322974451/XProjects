using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200018E RID: 398
	[ProtoContract(Name = "TakeOffAllJadeRes")]
	[Serializable]
	public class TakeOffAllJadeRes : IExtensible
	{
		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x06001815 RID: 6165 RVA: 0x00030074 File Offset: 0x0002E274
		// (set) Token: 0x06001816 RID: 6166 RVA: 0x000300A0 File Offset: 0x0002E2A0
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

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x06001817 RID: 6167 RVA: 0x000300B0 File Offset: 0x0002E2B0
		// (set) Token: 0x06001818 RID: 6168 RVA: 0x000300D0 File Offset: 0x0002E2D0
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

		// Token: 0x06001819 RID: 6169 RVA: 0x00030114 File Offset: 0x0002E314
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600181A RID: 6170 RVA: 0x0003012C File Offset: 0x0002E32C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x0600181B RID: 6171 RVA: 0x00030138 File Offset: 0x0002E338
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005F2 RID: 1522
		private ErrorCode? _errorcode;

		// Token: 0x040005F3 RID: 1523
		private IExtension extensionObject;
	}
}
