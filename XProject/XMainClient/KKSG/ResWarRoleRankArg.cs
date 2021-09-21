using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002BD RID: 701
	[ProtoContract(Name = "ResWarRoleRankArg")]
	[Serializable]
	public class ResWarRoleRankArg : IExtensible
	{
		// Token: 0x17000C1C RID: 3100
		// (get) Token: 0x060026EF RID: 9967 RVA: 0x0004BBD4 File Offset: 0x00049DD4
		// (set) Token: 0x060026F0 RID: 9968 RVA: 0x0004BC00 File Offset: 0x00049E00
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

		// Token: 0x17000C1D RID: 3101
		// (get) Token: 0x060026F1 RID: 9969 RVA: 0x0004BC10 File Offset: 0x00049E10
		// (set) Token: 0x060026F2 RID: 9970 RVA: 0x0004BC30 File Offset: 0x00049E30
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

		// Token: 0x060026F3 RID: 9971 RVA: 0x0004BC74 File Offset: 0x00049E74
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x060026F4 RID: 9972 RVA: 0x0004BC8C File Offset: 0x00049E8C
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x060026F5 RID: 9973 RVA: 0x0004BC98 File Offset: 0x00049E98
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009AB RID: 2475
		private uint? _param;

		// Token: 0x040009AC RID: 2476
		private IExtension extensionObject;
	}
}
