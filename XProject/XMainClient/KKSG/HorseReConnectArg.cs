using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000329 RID: 809
	[ProtoContract(Name = "HorseReConnectArg")]
	[Serializable]
	public class HorseReConnectArg : IExtensible
	{
		// Token: 0x17000DD8 RID: 3544
		// (get) Token: 0x06002CA3 RID: 11427 RVA: 0x000566E0 File Offset: 0x000548E0
		// (set) Token: 0x06002CA4 RID: 11428 RVA: 0x0005670C File Offset: 0x0005490C
		[ProtoMember(1, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		// Token: 0x17000DD9 RID: 3545
		// (get) Token: 0x06002CA5 RID: 11429 RVA: 0x0005671C File Offset: 0x0005491C
		// (set) Token: 0x06002CA6 RID: 11430 RVA: 0x0005673C File Offset: 0x0005493C
		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		// Token: 0x06002CA7 RID: 11431 RVA: 0x00056780 File Offset: 0x00054980
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x06002CA8 RID: 11432 RVA: 0x00056798 File Offset: 0x00054998
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x06002CA9 RID: 11433 RVA: 0x000567A4 File Offset: 0x000549A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B0D RID: 2829
		private uint? _param;

		// Token: 0x04000B0E RID: 2830
		private IExtension extensionObject;
	}
}
