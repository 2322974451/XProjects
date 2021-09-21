using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000297 RID: 663
	[ProtoContract(Name = "ResWarExploreArg")]
	[Serializable]
	public class ResWarExploreArg : IExtensible
	{
		// Token: 0x17000B84 RID: 2948
		// (get) Token: 0x06002510 RID: 9488 RVA: 0x000483C8 File Offset: 0x000465C8
		// (set) Token: 0x06002511 RID: 9489 RVA: 0x000483F4 File Offset: 0x000465F4
		[ProtoMember(1, IsRequired = false, Name = "iscancel", DataFormat = DataFormat.Default)]
		public bool iscancel
		{
			get
			{
				return this._iscancel ?? false;
			}
			set
			{
				this._iscancel = new bool?(value);
			}
		}

		// Token: 0x17000B85 RID: 2949
		// (get) Token: 0x06002512 RID: 9490 RVA: 0x00048404 File Offset: 0x00046604
		// (set) Token: 0x06002513 RID: 9491 RVA: 0x00048424 File Offset: 0x00046624
		[XmlIgnore]
		[Browsable(false)]
		public bool iscancelSpecified
		{
			get
			{
				return this._iscancel != null;
			}
			set
			{
				bool flag = value == (this._iscancel == null);
				if (flag)
				{
					this._iscancel = (value ? new bool?(this.iscancel) : null);
				}
			}
		}

		// Token: 0x06002514 RID: 9492 RVA: 0x00048468 File Offset: 0x00046668
		private bool ShouldSerializeiscancel()
		{
			return this.iscancelSpecified;
		}

		// Token: 0x06002515 RID: 9493 RVA: 0x00048480 File Offset: 0x00046680
		private void Resetiscancel()
		{
			this.iscancelSpecified = false;
		}

		// Token: 0x06002516 RID: 9494 RVA: 0x0004848C File Offset: 0x0004668C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000929 RID: 2345
		private bool? _iscancel;

		// Token: 0x0400092A RID: 2346
		private IExtension extensionObject;
	}
}
