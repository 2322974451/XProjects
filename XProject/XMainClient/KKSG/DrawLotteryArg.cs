using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200002D RID: 45
	[ProtoContract(Name = "DrawLotteryArg")]
	[Serializable]
	public class DrawLotteryArg : IExtensible
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00008AD4 File Offset: 0x00006CD4
		// (set) Token: 0x06000320 RID: 800 RVA: 0x00008B00 File Offset: 0x00006D00
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000321 RID: 801 RVA: 0x00008B10 File Offset: 0x00006D10
		// (set) Token: 0x06000322 RID: 802 RVA: 0x00008B30 File Offset: 0x00006D30
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00008B74 File Offset: 0x00006D74
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00008B8C File Offset: 0x00006D8C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00008B98 File Offset: 0x00006D98
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000D2 RID: 210
		private uint? _type;

		// Token: 0x040000D3 RID: 211
		private IExtension extensionObject;
	}
}
