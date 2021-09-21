using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000506 RID: 1286
	[ProtoContract(Name = "PeerBoxArg")]
	[Serializable]
	public class PeerBoxArg : IExtensible
	{
		// Token: 0x1700144E RID: 5198
		// (get) Token: 0x0600425B RID: 16987 RVA: 0x0007E508 File Offset: 0x0007C708
		// (set) Token: 0x0600425C RID: 16988 RVA: 0x0007E534 File Offset: 0x0007C734
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x1700144F RID: 5199
		// (get) Token: 0x0600425D RID: 16989 RVA: 0x0007E544 File Offset: 0x0007C744
		// (set) Token: 0x0600425E RID: 16990 RVA: 0x0007E564 File Offset: 0x0007C764
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x0600425F RID: 16991 RVA: 0x0007E5A8 File Offset: 0x0007C7A8
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06004260 RID: 16992 RVA: 0x0007E5C0 File Offset: 0x0007C7C0
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06004261 RID: 16993 RVA: 0x0007E5CC File Offset: 0x0007C7CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400108C RID: 4236
		private uint? _index;

		// Token: 0x0400108D RID: 4237
		private IExtension extensionObject;
	}
}
