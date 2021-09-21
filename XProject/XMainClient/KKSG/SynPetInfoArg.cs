using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001CB RID: 459
	[ProtoContract(Name = "SynPetInfoArg")]
	[Serializable]
	public class SynPetInfoArg : IExtensible
	{
		// Token: 0x17000876 RID: 2166
		// (get) Token: 0x06001ADE RID: 6878 RVA: 0x000352AC File Offset: 0x000334AC
		// (set) Token: 0x06001ADF RID: 6879 RVA: 0x000352D9 File Offset: 0x000334D9
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17000877 RID: 2167
		// (get) Token: 0x06001AE0 RID: 6880 RVA: 0x000352E8 File Offset: 0x000334E8
		// (set) Token: 0x06001AE1 RID: 6881 RVA: 0x00035308 File Offset: 0x00033508
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06001AE2 RID: 6882 RVA: 0x0003534C File Offset: 0x0003354C
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06001AE3 RID: 6883 RVA: 0x00035364 File Offset: 0x00033564
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x00035370 File Offset: 0x00033570
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006AE RID: 1710
		private ulong? _uid;

		// Token: 0x040006AF RID: 1711
		private IExtension extensionObject;
	}
}
