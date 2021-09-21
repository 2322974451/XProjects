using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000300 RID: 768
	[ProtoContract(Name = "HorseWaitTime")]
	[Serializable]
	public class HorseWaitTime : IExtensible
	{
		// Token: 0x17000D08 RID: 3336
		// (get) Token: 0x06002A08 RID: 10760 RVA: 0x000517FC File Offset: 0x0004F9FC
		// (set) Token: 0x06002A09 RID: 10761 RVA: 0x00051828 File Offset: 0x0004FA28
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

		// Token: 0x17000D09 RID: 3337
		// (get) Token: 0x06002A0A RID: 10762 RVA: 0x00051838 File Offset: 0x0004FA38
		// (set) Token: 0x06002A0B RID: 10763 RVA: 0x00051858 File Offset: 0x0004FA58
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

		// Token: 0x06002A0C RID: 10764 RVA: 0x0005189C File Offset: 0x0004FA9C
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06002A0D RID: 10765 RVA: 0x000518B4 File Offset: 0x0004FAB4
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06002A0E RID: 10766 RVA: 0x000518C0 File Offset: 0x0004FAC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A71 RID: 2673
		private uint? _time;

		// Token: 0x04000A72 RID: 2674
		private IExtension extensionObject;
	}
}
