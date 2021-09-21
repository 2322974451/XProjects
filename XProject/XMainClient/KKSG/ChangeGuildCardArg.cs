using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200009F RID: 159
	[ProtoContract(Name = "ChangeGuildCardArg")]
	[Serializable]
	public class ChangeGuildCardArg : IExtensible
	{
		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000B05 RID: 2821 RVA: 0x00017A64 File Offset: 0x00015C64
		// (set) Token: 0x06000B06 RID: 2822 RVA: 0x00017A90 File Offset: 0x00015C90
		[ProtoMember(1, IsRequired = false, Name = "card", DataFormat = DataFormat.TwosComplement)]
		public uint card
		{
			get
			{
				return this._card ?? 0U;
			}
			set
			{
				this._card = new uint?(value);
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000B07 RID: 2823 RVA: 0x00017AA0 File Offset: 0x00015CA0
		// (set) Token: 0x06000B08 RID: 2824 RVA: 0x00017AC0 File Offset: 0x00015CC0
		[XmlIgnore]
		[Browsable(false)]
		public bool cardSpecified
		{
			get
			{
				return this._card != null;
			}
			set
			{
				bool flag = value == (this._card == null);
				if (flag)
				{
					this._card = (value ? new uint?(this.card) : null);
				}
			}
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x00017B04 File Offset: 0x00015D04
		private bool ShouldSerializecard()
		{
			return this.cardSpecified;
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x00017B1C File Offset: 0x00015D1C
		private void Resetcard()
		{
			this.cardSpecified = false;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x00017B28 File Offset: 0x00015D28
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002C4 RID: 708
		private uint? _card;

		// Token: 0x040002C5 RID: 709
		private IExtension extensionObject;
	}
}
