using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005BA RID: 1466
	[ProtoContract(Name = "LoginExtraData")]
	[Serializable]
	public class LoginExtraData : IExtensible
	{
		// Token: 0x17001944 RID: 6468
		// (get) Token: 0x060051BF RID: 20927 RVA: 0x0009B75C File Offset: 0x0009995C
		// (set) Token: 0x060051C0 RID: 20928 RVA: 0x0009B788 File Offset: 0x00099988
		[ProtoMember(1, IsRequired = false, Name = "is_backflow_server", DataFormat = DataFormat.Default)]
		public bool is_backflow_server
		{
			get
			{
				return this._is_backflow_server ?? false;
			}
			set
			{
				this._is_backflow_server = new bool?(value);
			}
		}

		// Token: 0x17001945 RID: 6469
		// (get) Token: 0x060051C1 RID: 20929 RVA: 0x0009B798 File Offset: 0x00099998
		// (set) Token: 0x060051C2 RID: 20930 RVA: 0x0009B7B8 File Offset: 0x000999B8
		[XmlIgnore]
		[Browsable(false)]
		public bool is_backflow_serverSpecified
		{
			get
			{
				return this._is_backflow_server != null;
			}
			set
			{
				bool flag = value == (this._is_backflow_server == null);
				if (flag)
				{
					this._is_backflow_server = (value ? new bool?(this.is_backflow_server) : null);
				}
			}
		}

		// Token: 0x060051C3 RID: 20931 RVA: 0x0009B7FC File Offset: 0x000999FC
		private bool ShouldSerializeis_backflow_server()
		{
			return this.is_backflow_serverSpecified;
		}

		// Token: 0x060051C4 RID: 20932 RVA: 0x0009B814 File Offset: 0x00099A14
		private void Resetis_backflow_server()
		{
			this.is_backflow_serverSpecified = false;
		}

		// Token: 0x17001946 RID: 6470
		// (get) Token: 0x060051C5 RID: 20933 RVA: 0x0009B820 File Offset: 0x00099A20
		// (set) Token: 0x060051C6 RID: 20934 RVA: 0x0009B84C File Offset: 0x00099A4C
		[ProtoMember(2, IsRequired = false, Name = "backflow_level", DataFormat = DataFormat.TwosComplement)]
		public uint backflow_level
		{
			get
			{
				return this._backflow_level ?? 0U;
			}
			set
			{
				this._backflow_level = new uint?(value);
			}
		}

		// Token: 0x17001947 RID: 6471
		// (get) Token: 0x060051C7 RID: 20935 RVA: 0x0009B85C File Offset: 0x00099A5C
		// (set) Token: 0x060051C8 RID: 20936 RVA: 0x0009B87C File Offset: 0x00099A7C
		[XmlIgnore]
		[Browsable(false)]
		public bool backflow_levelSpecified
		{
			get
			{
				return this._backflow_level != null;
			}
			set
			{
				bool flag = value == (this._backflow_level == null);
				if (flag)
				{
					this._backflow_level = (value ? new uint?(this.backflow_level) : null);
				}
			}
		}

		// Token: 0x060051C9 RID: 20937 RVA: 0x0009B8C0 File Offset: 0x00099AC0
		private bool ShouldSerializebackflow_level()
		{
			return this.backflow_levelSpecified;
		}

		// Token: 0x060051CA RID: 20938 RVA: 0x0009B8D8 File Offset: 0x00099AD8
		private void Resetbackflow_level()
		{
			this.backflow_levelSpecified = false;
		}

		// Token: 0x060051CB RID: 20939 RVA: 0x0009B8E4 File Offset: 0x00099AE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001403 RID: 5123
		private bool? _is_backflow_server;

		// Token: 0x04001404 RID: 5124
		private uint? _backflow_level;

		// Token: 0x04001405 RID: 5125
		private IExtension extensionObject;
	}
}
