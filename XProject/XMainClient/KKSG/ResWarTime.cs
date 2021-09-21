using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002F4 RID: 756
	[ProtoContract(Name = "ResWarTime")]
	[Serializable]
	public class ResWarTime : IExtensible
	{
		// Token: 0x17000CE3 RID: 3299
		// (get) Token: 0x06002987 RID: 10631 RVA: 0x0005096C File Offset: 0x0004EB6C
		// (set) Token: 0x06002988 RID: 10632 RVA: 0x00050998 File Offset: 0x0004EB98
		[ProtoMember(1, IsRequired = false, Name = "nTime", DataFormat = DataFormat.TwosComplement)]
		public uint nTime
		{
			get
			{
				return this._nTime ?? 0U;
			}
			set
			{
				this._nTime = new uint?(value);
			}
		}

		// Token: 0x17000CE4 RID: 3300
		// (get) Token: 0x06002989 RID: 10633 RVA: 0x000509A8 File Offset: 0x0004EBA8
		// (set) Token: 0x0600298A RID: 10634 RVA: 0x000509C8 File Offset: 0x0004EBC8
		[XmlIgnore]
		[Browsable(false)]
		public bool nTimeSpecified
		{
			get
			{
				return this._nTime != null;
			}
			set
			{
				bool flag = value == (this._nTime == null);
				if (flag)
				{
					this._nTime = (value ? new uint?(this.nTime) : null);
				}
			}
		}

		// Token: 0x0600298B RID: 10635 RVA: 0x00050A0C File Offset: 0x0004EC0C
		private bool ShouldSerializenTime()
		{
			return this.nTimeSpecified;
		}

		// Token: 0x0600298C RID: 10636 RVA: 0x00050A24 File Offset: 0x0004EC24
		private void ResetnTime()
		{
			this.nTimeSpecified = false;
		}

		// Token: 0x0600298D RID: 10637 RVA: 0x00050A30 File Offset: 0x0004EC30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A51 RID: 2641
		private uint? _nTime;

		// Token: 0x04000A52 RID: 2642
		private IExtension extensionObject;
	}
}
