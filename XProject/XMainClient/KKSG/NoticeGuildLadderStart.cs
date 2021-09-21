using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000246 RID: 582
	[ProtoContract(Name = "NoticeGuildLadderStart")]
	[Serializable]
	public class NoticeGuildLadderStart : IExtensible
	{
		// Token: 0x17000A0F RID: 2575
		// (get) Token: 0x06002044 RID: 8260 RVA: 0x0003F358 File Offset: 0x0003D558
		// (set) Token: 0x06002045 RID: 8261 RVA: 0x0003F384 File Offset: 0x0003D584
		[ProtoMember(1, IsRequired = false, Name = "isstart", DataFormat = DataFormat.Default)]
		public bool isstart
		{
			get
			{
				return this._isstart ?? false;
			}
			set
			{
				this._isstart = new bool?(value);
			}
		}

		// Token: 0x17000A10 RID: 2576
		// (get) Token: 0x06002046 RID: 8262 RVA: 0x0003F394 File Offset: 0x0003D594
		// (set) Token: 0x06002047 RID: 8263 RVA: 0x0003F3B4 File Offset: 0x0003D5B4
		[XmlIgnore]
		[Browsable(false)]
		public bool isstartSpecified
		{
			get
			{
				return this._isstart != null;
			}
			set
			{
				bool flag = value == (this._isstart == null);
				if (flag)
				{
					this._isstart = (value ? new bool?(this.isstart) : null);
				}
			}
		}

		// Token: 0x06002048 RID: 8264 RVA: 0x0003F3F8 File Offset: 0x0003D5F8
		private bool ShouldSerializeisstart()
		{
			return this.isstartSpecified;
		}

		// Token: 0x06002049 RID: 8265 RVA: 0x0003F410 File Offset: 0x0003D610
		private void Resetisstart()
		{
			this.isstartSpecified = false;
		}

		// Token: 0x0600204A RID: 8266 RVA: 0x0003F41C File Offset: 0x0003D61C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400080F RID: 2063
		private bool? _isstart;

		// Token: 0x04000810 RID: 2064
		private IExtension extensionObject;
	}
}
