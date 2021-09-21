using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000441 RID: 1089
	[ProtoContract(Name = "BigMeleeRelive")]
	[Serializable]
	public class BigMeleeRelive : IExtensible
	{
		// Token: 0x170011A5 RID: 4517
		// (get) Token: 0x0600397B RID: 14715 RVA: 0x0006DF80 File Offset: 0x0006C180
		// (set) Token: 0x0600397C RID: 14716 RVA: 0x0006DFAC File Offset: 0x0006C1AC
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

		// Token: 0x170011A6 RID: 4518
		// (get) Token: 0x0600397D RID: 14717 RVA: 0x0006DFBC File Offset: 0x0006C1BC
		// (set) Token: 0x0600397E RID: 14718 RVA: 0x0006DFDC File Offset: 0x0006C1DC
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

		// Token: 0x0600397F RID: 14719 RVA: 0x0006E020 File Offset: 0x0006C220
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06003980 RID: 14720 RVA: 0x0006E038 File Offset: 0x0006C238
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06003981 RID: 14721 RVA: 0x0006E044 File Offset: 0x0006C244
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E44 RID: 3652
		private uint? _time;

		// Token: 0x04000E45 RID: 3653
		private IExtension extensionObject;
	}
}
