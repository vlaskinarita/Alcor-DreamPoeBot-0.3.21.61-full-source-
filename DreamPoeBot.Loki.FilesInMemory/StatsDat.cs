using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DreamPoeBot.Loki.FilesInMemory;

public class StatsDat : FileInMemory
{
	public enum StatType
	{
		Percents = 1,
		Value2,
		IntValue,
		Boolean,
		Precents5
	}

	public class StatRecord
	{
		public readonly string Key;

		public readonly string StatTypeGGG;

		public readonly long Address;

		public StatType Type;

		public string UserFriendlyName;

		public StatRecord(Memory m, long addr)
		{
			Address = addr;
			Key = m.ReadStringU(m.ReadLong(addr));
			Type = (Key.Contains("%") ? StatType.Percents : ((StatType)m.ReadInt(addr + 11L)));
			UserFriendlyName = m.ReadStringU(m.ReadLong(addr + 15L));
			StatTypeGGG = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Key).Replace("+", "Pos").Replace("-", "Neg")
				.Replace("%", "Pct")
				.Replace("_", "");
		}

		public override string ToString()
		{
			if (!string.IsNullOrWhiteSpace(UserFriendlyName))
			{
				return UserFriendlyName;
			}
			return Key;
		}

		internal string ValueToString(int val)
		{
			switch (Type)
			{
			default:
				return "";
			case StatType.Value2:
			case StatType.IntValue:
				return val.ToString("+#;-#");
			case StatType.Boolean:
				if (val == 0)
				{
					return "False";
				}
				return "True";
			case StatType.Percents:
			case StatType.Precents5:
				return val.ToString("+#;-#") + "%";
			}
		}
	}

	public Dictionary<string, StatRecord> records = new Dictionary<string, StatRecord>(StringComparer.OrdinalIgnoreCase);

	public StatsDat(Memory m, long address)
		: base(m, address)
	{
		LoadItems();
	}

	public StatRecord GetStatByAddress(long address)
	{
		return records.Values.ToList().Find((StatRecord x) => x.Address == address);
	}

	private void LoadItems()
	{
		IEnumerable<long> enumerable = RecordAddresses();
		foreach (long item in enumerable)
		{
			StatRecord statRecord = new StatRecord(base.M, item);
			if (!records.ContainsKey(statRecord.Key))
			{
				records.Add(statRecord.Key, statRecord);
			}
		}
	}
}
