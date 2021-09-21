using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000020 RID: 32
	[ProtoContract(Name = "SelectChestArg")]
	[Serializable]
	public class SelectChestArg : IExtensible
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000267 RID: 615 RVA: 0x000074D0 File Offset: 0x000056D0
		// (set) Token: 0x06000268 RID: 616 RVA: 0x000074FC File Offset: 0x000056FC
		[ProtoMember(1, IsRequired = false, Name = "chestIdx", DataFormat = DataFormat.TwosComplement)]
		public uint chestIdx
		{
			get
			{
				return this._chestIdx ?? 0U;
			}
			set
			{
				this._chestIdx = new uint?(value);
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000750C File Offset: 0x0000570C
		// (set) Token: 0x0600026A RID: 618 RVA: 0x0000752C File Offset: 0x0000572C
		[XmlIgnore]
		[Browsable(false)]
		public bool chestIdxSpecified
		{
			get
			{
				return this._chestIdx != null;
			}
			set
			{
				bool flag = value == (this._chestIdx == null);
				if (flag)
				{
					this._chestIdx = (value ? new uint?(this.chestIdx) : null);
				}
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00007570 File Offset: 0x00005770
		private bool ShouldSerializechestIdx()
		{
			return this.chestIdxSpecified;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00007588 File Offset: 0x00005788
		private void ResetchestIdx()
		{
			this.chestIdxSpecified = false;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00007594 File Offset: 0x00005794
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000A4 RID: 164
		private uint? _chestIdx;

		// Token: 0x040000A5 RID: 165
		private IExtension extensionObject;
	}
}
