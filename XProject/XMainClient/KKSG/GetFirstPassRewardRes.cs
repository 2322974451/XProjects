using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001E1 RID: 481
	[ProtoContract(Name = "GetFirstPassRewardRes")]
	[Serializable]
	public class GetFirstPassRewardRes : IExtensible
	{
		// Token: 0x170008AF RID: 2223
		// (get) Token: 0x06001BA9 RID: 7081 RVA: 0x000369CC File Offset: 0x00034BCC
		// (set) Token: 0x06001BAA RID: 7082 RVA: 0x000369F8 File Offset: 0x00034BF8
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

		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x06001BAB RID: 7083 RVA: 0x00036A08 File Offset: 0x00034C08
		// (set) Token: 0x06001BAC RID: 7084 RVA: 0x00036A28 File Offset: 0x00034C28
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

		// Token: 0x06001BAD RID: 7085 RVA: 0x00036A6C File Offset: 0x00034C6C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001BAE RID: 7086 RVA: 0x00036A84 File Offset: 0x00034C84
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06001BAF RID: 7087 RVA: 0x00036A90 File Offset: 0x00034C90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006E4 RID: 1764
		private ErrorCode? _error;

		// Token: 0x040006E5 RID: 1765
		private IExtension extensionObject;
	}
}
