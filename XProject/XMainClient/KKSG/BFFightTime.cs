using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004E8 RID: 1256
	[ProtoContract(Name = "BFFightTime")]
	[Serializable]
	public class BFFightTime : IExtensible
	{
		// Token: 0x170013DC RID: 5084
		// (get) Token: 0x060040E8 RID: 16616 RVA: 0x0007B980 File Offset: 0x00079B80
		// (set) Token: 0x060040E9 RID: 16617 RVA: 0x0007B9AC File Offset: 0x00079BAC
		[ProtoMember(1, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x170013DD RID: 5085
		// (get) Token: 0x060040EA RID: 16618 RVA: 0x0007B9BC File Offset: 0x00079BBC
		// (set) Token: 0x060040EB RID: 16619 RVA: 0x0007B9DC File Offset: 0x00079BDC
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x060040EC RID: 16620 RVA: 0x0007BA20 File Offset: 0x00079C20
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060040ED RID: 16621 RVA: 0x0007BA38 File Offset: 0x00079C38
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x060040EE RID: 16622 RVA: 0x0007BA44 File Offset: 0x00079C44
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400102C RID: 4140
		private uint? _time;

		// Token: 0x0400102D RID: 4141
		private IExtension extensionObject;
	}
}
