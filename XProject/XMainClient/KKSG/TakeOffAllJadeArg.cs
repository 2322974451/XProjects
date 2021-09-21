using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200018D RID: 397
	[ProtoContract(Name = "TakeOffAllJadeArg")]
	[Serializable]
	public class TakeOffAllJadeArg : IExtensible
	{
		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x0600180D RID: 6157 RVA: 0x0002FF90 File Offset: 0x0002E190
		// (set) Token: 0x0600180E RID: 6158 RVA: 0x0002FFBD File Offset: 0x0002E1BD
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x0600180F RID: 6159 RVA: 0x0002FFCC File Offset: 0x0002E1CC
		// (set) Token: 0x06001810 RID: 6160 RVA: 0x0002FFEC File Offset: 0x0002E1EC
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06001811 RID: 6161 RVA: 0x00030030 File Offset: 0x0002E230
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06001812 RID: 6162 RVA: 0x00030048 File Offset: 0x0002E248
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x06001813 RID: 6163 RVA: 0x00030054 File Offset: 0x0002E254
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005F0 RID: 1520
		private ulong? _uid;

		// Token: 0x040005F1 RID: 1521
		private IExtension extensionObject;
	}
}
