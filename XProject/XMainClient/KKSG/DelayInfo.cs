using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000DA RID: 218
	[ProtoContract(Name = "DelayInfo")]
	[Serializable]
	public class DelayInfo : IExtensible
	{
		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06000E06 RID: 3590 RVA: 0x0001D240 File Offset: 0x0001B440
		// (set) Token: 0x06000E07 RID: 3591 RVA: 0x0001D26C File Offset: 0x0001B46C
		[ProtoMember(1, IsRequired = false, Name = "delay", DataFormat = DataFormat.TwosComplement)]
		public uint delay
		{
			get
			{
				return this._delay ?? 0U;
			}
			set
			{
				this._delay = new uint?(value);
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06000E08 RID: 3592 RVA: 0x0001D27C File Offset: 0x0001B47C
		// (set) Token: 0x06000E09 RID: 3593 RVA: 0x0001D29C File Offset: 0x0001B49C
		[XmlIgnore]
		[Browsable(false)]
		public bool delaySpecified
		{
			get
			{
				return this._delay != null;
			}
			set
			{
				bool flag = value == (this._delay == null);
				if (flag)
				{
					this._delay = (value ? new uint?(this.delay) : null);
				}
			}
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x0001D2E0 File Offset: 0x0001B4E0
		private bool ShouldSerializedelay()
		{
			return this.delaySpecified;
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x0001D2F8 File Offset: 0x0001B4F8
		private void Resetdelay()
		{
			this.delaySpecified = false;
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x0001D304 File Offset: 0x0001B504
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000387 RID: 903
		private uint? _delay;

		// Token: 0x04000388 RID: 904
		private IExtension extensionObject;
	}
}
