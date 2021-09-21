using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000C7 RID: 199
	[ProtoContract(Name = "GetOnlineRewardArg")]
	[Serializable]
	public class GetOnlineRewardArg : IExtensible
	{
		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06000D23 RID: 3363 RVA: 0x0001B868 File Offset: 0x00019A68
		// (set) Token: 0x06000D24 RID: 3364 RVA: 0x0001B894 File Offset: 0x00019A94
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

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06000D25 RID: 3365 RVA: 0x0001B8A4 File Offset: 0x00019AA4
		// (set) Token: 0x06000D26 RID: 3366 RVA: 0x0001B8C4 File Offset: 0x00019AC4
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

		// Token: 0x06000D27 RID: 3367 RVA: 0x0001B908 File Offset: 0x00019B08
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x0001B920 File Offset: 0x00019B20
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x0001B92C File Offset: 0x00019B2C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400034B RID: 843
		private uint? _index;

		// Token: 0x0400034C RID: 844
		private IExtension extensionObject;
	}
}
