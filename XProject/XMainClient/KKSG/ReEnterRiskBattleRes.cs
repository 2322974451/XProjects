using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000213 RID: 531
	[ProtoContract(Name = "ReEnterRiskBattleRes")]
	[Serializable]
	public class ReEnterRiskBattleRes : IExtensible
	{
		// Token: 0x1700095C RID: 2396
		// (get) Token: 0x06001DE8 RID: 7656 RVA: 0x0003ACBC File Offset: 0x00038EBC
		// (set) Token: 0x06001DE9 RID: 7657 RVA: 0x0003ACE8 File Offset: 0x00038EE8
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

		// Token: 0x1700095D RID: 2397
		// (get) Token: 0x06001DEA RID: 7658 RVA: 0x0003ACF8 File Offset: 0x00038EF8
		// (set) Token: 0x06001DEB RID: 7659 RVA: 0x0003AD18 File Offset: 0x00038F18
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

		// Token: 0x06001DEC RID: 7660 RVA: 0x0003AD5C File Offset: 0x00038F5C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001DED RID: 7661 RVA: 0x0003AD74 File Offset: 0x00038F74
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06001DEE RID: 7662 RVA: 0x0003AD80 File Offset: 0x00038F80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000779 RID: 1913
		private ErrorCode? _error;

		// Token: 0x0400077A RID: 1914
		private IExtension extensionObject;
	}
}
