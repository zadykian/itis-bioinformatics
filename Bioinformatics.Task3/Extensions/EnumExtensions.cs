using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Bioinformatics.Task3.Extensions
{
	/// <summary>
	/// Методы расширения для типов перечислений.
	/// </summary>
	internal static class EnumExtensions
	{
		/// <summary>
		/// Получить атрибут, прикреплённый к члену enum. 
		/// </summary>
		public static TAttribute GetAttributeOfType<TEnum, TAttribute>(this TEnum enumItem)
			where TEnum : Enum
			where TAttribute : Attribute
		{
			return typeof(TEnum)
				.GetMember(enumItem.ToString())
				.Single()
				.GetCustomAttribute<TAttribute>();
		}
		
		/// <summary>
		/// Получить описание элемента перечисление,
		/// хранящееся в атрибуте <see cref="DescriptionAttribute"/> 
		/// </summary>
		public static string GetDescription<TEnum>(this TEnum enumItem)
			where TEnum : Enum
		{
			var description = enumItem
				.GetAttributeOfType<TEnum, DescriptionAttribute>()
				?.Description;

			return description ?? string.Empty;
		}

		/// <summary>
		/// Определить, что элемент перечисления не содержит более одного значения в качестве битовых флагов. 
		/// </summary>
		public static bool HasOnlySingleValue<TEnum>(this TEnum enumItem)
			where TEnum : Enum
		{
			var flagsCount = Enum
				.GetValues(typeof(TEnum))
				.Cast<TEnum>()
				.Count(item => enumItem.Equals(item));

			return flagsCount == 1;
		}
	}
}