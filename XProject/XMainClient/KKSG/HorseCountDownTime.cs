using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200032A RID: 810
	[ProtoContract(Name = "HorseCountDownTime")]
	[Serializable]
	public class HorseCountDownTime : IExtensible
	{
		// Token: 0x17000DDA RID: 3546
		// (get) Token: 0x06002CAB RID: 11435 RVA: 0x000567C4 File Offset: 0x000549C4
		// (set) Token: 0x06002CAC RID: 11436 RVA: 0x000567F1 File Offset: 0x000549F1
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

		// Token: 0x17000DDB RID: 3547
		// (get) Token: 0x06002CAD RID: 11437 RVA: 0x00056800 File Offset: 0x00054A00
		// (set) Token: 0x06002CAE RID: 11438 RVA: 0x00056820 File Offset: 0x00054A20
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

		// Token: 0x06002CAF RID: 11439 RVA: 0x00056864 File Offset: 0x00054A64
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06002CB0 RID: 11440 RVA: 0x0005687C File Offset: 0x00054A7C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06002CB1 RID: 11441 RVA: 0x00056888 File Offset: 0x00054A88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B0F RID: 2831
		private ulong? _time;

		// Token: 0x04000B10 RID: 2832
		private IExtension extensionObject;
	}
}
