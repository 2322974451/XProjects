using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004DE RID: 1246
	[ProtoContract(Name = "BattleFieldReliveInfo")]
	[Serializable]
	public class BattleFieldReliveInfo : IExtensible
	{
		// Token: 0x170013B2 RID: 5042
		// (get) Token: 0x0600405D RID: 16477 RVA: 0x0007A90C File Offset: 0x00078B0C
		// (set) Token: 0x0600405E RID: 16478 RVA: 0x0007A938 File Offset: 0x00078B38
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

		// Token: 0x170013B3 RID: 5043
		// (get) Token: 0x0600405F RID: 16479 RVA: 0x0007A948 File Offset: 0x00078B48
		// (set) Token: 0x06004060 RID: 16480 RVA: 0x0007A968 File Offset: 0x00078B68
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

		// Token: 0x06004061 RID: 16481 RVA: 0x0007A9AC File Offset: 0x00078BAC
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06004062 RID: 16482 RVA: 0x0007A9C4 File Offset: 0x00078BC4
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06004063 RID: 16483 RVA: 0x0007A9D0 File Offset: 0x00078BD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400100B RID: 4107
		private uint? _time;

		// Token: 0x0400100C RID: 4108
		private IExtension extensionObject;
	}
}
