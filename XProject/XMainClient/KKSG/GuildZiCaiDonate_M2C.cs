using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200053B RID: 1339
	[ProtoContract(Name = "GuildZiCaiDonate_M2C")]
	[Serializable]
	public class GuildZiCaiDonate_M2C : IExtensible
	{
		// Token: 0x170014FB RID: 5371
		// (get) Token: 0x0600449F RID: 17567 RVA: 0x00082838 File Offset: 0x00080A38
		// (set) Token: 0x060044A0 RID: 17568 RVA: 0x00082864 File Offset: 0x00080A64
		[ProtoMember(1, IsRequired = false, Name = "ec", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ec
		{
			get
			{
				return this._ec ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ec = new ErrorCode?(value);
			}
		}

		// Token: 0x170014FC RID: 5372
		// (get) Token: 0x060044A1 RID: 17569 RVA: 0x00082874 File Offset: 0x00080A74
		// (set) Token: 0x060044A2 RID: 17570 RVA: 0x00082894 File Offset: 0x00080A94
		[XmlIgnore]
		[Browsable(false)]
		public bool ecSpecified
		{
			get
			{
				return this._ec != null;
			}
			set
			{
				bool flag = value == (this._ec == null);
				if (flag)
				{
					this._ec = (value ? new ErrorCode?(this.ec) : null);
				}
			}
		}

		// Token: 0x060044A3 RID: 17571 RVA: 0x000828D8 File Offset: 0x00080AD8
		private bool ShouldSerializeec()
		{
			return this.ecSpecified;
		}

		// Token: 0x060044A4 RID: 17572 RVA: 0x000828F0 File Offset: 0x00080AF0
		private void Resetec()
		{
			this.ecSpecified = false;
		}

		// Token: 0x060044A5 RID: 17573 RVA: 0x000828FC File Offset: 0x00080AFC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001124 RID: 4388
		private ErrorCode? _ec;

		// Token: 0x04001125 RID: 4389
		private IExtension extensionObject;
	}
}
