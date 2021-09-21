using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000163 RID: 355
	[ProtoContract(Name = "TeamInviteArg")]
	[Serializable]
	public class TeamInviteArg : IExtensible
	{
		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x06001582 RID: 5506 RVA: 0x0002B364 File Offset: 0x00029564
		// (set) Token: 0x06001583 RID: 5507 RVA: 0x0002B390 File Offset: 0x00029590
		[ProtoMember(1, IsRequired = false, Name = "expid", DataFormat = DataFormat.TwosComplement)]
		public int expid
		{
			get
			{
				return this._expid ?? 0;
			}
			set
			{
				this._expid = new int?(value);
			}
		}

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x06001584 RID: 5508 RVA: 0x0002B3A0 File Offset: 0x000295A0
		// (set) Token: 0x06001585 RID: 5509 RVA: 0x0002B3C0 File Offset: 0x000295C0
		[XmlIgnore]
		[Browsable(false)]
		public bool expidSpecified
		{
			get
			{
				return this._expid != null;
			}
			set
			{
				bool flag = value == (this._expid == null);
				if (flag)
				{
					this._expid = (value ? new int?(this.expid) : null);
				}
			}
		}

		// Token: 0x06001586 RID: 5510 RVA: 0x0002B404 File Offset: 0x00029604
		private bool ShouldSerializeexpid()
		{
			return this.expidSpecified;
		}

		// Token: 0x06001587 RID: 5511 RVA: 0x0002B41C File Offset: 0x0002961C
		private void Resetexpid()
		{
			this.expidSpecified = false;
		}

		// Token: 0x06001588 RID: 5512 RVA: 0x0002B428 File Offset: 0x00029628
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000558 RID: 1368
		private int? _expid;

		// Token: 0x04000559 RID: 1369
		private IExtension extensionObject;
	}
}
