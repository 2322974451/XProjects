using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002EE RID: 750
	[ProtoContract(Name = "LeaveLargeRoomParam")]
	[Serializable]
	public class LeaveLargeRoomParam : IExtensible
	{
		// Token: 0x17000CD5 RID: 3285
		// (get) Token: 0x06002955 RID: 10581 RVA: 0x000503C4 File Offset: 0x0004E5C4
		// (set) Token: 0x06002956 RID: 10582 RVA: 0x000503F0 File Offset: 0x0004E5F0
		[ProtoMember(1, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		// Token: 0x17000CD6 RID: 3286
		// (get) Token: 0x06002957 RID: 10583 RVA: 0x00050400 File Offset: 0x0004E600
		// (set) Token: 0x06002958 RID: 10584 RVA: 0x00050420 File Offset: 0x0004E620
		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		// Token: 0x06002959 RID: 10585 RVA: 0x00050464 File Offset: 0x0004E664
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x0600295A RID: 10586 RVA: 0x0005047C File Offset: 0x0004E67C
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x0600295B RID: 10587 RVA: 0x00050488 File Offset: 0x0004E688
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A43 RID: 2627
		private uint? _param;

		// Token: 0x04000A44 RID: 2628
		private IExtension extensionObject;
	}
}
