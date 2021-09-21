using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000301 RID: 769
	[ProtoContract(Name = "HorseAnimation")]
	[Serializable]
	public class HorseAnimation : IExtensible
	{
		// Token: 0x17000D0A RID: 3338
		// (get) Token: 0x06002A10 RID: 10768 RVA: 0x000518E0 File Offset: 0x0004FAE0
		// (set) Token: 0x06002A11 RID: 10769 RVA: 0x0005190D File Offset: 0x0004FB0D
		[ProtoMember(1, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public ulong time
		{
			get
			{
				return this._time ?? 0UL;
			}
			set
			{
				this._time = new ulong?(value);
			}
		}

		// Token: 0x17000D0B RID: 3339
		// (get) Token: 0x06002A12 RID: 10770 RVA: 0x0005191C File Offset: 0x0004FB1C
		// (set) Token: 0x06002A13 RID: 10771 RVA: 0x0005193C File Offset: 0x0004FB3C
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
					this._time = (value ? new ulong?(this.time) : null);
				}
			}
		}

		// Token: 0x06002A14 RID: 10772 RVA: 0x00051980 File Offset: 0x0004FB80
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06002A15 RID: 10773 RVA: 0x00051998 File Offset: 0x0004FB98
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06002A16 RID: 10774 RVA: 0x000519A4 File Offset: 0x0004FBA4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A73 RID: 2675
		private ulong? _time;

		// Token: 0x04000A74 RID: 2676
		private IExtension extensionObject;
	}
}
