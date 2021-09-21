using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000282 RID: 642
	[ProtoContract(Name = "GardenFishInfoArg")]
	[Serializable]
	public class GardenFishInfoArg : IExtensible
	{
		// Token: 0x17000B25 RID: 2853
		// (get) Token: 0x060023D8 RID: 9176 RVA: 0x00045FA0 File Offset: 0x000441A0
		// (set) Token: 0x060023D9 RID: 9177 RVA: 0x00045FCD File Offset: 0x000441CD
		[ProtoMember(1, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
		public ulong garden_id
		{
			get
			{
				return this._garden_id ?? 0UL;
			}
			set
			{
				this._garden_id = new ulong?(value);
			}
		}

		// Token: 0x17000B26 RID: 2854
		// (get) Token: 0x060023DA RID: 9178 RVA: 0x00045FDC File Offset: 0x000441DC
		// (set) Token: 0x060023DB RID: 9179 RVA: 0x00045FFC File Offset: 0x000441FC
		[XmlIgnore]
		[Browsable(false)]
		public bool garden_idSpecified
		{
			get
			{
				return this._garden_id != null;
			}
			set
			{
				bool flag = value == (this._garden_id == null);
				if (flag)
				{
					this._garden_id = (value ? new ulong?(this.garden_id) : null);
				}
			}
		}

		// Token: 0x060023DC RID: 9180 RVA: 0x00046040 File Offset: 0x00044240
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x060023DD RID: 9181 RVA: 0x00046058 File Offset: 0x00044258
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x060023DE RID: 9182 RVA: 0x00046064 File Offset: 0x00044264
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008E0 RID: 2272
		private ulong? _garden_id;

		// Token: 0x040008E1 RID: 2273
		private IExtension extensionObject;
	}
}
