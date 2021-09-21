using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000185 RID: 389
	[ProtoContract(Name = "BossRushArg")]
	[Serializable]
	public class BossRushArg : IExtensible
	{
		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x06001776 RID: 6006 RVA: 0x0002EE1C File Offset: 0x0002D01C
		// (set) Token: 0x06001777 RID: 6007 RVA: 0x0002EE48 File Offset: 0x0002D048
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public BossRushReqStatus type
		{
			get
			{
				return this._type ?? BossRushReqStatus.BOSSRUSH_RESULT_WIN;
			}
			set
			{
				this._type = new BossRushReqStatus?(value);
			}
		}

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x06001778 RID: 6008 RVA: 0x0002EE58 File Offset: 0x0002D058
		// (set) Token: 0x06001779 RID: 6009 RVA: 0x0002EE78 File Offset: 0x0002D078
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
					this._type = (value ? new BossRushReqStatus?(this.type) : null);
				}
			}
		}

		// Token: 0x0600177A RID: 6010 RVA: 0x0002EEBC File Offset: 0x0002D0BC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x0002EED4 File Offset: 0x0002D0D4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x0600177C RID: 6012 RVA: 0x0002EEE0 File Offset: 0x0002D0E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005CC RID: 1484
		private BossRushReqStatus? _type;

		// Token: 0x040005CD RID: 1485
		private IExtension extensionObject;
	}
}
