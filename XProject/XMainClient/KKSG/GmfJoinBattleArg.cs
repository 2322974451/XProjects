using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000199 RID: 409
	[ProtoContract(Name = "GmfJoinBattleArg")]
	[Serializable]
	public class GmfJoinBattleArg : IExtensible
	{
		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x0600188A RID: 6282 RVA: 0x00030E00 File Offset: 0x0002F000
		// (set) Token: 0x0600188B RID: 6283 RVA: 0x00030E2C File Offset: 0x0002F02C
		[ProtoMember(1, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftTime
		{
			get
			{
				return this._leftTime ?? 0U;
			}
			set
			{
				this._leftTime = new uint?(value);
			}
		}

		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x0600188C RID: 6284 RVA: 0x00030E3C File Offset: 0x0002F03C
		// (set) Token: 0x0600188D RID: 6285 RVA: 0x00030E5C File Offset: 0x0002F05C
		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new uint?(this.leftTime) : null);
				}
			}
		}

		// Token: 0x0600188E RID: 6286 RVA: 0x00030EA0 File Offset: 0x0002F0A0
		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		// Token: 0x0600188F RID: 6287 RVA: 0x00030EB8 File Offset: 0x0002F0B8
		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		// Token: 0x06001890 RID: 6288 RVA: 0x00030EC4 File Offset: 0x0002F0C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000610 RID: 1552
		private uint? _leftTime;

		// Token: 0x04000611 RID: 1553
		private IExtension extensionObject;
	}
}
