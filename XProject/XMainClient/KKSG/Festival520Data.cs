using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200064D RID: 1613
	[ProtoContract(Name = "Festival520Data")]
	[Serializable]
	public class Festival520Data : IExtensible
	{
		// Token: 0x17001FAD RID: 8109
		// (get) Token: 0x0600646F RID: 25711 RVA: 0x000BFB48 File Offset: 0x000BDD48
		// (set) Token: 0x06006470 RID: 25712 RVA: 0x000BFB74 File Offset: 0x000BDD74
		[ProtoMember(1, IsRequired = false, Name = "loveValue", DataFormat = DataFormat.TwosComplement)]
		public uint loveValue
		{
			get
			{
				return this._loveValue ?? 0U;
			}
			set
			{
				this._loveValue = new uint?(value);
			}
		}

		// Token: 0x17001FAE RID: 8110
		// (get) Token: 0x06006471 RID: 25713 RVA: 0x000BFB84 File Offset: 0x000BDD84
		// (set) Token: 0x06006472 RID: 25714 RVA: 0x000BFBA4 File Offset: 0x000BDDA4
		[XmlIgnore]
		[Browsable(false)]
		public bool loveValueSpecified
		{
			get
			{
				return this._loveValue != null;
			}
			set
			{
				bool flag = value == (this._loveValue == null);
				if (flag)
				{
					this._loveValue = (value ? new uint?(this.loveValue) : null);
				}
			}
		}

		// Token: 0x06006473 RID: 25715 RVA: 0x000BFBE8 File Offset: 0x000BDDE8
		private bool ShouldSerializeloveValue()
		{
			return this.loveValueSpecified;
		}

		// Token: 0x06006474 RID: 25716 RVA: 0x000BFC00 File Offset: 0x000BDE00
		private void ResetloveValue()
		{
			this.loveValueSpecified = false;
		}

		// Token: 0x17001FAF RID: 8111
		// (get) Token: 0x06006475 RID: 25717 RVA: 0x000BFC0C File Offset: 0x000BDE0C
		[ProtoMember(2, Name = "alreadyGet", DataFormat = DataFormat.Default)]
		public List<bool> alreadyGet
		{
			get
			{
				return this._alreadyGet;
			}
		}

		// Token: 0x06006476 RID: 25718 RVA: 0x000BFC24 File Offset: 0x000BDE24
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001856 RID: 6230
		private uint? _loveValue;

		// Token: 0x04001857 RID: 6231
		private readonly List<bool> _alreadyGet = new List<bool>();

		// Token: 0x04001858 RID: 6232
		private IExtension extensionObject;
	}
}
