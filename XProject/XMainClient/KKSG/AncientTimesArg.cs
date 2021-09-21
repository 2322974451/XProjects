using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000469 RID: 1129
	[ProtoContract(Name = "AncientTimesArg")]
	[Serializable]
	public class AncientTimesArg : IExtensible
	{
		// Token: 0x17001221 RID: 4641
		// (get) Token: 0x06003B25 RID: 15141 RVA: 0x000710D4 File Offset: 0x0006F2D4
		// (set) Token: 0x06003B26 RID: 15142 RVA: 0x00071100 File Offset: 0x0006F300
		[ProtoMember(1, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public uint pos
		{
			get
			{
				return this._pos ?? 0U;
			}
			set
			{
				this._pos = new uint?(value);
			}
		}

		// Token: 0x17001222 RID: 4642
		// (get) Token: 0x06003B27 RID: 15143 RVA: 0x00071110 File Offset: 0x0006F310
		// (set) Token: 0x06003B28 RID: 15144 RVA: 0x00071130 File Offset: 0x0006F330
		[XmlIgnore]
		[Browsable(false)]
		public bool posSpecified
		{
			get
			{
				return this._pos != null;
			}
			set
			{
				bool flag = value == (this._pos == null);
				if (flag)
				{
					this._pos = (value ? new uint?(this.pos) : null);
				}
			}
		}

		// Token: 0x06003B29 RID: 15145 RVA: 0x00071174 File Offset: 0x0006F374
		private bool ShouldSerializepos()
		{
			return this.posSpecified;
		}

		// Token: 0x06003B2A RID: 15146 RVA: 0x0007118C File Offset: 0x0006F38C
		private void Resetpos()
		{
			this.posSpecified = false;
		}

		// Token: 0x06003B2B RID: 15147 RVA: 0x00071198 File Offset: 0x0006F398
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EB1 RID: 3761
		private uint? _pos;

		// Token: 0x04000EB2 RID: 3762
		private IExtension extensionObject;
	}
}
