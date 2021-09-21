using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200038C RID: 908
	[ProtoContract(Name = "HeroBattleTipsData")]
	[Serializable]
	public class HeroBattleTipsData : IExtensible
	{
		// Token: 0x17000F3B RID: 3899
		// (get) Token: 0x0600313E RID: 12606 RVA: 0x0005EE2C File Offset: 0x0005D02C
		// (set) Token: 0x0600313F RID: 12607 RVA: 0x0005EE58 File Offset: 0x0005D058
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17000F3C RID: 3900
		// (get) Token: 0x06003140 RID: 12608 RVA: 0x0005EE68 File Offset: 0x0005D068
		// (set) Token: 0x06003141 RID: 12609 RVA: 0x0005EE88 File Offset: 0x0005D088
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06003142 RID: 12610 RVA: 0x0005EECC File Offset: 0x0005D0CC
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06003143 RID: 12611 RVA: 0x0005EEE4 File Offset: 0x0005D0E4
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x06003144 RID: 12612 RVA: 0x0005EEF0 File Offset: 0x0005D0F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C3A RID: 3130
		private uint? _id;

		// Token: 0x04000C3B RID: 3131
		private IExtension extensionObject;
	}
}
