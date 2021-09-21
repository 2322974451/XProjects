using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200037C RID: 892
	[ProtoContract(Name = "LeagueBattleReqArg")]
	[Serializable]
	public class LeagueBattleReqArg : IExtensible
	{
		// Token: 0x17000F0D RID: 3853
		// (get) Token: 0x0600309C RID: 12444 RVA: 0x0005DC18 File Offset: 0x0005BE18
		// (set) Token: 0x0600309D RID: 12445 RVA: 0x0005DC44 File Offset: 0x0005BE44
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleReqType type
		{
			get
			{
				return this._type ?? LeagueBattleReqType.LBReqType_Match;
			}
			set
			{
				this._type = new LeagueBattleReqType?(value);
			}
		}

		// Token: 0x17000F0E RID: 3854
		// (get) Token: 0x0600309E RID: 12446 RVA: 0x0005DC54 File Offset: 0x0005BE54
		// (set) Token: 0x0600309F RID: 12447 RVA: 0x0005DC74 File Offset: 0x0005BE74
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new LeagueBattleReqType?(this.type) : null);
				}
			}
		}

		// Token: 0x060030A0 RID: 12448 RVA: 0x0005DCB8 File Offset: 0x0005BEB8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060030A1 RID: 12449 RVA: 0x0005DCD0 File Offset: 0x0005BED0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x060030A2 RID: 12450 RVA: 0x0005DCDC File Offset: 0x0005BEDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C0F RID: 3087
		private LeagueBattleReqType? _type;

		// Token: 0x04000C10 RID: 3088
		private IExtension extensionObject;
	}
}
