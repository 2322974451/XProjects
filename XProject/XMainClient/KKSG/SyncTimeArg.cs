using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200000F RID: 15
	[ProtoContract(Name = "SyncTimeArg")]
	[Serializable]
	public class SyncTimeArg : IExtensible
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00005048 File Offset: 0x00003248
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00005075 File Offset: 0x00003275
		[ProtoMember(1, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public long time
		{
			get
			{
				return this._time ?? 0L;
			}
			set
			{
				this._time = new long?(value);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00005084 File Offset: 0x00003284
		// (set) Token: 0x0600013E RID: 318 RVA: 0x000050A4 File Offset: 0x000032A4
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
					this._time = (value ? new long?(this.time) : null);
				}
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000050E8 File Offset: 0x000032E8
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00005100 File Offset: 0x00003300
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000510C File Offset: 0x0000330C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000056 RID: 86
		private long? _time;

		// Token: 0x04000057 RID: 87
		private IExtension extensionObject;
	}
}
