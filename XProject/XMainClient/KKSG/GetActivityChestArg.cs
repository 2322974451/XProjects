using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000049 RID: 73
	[ProtoContract(Name = "GetActivityChestArg")]
	[Serializable]
	public class GetActivityChestArg : IExtensible
	{
		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x0000C3D8 File Offset: 0x0000A5D8
		// (set) Token: 0x060004FC RID: 1276 RVA: 0x0000C404 File Offset: 0x0000A604
		[ProtoMember(1, IsRequired = false, Name = "ChestIndex", DataFormat = DataFormat.TwosComplement)]
		public uint ChestIndex
		{
			get
			{
				return this._ChestIndex ?? 0U;
			}
			set
			{
				this._ChestIndex = new uint?(value);
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0000C414 File Offset: 0x0000A614
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x0000C434 File Offset: 0x0000A634
		[XmlIgnore]
		[Browsable(false)]
		public bool ChestIndexSpecified
		{
			get
			{
				return this._ChestIndex != null;
			}
			set
			{
				bool flag = value == (this._ChestIndex == null);
				if (flag)
				{
					this._ChestIndex = (value ? new uint?(this.ChestIndex) : null);
				}
			}
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0000C478 File Offset: 0x0000A678
		private bool ShouldSerializeChestIndex()
		{
			return this.ChestIndexSpecified;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0000C490 File Offset: 0x0000A690
		private void ResetChestIndex()
		{
			this.ChestIndexSpecified = false;
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0000C49C File Offset: 0x0000A69C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000149 RID: 329
		private uint? _ChestIndex;

		// Token: 0x0400014A RID: 330
		private IExtension extensionObject;
	}
}
