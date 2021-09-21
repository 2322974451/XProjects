using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200043C RID: 1084
	[ProtoContract(Name = "BMReadyTime")]
	[Serializable]
	public class BMReadyTime : IExtensible
	{
		// Token: 0x17001190 RID: 4496
		// (get) Token: 0x06003937 RID: 14647 RVA: 0x0006D778 File Offset: 0x0006B978
		// (set) Token: 0x06003938 RID: 14648 RVA: 0x0006D7A4 File Offset: 0x0006B9A4
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

		// Token: 0x17001191 RID: 4497
		// (get) Token: 0x06003939 RID: 14649 RVA: 0x0006D7B4 File Offset: 0x0006B9B4
		// (set) Token: 0x0600393A RID: 14650 RVA: 0x0006D7D4 File Offset: 0x0006B9D4
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

		// Token: 0x0600393B RID: 14651 RVA: 0x0006D818 File Offset: 0x0006BA18
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x0600393C RID: 14652 RVA: 0x0006D830 File Offset: 0x0006BA30
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x0600393D RID: 14653 RVA: 0x0006D83C File Offset: 0x0006BA3C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E33 RID: 3635
		private uint? _time;

		// Token: 0x04000E34 RID: 3636
		private IExtension extensionObject;
	}
}
