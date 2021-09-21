using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000075 RID: 117
	[ProtoContract(Name = "RemoveFriendArg")]
	[Serializable]
	public class RemoveFriendArg : IExtensible
	{
		// Token: 0x17000288 RID: 648
		// (get) Token: 0x060007CB RID: 1995 RVA: 0x000117E4 File Offset: 0x0000F9E4
		// (set) Token: 0x060007CC RID: 1996 RVA: 0x00011811 File Offset: 0x0000FA11
		[ProtoMember(1, IsRequired = false, Name = "friendroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong friendroleid
		{
			get
			{
				return this._friendroleid ?? 0UL;
			}
			set
			{
				this._friendroleid = new ulong?(value);
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x00011820 File Offset: 0x0000FA20
		// (set) Token: 0x060007CE RID: 1998 RVA: 0x00011840 File Offset: 0x0000FA40
		[XmlIgnore]
		[Browsable(false)]
		public bool friendroleidSpecified
		{
			get
			{
				return this._friendroleid != null;
			}
			set
			{
				bool flag = value == (this._friendroleid == null);
				if (flag)
				{
					this._friendroleid = (value ? new ulong?(this.friendroleid) : null);
				}
			}
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00011884 File Offset: 0x0000FA84
		private bool ShouldSerializefriendroleid()
		{
			return this.friendroleidSpecified;
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0001189C File Offset: 0x0000FA9C
		private void Resetfriendroleid()
		{
			this.friendroleidSpecified = false;
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x000118A8 File Offset: 0x0000FAA8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001F9 RID: 505
		private ulong? _friendroleid;

		// Token: 0x040001FA RID: 506
		private IExtension extensionObject;
	}
}
