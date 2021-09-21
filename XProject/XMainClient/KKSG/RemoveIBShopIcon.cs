using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000217 RID: 535
	[ProtoContract(Name = "RemoveIBShopIcon")]
	[Serializable]
	public class RemoveIBShopIcon : IExtensible
	{
		// Token: 0x17000963 RID: 2403
		// (get) Token: 0x06001E03 RID: 7683 RVA: 0x0003AFB4 File Offset: 0x000391B4
		// (set) Token: 0x06001E04 RID: 7684 RVA: 0x0003AFE0 File Offset: 0x000391E0
		[ProtoMember(1, IsRequired = false, Name = "nData", DataFormat = DataFormat.TwosComplement)]
		public uint nData
		{
			get
			{
				return this._nData ?? 0U;
			}
			set
			{
				this._nData = new uint?(value);
			}
		}

		// Token: 0x17000964 RID: 2404
		// (get) Token: 0x06001E05 RID: 7685 RVA: 0x0003AFF0 File Offset: 0x000391F0
		// (set) Token: 0x06001E06 RID: 7686 RVA: 0x0003B010 File Offset: 0x00039210
		[XmlIgnore]
		[Browsable(false)]
		public bool nDataSpecified
		{
			get
			{
				return this._nData != null;
			}
			set
			{
				bool flag = value == (this._nData == null);
				if (flag)
				{
					this._nData = (value ? new uint?(this.nData) : null);
				}
			}
		}

		// Token: 0x06001E07 RID: 7687 RVA: 0x0003B054 File Offset: 0x00039254
		private bool ShouldSerializenData()
		{
			return this.nDataSpecified;
		}

		// Token: 0x06001E08 RID: 7688 RVA: 0x0003B06C File Offset: 0x0003926C
		private void ResetnData()
		{
			this.nDataSpecified = false;
		}

		// Token: 0x06001E09 RID: 7689 RVA: 0x0003B078 File Offset: 0x00039278
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000781 RID: 1921
		private uint? _nData;

		// Token: 0x04000782 RID: 1922
		private IExtension extensionObject;
	}
}
