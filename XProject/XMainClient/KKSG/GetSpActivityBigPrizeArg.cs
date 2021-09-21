using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000270 RID: 624
	[ProtoContract(Name = "GetSpActivityBigPrizeArg")]
	[Serializable]
	public class GetSpActivityBigPrizeArg : IExtensible
	{
		// Token: 0x17000AD1 RID: 2769
		// (get) Token: 0x060022C4 RID: 8900 RVA: 0x00043E94 File Offset: 0x00042094
		// (set) Token: 0x060022C5 RID: 8901 RVA: 0x00043EC0 File Offset: 0x000420C0
		[ProtoMember(1, IsRequired = false, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public uint actid
		{
			get
			{
				return this._actid ?? 0U;
			}
			set
			{
				this._actid = new uint?(value);
			}
		}

		// Token: 0x17000AD2 RID: 2770
		// (get) Token: 0x060022C6 RID: 8902 RVA: 0x00043ED0 File Offset: 0x000420D0
		// (set) Token: 0x060022C7 RID: 8903 RVA: 0x00043EF0 File Offset: 0x000420F0
		[XmlIgnore]
		[Browsable(false)]
		public bool actidSpecified
		{
			get
			{
				return this._actid != null;
			}
			set
			{
				bool flag = value == (this._actid == null);
				if (flag)
				{
					this._actid = (value ? new uint?(this.actid) : null);
				}
			}
		}

		// Token: 0x060022C8 RID: 8904 RVA: 0x00043F34 File Offset: 0x00042134
		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		// Token: 0x060022C9 RID: 8905 RVA: 0x00043F4C File Offset: 0x0004214C
		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		// Token: 0x060022CA RID: 8906 RVA: 0x00043F58 File Offset: 0x00042158
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008A1 RID: 2209
		private uint? _actid;

		// Token: 0x040008A2 RID: 2210
		private IExtension extensionObject;
	}
}
