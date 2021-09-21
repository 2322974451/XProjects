using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200003C RID: 60
	[ProtoContract(Name = "EmblemLevelUpRes")]
	[Serializable]
	public class EmblemLevelUpRes : IExtensible
	{
		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0000A500 File Offset: 0x00008700
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x0000A52C File Offset: 0x0000872C
		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000A53C File Offset: 0x0000873C
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x0000A55C File Offset: 0x0000875C
		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0000A5A0 File Offset: 0x000087A0
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0000A5B8 File Offset: 0x000087B8
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x0000A5C4 File Offset: 0x000087C4
		// (set) Token: 0x06000404 RID: 1028 RVA: 0x0000A5F0 File Offset: 0x000087F0
		[ProtoMember(2, IsRequired = false, Name = "islevelup", DataFormat = DataFormat.Default)]
		public bool islevelup
		{
			get
			{
				return this._islevelup ?? false;
			}
			set
			{
				this._islevelup = new bool?(value);
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x0000A600 File Offset: 0x00008800
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x0000A620 File Offset: 0x00008820
		[XmlIgnore]
		[Browsable(false)]
		public bool islevelupSpecified
		{
			get
			{
				return this._islevelup != null;
			}
			set
			{
				bool flag = value == (this._islevelup == null);
				if (flag)
				{
					this._islevelup = (value ? new bool?(this.islevelup) : null);
				}
			}
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000A664 File Offset: 0x00008864
		private bool ShouldSerializeislevelup()
		{
			return this.islevelupSpecified;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000A67C File Offset: 0x0000887C
		private void Resetislevelup()
		{
			this.islevelupSpecified = false;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000A688 File Offset: 0x00008888
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400010E RID: 270
		private ErrorCode? _ErrorCode;

		// Token: 0x0400010F RID: 271
		private bool? _islevelup;

		// Token: 0x04000110 RID: 272
		private IExtension extensionObject;
	}
}
