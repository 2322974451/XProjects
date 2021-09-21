using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000D0 RID: 208
	[ProtoContract(Name = "ChatRes")]
	[Serializable]
	public class ChatRes : IExtensible
	{
		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000D51 RID: 3409 RVA: 0x0001BD24 File Offset: 0x00019F24
		// (set) Token: 0x06000D52 RID: 3410 RVA: 0x0001BD50 File Offset: 0x00019F50
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

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000D53 RID: 3411 RVA: 0x0001BD60 File Offset: 0x00019F60
		// (set) Token: 0x06000D54 RID: 3412 RVA: 0x0001BD80 File Offset: 0x00019F80
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

		// Token: 0x06000D55 RID: 3413 RVA: 0x0001BDC4 File Offset: 0x00019FC4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x0001BDDC File Offset: 0x00019FDC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000D57 RID: 3415 RVA: 0x0001BDE8 File Offset: 0x00019FE8
		// (set) Token: 0x06000D58 RID: 3416 RVA: 0x0001BE14 File Offset: 0x0001A014
		[ProtoMember(2, IsRequired = false, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public uint cooldown
		{
			get
			{
				return this._cooldown ?? 0U;
			}
			set
			{
				this._cooldown = new uint?(value);
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000D59 RID: 3417 RVA: 0x0001BE24 File Offset: 0x0001A024
		// (set) Token: 0x06000D5A RID: 3418 RVA: 0x0001BE44 File Offset: 0x0001A044
		[XmlIgnore]
		[Browsable(false)]
		public bool cooldownSpecified
		{
			get
			{
				return this._cooldown != null;
			}
			set
			{
				bool flag = value == (this._cooldown == null);
				if (flag)
				{
					this._cooldown = (value ? new uint?(this.cooldown) : null);
				}
			}
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x0001BE88 File Offset: 0x0001A088
		private bool ShouldSerializecooldown()
		{
			return this.cooldownSpecified;
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x0001BEA0 File Offset: 0x0001A0A0
		private void Resetcooldown()
		{
			this.cooldownSpecified = false;
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x0001BEAC File Offset: 0x0001A0AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400035B RID: 859
		private ErrorCode? _errorcode;

		// Token: 0x0400035C RID: 860
		private uint? _cooldown;

		// Token: 0x0400035D RID: 861
		private IExtension extensionObject;
	}
}
