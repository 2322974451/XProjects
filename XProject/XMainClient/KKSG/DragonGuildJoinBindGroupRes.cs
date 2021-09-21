using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004CF RID: 1231
	[ProtoContract(Name = "DragonGuildJoinBindGroupRes")]
	[Serializable]
	public class DragonGuildJoinBindGroupRes : IExtensible
	{
		// Token: 0x17001395 RID: 5013
		// (get) Token: 0x06003FF2 RID: 16370 RVA: 0x00079D48 File Offset: 0x00077F48
		// (set) Token: 0x06003FF3 RID: 16371 RVA: 0x00079D74 File Offset: 0x00077F74
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

		// Token: 0x17001396 RID: 5014
		// (get) Token: 0x06003FF4 RID: 16372 RVA: 0x00079D84 File Offset: 0x00077F84
		// (set) Token: 0x06003FF5 RID: 16373 RVA: 0x00079DA4 File Offset: 0x00077FA4
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

		// Token: 0x06003FF6 RID: 16374 RVA: 0x00079DE8 File Offset: 0x00077FE8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003FF7 RID: 16375 RVA: 0x00079E00 File Offset: 0x00078000
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003FF8 RID: 16376 RVA: 0x00079E0C File Offset: 0x0007800C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FEB RID: 4075
		private ErrorCode? _result;

		// Token: 0x04000FEC RID: 4076
		private IExtension extensionObject;
	}
}
