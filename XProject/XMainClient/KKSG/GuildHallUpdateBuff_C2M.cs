using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000539 RID: 1337
	[ProtoContract(Name = "GuildHallUpdateBuff_C2M")]
	[Serializable]
	public class GuildHallUpdateBuff_C2M : IExtensible
	{
		// Token: 0x170014F6 RID: 5366
		// (get) Token: 0x0600448D RID: 17549 RVA: 0x0008263C File Offset: 0x0008083C
		// (set) Token: 0x0600448E RID: 17550 RVA: 0x00082668 File Offset: 0x00080868
		[ProtoMember(1, IsRequired = false, Name = "buffid", DataFormat = DataFormat.TwosComplement)]
		public uint buffid
		{
			get
			{
				return this._buffid ?? 0U;
			}
			set
			{
				this._buffid = new uint?(value);
			}
		}

		// Token: 0x170014F7 RID: 5367
		// (get) Token: 0x0600448F RID: 17551 RVA: 0x00082678 File Offset: 0x00080878
		// (set) Token: 0x06004490 RID: 17552 RVA: 0x00082698 File Offset: 0x00080898
		[XmlIgnore]
		[Browsable(false)]
		public bool buffidSpecified
		{
			get
			{
				return this._buffid != null;
			}
			set
			{
				bool flag = value == (this._buffid == null);
				if (flag)
				{
					this._buffid = (value ? new uint?(this.buffid) : null);
				}
			}
		}

		// Token: 0x06004491 RID: 17553 RVA: 0x000826DC File Offset: 0x000808DC
		private bool ShouldSerializebuffid()
		{
			return this.buffidSpecified;
		}

		// Token: 0x06004492 RID: 17554 RVA: 0x000826F4 File Offset: 0x000808F4
		private void Resetbuffid()
		{
			this.buffidSpecified = false;
		}

		// Token: 0x06004493 RID: 17555 RVA: 0x00082700 File Offset: 0x00080900
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400111F RID: 4383
		private uint? _buffid;

		// Token: 0x04001120 RID: 4384
		private IExtension extensionObject;
	}
}
