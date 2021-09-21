using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000365 RID: 869
	[ProtoContract(Name = "ResWarEnemyTime")]
	[Serializable]
	public class ResWarEnemyTime : IExtensible
	{
		// Token: 0x17000EB0 RID: 3760
		// (get) Token: 0x06002F6F RID: 12143 RVA: 0x0005B8D8 File Offset: 0x00059AD8
		// (set) Token: 0x06002F70 RID: 12144 RVA: 0x0005B904 File Offset: 0x00059B04
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

		// Token: 0x17000EB1 RID: 3761
		// (get) Token: 0x06002F71 RID: 12145 RVA: 0x0005B914 File Offset: 0x00059B14
		// (set) Token: 0x06002F72 RID: 12146 RVA: 0x0005B934 File Offset: 0x00059B34
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

		// Token: 0x06002F73 RID: 12147 RVA: 0x0005B978 File Offset: 0x00059B78
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x06002F74 RID: 12148 RVA: 0x0005B990 File Offset: 0x00059B90
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x06002F75 RID: 12149 RVA: 0x0005B99C File Offset: 0x00059B9C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BC3 RID: 3011
		private uint? _param;

		// Token: 0x04000BC4 RID: 3012
		private IExtension extensionObject;
	}
}
