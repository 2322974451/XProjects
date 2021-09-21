using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000416 RID: 1046
	[ProtoContract(Name = "TarjaBrief")]
	[Serializable]
	public class TarjaBrief : IExtensible
	{
		// Token: 0x17001116 RID: 4374
		// (get) Token: 0x06003799 RID: 14233 RVA: 0x0006A75C File Offset: 0x0006895C
		// (set) Token: 0x0600379A RID: 14234 RVA: 0x0006A788 File Offset: 0x00068988
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

		// Token: 0x17001117 RID: 4375
		// (get) Token: 0x0600379B RID: 14235 RVA: 0x0006A798 File Offset: 0x00068998
		// (set) Token: 0x0600379C RID: 14236 RVA: 0x0006A7B8 File Offset: 0x000689B8
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

		// Token: 0x0600379D RID: 14237 RVA: 0x0006A7FC File Offset: 0x000689FC
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x0600379E RID: 14238 RVA: 0x0006A814 File Offset: 0x00068A14
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x0600379F RID: 14239 RVA: 0x0006A820 File Offset: 0x00068A20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DC8 RID: 3528
		private uint? _time;

		// Token: 0x04000DC9 RID: 3529
		private IExtension extensionObject;
	}
}
