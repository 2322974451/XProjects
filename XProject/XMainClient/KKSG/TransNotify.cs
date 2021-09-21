using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004A5 RID: 1189
	[ProtoContract(Name = "TransNotify")]
	[Serializable]
	public class TransNotify : IExtensible
	{
		// Token: 0x170012F4 RID: 4852
		// (get) Token: 0x06003DDC RID: 15836 RVA: 0x00076090 File Offset: 0x00074290
		// (set) Token: 0x06003DDD RID: 15837 RVA: 0x000760BC File Offset: 0x000742BC
		[ProtoMember(1, IsRequired = false, Name = "istrans", DataFormat = DataFormat.Default)]
		public bool istrans
		{
			get
			{
				return this._istrans ?? false;
			}
			set
			{
				this._istrans = new bool?(value);
			}
		}

		// Token: 0x170012F5 RID: 4853
		// (get) Token: 0x06003DDE RID: 15838 RVA: 0x000760CC File Offset: 0x000742CC
		// (set) Token: 0x06003DDF RID: 15839 RVA: 0x000760EC File Offset: 0x000742EC
		[XmlIgnore]
		[Browsable(false)]
		public bool istransSpecified
		{
			get
			{
				return this._istrans != null;
			}
			set
			{
				bool flag = value == (this._istrans == null);
				if (flag)
				{
					this._istrans = (value ? new bool?(this.istrans) : null);
				}
			}
		}

		// Token: 0x06003DE0 RID: 15840 RVA: 0x00076130 File Offset: 0x00074330
		private bool ShouldSerializeistrans()
		{
			return this.istransSpecified;
		}

		// Token: 0x06003DE1 RID: 15841 RVA: 0x00076148 File Offset: 0x00074348
		private void Resetistrans()
		{
			this.istransSpecified = false;
		}

		// Token: 0x170012F6 RID: 4854
		// (get) Token: 0x06003DE2 RID: 15842 RVA: 0x00076154 File Offset: 0x00074354
		// (set) Token: 0x06003DE3 RID: 15843 RVA: 0x00076175 File Offset: 0x00074375
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.Default)]
		public string roleid
		{
			get
			{
				return this._roleid ?? "";
			}
			set
			{
				this._roleid = value;
			}
		}

		// Token: 0x170012F7 RID: 4855
		// (get) Token: 0x06003DE4 RID: 15844 RVA: 0x00076180 File Offset: 0x00074380
		// (set) Token: 0x06003DE5 RID: 15845 RVA: 0x0007619C File Offset: 0x0007439C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? this.roleid : null);
				}
			}
		}

		// Token: 0x06003DE6 RID: 15846 RVA: 0x000761CC File Offset: 0x000743CC
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003DE7 RID: 15847 RVA: 0x000761E4 File Offset: 0x000743E4
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06003DE8 RID: 15848 RVA: 0x000761F0 File Offset: 0x000743F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F68 RID: 3944
		private bool? _istrans;

		// Token: 0x04000F69 RID: 3945
		private string _roleid;

		// Token: 0x04000F6A RID: 3946
		private IExtension extensionObject;
	}
}
