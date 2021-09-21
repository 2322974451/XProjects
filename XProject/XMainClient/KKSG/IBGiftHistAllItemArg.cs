using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003BD RID: 957
	[ProtoContract(Name = "IBGiftHistAllItemArg")]
	[Serializable]
	public class IBGiftHistAllItemArg : IExtensible
	{
		// Token: 0x17000FCB RID: 4043
		// (get) Token: 0x06003338 RID: 13112 RVA: 0x00062674 File Offset: 0x00060874
		// (set) Token: 0x06003339 RID: 13113 RVA: 0x000626A0 File Offset: 0x000608A0
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

		// Token: 0x17000FCC RID: 4044
		// (get) Token: 0x0600333A RID: 13114 RVA: 0x000626B0 File Offset: 0x000608B0
		// (set) Token: 0x0600333B RID: 13115 RVA: 0x000626D0 File Offset: 0x000608D0
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

		// Token: 0x0600333C RID: 13116 RVA: 0x00062714 File Offset: 0x00060914
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600333D RID: 13117 RVA: 0x0006272C File Offset: 0x0006092C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x0600333E RID: 13118 RVA: 0x00062738 File Offset: 0x00060938
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CBB RID: 3259
		private uint? _type;

		// Token: 0x04000CBC RID: 3260
		private IExtension extensionObject;
	}
}
