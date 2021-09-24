using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEquipDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XEquipDocument.uuID;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XEquipDocument.AsyncLoader.AddTask("Table/DefaultEquip", XEquipDocument.m_defaultEquip, false);
			XEquipDocument.AsyncLoader.AddTask("Table/EnhanceFx", XEquipDocument.m_EnhanceFxTable, false);
			XEquipDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
			EnhanceFxTable.RowData rowData = null;
			for (int i = 0; i < XEquipDocument.m_EnhanceFxTable.Table.Length; i++)
			{
				EnhanceFxTable.RowData rowData2 = XEquipDocument.m_EnhanceFxTable.Table[i];
				bool flag = rowData2 != null;
				if (flag)
				{
					bool flag2 = rowData2.ProfID > XEquipDocument.maxProf;
					if (flag2)
					{
						XEquipDocument.maxProf = rowData2.ProfID;
					}
					bool flag3 = rowData2.EnhanceLevel > XEquipDocument.maxEnhanceLevel;
					if (flag3)
					{
						XEquipDocument.maxEnhanceLevel = rowData2.EnhanceLevel;
					}
					bool flag4 = rowData != null && XEquipDocument.enhanceIndexed;
					if (flag4)
					{
						bool flag5 = (rowData2.ProfID - rowData.ProfID <= 1U && rowData2.EnhanceLevel - rowData.EnhanceLevel == 1U) || rowData.EnhanceLevel - rowData2.EnhanceLevel + 1U == XEquipDocument.maxEnhanceLevel;
						if (!flag5)
						{
							XEquipDocument.enhanceIndexed = false;
						}
					}
					rowData = rowData2;
				}
			}
			XEquipDocument._CombineMeshUtility = new CombineMeshUtility();
			XEquipDocument._MeshPartList = new XMeshPartList();
			XEquipDocument._MeshPartList.Load();
			XOutlookData.InitSharedFasionList();
		}

		public static bool TryGetEnhanceFxData(uint prof, uint enhanceLevel, out string[] strFx)
		{
			prof %= 10U;
			strFx = null;
			bool flag = enhanceLevel == 0U;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				EnhanceFxTable.RowData rowData = null;
				bool flag2 = XEquipDocument.enhanceIndexed && (long)XEquipDocument.m_EnhanceFxTable.Table.Length == (long)((ulong)(XEquipDocument.maxEnhanceLevel * XEquipDocument.maxProf));
				if (flag2)
				{
					rowData = XEquipDocument.m_EnhanceFxTable.Table[(int)((prof - 1U) * XEquipDocument.maxEnhanceLevel + enhanceLevel - 1U)];
				}
				else
				{
					for (int i = 0; i < XEquipDocument.m_EnhanceFxTable.Table.Length; i++)
					{
						EnhanceFxTable.RowData rowData2 = XEquipDocument.m_EnhanceFxTable.Table[i];
						bool flag3 = rowData2 != null && rowData2.ProfID == prof && rowData2.EnhanceLevel == enhanceLevel;
						if (flag3)
						{
							rowData = rowData2;
						}
					}
				}
				bool flag4 = rowData == null;
				if (flag4)
				{
					result = false;
				}
				else
				{
					strFx = rowData.MainWeaponFx;
					result = true;
				}
			}
			return result;
		}

		public static string GetTips(uint prof, uint enhanceLevel)
		{
			int num = -1;
			for (int i = 0; i < XEquipDocument.m_EnhanceFxTable.Table.Length; i++)
			{
				EnhanceFxTable.RowData rowData = XEquipDocument.m_EnhanceFxTable.Table[i];
				bool flag = rowData.ProfID == prof && rowData.EnhanceLevel > enhanceLevel && !string.IsNullOrEmpty(rowData.Tips);
				if (flag)
				{
					bool flag2 = num == -1;
					if (flag2)
					{
						num = i;
					}
					else
					{
						bool flag3 = rowData.EnhanceLevel < XEquipDocument.m_EnhanceFxTable.Table[num].EnhanceLevel;
						if (flag3)
						{
							num = i;
						}
					}
				}
			}
			bool flag4 = num != -1;
			string result;
			if (flag4)
			{
				result = XEquipDocument.m_EnhanceFxTable.Table[num].Tips;
			}
			else
			{
				for (int j = 0; j < XEquipDocument.m_EnhanceFxTable.Table.Length; j++)
				{
					EnhanceFxTable.RowData rowData = XEquipDocument.m_EnhanceFxTable.Table[j];
					bool flag5 = rowData.ProfID == prof && rowData.EnhanceLevel <= enhanceLevel && !string.IsNullOrEmpty(rowData.Tips);
					if (flag5)
					{
						bool flag6 = num == -1;
						if (flag6)
						{
							num = j;
						}
						else
						{
							bool flag7 = rowData.EnhanceLevel > XEquipDocument.m_EnhanceFxTable.Table[num].EnhanceLevel;
							if (flag7)
							{
								num = j;
							}
						}
					}
				}
				bool flag8 = num != -1;
				if (flag8)
				{
					result = XEquipDocument.m_EnhanceFxTable.Table[num].Tips;
				}
				else
				{
					result = "";
				}
			}
			return result;
		}

		private static Material GetMaterial(Shader shader)
		{
			bool flag = shader == ShaderManager._skin_cutout;
			Material result;
			if (flag)
			{
				result = XSingleton<XResourceLoaderMgr>.singleton.CreateFromAsset<Material>("Materials/Char/RimLightBlendCutout", ".mat", true, false);
			}
			else
			{
				bool flag2 = shader == ShaderManager._skin_blend;
				if (flag2)
				{
					result = XSingleton<XResourceLoaderMgr>.singleton.CreateFromAsset<Material>("Materials/Char/RimLightBlend", ".mat", true, false);
				}
				else
				{
					bool flag3 = shader == ShaderManager._skin8;
					if (flag3)
					{
						result = XSingleton<XResourceLoaderMgr>.singleton.CreateFromAsset<Material>("Materials/Char/RimLightBlend8", ".mat", true, false);
					}
					else
					{
						result = new Material(shader);
					}
				}
			}
			return result;
		}

		public static void ReturnMaterial(Material mat)
		{
			bool flag = mat != null;
			if (flag)
			{
				Shader shader = mat.shader;
				bool flag2 = shader == ShaderManager._skin_cutout;
				if (flag2)
				{
					mat.SetTexture("_Face", null);
					mat.SetTexture("_Hair", null);
					mat.SetTexture("_Body", null);
					mat.SetTexture("_Alpha", null);
				}
				else
				{
					bool flag3 = shader == ShaderManager._skin_blend;
					if (flag3)
					{
						mat.SetTexture("_Face", null);
						mat.SetTexture("_Hair", null);
						mat.SetTexture("_Body", null);
					}
					else
					{
						bool flag4 = shader == ShaderManager._skin8;
						if (flag4)
						{
							mat.SetTexture("_Tex0", null);
							mat.SetTexture("_Tex1", null);
							mat.SetTexture("_Tex2", null);
							mat.SetTexture("_Tex3", null);
							mat.SetTexture("_Tex4", null);
							mat.SetTexture("_Tex5", null);
							mat.SetTexture("_Tex6", null);
							mat.SetTexture("_Tex7", null);
						}
					}
				}
				XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy(mat, true, false);
			}
		}

		public static Material GetRoleMat(bool isOnepart, bool hasAlpha, int roleType = 0)
		{
			Material result;
			if (isOnepart)
			{
				if (hasAlpha)
				{
					result = XEquipDocument.GetMaterial(ShaderManager._skin_cutout);
				}
				else
				{
					result = XEquipDocument.GetMaterial(ShaderManager._skin_blend);
				}
			}
			else
			{
				bool flag = roleType > 0;
				if (flag)
				{
					result = XSingleton<XResourceLoaderMgr>.singleton.CreateFromAsset<Material>(XSingleton<XProfessionSkillMgr>.singleton.GetRoleMaterial((uint)roleType), ".mat", true, false);
				}
				else
				{
					result = XEquipDocument.GetMaterial(ShaderManager._skin8);
				}
			}
			return result;
		}

		public static DefaultEquip.RowData GetDefaultEquip(short id)
		{
			return XEquipDocument.m_defaultEquip.GetByProfID((int)id);
		}

		public static string GetDefaultEquipName(int partIndex, string path, int professionIndex, out string dir)
		{
			bool flag = partIndex >= 0 && partIndex < XEquipDocument._MeshPartList.partSuffix.Length && professionIndex >= 0 && professionIndex < XEquipDocument._MeshPartList.proPrefix.Length;
			string result;
			if (flag)
			{
				string text = XEquipDocument._MeshPartList.proPrefix[professionIndex];
				string text2 = XEquipDocument._MeshPartList.partSuffix[partIndex];
				bool flag2 = string.IsNullOrEmpty(path);
				if (flag2)
				{
					dir = "Player";
					result = string.Format("Player/{0}{1}", text, text2);
				}
				else
				{
					bool flag3 = path.StartsWith("/");
					if (flag3)
					{
						dir = path;
						result = string.Format("{0}/{1}{2}", path, text, text2);
					}
					else
					{
						bool flag4 = path == "E";
						if (flag4)
						{
							dir = "";
							result = "";
						}
						else
						{
							dir = "Player";
							result = string.Format("Player/{0}{1}", text, path);
						}
					}
				}
			}
			else
			{
				dir = "";
				result = path;
			}
			return result;
		}

		public static int GetEquiplistByFashionTemplate(short fashionTemplate, ref FashionPositionInfo[] fashionlist)
		{
			bool flag = fashionTemplate == 0;
			int result;
			if (flag)
			{
				XOutlookData.InitFasionList(ref fashionlist);
				result = -1;
			}
			else
			{
				DefaultEquip.RowData defaultEquip = XEquipDocument.GetDefaultEquip(fashionTemplate);
				int num = (int)(defaultEquip.id - 1);
				FashionPositionInfo fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = XEquipDocument.GetDefaultEquipName(XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.EHeadgear), defaultEquip.Helmet, num, out fashionPositionInfo.fashionDir);
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_START)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = XEquipDocument.GetDefaultEquipName(XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.EUpperBody), defaultEquip.Body, num, out fashionPositionInfo.fashionDir);
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionUpperBody)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = XEquipDocument.GetDefaultEquipName(XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.ELowerBody), defaultEquip.Leg, num, out fashionPositionInfo.fashionDir);
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionLowerBody)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = XEquipDocument.GetDefaultEquipName(XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.EBoots), defaultEquip.Boots, num, out fashionPositionInfo.fashionDir);
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionBoots)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = XEquipDocument.GetDefaultEquipName(XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.EGloves), defaultEquip.Glove, num, out fashionPositionInfo.fashionDir);
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionGloves)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = XEquipDocument.GetDefaultEquipName(XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.ECombinePartEnd), defaultEquip.Weapon, num, out fashionPositionInfo.fashionDir);
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionMainWeapon)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = XEquipDocument.GetDefaultEquipName(XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.ECombinePartStart), defaultEquip.Face, num, out fashionPositionInfo.fashionDir);
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_END)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = XEquipDocument.GetDefaultEquipName(XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.EHair), defaultEquip.Hair, num, out fashionPositionInfo.fashionDir);
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.Hair)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = XEquipDocument.GetDefaultEquipName(XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.ESecondaryWeapon), defaultEquip.SecondWeapon, num, out fashionPositionInfo.fashionDir);
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionSecondaryWeapon)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = defaultEquip.Wing;
				bool flag2 = defaultEquip.Wing != null && defaultEquip.Wing.StartsWith(XEquipDocument.present_prefix);
				if (flag2)
				{
					fashionPositionInfo.presentID = uint.Parse(defaultEquip.Wing.Substring(XEquipDocument.present_prefix.Length));
				}
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionWings)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = defaultEquip.Tail;
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionTail)] = fashionPositionInfo;
				fashionPositionInfo.fasionID = defaultEquip.ProfID;
				fashionPositionInfo.fashionName = defaultEquip.Decal;
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionlist[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionDecal)] = fashionPositionInfo;
				result = num;
			}
			return result;
		}

		public static void RefreshFashionList(ref FashionPositionInfo[] fashionlist, uint typeID)
		{
			int i = 0;
			int num = fashionlist.Length;
			while (i < num)
			{
				FashionPositionInfo fashionPositionInfo = fashionlist[i];
				bool flag = !fashionPositionInfo.replace;
				if (flag)
				{
					fashionPositionInfo.fashionName = "";
					FashionList.RowData fashionConf = XBagDocument.GetFashionConf(fashionPositionInfo.itemID);
					bool flag2 = fashionConf != null;
					if (flag2)
					{
						bool flag3 = fashionConf.ReplaceID != null && fashionConf.ReplaceID.Length != 0;
						if (flag3)
						{
							int num2 = (int)(typeID % 10U - 1U);
							FashionList.RowData rowData = null;
							bool flag4 = num2 >= fashionConf.ReplaceID.Length;
							if (flag4)
							{
								XSingleton<XDebug>.singleton.AddErrorLog2("check FashionList ReplaceID Count by fasionID = {0}", new object[]
								{
									fashionPositionInfo.itemID
								});
							}
							else
							{
								rowData = XBagDocument.GetFashionConf((int)fashionConf.ReplaceID[num2]);
							}
							bool flag5 = rowData != null;
							if (flag5)
							{
								int equipPos = (int)rowData.EquipPos;
								bool flag6 = equipPos >= 0 && equipPos < fashionlist.Length;
								if (flag6)
								{
									FashionPositionInfo fashionPositionInfo2 = fashionlist[equipPos];
									bool flag7 = fashionPositionInfo2.fasionID < 10000;
									if (flag7)
									{
										fashionPositionInfo2.fashionName = XEquipDocument.GetEquipPrefabModel(rowData, typeID, out fashionPositionInfo2.fashionDir);
										fashionPositionInfo2.replace = true;
										fashionPositionInfo2.itemID = rowData.ItemID;
										fashionPositionInfo2.fasionID = rowData.ItemID;
										fashionlist[equipPos] = fashionPositionInfo2;
									}
								}
							}
						}
						bool flag8 = fashionConf.PresentID != 0;
						if (flag8)
						{
							fashionPositionInfo.presentID = (uint)fashionConf.PresentID;
							fashionPositionInfo.fashionName = "";
						}
						else
						{
							fashionPositionInfo.fashionName = XEquipDocument.GetEquipPrefabModel(fashionConf, typeID, out fashionPositionInfo.fashionDir);
						}
					}
					else
					{
						fashionPositionInfo.fasionID = (int)typeID;
						fashionPositionInfo.fashionName = XEquipDocument.GetDefaultEquipModel(typeID, (FashionPosition)i, out fashionPositionInfo.fashionDir);
					}
				}
				fashionlist[i] = fashionPositionInfo;
				i++;
			}
		}

		private static string GetDefaultEquipModel(DefaultEquip.RowData de, FashionPosition part)
		{
			string result;
			switch (part)
			{
			case FashionPosition.FASHION_START:
				result = de.Helmet;
				break;
			case FashionPosition.FashionUpperBody:
				result = de.Body;
				break;
			case FashionPosition.FashionLowerBody:
				result = de.Leg;
				break;
			case FashionPosition.FashionGloves:
				result = de.Glove;
				break;
			case FashionPosition.FashionBoots:
				result = de.Boots;
				break;
			case FashionPosition.FashionMainWeapon:
				result = de.Weapon;
				break;
			case FashionPosition.FashionSecondaryWeapon:
				result = de.SecondWeapon;
				break;
			case FashionPosition.FashionWings:
				result = de.Wing;
				break;
			case FashionPosition.FashionTail:
				result = de.Tail;
				break;
			case FashionPosition.FashionDecal:
				result = de.Decal;
				break;
			case FashionPosition.FASHION_END:
				result = de.Face;
				break;
			case FashionPosition.Hair:
				result = de.Hair;
				break;
			default:
				result = "";
				break;
			}
			return result;
		}

		public static string GetDefaultEquipModel(uint typeID, FashionPosition part, out string dir)
		{
			DefaultEquip.RowData defaultEquip = XEquipDocument.GetDefaultEquip((short)typeID);
			dir = "";
			bool flag = defaultEquip == null;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				int partIndex = CombineMeshTask.ConvertPart(part);
				int num = (int)(typeID % 10U);
				result = XEquipDocument.GetDefaultEquipName(partIndex, XEquipDocument.GetDefaultEquipModel(defaultEquip, part), num - 1, out dir);
			}
			return result;
		}

		public static string GetEquipPrefabModel(FashionList.RowData data, uint typeID, out string dir)
		{
			bool flag = data != null;
			string result;
			if (flag)
			{
				int num = CombineMeshTask.ConvertPart((FashionPosition)data.EquipPos);
				uint num2 = typeID % 10U;
				uint num3 = num2 - 1U;
				string arg = XEquipDocument._MeshPartList.proPrefix[(int)num3];
				string arg2 = "";
				bool flag2 = num >= 0 && num < XEquipDocument._MeshPartList.partSuffix.Length;
				if (flag2)
				{
					arg2 = XEquipDocument._MeshPartList.partSuffix[num];
				}
				string text = XSingleton<XProfessionSkillMgr>.singleton.GetEquipPrefabModel(data, num2);
				bool flag3 = text == "E" || (string.IsNullOrEmpty(data.SuitName) && string.IsNullOrEmpty(text));
				if (flag3)
				{
					dir = "";
					result = "";
				}
				else
				{
					bool flag4 = string.IsNullOrEmpty(data.SuitName);
					if (flag4)
					{
						dir = text;
						result = string.Format("{0}/{1}{2}", text, arg, arg2);
					}
					else
					{
						dir = data.SuitName;
						bool flag5 = string.IsNullOrEmpty(text);
						if (flag5)
						{
							result = string.Format("{0}/{1}{2}", data.SuitName, arg, arg2);
						}
						else
						{
							bool flag6 = text.StartsWith("$");
							if (flag6)
							{
								string text2 = typeID.ToString();
								string text3 = text.Substring(1);
								string[] array = text3.Split(XGlobalConfig.AllSeparators);
								bool flag7 = array.Length % 2 == 0;
								if (flag7)
								{
									for (int i = array.Length - 1; i > 0; i -= 2)
									{
										bool flag8 = text2.EndsWith(array[i - 1]);
										if (flag8)
										{
											text = array[i];
											XSingleton<XDebug>.singleton.AddGreenLog("Select Equip :" + text.ToString(), null, null, null, null, null);
											break;
										}
									}
								}
							}
							result = string.Format("{0}/{1}{2}", data.SuitName, arg, text);
						}
					}
				}
			}
			else
			{
				dir = "";
				result = "";
			}
			return result;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public static SkinnedMeshRenderer GetSmr(GameObject keyGo)
		{
			Transform transform = keyGo.transform.FindChild("CombinedMesh");
			bool flag = transform == null;
			if (flag)
			{
				transform = new GameObject("CombinedMesh")
				{
					transform = 
					{
						parent = keyGo.transform
					}
				}.transform;
			}
			SkinnedMeshRenderer skinnedMeshRenderer = transform.GetComponent<SkinnedMeshRenderer>();
			bool flag2 = skinnedMeshRenderer == null;
			if (flag2)
			{
				skinnedMeshRenderer = transform.gameObject.AddComponent<SkinnedMeshRenderer>();
			}
			return skinnedMeshRenderer;
		}

		public static Transform GetMountPoint(Transform keyTran, string point)
		{
			Transform transform = keyTran.FindChild(point);
			bool flag = transform != null;
			Transform result;
			if (flag)
			{
				result = transform;
			}
			else
			{
				result = XSingleton<XCommon>.singleton.FindChildRecursively(keyTran, point);
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XEquipDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static DefaultEquip m_defaultEquip = new DefaultEquip();

		private static EnhanceFxTable m_EnhanceFxTable = new EnhanceFxTable();

		public static string present_prefix = "_presentid:";

		public static CombineMeshUtility _CombineMeshUtility = null;

		public static XMeshPartList _MeshPartList = null;

		private static uint maxProf = 0U;

		private static uint maxEnhanceLevel = 0U;

		private static bool enhanceIndexed = true;

		public static int CurrentVisibleRole = 0;
	}
}
