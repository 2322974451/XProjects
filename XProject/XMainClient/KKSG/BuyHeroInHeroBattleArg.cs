using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000368 RID: 872
	[ProtoContract(Name = "BuyHeroInHeroBattleArg")]
	[Serializable]
	public class BuyHeroInHeroBattleArg : IExtensible
	{
		// Token: 0x17000EB5 RID: 3765
		// (get) Token: 0x06002F82 RID: 12162 RVA: 0x0005BAEC File Offset: 0x00059CEC
		// (set) Token: 0x06002F83 RID: 12163 RVA: 0x0005BB18 File Offset: 0x00059D18
		[ProtoMember(1, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		// Token: 0x17000EB6 RID: 3766
		// (get) Token: 0x06002F84 RID: 12164 RVA: 0x0005BB28 File Offset: 0x00059D28
		// (set) Token: 0x06002F85 RID: 12165 RVA: 0x0005BB48 File Offset: 0x00059D48
		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		// Token: 0x06002F86 RID: 12166 RVA: 0x0005BB8C File Offset: 0x00059D8C
		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		// Token: 0x06002F87 RID: 12167 RVA: 0x0005BBA4 File Offset: 0x00059DA4
		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		// Token: 0x06002F88 RID: 12168 RVA: 0x0005BBB0 File Offset: 0x00059DB0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BC9 RID: 3017
		private uint? _heroid;

		// Token: 0x04000BCA RID: 3018
		private IExtension extensionObject;
	}
}
