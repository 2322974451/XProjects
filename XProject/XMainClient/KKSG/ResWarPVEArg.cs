using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002AF RID: 687
	[ProtoContract(Name = "ResWarPVEArg")]
	[Serializable]
	public class ResWarPVEArg : IExtensible
	{
		// Token: 0x17000BF3 RID: 3059
		// (get) Token: 0x06002662 RID: 9826 RVA: 0x0004AB78 File Offset: 0x00048D78
		// (set) Token: 0x06002663 RID: 9827 RVA: 0x0004ABA4 File Offset: 0x00048DA4
		[ProtoMember(1, IsRequired = false, Name = "mine", DataFormat = DataFormat.TwosComplement)]
		public uint mine
		{
			get
			{
				return this._mine ?? 0U;
			}
			set
			{
				this._mine = new uint?(value);
			}
		}

		// Token: 0x17000BF4 RID: 3060
		// (get) Token: 0x06002664 RID: 9828 RVA: 0x0004ABB4 File Offset: 0x00048DB4
		// (set) Token: 0x06002665 RID: 9829 RVA: 0x0004ABD4 File Offset: 0x00048DD4
		[XmlIgnore]
		[Browsable(false)]
		public bool mineSpecified
		{
			get
			{
				return this._mine != null;
			}
			set
			{
				bool flag = value == (this._mine == null);
				if (flag)
				{
					this._mine = (value ? new uint?(this.mine) : null);
				}
			}
		}

		// Token: 0x06002666 RID: 9830 RVA: 0x0004AC18 File Offset: 0x00048E18
		private bool ShouldSerializemine()
		{
			return this.mineSpecified;
		}

		// Token: 0x06002667 RID: 9831 RVA: 0x0004AC30 File Offset: 0x00048E30
		private void Resetmine()
		{
			this.mineSpecified = false;
		}

		// Token: 0x06002668 RID: 9832 RVA: 0x0004AC3C File Offset: 0x00048E3C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000986 RID: 2438
		private uint? _mine;

		// Token: 0x04000987 RID: 2439
		private IExtension extensionObject;
	}
}
