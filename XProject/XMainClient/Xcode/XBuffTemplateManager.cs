using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffTemplateManager : XSingleton<XBuffTemplateManager>
	{

		public int GetBuffKey(int buffID, int buffLevel)
		{
			return buffID << 8 | buffLevel;
		}

		public void GetBuffIdentity(int buffKey, out int buffID, out int buffLevel)
		{
			buffID = buffKey >> 8;
			buffLevel = (buffKey & 15);
		}

		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/BuffList", this.m_BuffConfig, false);
				this._async_loader.AddTask("Table/BuffListPVP", this.m_BuffConfigPVP, false);
				this._async_loader.Execute(null);
			}
			bool flag2 = !this._async_loader.IsDone;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < this.m_BuffConfig.Table.Length; i++)
				{
					BuffTable.RowData rowData = this.m_BuffConfig.Table[i];
					int buffKey = this.GetBuffKey(rowData.BuffID, (int)rowData.BuffLevel);
					this.m_BuffIndex.Add(buffKey, rowData);
				}
				this.m_BuffConfig.Clear();
				for (int j = 0; j < this.m_BuffConfigPVP.Table.Length; j++)
				{
					BuffTable.RowData rowData2 = this.m_BuffConfigPVP.Table[j];
					int buffKey2 = this.GetBuffKey(rowData2.BuffID, (int)rowData2.BuffLevel);
					this.m_BuffIndexPVP.Add(buffKey2, rowData2);
				}
				this.m_BuffConfigPVP.Clear();
				result = true;
			}
			return result;
		}

		public override void Uninit()
		{
			this.m_BuffIndex.Clear();
			this.m_BuffIndexPVP.Clear();
			this._async_loader = null;
		}

		private bool CanUseBuff(int sceneType, BuffTable.RowData row)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = row.SceneEffect != null && row.SceneEffect.Length != 0;
			if (flag5)
			{
				for (int i = 0; i < row.SceneEffect.Length; i++)
				{
					int num = (int)row.SceneEffect[i];
					bool flag6 = num > 0;
					if (flag6)
					{
						flag4 = true;
						bool flag7 = num == sceneType;
						if (flag7)
						{
							flag2 = true;
						}
					}
					else
					{
						flag3 = true;
						bool flag8 = -num == sceneType;
						if (flag8)
						{
							flag = true;
						}
					}
				}
			}
			bool flag9 = flag4 && flag2;
			bool result;
			if (flag9)
			{
				result = true;
			}
			else
			{
				bool flag10 = flag3 && !flag;
				result = (flag10 || (!flag4 && !flag3));
			}
			return result;
		}

		public XBuff CreateBuff(BuffDesc buffDesc, CombatEffectHelper pEffectHelper)
		{
			int sceneType = XFastEnumIntEqualityComparer<SceneType>.ToInt(XSingleton<XScene>.singleton.SceneType);
			int buffKey = this.GetBuffKey(buffDesc.BuffID, buffDesc.BuffLevel);
			BuffTable.RowData row = null;
			bool flag = true;
			bool flag2 = this.m_BuffIndexPVP.TryGetValue(buffKey, out row);
			if (flag2)
			{
				flag = this.CanUseBuff(sceneType, row);
			}
			row = null;
			bool flag3 = true;
			bool flag4 = this.m_BuffIndex.TryGetValue(buffKey, out row);
			if (flag4)
			{
				flag3 = this.CanUseBuff(sceneType, row);
			}
			bool flag5 = !flag || !flag3;
			XBuff result;
			if (flag5)
			{
				result = null;
			}
			else
			{
				result = new XBuff(pEffectHelper, ref buffDesc);
			}
			return result;
		}

		public int GetBuffTargetType(int BuffID)
		{
			BuffTable.RowData buffData = this.GetBuffData(BuffID, 1);
			bool flag = buffData == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				result = (int)buffData.TargetType;
			}
			return result;
		}

		public BuffTable.RowData GetBuffData(int BuffID, int BuffLevel)
		{
			BuffTable.RowData rowData = null;
			int buffKey = this.GetBuffKey(BuffID, BuffLevel);
			bool isPVPScene = XSingleton<XScene>.singleton.IsPVPScene;
			if (isPVPScene)
			{
				this.m_BuffIndexPVP.TryGetValue(buffKey, out rowData);
			}
			bool flag = rowData == null && !this.m_BuffIndex.TryGetValue(buffKey, out rowData);
			BuffTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = rowData;
			}
			return result;
		}

		private XTableAsyncLoader _async_loader = null;

		private BuffTable m_BuffConfig = new BuffTable();

		private BuffTable m_BuffConfigPVP = new BuffTable();

		private Dictionary<int, BuffTable.RowData> m_BuffIndex = new Dictionary<int, BuffTable.RowData>();

		private Dictionary<int, BuffTable.RowData> m_BuffIndexPVP = new Dictionary<int, BuffTable.RowData>();

		private enum BuffTypeEM
		{

			BUFFTYPE_CHANGE_ATTRIBUTE = 1,

			BUFFTYPE_CHANGE_STATUS,

			BUFFTYPE_STUN
		}
	}
}
