using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003B7 RID: 951
	[ProtoContract(Name = "CountDownNtf")]
	[Serializable]
	public class CountDownNtf : IExtensible
	{
		// Token: 0x17000FA4 RID: 4004
		// (get) Token: 0x060032BC RID: 12988 RVA: 0x00061878 File Offset: 0x0005FA78
		// (set) Token: 0x060032BD RID: 12989 RVA: 0x000618A4 File Offset: 0x0005FAA4
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

		// Token: 0x17000FA5 RID: 4005
		// (get) Token: 0x060032BE RID: 12990 RVA: 0x000618B4 File Offset: 0x0005FAB4
		// (set) Token: 0x060032BF RID: 12991 RVA: 0x000618D4 File Offset: 0x0005FAD4
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

		// Token: 0x060032C0 RID: 12992 RVA: 0x00061918 File Offset: 0x0005FB18
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060032C1 RID: 12993 RVA: 0x00061930 File Offset: 0x0005FB30
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x060032C2 RID: 12994 RVA: 0x0006193C File Offset: 0x0005FB3C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CA0 RID: 3232
		private uint? _time;

		// Token: 0x04000CA1 RID: 3233
		private IExtension extensionObject;
	}
}
