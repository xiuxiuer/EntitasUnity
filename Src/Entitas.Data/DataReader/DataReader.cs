//----------------------------------------------------------------------------
//！！！不要手动修改此文件，此文件由TableReaderGenerator按table.dsl生成！！！
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using Util;

namespace Entitas.Data
{
	public sealed partial class ActionConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 16)]
		private struct ActionConfigRecord
		{
			internal int ModelId;
			internal int Description;
			internal int Stand;
			internal int Run;
		}

		public int ModelId;
		public string Description;
		public string Stand;
		public string Run;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			ModelId = DBCUtil.ExtractNumeric<int>(node, "ModelId", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Stand = DBCUtil.ExtractString(node, "Stand", "");
			Run = DBCUtil.ExtractString(node, "Run", "");
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			ActionConfigRecord record = GetRecord(table,index);
			ModelId = DBCUtil.ExtractInt(table, record.ModelId, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Stand = DBCUtil.ExtractString(table, record.Stand, "");
			Run = DBCUtil.ExtractString(table, record.Run, "");
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			ActionConfigRecord record = new ActionConfigRecord();
			record.ModelId = DBCUtil.SetValue(table, ModelId, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Stand = DBCUtil.SetValue(table, Stand, "");
			record.Run = DBCUtil.SetValue(table, Run, "");
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return ModelId;
		}

		private unsafe ActionConfigRecord GetRecord(BinaryTable table, int index)
		{
			ActionConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(ActionConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(ActionConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(ActionConfigRecord)];
			fixed (byte* p = bytes) {
				ActionConfigRecord* temp = (ActionConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class ActionConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_ActionConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_ActionConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_ActionConfigMgr.CollectDataFromBinary(file);
			} else {
				m_ActionConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_ActionConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_ActionConfigMgr.Clear();
		}

		public DataDictionaryMgr2<ActionConfig> ActionConfigMgr
		{
			get { return m_ActionConfigMgr; }
		}

		public int GetActionConfigCount()
		{
			return m_ActionConfigMgr.GetDataCount();
		}

		public ActionConfig GetActionConfig(int id)
		{
			return m_ActionConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<ActionConfig> m_ActionConfigMgr = new DataDictionaryMgr2<ActionConfig>();

		public static ActionConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static ActionConfigProvider s_Instance = new ActionConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class AttributeConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 112)]
		private struct AttributeConfigRecord
		{
			internal int Id;
			internal int Describe;
			internal int AddEnergyRecover;
			internal int AddEnergyMax;
			internal int AddMaxAd;
			internal int AddMinAd;
			internal int AddCritical;
			internal int AddCriticalFactor;
			internal int AddMetalFactor;
			internal int AddWoodFactor;
			internal int AddWaterFactor;
			internal int AddFireFactor;
			internal int AddEarthFactor;
			internal int AddFullDamageFactor;
			internal int AddHpMax;
			internal int AddArmor;
			internal int AddMiss;
			internal int AddMetalResist;
			internal int AddWoodResist;
			internal int AddWaterResist;
			internal int AddFireResist;
			internal int AddEarthResist;
			internal int AddAccuracyRecover;
			internal int AddDamageDerate;
			internal int AddMoveSpeed;
			internal int AddFullElementResist;
			internal int AddFullElementFactor;
			internal int AddHpFactor;
		}

		public int Id;
		public string Describe;
		public int AddEnergyRecover;
		public int AddEnergyMax;
		public int AddMaxAd;
		public int AddMinAd;
		public int AddCritical;
		public int AddCriticalFactor;
		public int AddMetalFactor;
		public int AddWoodFactor;
		public int AddWaterFactor;
		public int AddFireFactor;
		public int AddEarthFactor;
		public int AddFullDamageFactor;
		public int AddHpMax;
		public int AddArmor;
		public int AddMiss;
		public int AddMetalResist;
		public int AddWoodResist;
		public int AddWaterResist;
		public int AddFireResist;
		public int AddEarthResist;
		public int AddAccuracyRecover;
		public int AddDamageDerate;
		public int AddMoveSpeed;
		public int AddFullElementResist;
		public int AddFullElementFactor;
		public int AddHpFactor;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Describe = DBCUtil.ExtractString(node, "Describe", "");
			AddEnergyRecover = DBCUtil.ExtractNumeric<int>(node, "AddEnergyRecover", 0);
			AddEnergyMax = DBCUtil.ExtractNumeric<int>(node, "AddEnergyMax", 0);
			AddMaxAd = DBCUtil.ExtractNumeric<int>(node, "AddMaxAd", 0);
			AddMinAd = DBCUtil.ExtractNumeric<int>(node, "AddMinAd", 0);
			AddCritical = DBCUtil.ExtractNumeric<int>(node, "AddCritical", 0);
			AddCriticalFactor = DBCUtil.ExtractNumeric<int>(node, "AddCriticalFactor", 0);
			AddMetalFactor = DBCUtil.ExtractNumeric<int>(node, "AddMetalFactor", 0);
			AddWoodFactor = DBCUtil.ExtractNumeric<int>(node, "AddWoodFactor", 0);
			AddWaterFactor = DBCUtil.ExtractNumeric<int>(node, "AddWaterFactor", 0);
			AddFireFactor = DBCUtil.ExtractNumeric<int>(node, "AddFireFactor", 0);
			AddEarthFactor = DBCUtil.ExtractNumeric<int>(node, "AddEarthFactor", 0);
			AddFullDamageFactor = DBCUtil.ExtractNumeric<int>(node, "AddFullDamageFactor", 0);
			AddHpMax = DBCUtil.ExtractNumeric<int>(node, "AddHpMax", 0);
			AddArmor = DBCUtil.ExtractNumeric<int>(node, "AddArmor", 0);
			AddMiss = DBCUtil.ExtractNumeric<int>(node, "AddMiss", 0);
			AddMetalResist = DBCUtil.ExtractNumeric<int>(node, "AddMetalResist", 0);
			AddWoodResist = DBCUtil.ExtractNumeric<int>(node, "AddWoodResist", 0);
			AddWaterResist = DBCUtil.ExtractNumeric<int>(node, "AddWaterResist", 0);
			AddFireResist = DBCUtil.ExtractNumeric<int>(node, "AddFireResist", 0);
			AddEarthResist = DBCUtil.ExtractNumeric<int>(node, "AddEarthResist", 0);
			AddAccuracyRecover = DBCUtil.ExtractNumeric<int>(node, "AddAccuracyRecover", 0);
			AddDamageDerate = DBCUtil.ExtractNumeric<int>(node, "AddDamageDerate", 0);
			AddMoveSpeed = DBCUtil.ExtractNumeric<int>(node, "AddMoveSpeed", 0);
			AddFullElementResist = DBCUtil.ExtractNumeric<int>(node, "AddFullElementResist", 0);
			AddFullElementFactor = DBCUtil.ExtractNumeric<int>(node, "AddFullElementFactor", 0);
			AddHpFactor = DBCUtil.ExtractNumeric<int>(node, "AddHpFactor", 0);
			AfterCollectData();
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			AttributeConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Describe = DBCUtil.ExtractString(table, record.Describe, "");
			AddEnergyRecover = DBCUtil.ExtractInt(table, record.AddEnergyRecover, 0);
			AddEnergyMax = DBCUtil.ExtractInt(table, record.AddEnergyMax, 0);
			AddMaxAd = DBCUtil.ExtractInt(table, record.AddMaxAd, 0);
			AddMinAd = DBCUtil.ExtractInt(table, record.AddMinAd, 0);
			AddCritical = DBCUtil.ExtractInt(table, record.AddCritical, 0);
			AddCriticalFactor = DBCUtil.ExtractInt(table, record.AddCriticalFactor, 0);
			AddMetalFactor = DBCUtil.ExtractInt(table, record.AddMetalFactor, 0);
			AddWoodFactor = DBCUtil.ExtractInt(table, record.AddWoodFactor, 0);
			AddWaterFactor = DBCUtil.ExtractInt(table, record.AddWaterFactor, 0);
			AddFireFactor = DBCUtil.ExtractInt(table, record.AddFireFactor, 0);
			AddEarthFactor = DBCUtil.ExtractInt(table, record.AddEarthFactor, 0);
			AddFullDamageFactor = DBCUtil.ExtractInt(table, record.AddFullDamageFactor, 0);
			AddHpMax = DBCUtil.ExtractInt(table, record.AddHpMax, 0);
			AddArmor = DBCUtil.ExtractInt(table, record.AddArmor, 0);
			AddMiss = DBCUtil.ExtractInt(table, record.AddMiss, 0);
			AddMetalResist = DBCUtil.ExtractInt(table, record.AddMetalResist, 0);
			AddWoodResist = DBCUtil.ExtractInt(table, record.AddWoodResist, 0);
			AddWaterResist = DBCUtil.ExtractInt(table, record.AddWaterResist, 0);
			AddFireResist = DBCUtil.ExtractInt(table, record.AddFireResist, 0);
			AddEarthResist = DBCUtil.ExtractInt(table, record.AddEarthResist, 0);
			AddAccuracyRecover = DBCUtil.ExtractInt(table, record.AddAccuracyRecover, 0);
			AddDamageDerate = DBCUtil.ExtractInt(table, record.AddDamageDerate, 0);
			AddMoveSpeed = DBCUtil.ExtractInt(table, record.AddMoveSpeed, 0);
			AddFullElementResist = DBCUtil.ExtractInt(table, record.AddFullElementResist, 0);
			AddFullElementFactor = DBCUtil.ExtractInt(table, record.AddFullElementFactor, 0);
			AddHpFactor = DBCUtil.ExtractInt(table, record.AddHpFactor, 0);
			AfterCollectData();
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			AttributeConfigRecord record = new AttributeConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Describe = DBCUtil.SetValue(table, Describe, "");
			record.AddEnergyRecover = DBCUtil.SetValue(table, AddEnergyRecover, 0);
			record.AddEnergyMax = DBCUtil.SetValue(table, AddEnergyMax, 0);
			record.AddMaxAd = DBCUtil.SetValue(table, AddMaxAd, 0);
			record.AddMinAd = DBCUtil.SetValue(table, AddMinAd, 0);
			record.AddCritical = DBCUtil.SetValue(table, AddCritical, 0);
			record.AddCriticalFactor = DBCUtil.SetValue(table, AddCriticalFactor, 0);
			record.AddMetalFactor = DBCUtil.SetValue(table, AddMetalFactor, 0);
			record.AddWoodFactor = DBCUtil.SetValue(table, AddWoodFactor, 0);
			record.AddWaterFactor = DBCUtil.SetValue(table, AddWaterFactor, 0);
			record.AddFireFactor = DBCUtil.SetValue(table, AddFireFactor, 0);
			record.AddEarthFactor = DBCUtil.SetValue(table, AddEarthFactor, 0);
			record.AddFullDamageFactor = DBCUtil.SetValue(table, AddFullDamageFactor, 0);
			record.AddHpMax = DBCUtil.SetValue(table, AddHpMax, 0);
			record.AddArmor = DBCUtil.SetValue(table, AddArmor, 0);
			record.AddMiss = DBCUtil.SetValue(table, AddMiss, 0);
			record.AddMetalResist = DBCUtil.SetValue(table, AddMetalResist, 0);
			record.AddWoodResist = DBCUtil.SetValue(table, AddWoodResist, 0);
			record.AddWaterResist = DBCUtil.SetValue(table, AddWaterResist, 0);
			record.AddFireResist = DBCUtil.SetValue(table, AddFireResist, 0);
			record.AddEarthResist = DBCUtil.SetValue(table, AddEarthResist, 0);
			record.AddAccuracyRecover = DBCUtil.SetValue(table, AddAccuracyRecover, 0);
			record.AddDamageDerate = DBCUtil.SetValue(table, AddDamageDerate, 0);
			record.AddMoveSpeed = DBCUtil.SetValue(table, AddMoveSpeed, 0);
			record.AddFullElementResist = DBCUtil.SetValue(table, AddFullElementResist, 0);
			record.AddFullElementFactor = DBCUtil.SetValue(table, AddFullElementFactor, 0);
			record.AddHpFactor = DBCUtil.SetValue(table, AddHpFactor, 0);
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe AttributeConfigRecord GetRecord(BinaryTable table, int index)
		{
			AttributeConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(AttributeConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(AttributeConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(AttributeConfigRecord)];
			fixed (byte* p = bytes) {
				AttributeConfigRecord* temp = (AttributeConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class AttributeConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_AttributeConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_AttributeConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_AttributeConfigMgr.CollectDataFromBinary(file);
			} else {
				m_AttributeConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_AttributeConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_AttributeConfigMgr.Clear();
		}

		public DataDictionaryMgr2<AttributeConfig> AttributeConfigMgr
		{
			get { return m_AttributeConfigMgr; }
		}

		public int GetAttributeConfigCount()
		{
			return m_AttributeConfigMgr.GetDataCount();
		}

		public AttributeConfig GetAttributeConfig(int id)
		{
			return m_AttributeConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<AttributeConfig> m_AttributeConfigMgr = new DataDictionaryMgr2<AttributeConfig>();

		public static AttributeConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static AttributeConfigProvider s_Instance = new AttributeConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class BuffConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 12)]
		private struct BuffConfigRecord
		{
			internal int Id;
			internal int Description;
			internal int Script;
		}

		public int Id;
		public string Description;
		public string Script;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Script = DBCUtil.ExtractString(node, "Script", "");
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			BuffConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Script = DBCUtil.ExtractString(table, record.Script, "");
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			BuffConfigRecord record = new BuffConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Script = DBCUtil.SetValue(table, Script, "");
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe BuffConfigRecord GetRecord(BinaryTable table, int index)
		{
			BuffConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(BuffConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(BuffConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(BuffConfigRecord)];
			fixed (byte* p = bytes) {
				BuffConfigRecord* temp = (BuffConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class BuffConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_BuffConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_BuffConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_BuffConfigMgr.CollectDataFromBinary(file);
			} else {
				m_BuffConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_BuffConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_BuffConfigMgr.Clear();
		}

		public DataDictionaryMgr2<BuffConfig> BuffConfigMgr
		{
			get { return m_BuffConfigMgr; }
		}

		public int GetBuffConfigCount()
		{
			return m_BuffConfigMgr.GetDataCount();
		}

		public BuffConfig GetBuffConfig(int id)
		{
			return m_BuffConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<BuffConfig> m_BuffConfigMgr = new DataDictionaryMgr2<BuffConfig>();

		public static BuffConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static BuffConfigProvider s_Instance = new BuffConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class CharacterConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 24)]
		private struct CharacterConfigRecord
		{
			internal int Id;
			internal int Description;
			internal int Model;
			internal float Scale;
			internal int ActionId;
			internal int ActionPrefix;
		}

		public int Id;
		public string Description;
		public string Model;
		public float Scale;
		public int ActionId;
		public string ActionPrefix;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Model = DBCUtil.ExtractString(node, "Model", "");
			Scale = DBCUtil.ExtractNumeric<float>(node, "Scale", 0);
			ActionId = DBCUtil.ExtractNumeric<int>(node, "ActionId", 0);
			ActionPrefix = DBCUtil.ExtractString(node, "ActionPrefix", "");
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			CharacterConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Model = DBCUtil.ExtractString(table, record.Model, "");
			Scale = DBCUtil.ExtractFloat(table, record.Scale, 0);
			ActionId = DBCUtil.ExtractInt(table, record.ActionId, 0);
			ActionPrefix = DBCUtil.ExtractString(table, record.ActionPrefix, "");
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			CharacterConfigRecord record = new CharacterConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Model = DBCUtil.SetValue(table, Model, "");
			record.Scale = DBCUtil.SetValue(table, Scale, 0);
			record.ActionId = DBCUtil.SetValue(table, ActionId, 0);
			record.ActionPrefix = DBCUtil.SetValue(table, ActionPrefix, "");
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe CharacterConfigRecord GetRecord(BinaryTable table, int index)
		{
			CharacterConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(CharacterConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(CharacterConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(CharacterConfigRecord)];
			fixed (byte* p = bytes) {
				CharacterConfigRecord* temp = (CharacterConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class CharacterConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_CharacterConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_CharacterConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_CharacterConfigMgr.CollectDataFromBinary(file);
			} else {
				m_CharacterConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_CharacterConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_CharacterConfigMgr.Clear();
		}

		public DataDictionaryMgr2<CharacterConfig> CharacterConfigMgr
		{
			get { return m_CharacterConfigMgr; }
		}

		public int GetCharacterConfigCount()
		{
			return m_CharacterConfigMgr.GetDataCount();
		}

		public CharacterConfig GetCharacterConfig(int id)
		{
			return m_CharacterConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<CharacterConfig> m_CharacterConfigMgr = new DataDictionaryMgr2<CharacterConfig>();

		public static CharacterConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static CharacterConfigProvider s_Instance = new CharacterConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class SceneConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 16)]
		private struct SceneConfigRecord
		{
			internal int Id;
			internal int Description;
			internal int Script;
			internal int Navmesh;
		}

		public int Id;
		public string Description;
		public string Script;
		public string Navmesh;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Script = DBCUtil.ExtractString(node, "Script", "");
			Navmesh = DBCUtil.ExtractString(node, "Navmesh", "");
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			SceneConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Script = DBCUtil.ExtractString(table, record.Script, "");
			Navmesh = DBCUtil.ExtractString(table, record.Navmesh, "");
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			SceneConfigRecord record = new SceneConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Script = DBCUtil.SetValue(table, Script, "");
			record.Navmesh = DBCUtil.SetValue(table, Navmesh, "");
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe SceneConfigRecord GetRecord(BinaryTable table, int index)
		{
			SceneConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(SceneConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(SceneConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(SceneConfigRecord)];
			fixed (byte* p = bytes) {
				SceneConfigRecord* temp = (SceneConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class SceneConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_SceneConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_SceneConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_SceneConfigMgr.CollectDataFromBinary(file);
			} else {
				m_SceneConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_SceneConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_SceneConfigMgr.Clear();
		}

		public DataDictionaryMgr2<SceneConfig> SceneConfigMgr
		{
			get { return m_SceneConfigMgr; }
		}

		public int GetSceneConfigCount()
		{
			return m_SceneConfigMgr.GetDataCount();
		}

		public SceneConfig GetSceneConfig(int id)
		{
			return m_SceneConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<SceneConfig> m_SceneConfigMgr = new DataDictionaryMgr2<SceneConfig>();

		public static SceneConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static SceneConfigProvider s_Instance = new SceneConfigProvider();
	}
}

namespace Entitas.Data
{
	public sealed partial class SkillConfig : IData2
	{
		[StructLayout(LayoutKind.Auto, Pack = 1, Size = 12)]
		private struct SkillConfigRecord
		{
			internal int Id;
			internal int Description;
			internal int Script;
		}

		public int Id;
		public string Description;
		public string Script;

		public bool CollectDataFromDBC(DBC_Row node)
		{
			Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0);
			Description = DBCUtil.ExtractString(node, "Description", "");
			Script = DBCUtil.ExtractString(node, "Script", "");
			return true;
		}

		public bool CollectDataFromBinary(BinaryTable table, int index)
		{
			SkillConfigRecord record = GetRecord(table,index);
			Id = DBCUtil.ExtractInt(table, record.Id, 0);
			Description = DBCUtil.ExtractString(table, record.Description, "");
			Script = DBCUtil.ExtractString(table, record.Script, "");
			return true;
		}

		public void AddToBinary(BinaryTable table)
		{
			SkillConfigRecord record = new SkillConfigRecord();
			record.Id = DBCUtil.SetValue(table, Id, 0);
			record.Description = DBCUtil.SetValue(table, Description, "");
			record.Script = DBCUtil.SetValue(table, Script, "");
			byte[] bytes = GetRecordBytes(record);
			table.Records.Add(bytes);
		}

		public int GetId()
		{
			return Id;
		}

		private unsafe SkillConfigRecord GetRecord(BinaryTable table, int index)
		{
			SkillConfigRecord record;
			byte[] bytes = table.Records[index];
			fixed (byte* p = bytes) {
				record = *(SkillConfigRecord*)p;
			}
			return record;
		}
		private static unsafe byte[] GetRecordBytes(SkillConfigRecord record)
		{
			byte[] bytes = new byte[sizeof(SkillConfigRecord)];
			fixed (byte* p = bytes) {
				SkillConfigRecord* temp = (SkillConfigRecord*)p;
				*temp = record;
			}
			return bytes;
		}
	}

	public sealed partial class SkillConfigProvider
	{
		public void LoadForClient()
		{
			Load(FilePathDefine_Client.C_SkillConfig);
		}
		public void LoadForServer()
		{
			Load(FilePathDefine_Server.C_SkillConfig);
		}
		public void Load(string file)
		{
			if (BinaryTable.IsValid(HomePath.Instance.GetAbsolutePath(file))) {
				m_SkillConfigMgr.CollectDataFromBinary(file);
			} else {
				m_SkillConfigMgr.CollectDataFromDBC(file);
			}
		}
		public void Save(string file)
		{
		#if DEBUG
			m_SkillConfigMgr.SaveToBinary(file);
		#endif
		}
		public void Clear()
		{
			m_SkillConfigMgr.Clear();
		}

		public DataDictionaryMgr2<SkillConfig> SkillConfigMgr
		{
			get { return m_SkillConfigMgr; }
		}

		public int GetSkillConfigCount()
		{
			return m_SkillConfigMgr.GetDataCount();
		}

		public SkillConfig GetSkillConfig(int id)
		{
			return m_SkillConfigMgr.GetDataById(id);
		}

		private DataDictionaryMgr2<SkillConfig> m_SkillConfigMgr = new DataDictionaryMgr2<SkillConfig>();

		public static SkillConfigProvider Instance
		{
			get { return s_Instance; }
		}
		private static SkillConfigProvider s_Instance = new SkillConfigProvider();
	}
}
