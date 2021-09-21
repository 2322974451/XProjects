using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000462 RID: 1122
	[ProtoContract(Name = "SelectHeroAncientPowerArg")]
	[Serializable]
	public class SelectHeroAncientPowerArg : IExtensible
	{
		// Token: 0x17001209 RID: 4617
		// (get) Token: 0x06003AD3 RID: 15059 RVA: 0x00070760 File Offset: 0x0006E960
		// (set) Token: 0x06003AD4 RID: 15060 RVA: 0x0007078C File Offset: 0x0006E98C
		[ProtoMember(1, IsRequired = false, Name = "selectpower", DataFormat = DataFormat.TwosComplement)]
		public uint selectpower
		{
			get
			{
				return this._selectpower ?? 0U;
			}
			set
			{
				this._selectpower = new uint?(value);
			}
		}

		// Token: 0x1700120A RID: 4618
		// (get) Token: 0x06003AD5 RID: 15061 RVA: 0x0007079C File Offset: 0x0006E99C
		// (set) Token: 0x06003AD6 RID: 15062 RVA: 0x000707BC File Offset: 0x0006E9BC
		[XmlIgnore]
		[Browsable(false)]
		public bool selectpowerSpecified
		{
			get
			{
				return this._selectpower != null;
			}
			set
			{
				bool flag = value == (this._selectpower == null);
				if (flag)
				{
					this._selectpower = (value ? new uint?(this.selectpower) : null);
				}
			}
		}

		// Token: 0x06003AD7 RID: 15063 RVA: 0x00070800 File Offset: 0x0006EA00
		private bool ShouldSerializeselectpower()
		{
			return this.selectpowerSpecified;
		}

		// Token: 0x06003AD8 RID: 15064 RVA: 0x00070818 File Offset: 0x0006EA18
		private void Resetselectpower()
		{
			this.selectpowerSpecified = false;
		}

		// Token: 0x06003AD9 RID: 15065 RVA: 0x00070824 File Offset: 0x0006EA24
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E9D RID: 3741
		private uint? _selectpower;

		// Token: 0x04000E9E RID: 3742
		private IExtension extensionObject;
	}
}
