using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000648 RID: 1608
	[ProtoContract(Name = "SpFirstCompleteScene")]
	[Serializable]
	public class SpFirstCompleteScene : IExtensible
	{
		// Token: 0x17001F7F RID: 8063
		// (get) Token: 0x060063E6 RID: 25574 RVA: 0x000BEA64 File Offset: 0x000BCC64
		// (set) Token: 0x060063E7 RID: 25575 RVA: 0x000BEA90 File Offset: 0x000BCC90
		[ProtoMember(1, IsRequired = false, Name = "scenetype", DataFormat = DataFormat.TwosComplement)]
		public uint scenetype
		{
			get
			{
				return this._scenetype ?? 0U;
			}
			set
			{
				this._scenetype = new uint?(value);
			}
		}

		// Token: 0x17001F80 RID: 8064
		// (get) Token: 0x060063E8 RID: 25576 RVA: 0x000BEAA0 File Offset: 0x000BCCA0
		// (set) Token: 0x060063E9 RID: 25577 RVA: 0x000BEAC0 File Offset: 0x000BCCC0
		[XmlIgnore]
		[Browsable(false)]
		public bool scenetypeSpecified
		{
			get
			{
				return this._scenetype != null;
			}
			set
			{
				bool flag = value == (this._scenetype == null);
				if (flag)
				{
					this._scenetype = (value ? new uint?(this.scenetype) : null);
				}
			}
		}

		// Token: 0x060063EA RID: 25578 RVA: 0x000BEB04 File Offset: 0x000BCD04
		private bool ShouldSerializescenetype()
		{
			return this.scenetypeSpecified;
		}

		// Token: 0x060063EB RID: 25579 RVA: 0x000BEB1C File Offset: 0x000BCD1C
		private void Resetscenetype()
		{
			this.scenetypeSpecified = false;
		}

		// Token: 0x17001F81 RID: 8065
		// (get) Token: 0x060063EC RID: 25580 RVA: 0x000BEB28 File Offset: 0x000BCD28
		[ProtoMember(2, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> sceneid
		{
			get
			{
				return this._sceneid;
			}
		}

		// Token: 0x060063ED RID: 25581 RVA: 0x000BEB40 File Offset: 0x000BCD40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001837 RID: 6199
		private uint? _scenetype;

		// Token: 0x04001838 RID: 6200
		private readonly List<uint> _sceneid = new List<uint>();

		// Token: 0x04001839 RID: 6201
		private IExtension extensionObject;
	}
}
